using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Timers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace CyberStart77
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string saveGamePath, extraSaveGamePath;
        public static ProcInfoMin procInfo;
        private bool forceExit = false;
        private static DateTime lastSaveGameCreationDate;
        private static bool gameSaved = false;
        private System.Timers.Timer timerSaveGame;
        private int iChecksWithoutSavegame = 0;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();


        const uint SWP_NOSIZE = 0x0001;
        const uint SWP_NOZORDER = 0x0004;

        private void buttonStart_Click(object sender, EventArgs e)
        {

            startBackgroundWorker();

        }

        private void startBackgroundWorker()
        {
            saveGamePath = Properties.Settings.Default.savegamePath;
            extraSaveGamePath = Properties.Settings.Default.extraSavegamePath;
            List<ProcessStartInfo> pInfo = new List<ProcessStartInfo>();

            if (checkBoxDisableExtraSaveGames.Checked == false)
            {
                if (!Directory.Exists(saveGamePath))
                {
                    MessageBox.Show("Path not found.");
                    return;
                }
                else if (string.IsNullOrEmpty(extraSaveGamePath))
                {
                    MessageBox.Show("Invalid Extra savegame path");
                    return;
                }
            }
            if (checkBoxIgnoreAddApps.Checked == false)
            {
                foreach (var item in readProcessInfoFromJson())
                {
                    pInfo.Add(item.ConvertToProcessStartInfo());
                }
            }
            if (checkBoxIgnoreAddApps.Checked == true && checkBoxDisableExtraSaveGames.Checked == true)
            {
                MessageBox.Show("Invalid configuration! Custom Apps or extra save games have to be enabled");
                return;
            }
            else
            {
                panelSettingsRunDisable.Enabled = false;
                modernButtonStart.Enabled = false;
                modernButtonStop.Enabled = true;
                startToolStripMenuItem.Text = "Stop";
                bgwCheckProcess.RunWorkerAsync(pInfo);
            }
        }

        private void checkSaveGame()
        {
            int timeDifference = Properties.Settings.Default.minDifferenceLastSaveGame;
            int iAutosaveMinutes = Properties.Settings.Default.minAutosaveGame;

            bgwCheckProcess.ReportProgress(1, "Check for new savegames..." + Environment.NewLine);

            var legacySaves = Directory.EnumerateDirectories(saveGamePath).Where(d => d.Contains("AutoSave") || d.Contains("QuickSave") || d.Contains("PointOfNoReturnSave") || d.Contains("EndGameSave"));
            if (!Directory.Exists(extraSaveGamePath))
                Directory.CreateDirectory(extraSaveGamePath);

            var extraSaves = Directory.EnumerateDirectories(extraSaveGamePath);
            List<DirectoryInfo> listLegacyDirInfo = new List<DirectoryInfo>();
            List<DirectoryInfo> listExtraSavesDirInfo = new List<DirectoryInfo>();

            foreach (var item in legacySaves)
            {
                listLegacyDirInfo.Add(new DirectoryInfo(item));
            }
            foreach (var item in extraSaves)
            {
                listExtraSavesDirInfo.Add(new DirectoryInfo(item));
            }
            var existingDirs = listLegacyDirInfo.Where(d => listExtraSavesDirInfo.Any(f => d.CreationTime == f.CreationTime));

            var missingDirs = listLegacyDirInfo.Except(existingDirs);

            if (lastSaveGameCreationDate == null)
                lastSaveGameCreationDate = listLegacyDirInfo.Max(d => d.CreationTime);

            missingDirs = missingDirs.Where(d => (d.CreationTime - lastSaveGameCreationDate).TotalMinutes >= timeDifference);

            if (missingDirs.Count() > 0)
                copySaveGames(missingDirs);

            if (iAutosaveMinutes != 0)
            {
                int intervalInMin = Convert.ToInt32(Math.Floor(timerSaveGame.Interval / 1000 / 60));

                if (iChecksWithoutSavegame * intervalInMin >= (iAutosaveMinutes - intervalInMin))
                    gameSaved = false;

                if (gameSaved == false && isProcessInForeground(Properties.Settings.Default.process))
                {
                    SendKeys.SendWait("{F5}");
                    bgwCheckProcess.ReportProgress(0, "Autosave... (Sending F5)");
                }

                iChecksWithoutSavegame++;
            }
        }

        private bool isProcessInForeground(string processname)
        {
            //try
            //{

            IntPtr hwnd = GetForegroundWindow();
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            Process p = Process.GetProcessById((int)pid);
            if (p.ProcessName == processname)
                return true;
            else
                return false;

            //}
            //catch (Exception)
            //{
            //    return false;
            //}

        }

        private void startCustomApplications(List<ProcessStartInfo> listExe)
        {
            foreach (var item in listExe)
            {
                if (!string.IsNullOrEmpty(item.FileName))
                {
                    string pName = Path.GetFileNameWithoutExtension(item.FileName);

                    if (Process.GetProcessesByName(pName).Length == 0)
                    {
                        Process p = Process.Start(item);
                        int iFail = 0;
                        while (p.MainWindowHandle == IntPtr.Zero)
                        {
                            if (iFail > 500)
                                break;
                            Thread.Sleep(10);
                            iFail++;
                        }
                        IntPtr hWnd = p.MainWindowHandle;

                        if (hWnd != IntPtr.Zero)
                        {
                            if (Screen.AllScreens.Length > 1)
                            {
                                var sc = Screen.AllScreens.Where(s => s != Screen.PrimaryScreen);
                                Screen scr = sc.FirstOrDefault();
                                RECT rect = new RECT();
                                GetWindowRect(hWnd, ref rect);
                                int width = rect.Right - rect.Left;
                                int height = rect.Bottom - rect.Top;
                                SetWindowPos(hWnd, IntPtr.Zero, scr.Bounds.X + scr.Bounds.Width / 2 - width / 2, scr.Bounds.Y + scr.Bounds.Height / 2 - height / 2, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
                            }

                        }
                    }
                }
            }
        }
        private void copySaveGames(IEnumerable<DirectoryInfo> legacySaves)
        {
            if (!Directory.Exists(extraSaveGamePath))
                Directory.CreateDirectory(extraSaveGamePath);
            try
            {

                string lifepath, gender, lvl, newDirName;
                int nameSchemaMode = Properties.Settings.Default.name_schema;
                foreach (var item in legacySaves)
                {


                    if (nameSchemaMode == 1 || nameSchemaMode == 2)
                    {
                        var jsonFiles = Directory.EnumerateFiles(item.FullName, "metadata.9.json");
                        if (jsonFiles.Count() > 0)
                        {
                            string nameSchema = Properties.Settings.Default.customNameSchema;
                            if (nameSchemaMode == 2 && string.IsNullOrEmpty(nameSchema))
                            {
                                newDirName = getNameSchemaSaveGame(readJsonFromFile(jsonFiles.First()), item.CreationTime);
                            }
                            else
                            {
                                JObject jo = readJsonFromFile(jsonFiles.First());
                                lifepath = (string)jo["Data"]["metadata"]["lifePath"];
                                gender = (string)jo["Data"]["metadata"]["bodyGender"];
                                lvl = (string)jo["Data"]["metadata"]["level"];
                                newDirName = Path.Combine(extraSaveGamePath, lifepath + " " + gender + " " + lvl + " " + item.CreationTime.ToString("dd-MM-yy_HH-mm-ss"));
                            }
                        }
                        //Fallback if json not found/empty
                        else
                            newDirName = Path.Combine(extraSaveGamePath, item.Name.Substring(0, item.Name.IndexOf("-")) + "-" + item.CreationTime.ToString("dd-MM-yy_HH-mm-ss"));
                    }
                    else if (Properties.Settings.Default.name_schema == 2)
                    {
                        newDirName = getNameSchemaSaveGame(readJsonFromFile(item.FullName), item.CreationTime);
                    }
                    else
                        newDirName = Path.Combine(extraSaveGamePath, item.Name.Substring(0, item.Name.IndexOf("-")) + "-" + item.CreationTime.ToString("dd-MM-yy_HH-mm-ss"));
                    if (!Directory.Exists(newDirName))
                    {
                        Directory.CreateDirectory(newDirName);
                    }

                    foreach (var saveFiles in Directory.EnumerateFiles(item.FullName))
                    {
                        string destFile = Path.Combine(newDirName, Path.GetFileName(saveFiles));


                        File.Copy(saveFiles, destFile,false);
                        File.SetCreationTime(destFile, File.GetCreationTime(saveFiles));
                    }
                    Directory.SetCreationTime(newDirName, item.CreationTime);
                    Directory.SetLastWriteTime(newDirName, item.LastWriteTime);
                    if (bgwCheckProcess.IsBusy == true)
                        bgwCheckProcess.ReportProgress(1, "Copy Savegame " + item.Name + " to " + Path.GetDirectoryName(newDirName) + Environment.NewLine);

                    lastSaveGameCreationDate = item.CreationTime;
                    gameSaved = true;
                    iChecksWithoutSavegame = 0;
                }
            }
            catch (Exception err)
            {

                bgwCheckProcess.ReportProgress(-1, "ERROR (CopySaveGames): " + err.Message + Environment.NewLine);
            }
        }
        public static JObject readJsonFromFile(string jsonFile)
        {
            using (StreamReader sr = new StreamReader(jsonFile))
            {
                string jsonData = sr.ReadToEnd();
                return JObject.Parse(jsonData);
            }
        }
        public static JObject readJsonFromFile(byte[] jsonFile)
        {
            string jsonData = Encoding.UTF8.GetString(jsonFile);
            return JObject.Parse(jsonData);

        }
        public static string getNameSchemaSaveGame(JObject jsonFile, DateTime creationDate)
        {
            string nameSchema = Properties.Settings.Default.customNameSchema;
            //nameSchema = "%level% %streetCred% %hackinlg%_[dd-MM-yy_HH-mm-ss]";
            Regex reg = new Regex(@"%([a-zA-Z]+?)%|\[(.*?)\]");
            MatchCollection data = reg.Matches(nameSchema);

            List<JsonRegexNameSchema> jSchema = new List<JsonRegexNameSchema>();
            string sDateFormat = "", fullmatchDateFormat = "";
            foreach (Match grp in data)
            {
                if (grp.Groups[1] != null)
                {
                    //GROUP0 = Value including %
                    // GROUP1 = Value between %
                    // GROUP2 = Value between [] (returns empty.string when no square brackets found)
                    jSchema.Add(new JsonRegexNameSchema { jsonKey = grp.Groups[1].Value,
                                                            regexMatch = grp.Groups[0].Value });
                }
                if (grp.Groups[2] != null)
                {
                    if (!string.IsNullOrEmpty(grp.Groups[2].Value))
                    {
                        sDateFormat = grp.Groups[2].Value;
                        fullmatchDateFormat = grp.Groups[0].Value;
                    }
                }
            }


            List<string> jsonValues = new List<string>();
            if (jSchema.Count > 0)
                foreach (var item in jSchema)
                {

                    if (item.jsonKey != "playerPosition")
                    {
                        string tmp = (string)jsonFile["Data"]["metadata"][item.jsonKey];
                        if (!string.IsNullOrEmpty(tmp))
                            item.jsonValue = tmp;                     
                    }
                }

            if ((!string.IsNullOrEmpty(nameSchema)) && nameSchema != "playerPosition")
            {
                foreach (var item in jSchema.Where(j=>!string.IsNullOrEmpty(j.jsonValue)))
                {

                    nameSchema = nameSchema.Replace(item.regexMatch, item.jsonValue);
                }
                if (!string.IsNullOrEmpty(fullmatchDateFormat))
                    nameSchema = nameSchema.Replace(fullmatchDateFormat, creationDate.ToString(sDateFormat));
            }
            return nameSchema;

        }

        private bool checkProcessExit(Process p)
        {
            if (p == null)
                return false;
            else
            {
                p.Refresh();
                return p.HasExited;
            }
        }
        private void bgwCheckProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            Process[] p;
            List<ProcessStartInfo> pListStartinfo = (List<ProcessStartInfo>)e.Argument;
            string processName = Properties.Settings.Default.process;

            int timerProcess = Properties.Settings.Default.processTimer;
            int iTimerSaveGame = Properties.Settings.Default.savegameTimer * 1000;
            bool bDisableCustomApp = Properties.Settings.Default.disableAddApps;
            bool bDisbleExtraSaveGames = Properties.Settings.Default.disableExtraSavegames;

            timerSaveGame = new System.Timers.Timer();
            timerSaveGame.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            timerSaveGame.Interval = iTimerSaveGame;

            bgwCheckProcess.ReportProgress(-1, "Backgroundworker has started" + Environment.NewLine);
            while (bgwCheckProcess.CancellationPending == false)
            {
                bgwCheckProcess.ReportProgress(-1, "Check for running process " + processName + Environment.NewLine);
                p = Process.GetProcessesByName(processName);
                if (p.Length > 0)
                {
                    if (bDisableCustomApp == false)
                        startCustomApplications(pListStartinfo);

                    bgwCheckProcess.ReportProgress(0, processName + " is running..." + Environment.NewLine);
                    while (checkProcessExit(p.FirstOrDefault()) == false)
                    {
                        if (bDisbleExtraSaveGames == false)
                        {
                            if (timerSaveGame.Enabled == false)
                            {
                                timerSaveGame.Start();
                                bgwCheckProcess.ReportProgress(0, "Start SaveGameCheck in " + (timerSaveGame.Interval / 1000).ToString() + " seconds" + Environment.NewLine);
                            }
                        }
                        if (bgwCheckProcess.CancellationPending)
                        {
                            timerSaveGame.Stop();
                            break;
                        }
                        Thread.Sleep(500);
                    }
                    if (timerSaveGame.Enabled == true)
                        timerSaveGame.Stop();

                    if (bDisableCustomApp == false)
                        killCustomApplications(pListStartinfo);


                    bgwCheckProcess.ReportProgress(0, processName + " exited" + Environment.NewLine);
                }
                else
                {
                    if (timerProcess != 0)
                    {
                        bgwCheckProcess.ReportProgress(-1, "Sleep for " + timerProcess + " seoncds" + Environment.NewLine);
                        for (int i = 0; i < timerProcess; i++)
                        {
                            if (bgwCheckProcess.CancellationPending == true)
                                break;
                            Thread.Sleep(1000);
                        }
                    }
                }
            }
        }

        private void killCustomApplications(List<ProcessStartInfo> pListStartinfo)
        {
            foreach (var item in pListStartinfo)
            {
                var proc = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(item.FileName));
                foreach (var pro in proc)
                {
                    try
                    {
                        pro.Kill();
                        bgwCheckProcess.ReportProgress(-1, "Successfully killed process " + item.FileName + Environment.NewLine);
                    }
                    catch (Exception)
                    {

                        bgwCheckProcess.ReportProgress(-1, "Failed to kill process " + item.FileName + Environment.NewLine);
                    }
                }
            }
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            checkSaveGame();
        }
        private void bgwCheckProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBoxLog.AppendText(e.UserState.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDownProcess.Value = Properties.Settings.Default.processTimer;
            numericUpDownSaveGame.Value = Properties.Settings.Default.savegameTimer;
            textBoxLog.ScrollBars = ScrollBars.Vertical;
            this.DoubleBuffered = true;

            loadSettings();

            loadListboxProcess();

            if (Properties.Settings.Default.autostart == true)
                startBackgroundWorker();
        }

        private void loadSettings()
        {
            if (Properties.Settings.Default.savegamePath == string.Empty)
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Saved Games\CD Projekt Red\Cyberpunk 2077");
                if (Directory.Exists(path))
                {
                    saveGamePath = path;
                    Properties.Settings.Default.savegamePath = path;
                    Properties.Settings.Default.Save();
                }
            }

            textBoxProcess.Text = Properties.Settings.Default.process;
            checkBoxAutostart.Checked = Properties.Settings.Default.autostart;
            checkBoxCloseToTray.Checked = Properties.Settings.Default.closeToTray;
            checkBoxDisableExtraSaveGames.Checked = Properties.Settings.Default.disableExtraSavegames;
            checkBoxHideStatusLog.Checked = Properties.Settings.Default.hideStatusLog;
            checkBoxIgnoreAddApps.Checked = Properties.Settings.Default.disableAddApps;
            checkBoxMinimizeToTray.Checked = Properties.Settings.Default.minimizeToTray;

            if (Properties.Settings.Default.name_schema == 1)
                radioButtonSavegameContentSchema.Checked = true;

            else if (Properties.Settings.Default.name_schema == 2)
                radioButtonCustomName.Checked = true;
            else
                radioButtonDirNameSchema.Checked = true;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.customNameSchema))
                radioButtonCustomName.Text = "Savegame Custom (" + Properties.Settings.Default.customNameSchema + ")";
            textBoxPathExtraSavegames.Text = Properties.Settings.Default.extraSavegamePath;
            textBoxPathSavegame.Text = Properties.Settings.Default.savegamePath;
        }

        private void numericUpDownProcess_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.processTimer = (int)numericUpDownSaveGame.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDownSaveGame_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.savegameTimer = (int)numericUpDownSaveGame.Value;
            Properties.Settings.Default.Save();
        }

        private void bgwCheckProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (forceExit == true)
                Application.Exit();
            else
            {
                textBoxLog.AppendText("Backgroundworker exited successfully" + Environment.NewLine);
                panelSettingsRunDisable.Enabled = true;
                modernButtonStart.Enabled = true;
                modernButtonStop.Enabled = false;
                startToolStripMenuItem.Text = "Start";
            }
        }

        private static List<JObject> readProcessJsonRaw()
        {
            List<JObject> listJo = new List<JObject>();
            if (File.Exists("process.json"))
            {
                using (StreamReader sr = new StreamReader("process.json"))
                {
                    string jsonData = sr.ReadToEnd();
                    if (jsonData.Length > 0)
                    {
                        var jo = JArray.Parse(jsonData);
                        foreach (JObject item in jo)
                        {
                            listJo.Add(item);
                        }

                    }
                }
            }
            return listJo;
        }

        private void saveProcessInfoToJson(string filename, string workingdir, string argument, string pName)
        {
            List<JObject> listJo = readProcessJsonRaw();

            JObject processInfo =
                new JObject(
                    new JProperty("process",
                        new JObject(
                            new JProperty("process_name", pName),
                             new JProperty("filename", filename),
                             new JProperty("workingdir", workingdir),
                             new JProperty("argument", argument))));

            listJo.Add(processInfo);
            string json = JsonConvert.SerializeObject(listJo, Formatting.Indented);

            File.WriteAllText(@"process.json", json);
        }



        private List<ProcInfoMin> readProcessInfoFromJson(string processName = "")
        {
            List<JObject> listJo = readProcessJsonRaw();
            List<ProcInfoMin> lProcInfo = new List<ProcInfoMin>();
            if (processName != string.Empty)
            {
                var newJo = listJo.Where(j => (string)j["process"]["process_name"] == processName);
                foreach (var item in newJo)
                {
                    lProcInfo.Add(new ProcInfoMin
                    {
                        friendlyName = (string)item["process"]["process_name"],
                        processFile = (string)item["process"]["filename"],
                        processWorkDir = (string)item["process"]["workingdir"],
                        processArguments = (string)item["process"]["argument"]
                    });
                }
            }
            else
            {
                foreach (var item in listJo)
                {
                    lProcInfo.Add(new ProcInfoMin
                    {
                        friendlyName = (string)item["process"]["process_name"],
                        processFile = (string)item["process"]["filename"],
                        processWorkDir = (string)item["process"]["workingdir"],
                        processArguments = (string)item["process"]["argument"]
                    });
                }
            }
            return lProcInfo;

        }

        private void editProcessInfoInJson(ProcInfoMin proc, string prevProcName)
        {
            List<JObject> listJo = readProcessJsonRaw();
            JObject jObj = listJo.Where(j => (string)j["process"]["process_name"] == prevProcName).FirstOrDefault();

            if (jObj != null)
            {
                JObject tmpObj = jObj;
                JToken jTok = tmpObj.SelectToken("process.process_name");
                jTok.Replace(proc.friendlyName);
                jTok = tmpObj.SelectToken("process.filename");
                jTok.Replace(proc.processFile);
                jTok = tmpObj.SelectToken("process.workingdir");
                jTok.Replace(proc.processWorkDir);
                jTok = tmpObj.SelectToken("process.argument");
                jTok.Replace(proc.processArguments);

                int index = listJo.IndexOf(jObj);
                listJo.Remove(jObj);
                listJo.Insert(index, tmpObj);

                string json = JsonConvert.SerializeObject(listJo, Formatting.Indented);
                File.WriteAllText("process.json", json);
            }

        }

        private void deleteProcessInfoInJson(string processname)
        {
            List<JObject> listJo = readProcessJsonRaw();
            JObject jObj = listJo.Where(j => (string)j["process"]["process_name"] == processname).FirstOrDefault();

            if (jObj != null)
            {
                listJo.Remove(jObj);
                WriteListToJsonFile(listJo);

            }

        }

        private void WriteListToJsonFile(List<JObject> listJobjects)
        {
            string json = JsonConvert.SerializeObject(listJobjects, Formatting.Indented);
            File.WriteAllText("process.json", json);
        }
        public static bool ExistsProcessFriendlyName(string processname)
        {
            if (string.IsNullOrEmpty(processname))
                return false;
            else
                return (readProcessJsonRaw().Where(n => (string)n["process"]["process_name"] == processname).Count() > 0);
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (bgwCheckProcess.IsBusy)
            {
                bgwCheckProcess.ReportProgress(0, "Please wait...");
                bgwCheckProcess.CancelAsync();
            }
        }

        private void loadListboxProcess()
        {
            listBoxProcess.Items.Clear();
            foreach (var item in readProcessInfoFromJson())
            {
                if (!string.IsNullOrEmpty(item.friendlyName))
                    listBoxProcess.Items.Add(item.friendlyName);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //var test = readProcessInfoFromJson();
            //listBoxProcess.Items.Clear();
            //foreach (var item in test)
            //{
            //    if (!string.IsNullOrEmpty(item.friendlyName))
            //        listBoxProcess.Items.Add(item.friendlyName);
            //}

            // editProcessInfoInJson("test3");
        }



        private void pictureBox_MouseHover(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = Color.LightGray;
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = Color.White;
            pb.BorderStyle = BorderStyle.None;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            // ControlPaint.DrawBorder(e.Graphics, pictureBox1.ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BorderStyle = BorderStyle.None;
        }

        private void pictureBoxAdd_Click(object sender, EventArgs e)
        {
            using (FormProcess fP = new FormProcess(null, false))
            {
                procInfo = new ProcInfoMin();
                if (fP.ShowDialog() == DialogResult.OK)
                {
                    saveProcessInfoToJson(procInfo.processFile, procInfo.processWorkDir, procInfo.processArguments, procInfo.friendlyName);
                    loadListboxProcess();
                }
            }
        }

        private void pictureBoxEdit_Click(object sender, EventArgs e)
        {
            if (listBoxProcess.SelectedItem != null)
            {
                ProcInfoMin procInfoForm = readProcessInfoFromJson(listBoxProcess.SelectedItem.ToString()).FirstOrDefault();
                using (FormProcess fP = new FormProcess(procInfoForm, true))
                {
                    procInfo = new ProcInfoMin();
                    if (fP.ShowDialog() == DialogResult.OK)
                    {
                        editProcessInfoInJson(procInfo, procInfoForm.friendlyName);

                        loadListboxProcess();
                    }
                }
            }
        }

        private void pictureBoxDelete_Click(object sender, EventArgs e)
        {
            if (listBoxProcess.SelectedItem != null)
            {
                deleteProcessInfoInJson(listBoxProcess.SelectedItem.ToString());
                loadListboxProcess();
            }
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(label1, "Interval in seconds for checking if process (" + Properties.Settings.Default.process + ") is running");
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(label2, "Interval in seconds for checking if there are any new savegames");
        }

        private void textBoxProcess_TextChanged(object sender, EventArgs e)
        {

            Properties.Settings.Default.process = textBoxProcess.Text;
            Properties.Settings.Default.Save();
        }

        private void textBoxProcess_Leave(object sender, EventArgs e)
        {
            if (textBoxProcess.Text.Contains("."))
                textBoxProcess.Text = textBoxProcess.Text.Split('.').FirstOrDefault();
        }

        private void checkBoxDisableExtraSaveGames_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.disableExtraSavegames = checkBoxDisableExtraSaveGames.Checked;
            groupBoxExtraSavegames.Enabled = !checkBoxDisableExtraSaveGames.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxIgnoreAddApps_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.disableAddApps = checkBoxIgnoreAddApps.Checked;
            groupBoxAddApplication.Enabled = !checkBoxIgnoreAddApps.Checked;
            Properties.Settings.Default.Save();
        }

        private void radioButtonDirNameSchema_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDirNameSchema.Checked == true)
                Properties.Settings.Default.name_schema = 0;
            Properties.Settings.Default.Save();
        }

        private void radioButtonSavegameContentSchema_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSavegameContentSchema.Checked == true)
                Properties.Settings.Default.name_schema = 1;
            Properties.Settings.Default.Save();
        }

        private void buttonSearchSaveGamePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxPathSavegame.Text = fbd.SelectedPath;
            }
        }

        private void textBoxPathSavegame_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.savegamePath = textBoxPathSavegame.Text;
            Properties.Settings.Default.Save();
        }

        private void textBoxPathExtraSavegames_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.extraSavegamePath = textBoxPathExtraSavegames.Text;
            Properties.Settings.Default.Save();
        }

        private void checkBoxMinimizeToTray_CheckedChanged(object sender, EventArgs e)
        {

            Properties.Settings.Default.minimizeToTray = checkBoxMinimizeToTray.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxHideStatusLog_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHideStatusLog.Checked == true)
            {
                textBoxLog.Visible = false;

                panelRightSide.Location = new Point(10, 4);
                int xr = this.Bounds.Right;

                this.Width = panelRightSide.Width + 10 + 2 * 10;
                this.Location = new Point(this.Location.X + xr - this.Right, this.Location.Y);
               // panelCredit.Location = new Point(7, this.Height - panelCredit.Height);
            }
            else
            {
                textBoxLog.Visible = true;
                panelRightSide.Location = new Point(textBoxLog.Location.X + textBoxLog.Width + 5, 4);
                int xr = this.Bounds.Right;
                panelRightSide.Visible = false;
                this.Width = textBoxLog.Location.X + textBoxLog.Width + panelRightSide.Width + 2 * 10;

                this.Location = new Point(this.Location.X - (this.Right - xr), this.Location.Y);
                panelRightSide.Visible = true;
            }
           
            Properties.Settings.Default.hideStatusLog = checkBoxHideStatusLog.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxAutostart_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autostart = checkBoxAutostart.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxCloseToTray_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.closeToTray = checkBoxCloseToTray.Checked;
            Properties.Settings.Default.Save();
        }

        private void buttonSearchExtraSavegames_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (textBoxPathSavegame.Text != string.Empty)
                fbd.SelectedPath = textBoxPathSavegame.Text;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxPathExtraSavegames.Text = fbd.SelectedPath;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            exitApp();
        }

        private void exitApp()
        {
            forceExit = true;
            if (bgwCheckProcess.IsBusy == true)
            {
                bgwCheckProcess.CancelAsync();

                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = false;
            }
            else
                Application.Exit();


        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                if (checkBoxMinimizeToTray.Checked == true)
                {

                    minimizeToTray();
                }
            }
        }

        private void minimizeToTray()
        {
            this.Hide();
            notifyIcon1.Visible = true;
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.Text = this.Text;
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;

        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            //if(e.Button == MouseButtons.Right)
            //{

            //}
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitApp();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bgwCheckProcess.IsBusy == true)
            {
                bgwCheckProcess.CancelAsync();
                startToolStripMenuItem.Text = "Start";
            }
            else
            {
                bgwCheckProcess.RunWorkerAsync();
                startToolStripMenuItem.Text = "Stop";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkBoxCloseToTray.Checked == true && forceExit == false)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {

                    minimizeToTray();
                    e.Cancel = true;
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/WolvenKit/CyberCAT");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBoxAddSettings_Click(object sender, EventArgs e)
        {
            using (FormSettings fS = new FormSettings())
            {
                fS.Location = new Point(Cursor.Position.X - fS.Width / 2, Cursor.Position.Y);
                fS.ShowDialog();
            }
            loadSettings();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void radioButtonCustomName_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.name_schema = 2;
            Properties.Settings.Default.Save();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.flaticon.com/authors/kiranshastry");
        }
    }
    public class JsonRegexNameSchema
    {
        public string jsonKey { get; set; }
        public string jsonValue { get; set; }
        public string regexMatch { get; set; }
    }
    public class ProcInfoMin
    {
        public string friendlyName { get; set; } = string.Empty;
        public string processFile { get; set; } = string.Empty;
        public string processWorkDir { get; set; } = string.Empty;
        public string processArguments { get; set; } = string.Empty;

        public void Reset()
        {
            friendlyName = string.Empty;
            processFile = string.Empty;
            processWorkDir = string.Empty;
            processArguments = string.Empty;
        }

        public ProcessStartInfo ConvertToProcessStartInfo()
        {
            ProcessStartInfo pInfo = new ProcessStartInfo();
            pInfo.FileName = processFile;
            pInfo.WorkingDirectory = processWorkDir;
            pInfo.Arguments = processArguments;
            return pInfo;
        }
    }
}
