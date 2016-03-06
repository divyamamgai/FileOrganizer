using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.IO;
using FileOrganizerTask;

namespace FileOrganizerService {
    class WindowsService : ServiceBase {
        public string LogPath = AppDomain.CurrentDomain.BaseDirectory + @"\FileOrganizerServiceLog.txt";
        public GroupCollection GroupCollectionObject;
        public bool Initialized;
        /// <summary>
        /// Public Constructor for WindowsService.
        /// - Put all of your Initialization code here.
        /// </summary>
        public WindowsService() {
            ServiceName = "File Organizer Service";
            EventLog.Log = "Application";

            // These Flags set whether or not to handle that specific
            //  type of event. Set to true if you need it, false otherwise.
            CanHandlePowerEvent = true;
            CanHandleSessionChangeEvent = true;
            CanPauseAndContinue = true;
            CanShutdown = true;
            CanStop = true;
        }

        /// <summary>
        /// The Main Thread: This is where your Service is Run.
        /// </summary>
        static void Main() {
            Run(new WindowsService());
        }

        /// <summary>
        /// Dispose of objects that need it here.
        /// </summary>
        /// <param name="disposing">Whether
        ///    or not disposing is going on.</param>
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }

        /// <summary>
        /// OnStart(): Put startup code here
        ///  - Start threads, get inital data, etc.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args) {
            Log("Started", true);
            try {
                if (!Initialized) {
                    GroupCollectionObject = new GroupCollection(AppDomain.CurrentDomain.BaseDirectory + @"\FileOrganiserGroups.xml", new TaskDetail(GetTaskDetails));
                    Log("Loaded Groups - " + GroupCollectionObject.GroupListWithTimer.Count.ToString(), true);
                    GroupCollectionObject.ScheduleGroups();
                    Initialized = true;
                }
            } catch (Exception ex) {
                Log("Failed To Load GroupCollectionObject [" + ex.Message + "]", true);
            }
            base.OnStart(args);
        }

        /// <summary>
        /// OnStop(): Put your stop code here
        /// - Stop threads, set final data, etc.
        /// </summary>
        protected override void OnStop() {
            Log("Stopped", true);
            base.OnStop();
        }

        /// <summary>
        /// OnPause: Put your pause code here
        /// - Pause working threads, etc.
        /// </summary>
        protected override void OnPause() {
            Log("Paused", true);
            base.OnPause();
        }

        /// <summary>
        /// OnContinue(): Put your continue code here
        /// - Un-pause working threads, etc.
        /// </summary>
        protected override void OnContinue() {
            Log("Continued", true);
            base.OnContinue();
        }

        /// <summary>
        /// OnShutdown(): Called when the System is shutting down
        /// - Put code here when you need special handling
        ///   of code that deals with a system shutdown, such
        ///   as saving special data before shutdown.
        /// </summary>
        protected override void OnShutdown() {
            Log("Shutdown", true);
            base.OnShutdown();
        }

        /// <summary>
        /// OnCustomCommand(): If you need to send a command to your
        ///   service without the need for Remoting or Sockets, use
        ///   this method to do custom methods.
        /// </summary>
        /// <param name="command">Arbitrary Integer between 128 & 256</param>
        protected override void OnCustomCommand(int command) {
            //  A custom command can be sent to a service by using this method:
            //#  int command = 128; //Some Arbitrary number between 128 & 256
            //#  ServiceController sc = new ServiceController("NameOfService");
            //#  sc.ExecuteCommand(command);
            Log("Running Command #" + command.ToString(), true);
            base.OnCustomCommand(command);
        }

        /// <summary>
        /// OnPowerEvent(): Useful for detecting power status changes,
        ///   such as going into Suspend mode or Low Battery for laptops.
        /// </summary>
        /// <param name="powerStatus">The Power Broadcast Status
        /// (BatteryLow, Suspend, etc.)</param>
        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus) {
            Log("Power Status Changed", true);
            return base.OnPowerEvent(powerStatus);
        }

        /// <summary>
        /// OnSessionChange(): To handle a change event
        ///   from a Terminal Server session.
        ///   Useful if you need to determine
        ///   when a user logs in remotely or logs off,
        ///   or when someone logs into the console.
        /// </summary>
        /// <param name="changeDescription">The Session Change
        /// Event that occured.</param>
        protected override void OnSessionChange(
                  SessionChangeDescription changeDescription) {
            Log("Session Changed", true);
            base.OnSessionChange(changeDescription);
        }

        public void GetTaskDetails(int numberOfFiles, int currentFile, string fileName, string fileExtension, string fileNewName) {
            if (numberOfFiles == -1) Log("Loading Task...", true);
            else Log("Done : " + currentFile.ToString() + "/" + numberOfFiles.ToString(), true);
        }

        /// <summary>
        /// Log(): To log messages to the defined file path in the AppSettings.
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="PrintTime"></param>
        private void Log(string Message, bool PrintTime) {
            try {
                StreamWriter LogFile = new StreamWriter(LogPath, true);
                LogFile.WriteLine(PrintTime ? DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt :: ") + Message : Message);
                LogFile.Close();
            } catch {
                // Can't Do Anything
            }
        }
    }
}