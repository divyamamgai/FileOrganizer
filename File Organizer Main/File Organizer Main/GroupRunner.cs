using System.Windows.Forms;
using FileOrganizerTask;
using System;
using System.Threading;

namespace FileOrganizerMain {
    public partial class GroupRunner : Form {
        public readonly string vbCrLf = Environment.NewLine;
        public Tuple<GroupDetails, TaskCollection> GroupTuppleObject;
        public TaskCollection TaskCollectionObject;
        public int NumberOfFiles, DoneFiles, OperationValue, TaskIndex, TaskCount;
        public string FileName, FileExtension, FileNewName;
        TaskDetail GetTaskDetailsDelegate;
        public Task CurrentTaskObject;
        public void ShowTaskDelegate() {
            try {
                TaskNameValueLabel.Text = CurrentTaskObject.Name;
                SourceValueLabel.Text = CurrentTaskObject.Source.FullName;
                DestinationValueLabel.Text = CurrentTaskObject.Destination.FullName;
                ExtensionRegexValueLabel.Text = CurrentTaskObject.ExtensionRegex.ToString();
                NameRegexValueLabel.Text = CurrentTaskObject.NameRegex.ToString();
                FormatValueLabel.Text = CurrentTaskObject.Format;
                PerformValueLabel.Text = CurrentTaskObject.PerformType.ToString();
                TaskDetailsGroupBox.Text = "Task Details [" + (TaskIndex + 1).ToString() + "/" + TaskCount.ToString() + "]";
            } catch { }
        }
        public void ShowTask(Task task) {
            try {
                CurrentTaskObject = task;
                if (TaskDetailsGroupBox.InvokeRequired) TaskDetailsGroupBox.Invoke(new MethodInvoker(ShowTaskDelegate));
            } catch {
                TaskDetailsGroupBox.Invoke(new MethodInvoker(ShowTaskDelegate));
            }
        }
        public void ShowTaskDetails() {
            try {
                NewFileNameValueLabel.Text = FileNewName;
                FileNameValueLabel.Text = FileName;
                FileExtensionValueLabel.Text = FileExtension;
                MatchedFileGroupBox.Text = "Matched File [" + DoneFiles.ToString() + "/" + NumberOfFiles.ToString() + "]";
            } catch { }
        }
        public void SetStatus() {
            GroupStatusValue.Text = "Completed";
        }
        public void GetTaskDetails(int numberOfFiles, int doneFiles, string fileName, string fileExtension, string fileNewName) {
            try {
                if (numberOfFiles > 0) {
                    NumberOfFiles = numberOfFiles;
                    DoneFiles = doneFiles;
                    FileName = fileName;
                    FileExtension = fileExtension;
                    FileNewName = fileNewName;
                    if (MatchedFileGroupBox.InvokeRequired)
                        MatchedFileGroupBox.Invoke(new MethodInvoker(ShowTaskDetails));
                    if (doneFiles == numberOfFiles) {
                        if (++TaskIndex < TaskCount) {
                            ShowTask(TaskCollectionObject.TaskList[TaskIndex]);
                            Thread PerformTaskThread = new Thread(() => TaskCollectionObject.TaskList[TaskIndex].PerformTask(GetTaskDetailsDelegate));
                            PerformTaskThread.IsBackground = true;
                            PerformTaskThread.Start();
                        } else {
                            if (GroupStatusValue.InvokeRequired) GroupStatusValue.Invoke(new MethodInvoker(SetStatus));
                        }
                    }
                } else {
                    if (++TaskIndex < TaskCount) {
                        ShowTask(TaskCollectionObject.TaskList[TaskIndex]);
                        Thread PerformTaskThread = new Thread(() => TaskCollectionObject.TaskList[TaskIndex].PerformTask(GetTaskDetailsDelegate));
                        PerformTaskThread.IsBackground = true;
                        PerformTaskThread.Start();
                    } else {
                        if (GroupStatusValue.InvokeRequired) GroupStatusValue.Invoke(new MethodInvoker(SetStatus));
                    }
                }
            } catch {
                MatchedFileGroupBox.Invoke(new MethodInvoker(ShowTaskDetails));
            }
        }
        public GroupRunner(ref Tuple<GroupDetails, TaskCollection> groupTuppleObject) {
            InitializeComponent();
            GroupTuppleObject = groupTuppleObject;
            TaskCollectionObject = GroupTuppleObject.Item2;
            TaskCount = TaskCollectionObject.TaskList.Count;
            TaskIndex = 0;
            GetTaskDetailsDelegate = new TaskDetail(GetTaskDetails);
            GroupNameLabel.Text = GroupTuppleObject.Item1.Name;
            GroupIDLabel.Text = GroupTuppleObject.Item1.ID.ToString();
            if (TaskCount > 0) {
                ShowTask(TaskCollectionObject.TaskList[TaskIndex]);
                Thread PerformTaskThread = new Thread(() => TaskCollectionObject.TaskList[TaskIndex].PerformTask(GetTaskDetailsDelegate));
                PerformTaskThread.IsBackground = true;
                PerformTaskThread.Start();
            }
        }
    }
}
