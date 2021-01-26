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
        private List<SaveGameFile> svgList, svgListUntouched;
        private List<Panel> pnList;
        private int lastIndex = 0;
        private static Image imgDel, imgMove;
        private static bool selectionMode = false;
        private List<DirectoryInfo> pathToSavegame;
        private List<string> defaultSavegameNames;

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
            HideDatagridView(Properties.Settings.Default.svgmHideDetails);
            labelSelected.Text = "Selected: 0/0";
            labelHint.Parent = dataGridView1;
            if (Properties.Settings.Default.svgmLoadAll == true)
                modernButtonLoadMore.Visible = false;
            LoadExcludeList();

            LoadCombobox();
        }

        private void LoadExcludeList()
        {
            defaultSavegameNames = new List<string>();
            defaultSavegameNames.Add("AutoSave-0");
            defaultSavegameNames.Add("AutoSave-1");
            defaultSavegameNames.Add("AutoSave-2");
            defaultSavegameNames.Add("AutoSave-3");
            defaultSavegameNames.Add("AutoSave-4");
            defaultSavegameNames.Add("AutoSave-5");
            defaultSavegameNames.Add("AutoSave-6");
            defaultSavegameNames.Add("AutoSave-7");
            defaultSavegameNames.Add("AutoSave-8");
            defaultSavegameNames.Add("AutoSave-9");
            defaultSavegameNames.Add("QuickSave-0");
            defaultSavegameNames.Add("QuickSave-1");
            defaultSavegameNames.Add("QuickSave-2");
            defaultSavegameNames.Add("EndGameSave");
            defaultSavegameNames.Add("PointOfNoReturnSave");
            defaultSavegameNames.Add("ManualSave");
        }
        private void LoadCombobox()
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
        private List<SaveGameFile> LoadSaveGameFileList(string path)
        {

            List<SaveGameFile> listSaveGame = new List<SaveGameFile>();
            List<DirectoryInfo> listdir;

            if (checkBoxFilterNonCustomSaves.Checked == true)
                listdir = new DirectoryInfo(path).EnumerateDirectories().Where(x => defaultSavegameNames.All(d => !x.Name.Contains(d))).OrderByDescending(d => d.LastWriteTime).ToList();
            else
                listdir = new DirectoryInfo(path).EnumerateDirectories().OrderByDescending(d => d.LastWriteTime).ToList();

            if (textBoxSearchBar.Text != "" && textBoxSearchBar.Text != "Search...")
                listdir = listdir.Where(x => x.Name.ToLower().Contains(textBoxSearchBar.Text.ToLower())).ToList();

            foreach (var dir in listdir)
            {
                SaveGameFile svg = new SaveGameFile();
                svg.DirName = dir.FullName;
                svg.LastWriteTime = dir.LastWriteTime;
                foreach (var item in Directory.EnumerateFiles(dir.FullName))
                {
                    if (item.EndsWith(".json") && Path.GetFileName(item).StartsWith("meta"))
                        svg.MetaDataJson = item;
                    else if (Path.GetFileName(item) == ("sav.dat"))
                        svg.DatFile = item;
                    else if (item.EndsWith(".png"))
                        svg.ThumbnailPath = item;
                }
                listSaveGame.Add(svg);
            }
            return listSaveGame.Where(d => d.DatFile != null).ToList();
        }


        private void LoadView(int startIndex, int endIndex)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            labelSelected.Text = "Selected 0/" + svgList.Count().ToString();
            //cleanPanelSaveGames();
            if (pnList == null)
                pnList = new List<Panel>();

            if (endIndex > svgList.Count())
                endIndex = svgList.Count();


            if (pnList.Count() < endIndex && endIndex != 0)
            {
                for (int i = pnList.Count; i < endIndex; i++)
                {
                    pnList.Add(new Panel());
                    CreatePanel(i);

                    LoadDataToPanelControls(pnList[i], i);
                }
            }
            else if (pnList.Count() >= endIndex)
            {
                for (int i = pnList.Count() - 1; i >= endIndex; i--)
                {
                    pnList[i].Visible = false;
                }
                for (int i = startIndex; i < endIndex; i++)
                {
                    pnList[i].Visible = true;
                    LoadDataToPanelControls(pnList[i], i);
                }

            }
            if (endIndex > lastIndex)
                lastIndex = endIndex;
            if (startIndex == 0)
                panelDatagrid.Location = new Point(pnList[0].Location.X + pnList[0].Width + 50, 30);
            if (lastIndex == svgList.Count() - 1)
                modernButtonLoadMore.Enabled = false;
            else
                modernButtonLoadMore.Enabled = true;


            sw.Stop();
            // MessageBox.Show(sw.Elapsed.TotalSeconds.ToString());

            labelCount.Text = endIndex + "/" + svgList.Count().ToString();

        }

        private void CreatePanel(int index)
        {
            PictureBox pb = new PictureBox();
            Label lb = new Label();

            panelSaveGames.Controls.Add(pnList[index]);
            pnList[index].Controls.Add(pb);
            pnList[index].Controls.Add(lb);

            if (index == 0)
            {
                pnList[index].Location = new Point(6, 6);
            }
            else
                pnList[index].Location = new Point(6, pnList[index - 1].Location.Y + pnList[index - 1].Height + 6);

            pb.Location = new Point(3, 3);
            pnList[index].Size = new Size(panelSaveGames.Width - pnList[index].Location.X - 23, 150);
            pb.Size = new Size(300, 168);
            pb.MouseClick += panel_MouseClick;
            pb.MouseDoubleClick += pb_MouseDoubleClick;
            pb.Name = "pbThumb";


            lb.Location = new Point(pb.Location.X + pb.Width + 10, 3);
            lb.AutoSize = true;
            lb.Name = "labelDir";


            CreateLabelsForSaveGameInfo(6, index, lb);

            pnList[index].BackColor = Color.White;
            pnList[index].BorderStyle = BorderStyle.Fixed3D;
            pnList[index].MouseClick += panel_MouseClick;

            CreateSmallPictureBoxes(pnList[index]);


        }

        private void CreateLabelsForSaveGameInfo(int length, int index, Label lb)
        {
            Label[] lbArr = new Label[length];

            for (int j = 0; j < lbArr.Length; j++)
            {
                lbArr[j] = new Label();
                pnList[index].Controls.Add(lbArr[j]);
                if (j == 0)
                    lbArr[j].Location = new Point(lb.Location.X, lb.Location.Y + lb.Height + 3);
                else if (j == lbArr.Length / 2)
                    lbArr[j].Location = new Point(lbArr[0].Location.X + lbArr[0].Bounds.Right / 2, lb.Location.Y + lb.Height + 3);
                else
                    lbArr[j].Location = new Point(lbArr[j - 1].Location.X, lbArr[j - 1].Location.Y + lbArr[j - 1].Height + 3);
                lbArr[j].AutoSize = true;
                lbArr[j].MouseClick += panel_MouseClick;
                lbArr[j].Name = "lb" + j;
            }
        }
        private void CreateSmallPictureBoxes(Panel parent)
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
                toolTip1.SetToolTip(pbMoveDir, "Moves savegame to " + GetTargetDir());
            }
        }

        private void LoadDataToPanelControls(Panel parent, int i)
        {

            parent.BackColor = Color.White;
            if (svgList[i].JsonData == null)
                svgList[i].JsonData = LoadJsonData(svgList[i].MetaDataJson);

            foreach (Control item in parent.Controls)
            {
                switch (item.Name)
                {
                    case "labelDir":
                        item.Text = GetDirectoryName(svgList[i].DirName);
                        break;
                    case "lb0":
                        item.Text = "Body: " + svgList[i].JsonData.Data.metadata.bodyGender;
                        break;
                    case "lb1":
                        item.Text = "Brain: " + svgList[i].JsonData.Data.metadata.brainGender;
                        break;
                    case "lb2":
                        item.Text = "Lifepath: " + svgList[i].JsonData.Data.metadata.lifePath;
                        break;
                    case "lb3":
                        TimeSpan ts = new TimeSpan();
                        ts = TimeSpan.FromSeconds(Convert.ToInt32(svgList[i].JsonData.Data.metadata.playTime));
                        item.Text = "Playtime: " + ts.TotalHours.ToString("N0") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");
                        break;
                    case "lb4":
                        item.Text = "Level: " + svgList[i].JsonData.Data.metadata.level;
                        break;
                    case "lb5":
                        item.Text = "Streetcred: " + svgList[i].JsonData.Data.metadata.streetCred;
                        break;
                    case "pbThumb":
                        using (var stream = new FileStream(svgList[i].ThumbnailPath, FileMode.Open))
                        {

                            ((PictureBox)item).Image = Image.FromStream(stream);
                            ((PictureBox)item).SizeMode = PictureBoxSizeMode.Zoom;
                            ((PictureBox)item).ImageLocation = svgList[i].ThumbnailPath;
                        }
                        break;
                }
            }
        }

        private string GetTargetDir()
        {

            if (comboBoxPath.SelectedValue.ToString() == Properties.Settings.Default.savegameDefaultPath)
                return Properties.Settings.Default.savegameHistoryPath;
            else
                return Properties.Settings.Default.savegameDefaultPath;

        }
        private void DeleteDirectory(Panel pn)
        {

            SaveGameFile svg = GetSaveGameFileByPanelCtrl(pn);
            if (svg != null)
            {
                if (Properties.Settings.Default.svgmDisableConfirmation == false)
                    if (DialogResult.Yes != MessageBox.Show("Are you sure you want to delete " + new DirectoryInfo(svg.DirName).Name + "?", "Warning", MessageBoxButtons.YesNoCancel))
                        return;
                if (checkBoxSimulate.Checked == false)
                    Directory.Delete(svg.DirName, true);

                svgList.Remove(svg);
                LoadView(0, lastIndex);
            }
        }


        private void MoveDirectory(DirectoryInfo sourceDir)
        {
            try
            {
                string selectedDir = comboBoxPath.SelectedValue.ToString();
                string targetDir = GetTargetDir();

                string newDirName = Path.Combine(targetDir, sourceDir.Name);
                if (!Directory.Exists(newDirName))
                {
                    if (checkBoxSimulate.Checked == false)
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
            }
            catch (Exception error)
            {
                MessageBox.Show("This shouldn't happen.\n" + error.Message);
            }
        }


        private SaveGameFile GetSaveGameFileByPanelCtrl(Control ctrl)
        {
            //rework
            Panel pn;
            if (ctrl is Panel)
                pn = (Panel)ctrl;
            else
            {
                pn = (Panel)ctrl.Parent;
            }

            return svgList.Where(x => (pn.Controls["labelDir"] as Label).Text == GetDirectoryName(x.DirName)).FirstOrDefault();

        }
        private List<SaveGameFile> GetSaveGameFilesByPanelList(List<Panel> pn)
        {
            return svgList.Where(x => pn.Any(c => (c.Controls["labelDir"] as Label).Text == GetDirectoryName(x.DirName))).ToList(); ;
        }


        private string GetDirectoryName(string dir)
        {
            return new DirectoryInfo(dir).Name;
        }
        private void LoadDatagridViewData(Control sender)
        {
            labelHint.Visible = false;
            SaveGameFile sgf = GetSaveGameFileByPanelCtrl((Control)sender);
            RootJson jsonInfo = sgf.JsonData;
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
                labelDirNameDatagrid.Text = GetDirectoryName(sgf.DirName);

            }
        }

        private void ControlIsSelected(Control sender)
        {
            Panel pn;
            if (sender is Panel)
                pn = (Panel)sender;
            else
            {
                pn = (Panel)((Control)sender).Parent;
            }
            if (pn.BackColor == Color.White)
                pn.BackColor = SystemColors.ActiveCaption;
            else
                pn.BackColor = Color.White;

            labelSelected.Text = "Selected: " + pnList.Where(x => x.BackColor == SystemColors.ActiveCaption).Count().ToString() + "/ " + svgList.Count.ToString();
        }

        private RootJson LoadJsonData(string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<RootJson>(json);
            }
        }

        private void LoadAllFilesAndView(string path)
        {
            if (svgListUntouched == null)
            {
                svgListUntouched = LoadSaveGameFileList(path);
                svgList = svgListUntouched;
            }
            else
            {
                svgList = FilterSvgList();
            }

            int endIndex;
            if (Properties.Settings.Default.svgmLoadAll == true)
                endIndex = svgList.Count();
            else if (lastIndex != 0)
                endIndex = lastIndex;
            else
                endIndex = 20;

            LoadView(0, endIndex);

        }

        private List<SaveGameFile> FilterSvgList()
        {
            List<SaveGameFile> listSaveGame = new List<SaveGameFile>();
       

            if (checkBoxFilterNonCustomSaves.Checked == true)
               listSaveGame= svgListUntouched.Where(x => defaultSavegameNames.All(d => !GetDirectoryName(x.DirName).Contains(d))).OrderByDescending(d => d.LastWriteTime).ToList();
            else
                listSaveGame = svgListUntouched.OrderByDescending(d => d.LastWriteTime).ToList();

            if (textBoxSearchBar.Text != "" && textBoxSearchBar.Text != "Search...")
            {
               listSaveGame = listSaveGame.Where(x => GetDirectoryName(x.DirName).ToLower().Contains(textBoxSearchBar.Text.ToLower())).ToList();
            }

            

            return listSaveGame;

        }

        private void modernButtonLoadMore_Click(object sender, EventArgs e)
        {
            LoadMoreSaveGames(50);
        }
        private void LoadMoreSaveGames(int limit)
        {
            if (svgList != null)
            {
                int endIndex;
                // lastIndex++;
                if (lastIndex + limit < svgList.Count())
                    endIndex = lastIndex + limit;
                else
                    endIndex = svgList.Count();

                if (lastIndex + 1 != svgList.Count())
                    LoadView(lastIndex, endIndex);
            }
        }


        private void HideDatagridView(bool hide)
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

        private void DeleteSelectdDirectorties()
        {
            if (svgList != null)
            {
                var selectedGames = GetSaveGameFilesByPanelList(pnList.Where(c => c.BackColor == SystemColors.ActiveCaption).ToList());

                if (selectedGames.Count() > 0)
                {
                    DialogResult res = MessageBox.Show("Do you want to delete your selected savegames (" + selectedGames.Count().ToString() + ")?", "Warning", MessageBoxButtons.YesNoCancel);
                    if (res == DialogResult.Yes)
                    {
                        for (int i = selectedGames.Count() - 1; i >= 0; i--)
                        {
                            if (checkBoxSimulate.Checked == false)
                                Directory.Delete(selectedGames[i].DirName, true);

                            svgList.Remove(selectedGames[i]);
                            pnList.Where(c => c.Visible == true).LastOrDefault().Visible = false;
                        }

                        LoadView(0, lastIndex);
                    }
                }
            }
        }

        private void MoveSelectedDirectories()
        {
            if (svgList != null)
            {
                var selectedGames = GetSaveGameFilesByPanelList(pnList.Where(c => c.BackColor == SystemColors.ActiveCaption).ToList());

                if (selectedGames.Count() > 0)
                {
                    string targetDir = GetTargetDir();

                    DialogResult res = MessageBox.Show("Do you want to move your selected savegames(" + selectedGames.Count().ToString() + ") to" + targetDir + "?", "Warning", MessageBoxButtons.YesNoCancel);
                    if (res == DialogResult.Yes)
                    {
                        for (int i = selectedGames.Count() - 1; i >= 0; i--)
                        {

                            MoveDirectory(new DirectoryInfo(selectedGames[i].DirName));
                            svgList.Remove(selectedGames[i]);
                        }
                        LoadView(0, lastIndex);
                    }
                }
            }
        }

        //###################################################################################################################################################################################################
        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (selectionMode == false)
            {
                LoadDatagridViewData((Control)sender);
            }
            else
            {
                ControlIsSelected((Control)sender);
            }
        }
        private void comboBoxPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPath.SelectedItem != null)
            {

                LoadAllFilesAndView(comboBoxPath.SelectedValue.ToString());
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
                labelSelected.Text = "Selected: 0/ " + svgList.Count().ToString();

            }
            else
            {
                selectionMode = false;
                foreach (var item in pnList)
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
                foreach (var item in pnList)
                {
                    item.BackColor = SystemColors.ActiveCaption;
                }
                modernButtonSelectAll.Text = "Deselect all";
                labelSelected.Text = "Selected: " + pnList.Where(p => p.BackColor == SystemColors.ActiveCaption).Count().ToString() + "/" + svgList.Count().ToString();
            }
            else if (modernButtonSelectAll.Text == "Deselect all")
            {
                foreach (var item in pnList)
                {
                    item.BackColor = Color.White;
                }
                modernButtonSelectAll.Text = "Select all";
                labelSelected.Text = "Selected: 0/" + svgList.Count().ToString();
            }

        }

        private void pictureBoxDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectdDirectorties();
        }

        private void pictureBoxMove_Click(object sender, EventArgs e)
        {
            MoveSelectedDirectories();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //listSVG.RemoveAt(0);
            for (int i = 0; i < pnList.Where(c => c.Controls.Count > 0).Count(); i++)
            {
                LoadDataToPanelControls(pnList[i], i);
            }
        }

        private void checkBoxFilterNonCustomSaves_CheckedChanged(object sender, EventArgs e)
        {
            LoadAllFilesAndView(comboBoxPath.SelectedValue.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            svgList.RemoveAt(1);
            LoadView(0, 20);
            //pArr.Where(c => c.Visible == true).LastOrDefault().Visible = false;
            //adjustPanels();
        }



        private void FormSaveGameManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
                checkBoxSimulate.Visible = !checkBoxSimulate.Visible;
        }

        private void radioButtonOrderByLastWriteTime_CheckedChanged(object sender, EventArgs e)
        {
            if (svgList != null)
            {
                svgList = svgList.OrderByDescending(x => x.LastWriteTime).ToList();
                LoadView(0, lastIndex);
            }
        }

        private void radioButtonOrderByName_CheckedChanged(object sender, EventArgs e)
        {
            if (svgList != null)
            {
                svgList = svgList.OrderBy(x => GetDirectoryName(x.DirName)).ToList();
                LoadView(0, lastIndex);
            }

        }

        private void modernButtonHideDetails_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.svgmHideDetails = !Properties.Settings.Default.svgmHideDetails;
            HideDatagridView(Properties.Settings.Default.svgmHideDetails);
            Properties.Settings.Default.Save();
        }

        private void pbDelClick(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            DeleteDirectory((Panel)pb.Parent);
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

        private void comboBoxPath_MouseHover(object sender, EventArgs e)
        {
            if (comboBoxPath.SelectedItem != null)
            {
                toolTip1.SetToolTip(comboBoxPath, comboBoxPath.SelectedValue.ToString());
            }
        }

        private void textBoxSearchBar_Enter(object sender, EventArgs e)
        {
            if (textBoxSearchBar.Text == "Search...")
            {
                textBoxSearchBar.ForeColor = Color.Black;
                textBoxSearchBar.Clear();
            }
        }

        private void textBoxSearchBar_Leave(object sender, EventArgs e)
        {
            if(textBoxSearchBar.Text == "")
            {
                textBoxSearchBar.Text = "Search...";
                textBoxSearchBar.ForeColor = Color.DarkGray;
            }
        }

        private void textBoxSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearchBar.Text != "Search...")
            {
                LoadAllFilesAndView(comboBoxPath.SelectedValue.ToString());
            }
        }

        private void pbMoveDirMouseClick(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            SaveGameFile svg = GetSaveGameFileByPanelCtrl(pb);
            if (svg != null)
            {
                MoveDirectory(new DirectoryInfo(svg.DirName));
                svgList.Remove(svg);
                LoadView(0, lastIndex);
            }
        }
    }
    public class RootJson
    {
        public string RootType { get; set; }
        public Data Data { get; set; }
    }
    public class SaveGameFile
    {
        internal string MetaDataJson { get; set; }
        internal string DatFile { get; set; }
        internal string ThumbnailPath { get; set; }
        internal string DirName { get; set; }
        internal DateTime LastWriteTime { get; set; }

        internal RootJson JsonData { get; set; }

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
