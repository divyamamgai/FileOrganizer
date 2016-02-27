using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FileOrganizerFileTypes;
using MatchCaseNameSpace;
using FileOrganizer;
using FileOrganizerTask;
using System.Linq;
using System.Text;

namespace TaskNameSpace {
    public partial class TaskForm : Form {

        public readonly string vbCrLf = Environment.NewLine;
        public FileTypes FileFileExtensions;
        public FileType SelectedFileType;
        public FileOrganizerFileTypes.FileAttributes FileAtt;
        public List<CheckBox> FileExtChecks = new List<CheckBox>();
        public List<Tuple<CheckBox, TextBox>> FileAttChecks = new List<Tuple<CheckBox, TextBox>>();
        public List<string> s = new List<string>();
        public List<string> LoadedExtensionsList;
        public Task TaskObject;
        public bool TaskIsLoaded = false, PerformDeletion = false;

        public class ComboItem {
            public string Name;
            public int Value;
            public ComboItem(string name, int value) {
                Name = name;
                Value = value;
            }
            public override string ToString() {
                return Name;
            }
        }

        public TaskForm() {
            InitializeComponent();
            this.Text = "Create Task";
            TaskIDLabel.Text = "ID : " + Options.LastTaskID;
            PerformTypeComboBox.SelectedIndex = 0;
            CreateTaskbtn.Text = "Create Task";
            DeleteTaskButton.Visible = false;
        }

        public TaskForm(ref Task taskObject) {
            InitializeComponent();
            TaskObject = taskObject;
            TaskIsLoaded = true;
            this.Text = "Task : " + TaskObject.Name;
            TaskName.Text = TaskObject.Name;
            SourceFolder.Text = TaskObject.Source.FullName;
            DestinationFolder.Text = TaskObject.Destination.FullName;
            TaskIDLabel.Text = "ID : " + TaskObject.ID.ToString();
            PerformTypeComboBox.SelectedItem = TaskObject.PerformType.ToString();
            RegexTextBox.Text = TaskObject.NameRegex.ToString();
            FileNameTB.Text = TaskObject.Format;
            CreateTaskbtn.Text = "Save Task";
            DeleteTaskButton.Visible = true;
            LoadedExtensionsList = new List<string>(TaskObject.ExtensionRegex.ToString().Replace(")", "").Replace("(", "").Split('|'));
            FileTypeCB.SelectedIndex = TaskObject.FileTypeIndex;
        }

        private void BrowseButton_Click(object sender, EventArgs e) {
            DialogResult result = DestinationFolderDialog.ShowDialog();
            try {
                if (result == DialogResult.OK) {
                    DestinationFolder.Text = DestinationFolderDialog.SelectedPath;
                }
            } catch (IOException) {
                MessageBox.Show("Destination Folder Error!");
            }
        }

        private void BrowseButton2_Click(object sender, EventArgs e) {
            DialogResult result = SourceFolderDialog.ShowDialog();
            try {
                if (result == DialogResult.OK) {
                    SourceFolder.Text = SourceFolderDialog.SelectedPath;
                }
            } catch (IOException) {
                MessageBox.Show("Source Folder Error!");
            }
        }

        private void MatchCaseButton_Click(object sender, EventArgs e) {
            MatchCase CallMatchCase = new MatchCase(SelectedFileType);
            CallMatchCase.ShowDialog();
            CallMatchCase.Close();
            if (CallMatchCase.RegexFinal != null && CallMatchCase.EnteredUserNameFormat != null &&
                CallMatchCase.RegexFinal.Length > 0 && CallMatchCase.EnteredUserNameFormat.Length > 0) {
                if (RegexTextBox.Text.Length > 0 && FileNameTB.Text.Length > 0) {
                    DialogResult ReplaceMatch = MessageBox.Show("Do you really want to replace the existing File Name Regex and File Name Format expressions?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (ReplaceMatch == DialogResult.Yes) {
                        RegexTextBox.Text = CallMatchCase.RegexFinal;
                        FileNameTB.Text = CallMatchCase.EnteredUserNameFormat;
                    }
                } else {
                    RegexTextBox.Text = CallMatchCase.RegexFinal;
                    FileNameTB.Text = CallMatchCase.EnteredUserNameFormat;
                }
            }
        }

        public void DisplayFileExtensions(int l) {
            FileExtensionDisplayFLP.Controls.Clear();
            int Index = 0;
            s = FileTypes.TypesList[l];
            FileExtensionDisplayFLP.AutoScroll = true;
            foreach (string data in s) {
                CheckBox a = new CheckBox();
                a.Text = s[Index];
                if (!TaskIsLoaded) a.Checked = true;
                else a.Checked = LoadedExtensionsList.IndexOf(a.Text) != -1;
                FileExtChecks.Add(a);
                FileExtensionDisplayFLP.Controls.Add(a);
                Index++;
            }
        }

        public void DisplayFileAttributes(int l) {
            FileAttributeFLP.Controls.Clear();
            int Index = 0;
            s = FileOrganizerFileTypes.FileAttributes.AttributesList[l];
            FileAttributeFLP.AutoScroll = true;
            FileAttChecks = new List<Tuple<CheckBox, TextBox>>();
            foreach (string data in s) {
                CheckBox sample = new CheckBox();
                TextBox sample2 = new TextBox();
                sample.Text = data;
                if (!TaskIsLoaded) {
                    sample.Checked = false;
                    sample2.Enabled = false;
                } else {
                    bool IsChecked = TaskObject.AttributeMatchList != null && TaskObject.AttributeMatchList.FindIndex(aM => aM.TagName == data) != -1;
                    sample.Checked = IsChecked;
                    sample2.Enabled = IsChecked;
                }
                sample2.Size = new Size(630, 30);
                sample2.Tag = data;
                Tuple<CheckBox, TextBox> c = new Tuple<CheckBox, TextBox>(sample, sample2);
                FileAttChecks.Add(c);
                FileAttributeFLP.Controls.Add(sample);
                FileAttributeFLP.Controls.Add(sample2);
                sample.Click += new EventHandler(FileAttribute_Click);
                Index++;
            }
        }

        private void Item2_TextChanged(object sender, EventArgs e) {
            string s = (sender as TextBox).Text;
        }

        private void FileAttribute_Click(object Sender, EventArgs e) {
            CheckBox a = (CheckBox)Sender;
            foreach (Tuple<CheckBox, TextBox> t in FileAttChecks) {
                if (t.Item1 == a) {
                    if (t.Item1.Checked == true) {
                        t.Item1.Checked = true;
                        t.Item2.Enabled = true;
                        t.Item2.TextChanged += new EventHandler(Item2_TextChanged);
                    } else {
                        t.Item1.Checked = false;
                        t.Item2.Enabled = false;
                    }
                    return;
                }
            }
        }

        private void FileTypeCB_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedFileType = (FileType)FileTypeCB.SelectedIndex;
            DisplayFileExtensions(FileTypeCB.SelectedIndex);
            DisplayFileAttributes(FileTypeCB.SelectedIndex);
        }
        public static bool FormExit() {
            //try {
            //    var Result = MessageBox.Show("Are you sure you want to stop creating TaskForm?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (Result == DialogResult.Yes) {
            //        return true;
            //    }
            //} catch {
            //    MessageBox.Show("Error exit mishandled");
            //}
            //return false;
            return true;
        }

        private void CancelTaskbtn_Click(object sender, EventArgs e) {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            if (FormExit() == false) {
                e.Cancel = true;
            }
        }

        private void SelectAllButton_Click(object sender, EventArgs e) {
            if (FileTypeCB.SelectedIndex > 0) {
                foreach (CheckBox a in FileExtChecks) {
                    a.Checked = true;
                }
            }
        }

        private void SelectNoneButton_Click(object sender, EventArgs e) {
            if (FileTypeCB.SelectedIndex > 0) {
                foreach (CheckBox a in FileExtChecks) {
                    a.Checked = false;
                }
            }
        }

        private void CreateTaskbtn_Click(object sender, EventArgs e) {
            if (TaskName.Text == "") {
                MessageBox.Show("TaskForm Name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (SourceFolder.Text == "") {
                MessageBox.Show("Source Folder cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (DestinationFolder.Text == "") {
                MessageBox.Show("Destination Folder cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (RegexTextBox.Text == "") {
                MessageBox.Show("File Name Regex cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (FileNameTB.Text == "") {
                MessageBox.Show("File Name Format cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                List<CheckBox> TypeCheckBoxList = (FileExtensionDisplayFLP.Controls.OfType<CheckBox>()).Where(cO => cO.Checked == true).ToList();
                int TypeCheckBoxListCount = TypeCheckBoxList.Count();
                if (TypeCheckBoxListCount > 0) {
                    StringBuilder AttributeMatchBuilder = new StringBuilder(), ExtensionBuilder = new StringBuilder();
                    ExtensionBuilder.Append("(");
                    int i = 0, LastIndex = TypeCheckBoxListCount - 1;
                    for (; i < TypeCheckBoxListCount; i++)
                        if (i != LastIndex) ExtensionBuilder.Append(TypeCheckBoxList[i].Text + "|");
                        else ExtensionBuilder.Append(TypeCheckBoxList[i].Text + ")");
                    IEnumerable<TextBox> TextBoxList = FileAttributeFLP.Controls.OfType<TextBox>().Where(tO => tO.Enabled == true);
                    foreach (TextBox TextBoxObject in TextBoxList) AttributeMatchBuilder.Append(TextBoxObject.Tag + "?" + TextBoxObject.Text + "|");
                    TaskObject = new Task(TaskIsLoaded ? TaskObject.ID : Options.LastTaskID, TaskName.Text, SourceFolder.Text, DestinationFolder.Text, ExtensionBuilder.ToString(), RegexTextBox.Text,
                        AttributeMatchBuilder.ToString(), FileNameTB.Text, PerformTypeComboBox.SelectedItem.ToString().ToLower(), FileTypeCB.SelectedIndex);
                    Close();
                } else {
                    MessageBox.Show("File Types cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SourceFolder_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.OemQuestion || e.KeyCode == Keys.Multiply
                || e.KeyCode == Keys.D8 && e.Shift || e.KeyCode == Keys.OemQuestion && e.Shift || e.KeyCode == Keys.OemQuotes && e.Shift
                || e.KeyCode == Keys.Oemcomma && e.Shift || e.KeyCode == Keys.OemPeriod && e.Shift) e.SuppressKeyPress = true;
        }

        private void SourceFolder_Leave(object sender, EventArgs e) {
            if (SourceFolder.Text.Length > 0) {
                try {
                    string DirectoryPath = Path.GetDirectoryName(SourceFolder.Text);
                    if (Directory.Exists(SourceFolder.Text) && Directory.Exists(DirectoryPath)) {
                        SourceFolderDialog.SelectedPath = SourceFolder.Text;
                    } else {
                        MessageBox.Show("The Path you provided doesn't exists. Please enter a valid path or use Browse." + vbCrLf + "Path Given : " + SourceFolder.Text);
                        SourceFolder.Text = "";
                    }
                } catch (Exception ex) {
                    MessageBox.Show("The Path you provided generated unexpected error." + vbCrLf + "Exception Message : " + ex.Message);
                    SourceFolder.Text = "";
                }
            }
        }

        private void DestinationFolder_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.OemQuestion || e.KeyCode == Keys.Multiply
                    || e.KeyCode == Keys.D8 && e.Shift || e.KeyCode == Keys.OemQuestion && e.Shift || e.KeyCode == Keys.OemQuotes && e.Shift
                    || e.KeyCode == Keys.Oemcomma && e.Shift || e.KeyCode == Keys.OemPeriod && e.Shift) e.SuppressKeyPress = true;
        }

        private void DestinationFolder_Leave(object sender, EventArgs e) {
            if (DestinationFolder.Text.Length > 0) {
                try {
                    string DirectoryPath = Path.GetDirectoryName(SourceFolder.Text);
                    if (Directory.Exists(DestinationFolder.Text) && Directory.Exists(DirectoryPath)) {
                        DestinationFolderDialog.SelectedPath = DestinationFolder.Text;
                    } else {
                        MessageBox.Show("The Path you provided doesn't exists. Please enter a valid path or use Browse." + vbCrLf + "Path Given : " + DestinationFolder.Text);
                        DestinationFolder.Text = "";
                    }
                } catch (Exception ex) {
                    MessageBox.Show("The Path you provided generated unexpected error." + vbCrLf + "Exception Message : " + ex.Message);
                    DestinationFolder.Text = "";
                }
            }
        }

        private void SelectAllButtonAtt_Click(object sender, EventArgs e) {
            if (FileTypeCB.SelectedIndex > 0) {
                foreach (Tuple<CheckBox, TextBox> a in FileAttChecks) {
                    a.Item1.Checked = true;
                    a.Item2.Enabled = true;
                }
            }
        }

        private void SelectNoneButtonAtt_Click(object sender, EventArgs e) {
            if (FileTypeCB.SelectedIndex > 0) {
                foreach (Tuple<CheckBox, TextBox> a in FileAttChecks) {
                    a.Item1.Checked = false;
                    a.Item2.Enabled = false;
                }
            }
        }

        private void DeleteTaskButton_Click(object sender, EventArgs e) {
            DialogResult ConfirmDelete = MessageBox.Show("Do you really want to delete " + TaskObject.Name + " task?" + vbCrLf + "Note : This is not reversible*, if you will choose not to save the group it won't be deleted, but you will need to restart the application.", "Delete Task Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ConfirmDelete == DialogResult.Yes) {
                PerformDeletion = true;
                Close();
            }
        }
    }
}