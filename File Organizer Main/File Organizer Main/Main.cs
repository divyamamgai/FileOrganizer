using System.Windows.Forms;
using FileOrganizer;
using FileOrganizerTask;
using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Diagnostics;

namespace FileOrganizerMain {
    public partial class Main : Form {

        public readonly string vbCrLf = Environment.NewLine;
        public int GroupsLoadedCount, NumberOfGroups, SortByValue;
        public List<GroupButton> GroupButtonList;

        public Main() {
            GroupsLoadedCount = 0;
            NumberOfGroups = Program.GroupCollectionObject.GroupWithoutTimerList.Count;
            InitializeComponent();
            ServiceInstalledUpdateControls();
            foreach (Tuple<GroupDetails, TaskCollection> GroupTupleObject in Program.GroupCollectionObject.GroupWithoutTimerList)
                ThreadPool.QueueUserWorkItem(new WaitCallback(PopulateGroups), GroupTupleObject);
        }

        public void ServiceInstalledUpdateControls() {
            if (Program.FileOrganizerServiceControllerInstalled) {
                if (Program.FileOrganizerServiceControllerObject.Status == ServiceControllerStatus.Running) {
                    StartStopServiceButtion.Text = "Stop Service";
                    InstallOrUninstallServiceButton.Enabled = false;
                } else {
                    InstallOrUninstallServiceButton.Enabled = true;
                    InstallOrUninstallServiceButton.Text = "Uninstall Service";
                    StartStopServiceButtion.Text = "Start Service";
                }
            } else {
                InstallOrUninstallServiceButton.Enabled = true;
                InstallOrUninstallServiceButton.Text = "Install Service";
                StartStopServiceButtion.Enabled = false;
            }
        }

        public void SortByChangeEnabled(bool enabled) {
            SortByComboBox.Enabled = enabled;
            SortByLabel.Enabled = enabled;
        }

        public void PopulateGroups(object groupTupleObject) {
            try {
                if (GroupsFlowPanel.InvokeRequired) GroupsFlowPanel.Invoke((MethodInvoker)delegate { PopulateGroups(groupTupleObject); });
                else {
                    Tuple<GroupDetails, TaskCollection> GroupTupleObject = (Tuple<GroupDetails, TaskCollection>)groupTupleObject;
                    GroupDetails GroupDetailsObject = GroupTupleObject.Item1;
                    GroupButton GroupButtonObject = new GroupButton(ref GroupDetailsObject);
                    GroupButtonObject.Width = GroupsFlowPanel.Width - 30;
                    GroupButtonObject.Height = 70;
                    GroupButtonObject.Padding = new Padding(5, 5, 5, 5);
                    GroupButtonObject.MouseClick += new MouseEventHandler(delegate (object sender, MouseEventArgs e) {
                        if (e.Button == MouseButtons.Left) {
                            GroupForm GroupFormObject = new GroupForm(ref GroupTupleObject, ref GroupButtonObject);
                            GroupFormObject.ShowDialog();
                        } else if (e.Button == MouseButtons.Right && GroupTupleObject.Item1.Enabled && GroupTupleObject.Item2.TaskList.Count > 0) {
                            GroupRunner GroupRunnerFormObject = new GroupRunner(ref GroupTupleObject);
                            GroupRunnerFormObject.ShowDialog();
                        }
                    });
                    GroupsFlowPanel.Controls.Add(GroupButtonObject);
                    if (++GroupsLoadedCount == NumberOfGroups) {
                        GroupButtonList = GroupsFlowPanel.Controls.OfType<GroupButton>().Cast<GroupButton>().ToList();
                        SortByChangeEnabled(true);
                        SortByComboBox.SelectedIndex = 0;
                    }
                }
            } catch {
                GroupsFlowPanel.Invoke((MethodInvoker)delegate { PopulateGroups(groupTupleObject); });
            }
        }

        public void AddGroup(Tuple<GroupDetails, TaskCollection> groupTuppleObject) {
            GroupDetails GroupDetailsObject = groupTuppleObject.Item1;
            GroupButton GroupButtonObject = new GroupButton(ref GroupDetailsObject);
            GroupButtonObject.Width = GroupsFlowPanel.Width - 30;
            GroupButtonObject.Height = 70;
            GroupButtonObject.Padding = new Padding(5, 5, 5, 5);
            GroupButtonObject.MouseClick += new MouseEventHandler(delegate (object sender, MouseEventArgs e) {
                if (e.Button == MouseButtons.Left) {
                    GroupForm GroupFormObject = new GroupForm(ref groupTuppleObject, ref GroupButtonObject);
                    GroupFormObject.ShowDialog();
                } else if (e.Button == MouseButtons.Right && groupTuppleObject.Item1.Enabled && groupTuppleObject.Item2.TaskList.Count > 0) {
                    GroupRunner GroupRunnerFormObject = new GroupRunner(ref groupTuppleObject);
                    GroupRunnerFormObject.ShowDialog();
                }
            });
            GroupsFlowPanel.Controls.Add(GroupButtonObject);
            GroupButtonList.Add(GroupButtonObject);
        }

        public void SortGroups(int SortType) {
            switch (SortType) {
                case 0:
                    GroupButtonList.Sort(delegate (GroupButton GroupButtonOne, GroupButton GroupButtonTwo) {
                        try {
                            if (GroupButtonOne == null && GroupButtonTwo == null) return 0;
                            else if (GroupButtonOne == null) return -1;
                            else if (GroupButtonTwo == null) return 1;
                            else return GroupButtonOne.GroupDetailsObject.ID.CompareTo(GroupButtonTwo.GroupDetailsObject.ID);
                        } catch {
                            return 0;
                        }
                    });
                    break;
                case 1:
                    GroupButtonList.Sort(delegate (GroupButton GroupButtonOne, GroupButton GroupButtonTwo) {
                        try {
                            if (GroupButtonOne == null && GroupButtonTwo == null) return 0;
                            else if (GroupButtonOne == null) return -1;
                            else if (GroupButtonTwo == null) return 1;
                            else return GroupButtonOne.GroupDetailsObject.Name.CompareTo(GroupButtonTwo.GroupDetailsObject.Name);
                        } catch {
                            return 0;
                        }
                    });
                    break;
                case 2:
                    GroupButtonList.Sort(delegate (GroupButton GroupButtonOne, GroupButton GroupButtonTwo) {
                        try {
                            if (GroupButtonOne == null && GroupButtonTwo == null) return 0;
                            else if (GroupButtonOne == null) return -1;
                            else if (GroupButtonTwo == null) return 1;
                            else return GroupButtonOne.GroupDetailsObject.ScheduleTime.CompareTo(GroupButtonTwo.GroupDetailsObject.ScheduleTime);
                        } catch {
                            return 0;
                        }
                    });
                    break;
                case 3:
                    GroupButtonList.Sort(delegate (GroupButton GroupButtonOne, GroupButton GroupButtonTwo) {
                        try {
                            if (GroupButtonOne == null && GroupButtonTwo == null) return 0;
                            else if (GroupButtonOne == null) return -1;
                            else if (GroupButtonTwo == null) return 1;
                            else return GroupButtonOne.GroupDetailsObject.ScheduleDay.CompareTo(GroupButtonTwo.GroupDetailsObject.ScheduleDay);
                        } catch {
                            return 0;
                        }
                    });
                    break;
                case 4:
                    GroupButtonList.Sort(delegate (GroupButton GroupButtonOne, GroupButton GroupButtonTwo) {
                        try {
                            if (GroupButtonOne == null && GroupButtonTwo == null) return 0;
                            else if (GroupButtonOne == null) return -1;
                            else if (GroupButtonTwo == null) return 1;
                            else return GroupButtonOne.GroupDetailsObject.ScheduleInterval.CompareTo(GroupButtonTwo.GroupDetailsObject.ScheduleInterval);
                        } catch {
                            return 0;
                        }
                    });
                    break;
                default:
                    break;
            }
            int i = 0;
            for (; i < GroupButtonList.Count; i++) GroupsFlowPanel.Controls.SetChildIndex(GroupButtonList[i], i);
        }

        public void ChangeStartStopServiceButtonText(string text, bool enabled) {
            try {
                if (StartStopServiceButtion.InvokeRequired) StartStopServiceButtion.Invoke((MethodInvoker)delegate { ChangeStartStopServiceButtonText(text, enabled); });
                StartStopServiceButtion.Text = text;
                StartStopServiceButtion.Enabled = enabled;
            } catch {
                StartStopServiceButtion.Invoke((MethodInvoker)delegate { ChangeStartStopServiceButtonText(text, enabled); });
            }
        }

        public void StartStopService() {
            try {
                if (Program.FileOrganizerServiceControllerObject.Status == ServiceControllerStatus.Running) {
                    Program.FileOrganizerServiceControllerObject.Stop();
                    Program.FileOrganizerServiceControllerObject.WaitForStatus(ServiceControllerStatus.Stopped);
                    ChangeStartStopServiceButtonText("Start Service", true);
                    InstallOrUninstallServiceButton.Enabled = false;
                } else {
                    Program.FileOrganizerServiceControllerObject.Start();
                    Program.FileOrganizerServiceControllerObject.WaitForStatus(ServiceControllerStatus.Running);
                    ChangeStartStopServiceButtonText("Stop Service", true);
                    InstallOrUninstallServiceButton.Enabled = false;
                }
            } catch (Exception ex) {
                MessageBox.Show("An unexpected error occurred while changing service status." + vbCrLf + "Exception Message : " + ex.Message);
            }
        }

        private void StartStopServiceButtionClick(object sender, EventArgs e) {
            StartStopServiceButtion.Enabled = false;
            Thread StartStopServiceThread = new Thread(StartStopService);
            StartStopServiceThread.Start();
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e) {
            Options.SaveOptions();
        }

        private void AboutButtonClick(object sender, EventArgs e) {
            (new AboutUs.AboutUs()).ShowDialog();
        }

        private void InstallOrUninstallServiceButtonClick(object sender, EventArgs e) {
            if (Program.FileOrganizerServiceControllerInstalled) {
                if (Environment.Is64BitOperatingSystem) {
                    try {
                        Process.Start("UninstallService64.exe");
                    } catch {
                        MessageBox.Show("Cannot Uninstall the service, please try using the UninstallService64.exe file in the program directory.", "Failed Uninstallation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    try {
                        Process.Start("UninstallService.exe");
                    } catch {
                        MessageBox.Show("Cannot Uninstall the service, please try using the UninstallService.exe file in the program directory.", "Failed Uninstallation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                if (Environment.Is64BitOperatingSystem) {
                    try {
                        Process.Start("InstallService64.exe");
                    } catch {
                        MessageBox.Show("Cannot Install the service, please try using the InstallService64.exe file in the program directory.", "Failed Installation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    try {
                        Process.Start("InstallService.exe");
                    } catch {
                        MessageBox.Show("Cannot Install the service, please try using the InstallService.exe file in the program directory.", "Failed Installation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SortByComboBoxSelectedIndexChanged(object sender, EventArgs e) {
            ComboBox SortByComboBoxObject = (ComboBox)sender;
            SortByValue = SortByComboBoxObject.SelectedIndex;
            SortGroups(SortByValue);
        }

        private void CreateGroupButtonClick(object sender, EventArgs e) {
            (new GroupForm()).ShowDialog();
        }
    }
}
