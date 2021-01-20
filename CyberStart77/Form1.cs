﻿using System;
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

        //   string saveGameDefaultPath, saveGameHistoryPath;
        public static ProcInfoMin procInfo;
        private bool forceExit = false;
        private static DateTime lastSaveGameCreationDate = new DateTime();
        //    private static bool gameSaved = false;
        private System.Timers.Timer timerSaveGame;
        private System.Timers.Timer timerAutoQuickSave;
        //      private int iChecksWithoutSavegame = 0;
        private static CyberSave77Settings settings;
        private static bool bDebug = false;
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

            List<ProcessStartInfo> pInfo = new List<ProcessStartInfo>();

            settings = new CyberSave77Settings();
            settings.ProcessName = Properties.Settings.Default.processName;
            settings.SavegamePathDefault = Properties.Settings.Default.savegameDefaultPath;
            settings.SavegamePathHistory = Properties.Settings.Default.savegameHistoryPath;

            settings.IntervalAutoQuickSave = Properties.Settings.Default.intervalAutoQuickSaveMinutes * 1000 * 60;
            settings.IntervalProcessCheck = Properties.Settings.Default.counterProcessCheck;
            settings.IntervalSaveGameCheck = Properties.Settings.Default.intervalSaveGameCheckSeconds * 1000;

            settings.KillStartedApplicationsOnExit = Properties.Settings.Default.killStartedAppsOnExit;
            settings.DisableApplicationsOnStart = Properties.Settings.Default.disableAddApps;
            settings.DisableAutoQuickSave = Properties.Settings.Default.disableAutoQuicksave;
            settings.DisableSaveHameHistory = Properties.Settings.Default.disableExtraSavegames;

            settings.TimeDifferenceBtwSavegames = Properties.Settings.Default.timeDifferenceSaveGames;
            settings.AutoQsRetryInSecs = Properties.Settings.Default.autoQuickSaveErrorDelay;

            if (settings.DisableSaveHameHistory == false)
            {
                if (!Directory.Exists(settings.SavegamePathDefault))
                {
                    MessageBox.Show("Path not found.");
                    return;
                }
                else if (string.IsNullOrEmpty(settings.SavegamePathHistory))
                {
                    MessageBox.Show("Invalid Extra savegame path");
                    return;
                }
            }
            if (settings.DisableApplicationsOnStart == false)
            {
                foreach (var item in readProcessInfoFromJson())
                {
                    pInfo.Add(item.ConvertToProcessStartInfo());
                }
                settings.ApplicationsToStartList = pInfo;
            }
            if (settings.DisableApplicationsOnStart == true && settings.DisableAutoQuickSave == true && settings.DisableSaveHameHistory)
            {
                MessageBox.Show("Invalid configuration! Custom Apps, AutoQuickSave or SaveGame History has to be enabled");
                return;
            }
            else
            {
                panelSettingsRunDisable.Enabled = false;
                modernButtonStart.Enabled = false;
                modernButtonStop.Enabled = true;
                startToolStripMenuItem.Text = "Stop";
                bgwCheckProcess.RunWorkerAsync(settings);
            }
        }

        private void checkSaveGame()
        {

            DirectoryInfo dirInfoDefault = new DirectoryInfo(settings.SavegamePathDefault);
            DirectoryInfo dirInfoHistory = new DirectoryInfo(settings.SavegamePathHistory);

            bgwCheckProcess.ReportProgress(0, "Check for new savegames...");

            if (!Directory.Exists(settings.SavegamePathHistory))
                Directory.CreateDirectory(settings.SavegamePathHistory);

            //Get all directories
            var allDirectories = dirInfoDefault.EnumerateDirectories();

            //History saves will be saved in the default save game directory
            if (string.Compare(dirInfoDefault.FullName, dirInfoHistory.FullName, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                //Get all directories which are unique by their creation date (Copies will always have the same creation date as the original)
                var uniqueDirsByDate = allDirectories.GroupBy(c => c.CreationTime).Where(g => g.Count() == 1).SelectMany(c => c);

                //Filter unique dirs by their name to exclude ManualSaves and other dirs
                var uniqueDirsFiltered = uniqueDirsByDate.Where(d => d.Name.Contains("AutoSave") || d.Name.Contains("QuickSave")).ToList();// || d.Name.Contains("PointOfNoReturnSave") || d.Name.Contains("EndGameSave")).ToList();

                if (lastSaveGameCreationDate == new DateTime() && allDirectories.Count() > 0)
                {
                    //Get the latest save game which got copied (if one exists)
                    var listDuplicateDirDates = allDirectories.GroupBy(c => c.CreationTime).Where(g => g.Count() > 1).SelectMany(c => c);
                    if (listDuplicateDirDates.Count() > 0)
                        lastSaveGameCreationDate = listDuplicateDirDates.Max(d => d.CreationTime);
                }

                List<DirectoryInfo> dirsToBeCopied;


                if (settings.TimeDifferenceBtwSavegames != 0)
                    dirsToBeCopied = filterDirsByTime(uniqueDirsFiltered, settings.TimeDifferenceBtwSavegames);
                else
                    dirsToBeCopied = uniqueDirsFiltered;

                if (dirsToBeCopied.Count() > 0)
                {
                    bgwCheckProcess.ReportProgress(2, "Found " + dirsToBeCopied.Count().ToString() + " savegame(s) to be copied");
                    copySaveGames(dirsToBeCopied);
                }
            }
            else

            {
                var listDefaultSaveGames = allDirectories.Where(d => d.Name.Contains("AutoSave") || d.Name.Contains("QuickSave")).ToList();// || d.Name.Contains("PointOfNoReturnSave") || d.Name.Contains("EndGameSave"));
                var listHistorySaveGames = dirInfoHistory.EnumerateDirectories();

                //Get all dirs with a different CreationTime (since all copied saves have the same creation time as the original ones)
                var missingDirs = listDefaultSaveGames.Where(d => listHistorySaveGames.All(f => d.CreationTime != f.CreationTime));

                if (lastSaveGameCreationDate == new DateTime() && listHistorySaveGames.Count() > 0)
                    lastSaveGameCreationDate = listHistorySaveGames.Max(d => d.CreationTime);

                // = missingDirs.Where(d => allDirectories.All(a => Math.Abs((d.CreationTime - a.CreationTime).TotalMinutes) > timeDifference));

                var dirsToBeCopied = filterDirsByTime(missingDirs.ToList(), settings.TimeDifferenceBtwSavegames);



                if (dirsToBeCopied.Count() > 0)
                {
                    bgwCheckProcess.ReportProgress(2, "Found " + dirsToBeCopied.Count().ToString() + " savegame(s) to be copied");
                    copySaveGames(dirsToBeCopied);
                }
            }

            //var extraSaves = Directory.EnumerateDirectories(extraSaveGamePath);
            //List<DirectoryInfo> listLegacyDirInfo = new List<DirectoryInfo>();
            //List<DirectoryInfo> listExtraSavesDirInfo = new List<DirectoryInfo>();

            //foreach (var item in legacySaves)
            //{
            //    listLegacyDirInfo.Add(new DirectoryInfo(item));
            //}
            //foreach (var item in extraSaves)
            //{
            //    listExtraSavesDirInfo.Add(new DirectoryInfo(item));
            //}

        }

        private List<DirectoryInfo> filterDirsByTime(List<DirectoryInfo> uniqueDirs, int timeDifference)
        {
            List<DirectoryInfo> lDirInfo = new List<DirectoryInfo>();
            uniqueDirs = uniqueDirs.OrderBy(d => d.CreationTime).ToList();

            for (int i = 0; i < uniqueDirs.Count(); i++)
            {
                if (i == 0 && lastSaveGameCreationDate == new DateTime())
                {
                    lastSaveGameCreationDate = uniqueDirs[i].CreationTime;
                    lDirInfo.Add(uniqueDirs[i]);
                }
                else if (((uniqueDirs[i].CreationTime - lastSaveGameCreationDate).TotalMinutes) >= timeDifference)
                {
                    lastSaveGameCreationDate = uniqueDirs[i].CreationTime;
                    lDirInfo.Add(uniqueDirs[i]);
                }
            }
            return lDirInfo;
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
            try
            {
                string lifepath, gender, lvl, newDirName;
            int nameSchemaMode = Properties.Settings.Default.nameSchemaMode;
            foreach (var item in legacySaves)
            {
                if (nameSchemaMode == 1 || nameSchemaMode == 2)
                {
                    var jsonFiles = Directory.EnumerateFiles(item.FullName, "metadata.9.json");
                    if (jsonFiles.Count() > 0)
                    {
                        string nameSchema = Properties.Settings.Default.customNameSchema;
                        if (nameSchemaMode == 2 && !string.IsNullOrEmpty(nameSchema))
                        {
                            newDirName = Path.Combine(settings.SavegamePathHistory, getNameSchemaSaveGame(readJsonFromFile(jsonFiles.First()), item.CreationTime));
                        }
                        else
                        {
                            JObject jo = readJsonFromFile(jsonFiles.First());
                            lifepath = (string)jo["Data"]["metadata"]["lifePath"];
                            gender = (string)jo["Data"]["metadata"]["bodyGender"];
                            lvl = (string)jo["Data"]["metadata"]["level"];
                            newDirName = Path.Combine(settings.SavegamePathHistory, lifepath + " " + gender + " " + lvl + " " + item.CreationTime.ToString("dd-MM-yy_HH-mm-ss"));
                        }
                    }
                    //Fallback if json not found/empty
                    else
                        newDirName = Path.Combine(settings.SavegamePathHistory, item.Name.Substring(0, item.Name.IndexOf("-")) + "-" + item.CreationTime.ToString("dd-MM-yy_HH-mm-ss"));
                }
                else
                    newDirName = Path.Combine(settings.SavegamePathHistory, item.Name.Substring(0, item.Name.IndexOf("-")) + "-" + item.CreationTime.ToString("dd-MM-yy_HH-mm-ss"));

                if (!Directory.Exists(newDirName) && settings.copyDirs == true)
                {
                    Directory.CreateDirectory(newDirName);
                }

                if (settings.copyDirs == true)
                {
                    foreach (var saveFiles in Directory.EnumerateFiles(item.FullName))
                    {
                        string destFile = Path.Combine(newDirName, Path.GetFileName(saveFiles));


                        File.Copy(saveFiles, destFile, false);
                        File.SetCreationTime(destFile, File.GetCreationTime(saveFiles));
                    }

                    Directory.SetCreationTime(newDirName, item.CreationTime);
                    Directory.SetLastWriteTime(newDirName, item.LastWriteTime);
                }
                if (bgwCheckProcess.IsBusy == true)
                    bgwCheckProcess.ReportProgress(0, "Copy Savegame " + item.Name + " to " + new DirectoryInfo(newDirName).Name);

                lastSaveGameCreationDate = item.CreationTime;

                //Restart Autosave Timer since a
                if (timerAutoQuickSave.Enabled == true)
                {
                    timerAutoQuickSave.Stop();
                    timerAutoQuickSave.Start();
                }
            }
        }
            catch (Exception err)
            {
                bgwCheckProcess.ReportProgress(-1, "ERROR (CopySaveGames): " + err.Message);
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
                    jSchema.Add(new JsonRegexNameSchema
                    {
                        jsonKey = grp.Groups[1].Value,
                        regexMatch = grp.Groups[0].Value
                    });
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
                foreach (var item in jSchema.Where(j => !string.IsNullOrEmpty(j.jsonValue)))
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

            CyberSave77Settings settings = (CyberSave77Settings)e.Argument;

            //string processName = Properties.Settings.Default.process;

            //int timerProcess = Properties.Settings.Default.processTimer;
            ////seconds -> ms
            //int iTimerSaveGame = Properties.Settings.Default.savegameTimer * 1000;
            ////minutes -> ms
            //int iTimerAutoQuickSave = Properties.Settings.Default.intervalAutoSafeMinutes * 60 * 1000;

            //bool bDisableCustomApp = Properties.Settings.Default.disableAddApps;
            //bool bDisbleExtraSaveGames = Properties.Settings.Default.disableExtraSavegames;
            //bool bTerminateStartAppOnExit = Properties.Settings.Default.terminateStartApps;
            timerSaveGame.Interval = settings.IntervalSaveGameCheck;
            timerAutoQuickSave.Interval = settings.IntervalAutoQuickSave;


            bgwCheckProcess.ReportProgress(2, "Backgroundworker has started");
            displaySettings();



            while (bgwCheckProcess.CancellationPending == false)
            {
                bgwCheckProcess.ReportProgress(0, "Check for running process " + settings.ProcessName);

                p = Process.GetProcessesByName(settings.ProcessName);
                if (p.Length > 0 || bDebug == true)
                {
                    if (settings.DisableApplicationsOnStart == false)
                        startCustomApplications(settings.ApplicationsToStartList);

                    bgwCheckProcess.ReportProgress(0, settings.ProcessName + " is running...");

                    //while Process is running
                    while (checkProcessExit(p.FirstOrDefault()) == false || bDebug == true)
                    {
                        //SaveGameChecker
                        if (settings.DisableSaveHameHistory == false)
                        {
                            if (timerSaveGame.Enabled == false)
                            {
                                timerSaveGame.Start();
                                bgwCheckProcess.ReportProgress(0, "Start SaveGameCheck in " + (timerSaveGame.Interval / 1000).ToString() + " seconds");
                            }
                        }
                        //Autosaver
                        if (settings.DisableAutoQuickSave == false && timerAutoQuickSave.Enabled == false)
                        {
                            timerAutoQuickSave.Start();
                            bgwCheckProcess.ReportProgress(0, "Start AutoQuickSave...");
                        }

                        if (bgwCheckProcess.CancellationPending)
                        {

                            timerSaveGame.Stop();
                            timerAutoQuickSave.Stop();
                            CancelTimer = true;
                            return;
                        }
                        //Small delay to keep the load low
                        Thread.Sleep(500);
                    }

                    timerSaveGame.Stop();
                    timerAutoQuickSave.Stop();

                    if (settings.DisableApplicationsOnStart == false)
                        if (settings.KillStartedApplicationsOnExit == true)
                            killCustomApplications(settings.ApplicationsToStartList);


                    bgwCheckProcess.ReportProgress(0, settings.ProcessName + " exited");

                    //try to prevent multiple exits, since multiple processes are running
                    Thread.Sleep(750);
                }
                else
                {
                    if (settings.IntervalProcessCheck != 0)
                    {
                        bgwCheckProcess.ReportProgress(2, "Sleep for " + settings.IntervalProcessCheck + " seoncds");
                        for (int i = 0; i < settings.IntervalProcessCheck; i++)
                        {
                            if (bgwCheckProcess.CancellationPending == true)
                                break;
                            Thread.Sleep(1000);
                        }
                    }
                }
            }
        }
        private void displaySettings()
        {
            string stateHistorySavegame, stateAutoQuickSave, stateStartApp;
            if (Properties.Settings.Default.disableExtraSavegames == true)
                stateHistorySavegame = "Savegame History is disabled";
            else
                stateHistorySavegame = "Copy only savegames which are older than " + Properties.Settings.Default.timeDifferenceSaveGames + " minutes";

            if (Properties.Settings.Default.disableAutoQuicksave == true)
                stateAutoQuickSave = "AutoQuickSave is disabled";
            else
                stateAutoQuickSave = "AutoQuickSave every " + Properties.Settings.Default.intervalAutoQuickSaveMinutes + "  minutes";

            if (Properties.Settings.Default.disableAddApps == true)
                stateStartApp = "Start additional applications on start is disabled";
            else
                stateStartApp = "Start additional applications on start is enabled";

            bgwCheckProcess.ReportProgress(0, "#########################################");
            bgwCheckProcess.ReportProgress(0, stateHistorySavegame);
            bgwCheckProcess.ReportProgress(0, stateAutoQuickSave);
            bgwCheckProcess.ReportProgress(0, stateStartApp);
            bgwCheckProcess.ReportProgress(0, "#########################################");

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
                        bgwCheckProcess.ReportProgress(2, "Successfully killed process " + item.FileName);
                    }
                    catch (Exception)
                    {

                        bgwCheckProcess.ReportProgress(2, "Failed to kill process " + item.FileName);
                    }
                }
            }
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            checkSaveGame();
        }
        private static bool CancelTimer = false;
        //DEPRECATED -> in-game autosve interval is 5 minutes, which should be enough for most of the people (pretty much forgot about this feature)
        //I still leave it in here, for lower custom intervals if this feature will ever be used
        private void OnTimedEventAutoQuickSave(object source, ElapsedEventArgs e)
        {
            CancelTimer = false;

            DateTime dt = new DateTime();
            int iCounter = 1;
            int iMaxRetries = Properties.Settings.Default.autoQuickSaveMaxRetries;
            int iRetryAutoQuickSaveSeconds = settings.AutoQsRetryInSecs - 5;

            if (isProcessInForeground(Properties.Settings.Default.processName))
            {
                SendKeys.SendWait("{F5}");
                bgwCheckProcess.ReportProgress(0, "Create Quicksave... (Sending F5)");
                dt = DateTime.Now;
                Thread.Sleep(5000);
            }
            else
            {
                //Add action for not focused process
                bgwCheckProcess.ReportProgress(-1, "Quicksave canceld. Process not focussed");
                return;
            }
            while (savefileFound(dt) == false && iMaxRetries > 0)
            {
                timerAutoQuickSave.AutoReset = false;
                bgwCheckProcess.ReportProgress(0, "Quicksave failed. Trying again in 30 seconds.");

                //FOR Loop to check every second instead waiting for 30 seconds to cancel
                for (int i = 0; i < iRetryAutoQuickSaveSeconds; i++)
                {
                    Thread.Sleep(1000);
                    if (CancelTimer == true)
                        return;
                }
                if (isProcessInForeground(Properties.Settings.Default.processName))
                {
                    SendKeys.SendWait("{F5}");
                    bgwCheckProcess.ReportProgress(0, "Create Quicksave Try #" + iCounter + " (Sending F5)");
                    dt = DateTime.Now;
                    Thread.Sleep(5000);

                    if (iCounter > iMaxRetries)
                    {
                        bgwCheckProcess.ReportProgress(-1, "Failed to save game in time after " + iCounter + " retries.");
                        return;
                    }
                }
                else
                {
                    //Add action for not focused process
                    timerAutoQuickSave.Stop();
                    timerAutoQuickSave.Start();
                    timerAutoQuickSave.AutoReset = true;
                    bgwCheckProcess.ReportProgress(-1, "Autosave canceld. Process not focussed");
                    return;
                }
                iCounter++;
            }

            //Restart Timer   
            timerAutoQuickSave.Stop();
            timerAutoQuickSave.Start();
            timerAutoQuickSave.AutoReset = true;
            bgwCheckProcess.ReportProgress(0, "Game saved successfully");


        }
        //Checks if a Quciksave exists which isnt older than 5 seconds than the given DateTime, should be enough for slow HDDs
        private bool savefileFound(DateTime expectedDate)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(settings.SavegamePathDefault);
            var dirs = dirInfo.GetDirectories().Where(d => d.Name.Contains("QuickSave") && Math.Abs((d.CreationTime - expectedDate).TotalSeconds) < 5);
            if (dirs.Count() > 0)
                return true;
            else
                return false;
        }
        private void bgwCheckProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //State -1 = Error / 0 = Info / 2 = Debug
            if (bDebug == true)
            {
                textBoxLog.AppendText(e.UserState.ToString() + Environment.NewLine);
            }
            else if (e.ProgressPercentage == -1 || e.ProgressPercentage == 0)
                textBoxLog.AppendText(e.UserState.ToString() + Environment.NewLine);
            using (StreamWriter sw = new StreamWriter("CyberSave77.log",true))
            {
                Log(e.UserState.ToString(), sw, e.ProgressPercentage);
            }
        }
        public static void Log(string logMessage, TextWriter w, int loglevel)
        {
            string state;
            if (loglevel == -1)
                state = "ERRROR";
            else if (loglevel == 2)
                state = "DEBUG";
            else
                state = "INFO";

            w.WriteLine("[" + state + "]\t[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "]\t" + logMessage);
            //w.WriteLine();
            //w.WriteLine("-------------------------------");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Debugger.IsAttached == false)
            {
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            }
            if (Properties.Settings.Default.guiLocation == new Point(0, 0))
            {
                Screen sc = Screen.FromControl(this);
                this.Location = new Point((sc.Bounds.Width - this.Width) / 2, (sc.Bounds.Height - this.Height) / 2);
            }
            else
                this.Location = Properties.Settings.Default.guiLocation;


            textBoxLog.ScrollBars = ScrollBars.Vertical;
            this.DoubleBuffered = true;

            loadTimer();
            loadSettings();

            loadListboxProcess();

            if (Properties.Settings.Default.autostartBgw == true)
                startBackgroundWorker();
        }


        private void loadTimer()
        {
            timerAutoQuickSave = new System.Timers.Timer();
            timerAutoQuickSave.Elapsed += new ElapsedEventHandler(OnTimedEventAutoQuickSave);
            timerSaveGame = new System.Timers.Timer();
            timerSaveGame.Elapsed += new ElapsedEventHandler(OnTimedEvent);

        }
        private void loadSettings()
        {
            if (Properties.Settings.Default.savegameDefaultPath == string.Empty)
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Saved Games\CD Projekt Red\Cyberpunk 2077");
                if (Directory.Exists(path))
                {
                    Properties.Settings.Default.savegameDefaultPath = path;
                    if (string.IsNullOrEmpty(Properties.Settings.Default.savegameHistoryPath))
                    {
                        string sgHistoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Saved Games\CD Projekt Red\SaveGameHistory");
                        Properties.Settings.Default.savegameHistoryPath = sgHistoryPath;
                    }
                    Properties.Settings.Default.Save();
                }
                else
                    MessageBox.Show("Couldn't find save game directory (expcted " + path + ")");
            }


            checkBoxAutostart.Checked = Properties.Settings.Default.autostartBgw;
            checkBoxCloseToTray.Checked = Properties.Settings.Default.closeToTray;
            checkBoxDisableSaveGameHistory.Checked = Properties.Settings.Default.disableExtraSavegames;
            checkBoxDisableAutosave.Checked = Properties.Settings.Default.disableAutoQuicksave;
            checkBoxHideStatusLog.Checked = Properties.Settings.Default.hideStatusLog;
            checkBoxIgnoreAddApps.Checked = Properties.Settings.Default.disableAddApps;
            checkBoxMinimizeToTray.Checked = Properties.Settings.Default.minimizeToTray;
            labelProcess.Text = "Process: " + Properties.Settings.Default.processName;


            numericUpDownMinSaveGames.Value = Properties.Settings.Default.timeDifferenceSaveGames;
            numericUpDownTryAutoQuickSave.Value = Properties.Settings.Default.intervalAutoQuickSaveMinutes;
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
                lastSaveGameCreationDate = new DateTime();
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



        private void checkBoxDisableExtraSaveGames_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.disableExtraSavegames = checkBoxDisableSaveGameHistory.Checked;
            groupBoxExtraSavegames.Enabled = !checkBoxDisableSaveGameHistory.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxIgnoreAddApps_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.disableAddApps = checkBoxIgnoreAddApps.Checked;
            groupBoxAddApplication.Enabled = !checkBoxIgnoreAddApps.Checked;
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
            Properties.Settings.Default.autostartBgw = checkBoxAutostart.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxCloseToTray_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.closeToTray = checkBoxCloseToTray.Checked;
            Properties.Settings.Default.Save();
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
            else
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    Properties.Settings.Default.guiLocation = this.Location;
                    Properties.Settings.Default.Save();
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
            Properties.Settings.Default.nameSchemaMode = 2;
            Properties.Settings.Default.Save();
        }

        private void textBoxPathSavegame_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (!string.IsNullOrEmpty(tb.Text))
                Process.Start(tb.Text);
        }

        private void numericUpDownTryAutosave_ValueChanged(object sender, EventArgs e)
        {
            //if (numericUpDownTryAutosave.Value < numericUpDownMinSaveGames.Value && numericUpDownTryAutosave.Value != 0)
            //{
            //    toolTip1.ShowAlways = true;
            //    toolTip1.IsBalloon = true;
            //    toolTip1.SetToolTip(numericUpDownTryAutosave, "Autosave value shouldn't be lower than 'Minutes between Savegames'");
            //}

            Properties.Settings.Default.intervalAutoQuickSaveMinutes = (int)numericUpDownTryAutoQuickSave.Value;
            Properties.Settings.Default.Save();
        }



        private void labelAutosve_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(labelAutosve, "Try to create a quicksave of the game every " + numericUpDownTryAutoQuickSave.Value + " minutes (0 is disable)");
        }

        private void labelSaveGameTimeDif_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(labelSaveGameTimeDif, "Copy only savegames which are older than " + numericUpDownMinSaveGames.Value + " minutes than the last save.");
        }

        private void numericUpDownMinSaveGames_ValueChanged(object sender, EventArgs e)
        {

            //if (numericUpDownTryAutosave.Value < numericUpDownMinSaveGames.Value && numericUpDownTryAutosave.Value != 0)
            //{
            //    toolTip1.ShowAlways = true;
            //    toolTip1.IsBalloon = true;
            //    toolTip1.SetToolTip(numericUpDownMinSaveGames, "'Minutes between Savegames' value shouldn't be higher than 'Autosave'");
            //}
            Properties.Settings.Default.timeDifferenceSaveGames = (int)numericUpDownMinSaveGames.Value;
            Properties.Settings.Default.Save();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            checkSaveGame();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
                modernButtonDebug.Visible = !modernButtonDebug.Visible;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.flaticon.com/authors/kiranshastry");
        }

        private void modernButtonDebug_Click(object sender, EventArgs e)
        {
            
            bDebug = true;
            List<ProcessStartInfo> pInfo = new List<ProcessStartInfo>();

            settings = new CyberSave77Settings();
            settings.ProcessName = Properties.Settings.Default.processName;
            settings.SavegamePathDefault = Properties.Settings.Default.savegameDefaultPath;
            settings.SavegamePathHistory = Properties.Settings.Default.savegameDefaultPath;
            settings.IntervalAutoQuickSave = Properties.Settings.Default.intervalAutoQuickSaveMinutes;
            settings.IntervalProcessCheck = 10;
            settings.IntervalSaveGameCheck = 10 * 1000;
            settings.KillStartedApplicationsOnExit = Properties.Settings.Default.killStartedAppsOnExit;
            settings.DisableApplicationsOnStart = Properties.Settings.Default.disableAddApps;
            settings.DisableAutoQuickSave = Properties.Settings.Default.disableAutoQuicksave;
            settings.DisableSaveHameHistory = Properties.Settings.Default.disableExtraSavegames;
            settings.TimeDifferenceBtwSavegames = Properties.Settings.Default.timeDifferenceSaveGames;
            settings.copyDirs = false;

            modernButtonStop.Enabled = true;
            bgwCheckProcess.RunWorkerAsync(settings);
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("CyberSave77.log", true))
            {
                Log(e.Exception.Message, sw, -1);
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("CyberSave77.log", true))
                Log((e.ExceptionObject as Exception).Message,sw,-1);
        
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
          
        }

        private void checkBoxDisableAutosave_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxAutosave.Enabled = !checkBoxDisableAutosave.Checked;
        }
    }

    public class CyberSave77Settings
    {
        public string ProcessName { get; set; }
        public string SavegamePathDefault { get; set; }
        public string SavegamePathHistory { get; set; }
        public int IntervalProcessCheck { get; set; }
        public int IntervalSaveGameCheck { get; set; }
        public int TimeDifferenceBtwSavegames { get; set; }
        public int IntervalAutoQuickSave { get; set; }
        public int AutoQsRetryInSecs { get; set; }
        public bool DisableApplicationsOnStart { get; set; }
        public bool DisableSaveHameHistory { get; set; }
        public bool DisableAutoQuickSave { get; set; }
        public bool KillStartedApplicationsOnExit { get; set; }
        public bool copyDirs { get; set; } = true;
        public List<ProcessStartInfo> ApplicationsToStartList { get; set; }
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
