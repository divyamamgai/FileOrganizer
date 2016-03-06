using System.Windows.Forms;
using FileOrganizerTask;
using System;
using System.Threading;
using FileOrganizer;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;

namespace FileOrganizerMain {
    public partial class GroupRunner : Form {

        public readonly string vbCrLf = Environment.NewLine;
        public Tuple<GroupDetails, TaskCollection> GroupTuppleObject;
        public TaskCollection TaskCollectionObject;
        public int TasksLoadedCount, TaskCount, TaskIndex, NumberOfFiles, CurrentFile;
        public string FileName, FileExtension, FileNewName;
        public UIOption VerboseOption;
        public Task CurrentTaskObject;
        public TaskDetail GetTaskDetailsDelegate;

        public GroupRunner(ref Tuple<GroupDetails, TaskCollection> groupTuppleObject) {
            InitializeComponent();
            GroupTuppleObject = groupTuppleObject;
            TaskCollectionObject = GroupTuppleObject.Item2;
            TaskCount = TaskCollectionObject.TaskList.Count;
            GetTaskDetailsDelegate = new TaskDetail(GetTaskDetails);
            GroupNameLabel.Text = GroupTuppleObject.Item1.Name;
            Text = "Group Runner : " + GroupTuppleObject.Item1.Name;
            GroupIDLabel.Text = GroupTuppleObject.Item1.ID.ToString();
            VerboseComboBox.SelectedIndex = 1;
            if (TaskCount > 0) {
                TasksLoadedCount = 0;
                foreach (Task TaskObject in TaskCollectionObject.TaskList)
                    ThreadPool.QueueUserWorkItem(new WaitCallback(PopulateTasks), TaskObject);
            }
        }

        public void OnTaskPopulated() {
            StartButton.Enabled = true;
            // Sort By Original Order
            foreach (TaskRunnerButton TaskRunnerButtonObject in TasksFlowPanel.Controls)
                TasksFlowPanel.Controls.SetChildIndex(TaskRunnerButtonObject, TaskCollectionObject.TaskList.IndexOf(TaskRunnerButtonObject.TaskObject));
        }

        public void PopulateTasks(object taskObject) {
            try {
                if (TasksFlowPanel.InvokeRequired) TasksFlowPanel.Invoke((MethodInvoker)delegate { PopulateTasks(taskObject); });
                else {
                    Task TaskObject = (Task)taskObject;
                    TaskRunnerButton TaskButtonObject = new TaskRunnerButton(ref TaskObject);
                    TaskButtonObject.Width = TasksFlowPanel.Width - 30;
                    TaskButtonObject.Height = 70;
                    TaskButtonObject.Padding = new Padding(5, 5, 5, 5);
                    TasksFlowPanel.Controls.Add(TaskButtonObject);
                    if (++TasksLoadedCount == TaskCount) OnTaskPopulated();
                }
            } catch {
                TasksFlowPanel.Invoke((MethodInvoker)delegate { PopulateTasks(taskObject); });
            }
        }

        private void VerboseComboBoxSelectedIndexChanged(object sender, EventArgs e) {
            switch (VerboseComboBox.SelectedIndex) {
                case 0:
                    VerboseOption = UIOption.AllDialogs; // 3
                    break;
                case 1:
                    VerboseOption = UIOption.OnlyErrorDialogs; // 2
                    break;
            }
        }

        private void StartButtonClick(object sender, EventArgs e) {
            TaskIndex = 0;
            GroupStatusValue.Text = "Started";
            MatchedFileGroupBox.Enabled = true;
            StartTaskThread();
        }

        public void StartTaskThread() {
            if (TaskCollectionObject.TaskList[TaskIndex].Enabled) {
                ((TaskRunnerButton)TasksFlowPanel.Controls[TaskIndex]).ChangeRunning(true);
                Thread PerformTaskThread = new Thread(() => TaskCollectionObject.TaskList[TaskIndex].PerformTask(GetTaskDetailsDelegate, VerboseOption));
                PerformTaskThread.IsBackground = true;
                PerformTaskThread.Start();
            } else if (++TaskIndex < TaskCount) StartTaskThread();
            else if (MatchedFileGroupBox.InvokeRequired) MatchedFileGroupBox.Invoke((MethodInvoker)OnGroupComplete);
        }

        public void ShowTaskDetails() {
            try {
                if (NumberOfFiles > 0) {
                    NewFileNameValueLabel.Text = FileNewName;
                    FileNameValueLabel.Text = FileName;
                    FileExtensionValueLabel.Text = FileExtension;
                    MatchedFileGroupBox.Text = "Matched File [" + CurrentFile.ToString() + "/" + NumberOfFiles.ToString() + "]";
                    ((TaskRunnerButton)TasksFlowPanel.Controls[TaskIndex]).ChangePercentageDone((float)CurrentFile / (float)NumberOfFiles);
                } else if (NumberOfFiles == -1) {
                    NewFileNameValueLabel.Text = "Loading...";
                    FileNameValueLabel.Text = "Loading...";
                    FileExtensionValueLabel.Text = "Loading...";
                    MatchedFileGroupBox.Text = "Matched File";
                }
            } catch { }
        }

        public void OnGroupComplete() {
            try {
                MatchedFileGroupBox.Enabled = false;
                GroupStatusValue.Text = "Completed";
                FileNameValueLabel.Text = "File Name";
                FileExtensionValueLabel.Text = "File Extension";
                NewFileNameValueLabel.Text = "New File Name";
                MatchedFileGroupBox.Text = "Matched File";
            } catch { }
        }

        public void GetTaskDetails(int numberOfFiles, int currentFile, string fileName, string fileExtension, string fileNewName) {
            try {
                NumberOfFiles = numberOfFiles;
                if (numberOfFiles > 0) {
                    CurrentFile = currentFile;
                    FileName = fileName;
                    FileExtension = fileExtension;
                    FileNewName = fileNewName;
                    if (MatchedFileGroupBox.InvokeRequired) MatchedFileGroupBox.Invoke((MethodInvoker)ShowTaskDetails);
                    if (currentFile == numberOfFiles) {
                        ((TaskRunnerButton)TasksFlowPanel.Controls[TaskIndex]).ChangeRunning(false);
                        if (++TaskIndex < TaskCount) StartTaskThread();
                        else if (GroupStatusValue.InvokeRequired) GroupStatusValue.Invoke((MethodInvoker)OnGroupComplete);
                    }
                } else if (numberOfFiles == 0) {
                    ((TaskRunnerButton)TasksFlowPanel.Controls[TaskIndex]).ChangeRunning(false);
                    if (++TaskIndex < TaskCount) StartTaskThread();
                    else if (MatchedFileGroupBox.InvokeRequired) MatchedFileGroupBox.Invoke((MethodInvoker)OnGroupComplete);
                } else {
                    if (MatchedFileGroupBox.InvokeRequired) MatchedFileGroupBox.Invoke((MethodInvoker)ShowTaskDetails);
                }
            } catch {
                MatchedFileGroupBox.Invoke((MethodInvoker)ShowTaskDetails);
            }
        }

    }
}
