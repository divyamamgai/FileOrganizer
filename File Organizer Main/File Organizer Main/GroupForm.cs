using System.Windows.Forms;
using FileOrganizerTask;
using System;
using FileOrganizer;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using TaskNameSpace;

namespace FileOrganizerMain {
    public partial class GroupForm : Form {

        public readonly string vbCrLf = Environment.NewLine;
        public bool GroupExisting, GroupSaved;
        public Tuple<GroupDetails, TaskCollection> GroupTuppleObject;
        public int TasksLoadedCount, NumberOfTasks, GroupID;
        public List<TaskButton> TaskButtonList;
        public GroupDetails GroupDetailsObject;
        public TaskCollection TaskColletionObject;
        public GroupButton GroupButtonObject;

        public GroupForm(ref Tuple<GroupDetails, TaskCollection> groupTuppleObject, ref GroupButton groupButtonObject) {
            InitializeComponent();
            GroupExisting = true;
            GroupSaved = false;
            GroupTuppleObject = groupTuppleObject;
            GroupButtonObject = groupButtonObject;
            LoadGroupData();
        }

        public GroupForm() {
            InitializeComponent();
            GroupExisting = false;
            GroupSaved = false;
            TaskColletionObject = new TaskCollection();
            GroupButtonObject = null;

            this.Text = "Create Group";
            CreateSaveGroupButton.Text = "Create Group";
            CancelCloseButton.Text = "Cancel";
            PathChangeEnabled(false);
            GroupID = Options.LastGroupID + 1;
            GroupIDLabel.Text = "ID : " + GroupID.ToString();
            EnabledComboBox.SelectedIndex = 0;
            OccurrenceComboBox.SelectedIndex = 0;
            DayComboBox.SelectedIndex = 0;
            IntervalComboBox.SelectedIndex = 0;
            DeleteGroup.Visible = false;
        }

        public void LoadGroupData() {
            GroupDetailsObject = GroupTuppleObject.Item1;
            DeleteGroup.Visible = true;
            this.Text = "Group : " + GroupDetailsObject.Name;
            NameTextBox.Text = GroupDetailsObject.Name;
            PathTextBox.Text = GroupDetailsObject.Path;
            GroupFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(GroupDetailsObject.Path);
            GroupFileDialog.FileName = System.IO.Path.GetFileName(GroupDetailsObject.Path);
            if (GroupDetailsObject.Enabled) EnabledComboBox.SelectedIndex = 0;
            else EnabledComboBox.SelectedIndex = 1;
            switch (GroupDetailsObject.ScheduleOccurrence) {
                case "weekly":
                    OccurrenceComboBox.SelectedIndex = 0;
                    break;
                case "daily":
                    OccurrenceComboBox.SelectedIndex = 1;
                    break;
                case "interval":
                    OccurrenceComboBox.SelectedIndex = 2;
                    break;
            }
            DayComboBox.SelectedIndex = GroupDetailsObject.ScheduleDay - 1;
            HourTextBox.Text = GroupDetailsObject.ScheduleTime.Hour.ToString();
            MinuteTextBox.Text = GroupDetailsObject.ScheduleTime.Minute.ToString().PadLeft(2, '0');
            IntervalTextBox.Text = GroupDetailsObject.ScheduleInterval.ToString();
            CreateSaveGroupButton.Text = "Save Group";
            CancelCloseButton.Text = "Close";
            IntervalComboBox.SelectedIndex = 0;
            GroupID = GroupDetailsObject.ID;
            GroupIDLabel.Text = "ID : " + GroupID.ToString();
            TasksLoadedCount = 0;
            TaskColletionObject = GroupTuppleObject.Item2;
            NumberOfTasks = TaskColletionObject.TaskList.Count;
            TotalTasksLabel.Text = "Total Tasks : " + NumberOfTasks.ToString();
            foreach (Task TaskObject in TaskColletionObject.TaskList)
                ThreadPool.QueueUserWorkItem(new WaitCallback(PopulateTasks), TaskObject);
        }

        public void PopulateTasks(object taskObject) {
            try {
                if (TasksFlowPanel.InvokeRequired) TasksFlowPanel.Invoke((MethodInvoker)delegate { PopulateTasks(taskObject); });
                else {
                    Task TaskObject = (Task)taskObject;
                    TaskButton TaskButtonObject = new TaskButton(ref TaskObject);
                    TaskButtonObject.Width = TasksFlowPanel.Width - 30;
                    TaskButtonObject.Height = 70;
                    TaskButtonObject.Padding = new Padding(5, 5, 5, 5);
                    TaskButtonObject.MouseClick += new MouseEventHandler(delegate (object sender, MouseEventArgs e) {
                        TaskButton TaskButtonObjectInner = (TaskButton)sender;
                        TaskForm TaskFormObject = new TaskForm(ref TaskButtonObjectInner.TaskObject);
                        TaskFormObject.ShowDialog();
                        if (TaskFormObject.TaskObject != null) {
                            if (TaskFormObject.PerformDeletion) {
                                TaskColletionObject.TaskList.Remove(TaskFormObject.TaskObject);
                                TaskButtonObjectInner.Dispose();
                                TotalTasksLabel.Text = "Total Tasks : " + TaskColletionObject.TaskList.Count;
                                if (TaskColletionObject.TaskList.Count > 0) SortByChangeEnabled(true);
                                else SortByChangeEnabled(false);
                            } else {
                                int TaskIndex = TaskColletionObject.TaskList.FindIndex(tO => tO.ID == TaskFormObject.TaskObject.ID);
                                if (TaskIndex >= 0) {
                                    TaskColletionObject.TaskList[TaskIndex] = TaskFormObject.TaskObject;
                                    TaskButtonObjectInner.Initialize(ref TaskFormObject.TaskObject);
                                    TaskButtonObjectInner.Invalidate();
                                }
                            }
                        }
                    });
                    TasksFlowPanel.Controls.Add(TaskButtonObject);
                    if (++TasksLoadedCount == NumberOfTasks) {
                        TaskButtonList = TasksFlowPanel.Controls.OfType<TaskButton>().Cast<TaskButton>().ToList();
                        SortByChangeEnabled(true);
                        SortByComboBox.SelectedIndex = 0;
                    }
                }
            } catch {
                TasksFlowPanel.Invoke((MethodInvoker)delegate { PopulateTasks(taskObject); });
            }
        }

        public void PopulateTask(object taskObject) {
            Task TaskObject = (Task)taskObject;
            TaskButton TaskButtonObject = new TaskButton(ref TaskObject);
            TaskButtonObject.Width = TasksFlowPanel.Width - 30;
            TaskButtonObject.Height = 70;
            TaskButtonObject.Padding = new Padding(5, 5, 5, 5);
            TaskButtonObject.MouseClick += new MouseEventHandler(delegate (object sender, MouseEventArgs e) {
                TaskForm TaskFormObject = new TaskForm(ref TaskObject);
                TaskFormObject.ShowDialog();
            });
            TasksFlowPanel.Controls.Add(TaskButtonObject);
            if (TaskButtonList == null) TaskButtonList = new List<TaskButton>();
            TaskButtonList.Add(TaskButtonObject);
        }

        public void IntervalChangeEnabled(bool enabled) {
            IntervalLabel.Enabled = enabled;
            IntervalTextBox.Enabled = enabled;
            IntervalComboBox.Enabled = enabled;
            MinutesLabel.Enabled = enabled;
        }

        public void DayChangeEnabled(bool enabled) {
            DayLabel.Enabled = enabled;
            DayComboBox.Enabled = enabled;
        }

        public void TimeChangeEnabled(bool enabled) {
            TimeLabel.Enabled = enabled;
            HourTextBox.Enabled = enabled;
            MinuteTextBox.Enabled = enabled;
            TimeSeparatorLabel.Enabled = enabled;
        }

        public void PathChangeEnabled(bool enabled) {
            PathLabel.Enabled = enabled;
            PathTextBox.Enabled = enabled;
            BrowseButton.Enabled = enabled;
        }

        public void SortByChangeEnabled(bool enabled) {
            SortByComboBox.Enabled = enabled;
            SortByLabel.Enabled = enabled;
        }

        private void OccurrenceComboBoxSelectedIndexChanged(object sender, EventArgs e) {
            switch (OccurrenceComboBox.SelectedIndex) {
                case 0:
                    DayChangeEnabled(true);
                    TimeChangeEnabled(true);
                    IntervalChangeEnabled(false);
                    break;
                case 1:
                    DayChangeEnabled(false);
                    TimeChangeEnabled(true);
                    IntervalChangeEnabled(false);
                    break;
                case 2:
                    DayChangeEnabled(false);
                    TimeChangeEnabled(false);
                    IntervalChangeEnabled(true);
                    break;
                default:
                    break;
            }
        }

        private void DayComboBoxSelectedIndexChanged(object sender, EventArgs e) {
            HourTextBox.Focus();
        }

        private void HourTextBoxTextChanged(object sender, EventArgs e) {
            TextBox TextBoxObject = (TextBox)sender;
            try {
                int Value = Convert.ToInt16(TextBoxObject.Text);
                if (Value > 23) TextBoxObject.Text = "23";
            } catch {

            }
        }

        private void HourTextBoxKeyDown(object sender, KeyEventArgs e) {
            if (!((e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                || (e.KeyCode == Keys.Back) || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || (e.KeyCode == Keys.A && e.Control)))
                e.SuppressKeyPress = true;
        }

        private void MinuteTextBoxTextChanged(object sender, EventArgs e) {
            TextBox TextBoxObject = (TextBox)sender;
            try {
                int Value = Convert.ToInt16(TextBoxObject.Text);
                if (Value > 59) TextBoxObject.Text = "59";
            } catch {

            }
        }

        private void MinuteTextBoxKeyDown(object sender, KeyEventArgs e) {
            if (!((e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                || (e.KeyCode == Keys.Back) || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || (e.KeyCode == Keys.A && e.Control)))
                e.SuppressKeyPress = true;
        }

        private void BrowseButtonClick(object sender, EventArgs e) {
            DialogResult GroupFileDialogResult = GroupFileDialog.ShowDialog();
            if (GroupFileDialogResult == DialogResult.OK) {
                PathTextBox.Text = GroupFileDialog.FileName;
            }
        }

        private void CancelCloseButtonClick(object sender, EventArgs e) {
            Close();
        }

        private void NameTextBoxTextChanged(object sender, EventArgs e) {
            if (NameTextBox.Text.Length > 0) {
                PathChangeEnabled(true);
                CreateSaveGroupButton.Enabled = true;
            } else {
                CreateSaveGroupButton.Enabled = false;
                PathChangeEnabled(false);
            }
        }

        private void NameTextBoxLeave(object sender, EventArgs e) {
            if (NameTextBox.Text.Length > 0) {
                GroupFileDialog.FileName = NameTextBox.Text + ".xml";
                BrowseButton.Focus();
            }
        }

        private void GroupFormFormClosing(object sender, FormClosingEventArgs e) {
            if (!GroupSaved && ValueChanged()) {
                DialogResult CloseWithoutSaving = MessageBox.Show("Do you want to close without saving the changes?", "Close Group Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (CloseWithoutSaving == DialogResult.Yes) e.Cancel = false;
                else e.Cancel = true;
            }
        }

        public void SortTasks(int SortType) {
            switch (SortType) {
                case 0:
                    TaskButtonList.Sort(delegate (TaskButton TaskButtonOne, TaskButton TaskButtonTwo) {
                        try {
                            if (TaskButtonOne == null && TaskButtonTwo == null) return 0;
                            else if (TaskButtonOne == null) return -1;
                            else if (TaskButtonTwo == null) return 1;
                            else return TaskButtonOne.TaskObject.ID.CompareTo(TaskButtonTwo.TaskObject.ID);
                        } catch {
                            return 0;
                        }
                    });
                    break;
                case 1:
                    TaskButtonList.Sort(delegate (TaskButton TaskButtonOne, TaskButton TaskButtonTwo) {
                        try {
                            if (TaskButtonOne == null && TaskButtonTwo == null) return 0;
                            else if (TaskButtonOne == null) return -1;
                            else if (TaskButtonTwo == null) return 1;
                            else return TaskButtonOne.TaskObject.Name.CompareTo(TaskButtonTwo.TaskObject.Name);
                        } catch {
                            return 0;
                        }
                    });
                    break;
                case 2:
                    TaskButtonList.Sort(delegate (TaskButton TaskButtonOne, TaskButton TaskButtonTwo) {
                        try {
                            if (TaskButtonOne == null && TaskButtonTwo == null) return 0;
                            else if (TaskButtonOne == null) return -1;
                            else if (TaskButtonTwo == null) return 1;
                            else return TaskButtonOne.TaskObject.PerformType.CompareTo(TaskButtonTwo.TaskObject.PerformType);
                        } catch {
                            return 0;
                        }
                    });
                    break;
                default:
                    break;
            }
            int i = 0;
            for (; i < TaskButtonList.Count; i++) TasksFlowPanel.Controls.SetChildIndex(TaskButtonList[i], i);
        }

        public void ValidatePath() {
            if (PathTextBox.Text.Length > 0) {
                try {
                    string DirectoryPath = System.IO.Path.GetDirectoryName(PathTextBox.Text),
                        FileName = System.IO.Path.GetFileNameWithoutExtension(PathTextBox.Text),
                        FileExtension = System.IO.Path.GetExtension(PathTextBox.Text);
                    if (System.IO.Directory.Exists(DirectoryPath)) {
                        if (FileName.Length > 0) {
                            if (FileExtension.ToLower() == ".xml") {
                                GroupFileDialog.FileName = PathTextBox.Text;
                            } else {
                                MessageBox.Show("The File Extension you provided for XML is not '.xml'." + vbCrLf + "File Extension Given : " + FileExtension);
                                PathTextBox.Text = "";
                            }
                        } else {
                            MessageBox.Show("The File Name you provided for XML is empty." + vbCrLf + "File Name Given : " + FileName);
                            PathTextBox.Text = "";
                        }
                    } else {
                        MessageBox.Show("The XML Path you provided doesn't exists. Please enter a valid path or use Browse." + vbCrLf + "Path Given : " + PathTextBox.Text);
                        PathTextBox.Text = "";
                    }
                } catch (Exception ex) {
                    MessageBox.Show("The XML Path you provided generated unexpected error." + vbCrLf + "Exception Message : " + ex.Message);
                    PathTextBox.Text = "";
                }
            }
        }

        public bool ValueChanged() {
            if (GroupExisting) {
                if (GroupDetailsObject.Name != NameTextBox.Text) return true;
                if (GroupDetailsObject.Path != PathTextBox.Text) return true;
                if (GroupDetailsObject.Enabled.ToString() != EnabledComboBox.SelectedItem.ToString()) return true;
                if (GroupDetailsObject.ScheduleOccurrence != OccurrenceComboBox.SelectedItem.ToString().ToLower()) return true;
                if (GroupDetailsObject.ScheduleDay != (DayComboBox.SelectedIndex + 1)) return true;
                if (GroupDetailsObject.ScheduleTime.Hour != Convert.ToInt16(HourTextBox.Text) || GroupDetailsObject.ScheduleTime.Minute != Convert.ToInt16(MinuteTextBox.Text)) return true;
                if (GroupDetailsObject.ScheduleInterval.ToString() != IntervalTextBox.Text) return true;
                return false;
            }
            return false;
        }

        private void PathTextBoxLeave(object sender, EventArgs e) {
            ValidatePath();
        }

        private void PathTextBoxKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.OemQuestion || e.KeyCode == Keys.Multiply
                || e.KeyCode == Keys.D8 && e.Shift || e.KeyCode == Keys.OemQuestion && e.Shift || e.KeyCode == Keys.OemQuotes && e.Shift
                || e.KeyCode == Keys.Oemcomma && e.Shift || e.KeyCode == Keys.OemPeriod && e.Shift) e.SuppressKeyPress = true;
        }

        private void AddTaskButton_Click(object sender, EventArgs e) {
            TaskForm TaskFormObject = new TaskForm();
            TaskFormObject.ShowDialog();
            if (TaskFormObject.TaskObject != null) {
                TaskColletionObject.TaskList.Add(TaskFormObject.TaskObject);
                PopulateTask(TaskFormObject.TaskObject);
                TotalTasksLabel.Text = "Total Tasks : " + TaskColletionObject.TaskList.Count;
                if (TaskColletionObject.TaskList.Count > 0) SortByChangeEnabled(true);
                Options.LastTaskID++;
            }
        }

        private void DeleteGroup_Click(object sender, EventArgs e) {
            DialogResult ConfirmDelete = MessageBox.Show("Do you really want to delete " + GroupDetailsObject.Name + " group?" + vbCrLf + "Note : This is not reversible!", "Delete Group Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ConfirmDelete == DialogResult.Yes) {
                Program.GroupCollectionObject.GroupWithoutTimerList.Remove(GroupTuppleObject);
                Program.GroupCollectionObject.PerformSaveWithoutTimer(Program.GroupCollectionPath);
                GroupButtonObject.Dispose();
                Close();
            }
        }



        private void CreateSaveGroupButtonClick(object sender, EventArgs e) {
            if (ValidateData()) {
                bool PerformSave = true;
                if (System.IO.File.Exists(PathTextBox.Text)) {
                    DialogResult OverWriteFile = MessageBox.Show("It seems like the XML Path you provided already exists. Do you want to overwite the existing file? " + vbCrLf + "Path : " + PathTextBox.Text, "XML Already Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (OverWriteFile == DialogResult.No) PerformSave = false;
                }
                if (PerformSave) {
                    try {
                        if (GroupExisting) {
                            int IndexOfGroupObject = Program.GroupCollectionObject.GroupWithoutTimerList.IndexOf(GroupTuppleObject);
                            GroupDetailsObject.Name = NameTextBox.Text;
                            GroupDetailsObject.Path = PathTextBox.Text;
                            GroupDetailsObject.Enabled = EnabledComboBox.SelectedIndex == 0;
                            GroupDetailsObject.ScheduleOccurrence = OccurrenceComboBox.SelectedItem.ToString().ToLower();
                            GroupDetailsObject.ScheduleDay = DayComboBox.SelectedIndex + 1;
                            GroupDetailsObject.ScheduleInterval = Convert.ToInt16(IntervalTextBox.Text);
                            GroupDetailsObject.ScheduleTime = DateTime.Parse(HourTextBox.Text + ":" + MinuteTextBox.Text);
                            GroupTuppleObject = new Tuple<GroupDetails, TaskCollection>(GroupDetailsObject, TaskColletionObject);
                            Program.GroupCollectionObject.GroupWithoutTimerList[IndexOfGroupObject] = GroupTuppleObject;
                            TaskColletionObject.SaveGroup(PathTextBox.Text);
                            Program.GroupCollectionObject.PerformSaveWithoutTimer(Program.GroupCollectionPath);
                            GroupButtonObject.Initialize(ref GroupDetailsObject);
                            GroupButtonObject.Invalidate();
                        } else {
                            GroupDetailsObject = new GroupDetails(GroupID, NameTextBox.Text, PathTextBox.Text, OccurrenceComboBox.SelectedItem.ToString().ToLower(),
                            DayComboBox.SelectedIndex + 1, Convert.ToInt16(IntervalTextBox.Text), DateTime.Parse(HourTextBox.Text + ":" + MinuteTextBox.Text),
                            EnabledComboBox.SelectedIndex == 0);
                            GroupTuppleObject = new Tuple<GroupDetails, TaskCollection>(GroupDetailsObject, TaskColletionObject);
                            Program.GroupCollectionObject.GroupWithoutTimerList.Add(new Tuple<GroupDetails, TaskCollection>(GroupDetailsObject, TaskColletionObject));
                            TaskColletionObject.SaveGroup(PathTextBox.Text);
                            Program.GroupCollectionObject.PerformSaveWithoutTimer(Program.GroupCollectionPath);
                            Options.LastGroupID++;
                            Options.SaveOptions();
                            Program.MainFormObject.AddGroup(GroupTuppleObject);
                        }
                        GroupSaved = true;
                        Program.MainFormObject.SortGroups(Program.MainFormObject.SortByValue);
                        Close();
                    } catch (Exception ex) {
                        MessageBox.Show("An unexpected error occurred while trying to save the group." + vbCrLf + "Exception Message : " + ex.Message, "Error On Group Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else MessageBox.Show("Group " + (GroupExisting ? "Saving" : "Creation") + " was canceled by the user.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else MessageBox.Show("It seems like you did not provided valid data. Please verify that all the fields are filled.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SortByComboBoxSelectedIndexChanged(object sender, EventArgs e) {
            ComboBox SortByComboBoxObject = (ComboBox)sender;
            SortTasks(SortByComboBoxObject.SelectedIndex);
        }

        public bool ValidateData() {
            if (NameTextBox.Text.Length == 0) return false;
            if (PathTextBox.Text.Length == 0) return false;
            switch (OccurrenceComboBox.SelectedIndex) {
                case 0:
                case 1:
                    if (IntervalTextBox.Text.Length == 0) IntervalTextBox.Text = "5";
                    if (HourTextBox.Text.Length == 0) return false;
                    if (MinuteTextBox.Text.Length == 0) return false;
                    break;
                case 2:
                    if (HourTextBox.Text.Length == 0) HourTextBox.Text = "0";
                    if (MinuteTextBox.Text.Length == 0) MinuteTextBox.Text = "0";
                    if (IntervalTextBox.Text.Length == 0) return false;
                    break;
                default:
                    break;
            }
            return true;
        }

    }
}
