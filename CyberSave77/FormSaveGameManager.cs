using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace CyberSave77
{
    public partial class FormSaveGameManager : Form
    {
        public FormSaveGameManager(List<DirectoryInfo> pathSavegame)
        {
            InitializeComponent();
            pathToSavegame = pathSavegame;
        }
        private static List<SaveGameFile> listSVG;
        private static Panel[] pArr;
        private static int lastIndex = 0;
        private static Image imgDel, imgMove;
        private static bool selectionMode = false;
        private List<DirectoryInfo> pathToSavegame;

        private void FormSaveGameManager_Load(object sender, EventArgs e)
        {
            imgMove = Properties.Resources.move;
            imgDel = Properties.Resources._097_delete_3;
            pictureBoxDelete.MouseDown += pbDelMouseDown;
            pictureBoxDelete.MouseUp += pbDelMouseUp;
            pictureBoxDelete.MouseLeave += pbDelMouseLeave;
            pictureBoxDelete.MouseHover += pbDelMouseHover;
            pictureBoxMove.MouseDown += pbDelMouseDown;
            pictureBoxMove.MouseUp += pbDelMouseUp;
            pictureBoxMove.MouseLeave += pbDelMouseLeave;
            pictureBoxMove.MouseHover += pbDelMouseHover;
            hideRightSide(Properties.Settings.Default.svgmHideDetails);
            labelSelected.Text = "Selected: 0/0";
            labelHint.Parent = dataGridView1;
            loadCombobox();
        }
        private void loadCombobox()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Fullname");
            dt.Columns.Add("Name");
            foreach (var item in pathToSavegame)
            {
                if (item.FullName == Properties.Settings.Default.savegameDefaultPath)
                    dt.Rows.Add(item.FullName, item.Name + " (default)");
                else
                    dt.Rows.Add(item.FullName, item.Name + " (history)");
            }

            comboBoxPath.ValueMember = "Fullname";
            comboBoxPath.DisplayMember = "Name";
            comboBoxPath.DataSource = dt;

            comboBoxPath.SelectedIndex = 0;
        }
        private List<SaveGameFile> loadFiles(string path)
        {

            var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
            List<SaveGameFile> listSaveGame = new List<SaveGameFile>();


            var listdir = new DirectoryInfo(path).GetDirectories().OrderByDescending(d => d.LastWriteTime).ToList();

            foreach (var dir in listdir)
            {
                SaveGameFile svg = new SaveGameFile();
                svg.dirName = dir.FullName;
                foreach (var item in Directory.EnumerateFiles(dir.FullName))
                {
                    if (item.EndsWith(".json") && Path.GetFileName(item).StartsWith("meta"))
                        svg.metadata = item;
                    else if (Path.GetFileName(item) == ("sav.dat"))
                        svg.datFile = item;
                    else if (item.EndsWith(".png"))
                        svg.thumb = item;
                }
                listSaveGame.Add(svg);
            }
            return listSaveGame.Where(d => d.datFile != null).ToList();
        }
        private void cleanPanelSaveGames()
        {
            while (panelSaveGames.Controls.Count > 0)
                foreach (Control item in panelSaveGames.Controls)
                {
                    panelSaveGames.Controls.Remove(item);
                    if (item is PictureBox)
                    {
                        ((PictureBox)item).Image.Dispose();
                    }
                    item.Dispose();
                }
            panelSaveGames.Refresh();
        }

        private void loadView(List<SaveGameFile> listSvg, int startIndex, int endIndex)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (startIndex == 0)
            {
                cleanPanelSaveGames();

                pArr = new Panel[listSvg.Count];
                for (int i = 0; i < listSvg.Count; i++)
                {
                    pArr[i] = new Panel();
                }
            }
            if (endIndex > listSVG.Count())
                endIndex = listSVG.Count();

            for (int i = startIndex; i < endIndex; i++)
            {

                PictureBox pb = new PictureBox();
                Label lb = new Label();

                panelSaveGames.Controls.Add(pArr[i]);
                pArr[i].Controls.Add(pb);
                pArr[i].Controls.Add(lb);
                listSvg[i].panelName = pArr[i].Name = "pn" + i;

                if (i == 0)
                {
                    pArr[i].Location = new Point(6, 6);

                }
                else
                    pArr[i].Location = new Point(6, pArr[i - 1].Location.Y + pArr[i - 1].Height + 6);

                pb.Location = new Point(3, 3);
                pArr[i].Size = new Size(panelSaveGames.Width - pArr[i].Location.X - 23, 150);
                pb.Size = new Size(300, 168);
                pb.MouseClick += panel_MouseClick;
                pb.MouseDoubleClick += pb_MouseDoubleClick;


                lb.Location = new Point(pb.Location.X + pb.Width + 10, 3);
                lb.AutoSize = true;
                lb.Text = listSvg[i].dirName.Split('\\').LastOrDefault();


                Label[] lbArr = new Label[6];

                for (int j = 0; j < lbArr.Length; j++)
                {
                    lbArr[j] = new Label();
                    pArr[i].Controls.Add(lbArr[j]);
                    if (j == 0)
                        lbArr[j].Location = new Point(lb.Location.X, lb.Location.Y + lb.Height + 3);
                    else if (j == 3)
                        lbArr[j].Location = new Point(lbArr[0].Location.X + lbArr[0].Bounds.Right / 2, lb.Location.Y + lb.Height + 3);
                    else
                        lbArr[j].Location = new Point(lbArr[j - 1].Location.X, lbArr[j - 1].Location.Y + lbArr[j - 1].Height + 3);
                    lbArr[j].AutoSize = true;
                    lbArr[j].MouseClick += panel_MouseClick;
                }

                using (var stream = new FileStream(listSvg[i].thumb, FileMode.Open))
                {

                    pb.Image = Image.FromStream(stream);
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.ImageLocation = listSVG[i].thumb;
                }

                pArr[i].BackColor = Color.White;
                pArr[i].BorderStyle = BorderStyle.Fixed3D;
                pArr[i].MouseClick += panel_MouseClick;

                RootJson rj = loadJsonFile(listSvg[i].metadata);
                if (rj.Data != null)
                {
                    TimeSpan ts = new TimeSpan();
                    ts = TimeSpan.FromSeconds(Convert.ToInt32(rj.Data.metadata.playTime));
                    lb.Font = new Font(lb.Font, FontStyle.Bold);
                    lbArr[0].Text = "Body: " + rj.Data.metadata.bodyGender;
                    lbArr[1].Text = "Brain: " + rj.Data.metadata.brainGender;
                    lbArr[2].Text = "Lifepath: " + rj.Data.metadata.lifePath;
                    lbArr[3].Text = "Playtime: " + ts.TotalHours.ToString("N0") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");
                    lbArr[4].Text = "Level: " + rj.Data.metadata.level;
                    lbArr[5].Text = "Streetcred: " + rj.Data.metadata.streetCred;
                }

                createSmallPictureBoxes(pArr[i]);


                lastIndex = i;


            }//Ende for
            if (startIndex == 0)
                panelDatagrid.Location = new Point(pArr[0].Location.X + pArr[0].Width + 50, 30);
            if (lastIndex == listSVG.Count() - 1)
                modernButtonLoadMore.Enabled = false;
            else
                modernButtonLoadMore.Enabled = true;


            sw.Stop();


            labelCount.Text = endIndex + "/" + listSVG.Count().ToString();

        }
        private void createSmallPictureBoxes(Panel parent)
        {
            PictureBox pbDel = new PictureBox();

            pbDel.Image = imgDel;
            pbDel.SizeMode = PictureBoxSizeMode.Zoom;
            pbDel.BackColor = Color.Transparent;
            pbDel.Size = new Size(40, 30);
            pbDel.Parent = parent;
            pbDel.Click += new EventHandler(pbDelClick);
            pbDel.MouseDown += new MouseEventHandler(pbDelMouseDown);
            pbDel.MouseUp += new MouseEventHandler(pbDelMouseUp);
            pbDel.MouseHover += new EventHandler(pbDelMouseHover);
            pbDel.MouseLeave += new EventHandler(pbDelMouseLeave);
            pbDel.Location = new Point(parent.Width - pbDel.Width - 5, parent.Height - pbDel.Height - 5);

            if (comboBoxPath.Items.Count > 1)
            {
                PictureBox pbMoveDir = new PictureBox();
                pbMoveDir.Image = imgMove;
                pbMoveDir.SizeMode = PictureBoxSizeMode.Zoom;
                pbMoveDir.BackColor = Color.Transparent;
                pbMoveDir.Size = pbDel.Size;
                pbMoveDir.Parent = parent;
                //pbMoveDir.Click += new EventHandler(pbDelClick);
                pbMoveDir.MouseDown += new MouseEventHandler(pbDelMouseDown);
                pbMoveDir.MouseUp += new MouseEventHandler(pbDelMouseUp);
                pbMoveDir.MouseHover += new EventHandler(pbDelMouseHover);
                pbMoveDir.MouseLeave += new EventHandler(pbDelMouseLeave);
                pbMoveDir.Location = new Point(pbDel.Location.X - pbMoveDir.Width - 5, pbDel.Location.Y);
                pbMoveDir.MouseClick += new MouseEventHandler(pbMoveDirMouseClick);
                toolTip1.SetToolTip(pbMoveDir, "Moves savegame to " + getTargetDir());
            }
        }

        private string getTargetDir()
        {

            if (comboBoxPath.SelectedValue.ToString() == Properties.Settings.Default.savegameDefaultPath)
                return Properties.Settings.Default.savegameHistoryPath;
            else
                return Properties.Settings.Default.savegameDefaultPath;

        }

        private void pbDelClick(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            SaveGameFile svg = listSVG.Where(x => x.panelName == pb.Parent.Name).FirstOrDefault();
            if (svg != null)
            {
                Directory.Delete(svg.dirName, true);
                listSVG.Remove(svg);
                loadView(listSVG, 0, 20);
            }
        }
        private static void pbDelMouseDown(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BorderStyle = BorderStyle.Fixed3D;
        }
        private static void pbDelMouseUp(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BorderStyle = BorderStyle.None;
        }
        private static void pbDelMouseHover(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = Color.LightGray;
        }
        private static void pbDelMouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = Color.Transparent;//  pb.Parent.BackColor;
            pb.BorderStyle = BorderStyle.None;
        }

        private static void pb_MouseDoubleClick(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if (pb.Image != null)
                Process.Start(pb.ImageLocation);
        }
        private void pbMoveDirMouseClick(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            SaveGameFile svg = listSVG.Where(x => x.panelName == pb.Parent.Name).FirstOrDefault();
            if (svg != null)
            {
                moveDirectory(new DirectoryInfo(svg.dirName));
                listSVG.Remove(svg);
                loadView(listSVG, 0, 20);
            }
        }

        private void moveDirectory(DirectoryInfo sourceDir)
        {
            try
            {


                string selectedDir = comboBoxPath.SelectedValue.ToString();
                string targetDir = getTargetDir();



                string newDirName = Path.Combine(targetDir, sourceDir.Name);
                if (!Directory.Exists(newDirName))
                {
                    Directory.CreateDirectory(newDirName);
                    DateTime lastWrite = sourceDir.LastWriteTime;

                    var files = sourceDir.EnumerateFiles();

                    foreach (var item in files)
                    {
                        File.Move(item.FullName, Path.Combine(newDirName, item.Name));
                        //  File.SetCreationTime(Path.Combine(newDirName, item.Name), item.CreationTime);
                    }

                    Directory.SetCreationTime(newDirName, sourceDir.CreationTime);
                    Directory.SetLastWriteTime(newDirName, lastWrite);
                    Directory.Delete(sourceDir.FullName);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("This shouldn't happen.\n" + error.Message);
            }
        }



        private void panel_MouseClick(object sender, MouseEventArgs e)
        {

            Panel pn;
            if (sender is Panel)
                pn = (Panel)sender;
            else
            {
                var ctrl = (Control)sender;
                pn = (Panel)ctrl.Parent;
            }
            if (selectionMode == false)
            {
                labelHint.Visible = false;
                string name = pn.Name;

                var match = listSVG.Where(l => l.panelName == pn.Name);
                foreach (var item in match)
                {
                    RootJson jsonInfo = loadJsonFile(item.metadata);
                    if (jsonInfo.Data != null)
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Name");
                        dt.Columns.Add("Value");
                        string tmp = "";
                        foreach (PropertyInfo prop in typeof(Metadata).GetProperties())
                        {
                            tmp += prop.Name + "\t" + prop.GetValue(jsonInfo.Data.metadata, null) + "\n";

                            dt.Rows.Add(prop.Name, prop.GetValue(jsonInfo.Data.metadata, null));
                        }
                        dataGridView1.DataSource = dt;
                        dataGridView1.RowHeadersVisible = false;
                        labelDirname.Text = new DirectoryInfo(item.dirName).Name;
                    }
                }
            }
            else
            {
                if (pn.BackColor == Color.White)
                    pn.BackColor = SystemColors.ActiveCaption;
                else
                    pn.BackColor = Color.White;

                labelSelected.Text = "Selected: " + pArr.Where(x => x.BackColor == SystemColors.ActiveCaption).Count().ToString() + "/ " + listSVG.Count.ToString();
            }
        }
        private RootJson loadJsonFile(string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<RootJson>(json);

            }
        }


        private void loadFilesAndView(string path)
        {
            listSVG = loadFiles(path);

            loadView(listSVG, 0, 20);
        }



        private void modernButtonLoadMore_Click(object sender, EventArgs e)
        {
            loadMoreSaveGames(50);
        }
        private void loadMoreSaveGames(int limit)
        {
            if (listSVG != null)
            {
                int endIndex;
                lastIndex++;
                if (lastIndex + limit < listSVG.Count())
                    endIndex = lastIndex + limit;
                else
                    endIndex = listSVG.Count();

                if (lastIndex + 1 != listSVG.Count())
                    loadView(listSVG, lastIndex, endIndex);
            }
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, this.panelRight.ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }

        private void comboBoxPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPath.SelectedItem != null)
            {

                loadFilesAndView(comboBoxPath.SelectedValue.ToString());
            }
        }

        private void modernButtonScrollUp_Click(object sender, EventArgs e)
        {
            panelSaveGames.VerticalScroll.Value = panelSaveGames.VerticalScroll.Minimum;
            panelSaveGames.PerformLayout();
        }

        private void modernButtonScrollDown_Click(object sender, EventArgs e)
        {
            panelSaveGames.VerticalScroll.Value = panelSaveGames.VerticalScroll.Maximum;
            panelSaveGames.PerformLayout();
        }

        private void modernButtonEnableSelectionMode_Click(object sender, EventArgs e)
        {
            if (selectionMode == false)
            {
                selectionMode = true;
                modernButtonEnableSelectionMode.Text = "Disable selection mode";
                labelSelected.Text = "Selected: 0/ " + listSVG.Count().ToString();

            }
            else
            {
                selectionMode = false;
                foreach (var item in pArr)
                {
                    item.BackColor = Color.White;
                }
                modernButtonEnableSelectionMode.Text = "Enable selection mode";
                labelSelected.Text = "Selected: 0/0";
            }

            modernButtonSelectAll.Visible = selectionMode;
            pictureBoxDelete.Visible = selectionMode;
            labelSelected.Visible = selectionMode;

            if (comboBoxPath.Items.Count > 1)
                pictureBoxMove.Visible = selectionMode;
        }

        private void modernButtonSelectAll_Click(object sender, EventArgs e)
        {
            if (modernButtonSelectAll.Text == "Select all")
            {
                foreach (var item in pArr)
                {
                    item.BackColor = SystemColors.ActiveCaption;
                }
                modernButtonSelectAll.Text = "Deselect all";
                labelSelected.Text = "Selected: " + (lastIndex + 1).ToString() + "/" + listSVG.Count().ToString();
            }
            else if (modernButtonSelectAll.Text == "Deselect all")
            {
                foreach (var item in pArr)
                {
                    item.BackColor = Color.White;
                }
                modernButtonSelectAll.Text = "Select all";
                labelSelected.Text = "Selected: 0/" + listSVG.Count().ToString();
            }

        }

        private void hideRightSide(bool hide)
        {
            if (hide == true)
            {
                panelRight.Visible = false;
                this.Width = panelLeft.Right + 14;
                modernButtonHideDetails.Text = "Show details";
                Properties.Settings.Default.svgmHideDetails = true;
            }
            else
            {
                panelRight.Visible = true;
                this.Width = panelRight.Width + panelLeft.Width + 25;
                modernButtonHideDetails.Text = "Hide details";
                Properties.Settings.Default.svgmHideDetails = false;
            }
        }

        private void pictureBoxDelete_Click(object sender, EventArgs e)
        {
            if (listSVG != null)
            {
                var selectedGames = listSVG.Where(x => pArr.Any(d => d.BackColor == SystemColors.ActiveCaption && d.Name == x.panelName)).ToList();

                if (selectedGames.Count() > 0)
                {
                    DialogResult res = MessageBox.Show("Do you want to delete your selected savegames (" + selectedGames.Count().ToString() + ")?", "Warning", MessageBoxButtons.YesNoCancel);
                    if (res == DialogResult.Yes)
                    {
                        for (int i = selectedGames.Count() - 1; i >= 0; i--)
                        {
                            Directory.Delete(selectedGames[i].dirName, true);
                            listSVG.Remove(selectedGames[i]);
                        }

                        loadView(listSVG, 0, 20);
                    }
                }
            }
        }

        private void pictureBoxMove_Click(object sender, EventArgs e)
        {
            if (listSVG != null)
            {
                var selectedGames = listSVG.Where(x => pArr.Any(d => d.BackColor == SystemColors.ActiveCaption && d.Name == x.panelName)).ToList();

                if (selectedGames.Count() > 0)
                {
                    string targetDir = getTargetDir();

                    DialogResult res = MessageBox.Show("Do you want to move your selected savegames(" + selectedGames.Count().ToString() + ") to" + targetDir + "?", "Warning", MessageBoxButtons.YesNoCancel);
                    if (res == DialogResult.Yes)
                    {
                        for (int i = selectedGames.Count() - 1; i >= 0; i--)
                        {
                            moveDirectory(new DirectoryInfo(selectedGames[i].dirName));
                            listSVG.Remove(selectedGames[i]);
                        }
                        loadView(listSVG, 0, 20);
                    }
                }
            }
        }

        private void modernButtonHideDetails_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.svgmHideDetails = !Properties.Settings.Default.svgmHideDetails;
            hideRightSide(Properties.Settings.Default.svgmHideDetails);
            Properties.Settings.Default.Save();
        }
    }
    public class RootJson
    {
        public string RootType { get; set; }
        public Data Data { get; set; }
    }
    public class SaveGameFile
    {
        internal string metadata { get; set; }
        internal string datFile { get; set; }
        internal string thumb { get; set; }
        internal string dirName { get; set; }
        internal string panelName { get; set; }
    }


    public class PlayerPosition
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

    public class Metadata
    {
        public string gameDefinition { get; set; }
        public string activeQuests { get; set; }
        public string trackedQuestEntry { get; set; }
        public string trackedQuest { get; set; }
        public string mainQuest { get; set; }
        public string debugString { get; set; }
        public string locationName { get; set; }
        public PlayerPosition playerPosition { get; set; }
        public double playTime { get; set; }
        public double playthroughTime { get; set; }
        public int nextSavableEntityID { get; set; }
        public int nextNonSavableEntityID { get; set; }
        public string lifePath { get; set; }
        public string bodyGender { get; set; }
        public string brainGender { get; set; }
        public double level { get; set; }
        public double streetCred { get; set; }
        public double gunslinger { get; set; }
        public double assault { get; set; }
        public double demolition { get; set; }
        public double athletics { get; set; }
        public double brawling { get; set; }
        public double coldBlood { get; set; }
        public double stealth { get; set; }
        public double engineering { get; set; }
        public double crafting { get; set; }
        public double hacking { get; set; }
        public double combatHacking { get; set; }
        public double strength { get; set; }
        public double intelligence { get; set; }
        public double reflexes { get; set; }
        public double technicalAbility { get; set; }
        public double cool { get; set; }
        public string initialBuildID { get; set; }
        public string finishedQuests { get; set; }
        public string playthroughID { get; set; }
        public string pointOfNoReturnId { get; set; }
        public string visitID { get; set; }
        public string buildSKU { get; set; }
        public string buildPatch { get; set; }
        public string difficulty { get; set; }
        public int saveVersion { get; set; }
        public int gameVersion { get; set; }
        public string timestampString { get; set; }
        public string name { get; set; }
        public string userName { get; set; }
        public string buildID { get; set; }
        public string platform { get; set; }
        public string censorFlags { get; set; }
        public string buildConfiguration { get; set; }
        public int fileSize { get; set; }
        public bool isForced { get; set; }
        public bool isCheckpoint { get; set; }
        public long initialLoadingScreenID { get; set; }
        public bool isStoryMode { get; set; }
        public bool isPointOfNoReturn { get; set; }
        public bool isEndGameSave { get; set; }
    }

    public class Data
    {
        public Metadata metadata { get; set; }
    }

}
