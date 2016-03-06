using System;
using System.Windows.Forms;
using FileOrganizerTask;
using FileOrganizerFileTypes;
using FileOrganizerMain;
using System.Drawing;
using System.Collections.Generic;
using System.Xml;
using System.ServiceProcess;

namespace FileOrganizer {
    public class PathFormatter {
        public static string FormatPath(string pathString, int MaxPathSize = 100) {
            string PathString = pathString;
            if (PathString.Length > MaxPathSize) {
                string FileName = System.IO.Path.GetFileName(pathString);
                PathString = pathString;
                PathString = System.IO.Path.GetDirectoryName(PathString);
                PathString = PathString.Substring(0, MaxPathSize - FileName.Length);
                PathString = PathString.Substring(0, PathString.LastIndexOf('\\') + 1);
                PathString += "...\\" + FileName;
            }
            return PathString;
        }
    }
    public class GroupButton : Control {
        public static bool EnableSelection = false;
        public static string[] DaysList = { "Empty", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        public static SolidBrush HoverColor = new SolidBrush(Color.FromArgb(255, 25, 118, 210)),
            NormalColor = new SolidBrush(Color.FromArgb(255, 21, 101, 192)),
            DisabledHoverColor = new SolidBrush(Color.FromArgb(255, 69, 90, 100)),
            DisabledNormalColor = new SolidBrush(Color.FromArgb(255, 55, 71, 79)),
            SelectedHoverColor = new SolidBrush(Color.FromArgb(255, 48, 63, 159)),
            SelectedNormalColor = new SolidBrush(Color.FromArgb(255, 40, 53, 147)),
            DisabledSelectedHoverColor = new SolidBrush(Color.FromArgb(255, 48, 63, 159)),
            DisabledSelectedNormalColor = new SolidBrush(Color.FromArgb(255, 40, 53, 147)),
            PrimaryFontColor = new SolidBrush(Color.FromArgb(235, 255, 255, 255)),
            SecondaryFontColor = new SolidBrush(Color.FromArgb(235, 245, 245, 245));
        public static Pen BorderNormalColor = new Pen(new SolidBrush(Color.FromArgb(255, 13, 71, 161))),
            BorderHoverColor = new Pen(new SolidBrush(Color.FromArgb(255, 21, 101, 192))),
            DisabledBorderNormalColor = new Pen(new SolidBrush(Color.FromArgb(255, 38, 50, 56))),
            DisabledBorderHoverColor = new Pen(new SolidBrush(Color.FromArgb(255, 55, 71, 79)));
        public static Font PrimaryFont = new Font("Segoe UI", 16);
        public Rectangle BackgroundRectangle, BorderRectangle;
        public int IDPositionX, PathPositionY, ServiceInfoPositionY;
        public string IDString, PathString, ServiceInfoString;
        public bool Selected, Hover, Initialized;
        public GroupDetails GroupDetailsObject;

        public GroupButton(ref GroupDetails groupDetailsObject) {
            Initialize(ref groupDetailsObject);
        }

        public void Initialize(ref GroupDetails groupDetailsObject) {
            GroupDetailsObject = groupDetailsObject;
            IDString = "ID : " + GroupDetailsObject.ID.ToString();
            PathString = "Path : " + PathFormatter.FormatPath(GroupDetailsObject.Path);
            ServiceInfoString = "";
            switch (GroupDetailsObject.ScheduleOccurrence) {
                case "weekly":
                    ServiceInfoString += "Occurrence : Weekly   Day : " + DaysList[GroupDetailsObject.ScheduleDay] + "   Time : " + GroupDetailsObject.ScheduleTime.ToShortTimeString();
                    break;
                case "daily":
                    ServiceInfoString += "Occurrence : Daily   Time : " + GroupDetailsObject.ScheduleTime.ToShortTimeString();
                    break;
                case "interval":
                    ServiceInfoString += "Occurrence : Interval   Interval : " + GroupDetailsObject.ScheduleInterval + " min";
                    break;
            }
            Selected = false;
            Hover = false;
            Initialized = false;
        }

        protected override Size DefaultSize {
            get {
                Width = 717;
                Height = 70;
                return base.DefaultSize;
            }
        }

        protected override void OnMouseEnter(EventArgs e) {
            if (!Hover) {
                Hover = true;
                Invalidate();
            }
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e) {
            if (Hover) {
                Hover = false;
                Invalidate();
            }
            base.OnMouseHover(e);
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            if (EnableSelection) {
                Selected = Selected ? false : true;
                Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (!Initialized) {
                BackgroundRectangle = new Rectangle(0, 0, Width, Height);
                BorderRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
                IDPositionX = ClientSize.Width - Convert.ToInt16(e.Graphics.MeasureString(IDString, Font).Width) - Padding.Right;
                PathPositionY = ClientSize.Height - FontHeight - Padding.Bottom;
                ServiceInfoPositionY = ClientSize.Height - FontHeight * 2 - Padding.Bottom;
                Initialized = true;
            }
            e.Graphics.FillRectangle(Selected ? (Hover ? (GroupDetailsObject.Enabled ? SelectedHoverColor : DisabledSelectedHoverColor) : (GroupDetailsObject.Enabled ? SelectedNormalColor : DisabledSelectedNormalColor)) : (Hover ? (GroupDetailsObject.Enabled ? HoverColor : DisabledHoverColor) : (GroupDetailsObject.Enabled ? NormalColor : DisabledNormalColor)), BackgroundRectangle);
            e.Graphics.DrawRectangle(Hover ? (GroupDetailsObject.Enabled ? BorderHoverColor : DisabledBorderHoverColor) : (GroupDetailsObject.Enabled ? BorderNormalColor : DisabledBorderNormalColor), BorderRectangle);
            e.Graphics.DrawString(GroupDetailsObject.Name, PrimaryFont, PrimaryFontColor, 3, 3);
            e.Graphics.DrawString(PathString, Font, SecondaryFontColor, 3, PathPositionY);
            e.Graphics.DrawString(ServiceInfoString, Font, SecondaryFontColor, 3, ServiceInfoPositionY);
            e.Graphics.DrawString(IDString, Font, SecondaryFontColor, IDPositionX, 3);
            base.OnPaint(e);
        }
    }

    public class TaskButton : Control {
        public static bool EnableSelection = false;
        public static SolidBrush HoverColor = new SolidBrush(Color.FromArgb(255, 56, 142, 60)),
            NormalColor = new SolidBrush(Color.FromArgb(255, 46, 125, 50)),
            DisabledHoverColor = new SolidBrush(Color.FromArgb(255, 69, 90, 100)),
            DisabledNormalColor = new SolidBrush(Color.FromArgb(255, 55, 71, 79)),
            SelectedHoverColor = new SolidBrush(Color.FromArgb(255, 85, 139, 47)),
            SelectedNormalColor = new SolidBrush(Color.FromArgb(255, 51, 105, 30)),
            DisabledSelectedHoverColor = new SolidBrush(Color.FromArgb(255, 48, 63, 159)),
            DisabledSelectedNormalColor = new SolidBrush(Color.FromArgb(255, 40, 53, 147)),
            PrimaryFontColor = new SolidBrush(Color.FromArgb(235, 255, 255, 255)),
            SecondaryFontColor = new SolidBrush(Color.FromArgb(235, 245, 245, 245));
        public static Pen BorderNormalColor = new Pen(new SolidBrush(Color.FromArgb(255, 27, 94, 32))),
            BorderHoverColor = new Pen(new SolidBrush(Color.FromArgb(255, 46, 125, 50))),
            DisabledBorderNormalColor = new Pen(new SolidBrush(Color.FromArgb(255, 27, 94, 32))),
            DisabledBorderHoverColor = new Pen(new SolidBrush(Color.FromArgb(255, 46, 125, 50)));
        public static Font PrimaryFont = new Font("Segoe UI", 16);
        public Rectangle BackgroundRectangle, BorderRectangle;
        public int IDPositionX, PerformPositionX, PerformPositionY, SourcePositionY, DestinationPositionY;
        public string IDString, SourceString, DestinationString, PerformString;
        public bool Selected, Hover, Initialized;
        public Task TaskObject;

        public TaskButton(ref Task taskObject) {
            Initialize(ref taskObject);
        }

        public void Initialize(ref Task taskObject) {
            TaskObject = taskObject;
            IDString = "ID : " + TaskObject.ID.ToString();
            PerformString = "Perform : " + TaskObject.PerformType;
            SourceString = "Source : " + PathFormatter.FormatPath(TaskObject.Source.FullName);
            DestinationString = "Destination : " + PathFormatter.FormatPath(TaskObject.Destination.FullName);
            Selected = false;
            Hover = false;
            Initialized = false;
        }

        protected override Size DefaultSize {
            get {
                Width = 717;
                Height = 70;
                return base.DefaultSize;
            }
        }

        protected override void OnMouseEnter(EventArgs e) {
            if (!Hover) {
                Hover = true;
                Invalidate();
            }
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e) {
            if (Hover) {
                Hover = false;
                Invalidate();
            }
            base.OnMouseHover(e);
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            if (EnableSelection) {
                Selected = Selected ? false : true;
                Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (!Initialized) {
                BackgroundRectangle = new Rectangle(0, 0, Width, Height);
                BorderRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
                IDPositionX = ClientSize.Width - Convert.ToInt16(e.Graphics.MeasureString(IDString, Font).Width) - Padding.Right;
                PerformPositionX = ClientSize.Width - Convert.ToInt16(e.Graphics.MeasureString(PerformString, Font).Width) - Padding.Right;
                PerformPositionY = FontHeight + 3;
                DestinationPositionY = ClientSize.Height - FontHeight - Padding.Bottom;
                SourcePositionY = ClientSize.Height - FontHeight * 2 - Padding.Bottom;
                Initialized = true;
            }
            e.Graphics.FillRectangle(Selected ? (Hover ? (TaskObject.Enabled ? SelectedHoverColor : DisabledSelectedHoverColor) : (TaskObject.Enabled ? SelectedNormalColor : DisabledSelectedNormalColor)) : (Hover ? (TaskObject.Enabled ? HoverColor : DisabledHoverColor) : (TaskObject.Enabled ? NormalColor : DisabledNormalColor)), BackgroundRectangle);
            e.Graphics.DrawRectangle(Hover ? (TaskObject.Enabled ? BorderHoverColor : DisabledBorderHoverColor) : (TaskObject.Enabled ? BorderNormalColor : DisabledBorderNormalColor), BorderRectangle);
            e.Graphics.DrawString(TaskObject.Name, PrimaryFont, PrimaryFontColor, 3, 3);
            e.Graphics.DrawString(IDString, Font, SecondaryFontColor, IDPositionX, 3);
            e.Graphics.DrawString(PerformString, Font, SecondaryFontColor, PerformPositionX, PerformPositionY);
            e.Graphics.DrawString(SourceString, Font, SecondaryFontColor, 3, SourcePositionY);
            e.Graphics.DrawString(DestinationString, Font, SecondaryFontColor, 3, DestinationPositionY);
            base.OnPaint(e);
        }
    }

    public class TaskRunnerButton : Control {

        public static SolidBrush ProgressColor = new SolidBrush(Color.FromArgb(255, 67, 160, 71)),
            CompletedColor = new SolidBrush(Color.FromArgb(255, 85, 139, 47)),
            RunningColor = new SolidBrush(Color.FromArgb(255, 46, 125, 50)),
            NormalColor = new SolidBrush(Color.FromArgb(255, 27, 94, 32)),
            DisabledNormalColor = new SolidBrush(Color.FromArgb(255, 55, 71, 79)),
            PrimaryFontColor = new SolidBrush(Color.FromArgb(235, 255, 255, 255)),
            SecondaryFontColor = new SolidBrush(Color.FromArgb(235, 245, 245, 245));
        public static Pen BorderNormalColor = new Pen(new SolidBrush(Color.FromArgb(255, 27, 94, 32))),
            DisabledBorderNormalColor = new Pen(new SolidBrush(Color.FromArgb(255, 27, 94, 32)));
        public static Font PrimaryFont = new Font("Segoe UI", 16);
        public Rectangle BackgroundRectangle, BorderRectangle;
        public RectangleF ProgressRectangle;
        public int IDPositionX, PerformPositionX, PerformPositionY, SourcePositionY, DestinationPositionY;
        public string IDString, SourceString, DestinationString, PerformString;
        public bool Initialized, Running;
        public Task TaskObject;
        float PercentageDone = 0;

        public TaskRunnerButton(ref Task taskObject) {
            Initialize(ref taskObject);
        }

        public void Initialize(ref Task taskObject) {
            TaskObject = taskObject;
            IDString = "ID : " + TaskObject.ID.ToString();
            PerformString = "Perform : " + TaskObject.PerformType;
            SourceString = "Source : " + PathFormatter.FormatPath(TaskObject.Source.FullName, 64);
            DestinationString = "Destination : " + PathFormatter.FormatPath(TaskObject.Destination.FullName, 64);
            Initialized = false;
            Running = false;
        }

        public void ChangePercentageDone(float percentageDone) {
            PercentageDone = percentageDone;
            ProgressRectangle.Width = PercentageDone * Width;
            Invalidate();
        }

        public void ChangeRunning(bool running) {
            Running = running;
            Invalidate();
        }

        protected override Size DefaultSize {
            get {
                Width = 717;
                Height = 70;
                return base.DefaultSize;
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (!Initialized) {
                BackgroundRectangle = new Rectangle(0, 0, Width, Height);
                ProgressRectangle = new RectangleF(0, 0, PercentageDone, Height);
                BorderRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
                IDPositionX = ClientSize.Width - Convert.ToInt16(e.Graphics.MeasureString(IDString, Font).Width) - Padding.Right;
                PerformPositionX = ClientSize.Width - Convert.ToInt16(e.Graphics.MeasureString(PerformString, Font).Width) - Padding.Right;
                PerformPositionY = FontHeight + 3;
                DestinationPositionY = ClientSize.Height - FontHeight - Padding.Bottom;
                SourcePositionY = ClientSize.Height - FontHeight * 2 - Padding.Bottom;
                Initialized = true;
            }
            e.Graphics.FillRectangle(TaskObject.Enabled ? (Running ? RunningColor : NormalColor) : DisabledNormalColor, BackgroundRectangle);
            if (TaskObject.Enabled) e.Graphics.FillRectangle(PercentageDone >= 1 ? CompletedColor : ProgressColor, ProgressRectangle);
            e.Graphics.DrawRectangle(TaskObject.Enabled ? BorderNormalColor : DisabledBorderNormalColor, BorderRectangle);
            e.Graphics.DrawString(TaskObject.Name, PrimaryFont, PrimaryFontColor, 3, 3);
            e.Graphics.DrawString(IDString, Font, SecondaryFontColor, IDPositionX, 3);
            e.Graphics.DrawString(PerformString, Font, SecondaryFontColor, PerformPositionX, PerformPositionY);
            e.Graphics.DrawString(SourceString, Font, SecondaryFontColor, 3, SourcePositionY);
            e.Graphics.DrawString(DestinationString, Font, SecondaryFontColor, 3, DestinationPositionY);
            base.OnPaint(e);
        }
    }

    //public class TimeTextBox : TextBox {
    //    public int Hours, Minutes;
    //    public TimeTextBox() {
    //        Hours = 0;
    //        Minutes = 0;
    //        Text = " 00 : 00"; // 1 2 & 6 7
    //    }
    //    public void SetSelectionStart() {
    //        if (SelectionStart == 0) {
    //            SelectionStart = 1;
    //        } else if (SelectionStart == 3) {
    //            if (Text.ToCharArray()[2] == ' ') SelectionStart = 2;
    //        } else if (SelectionStart == 4) {
    //            SelectionStart = 6;
    //        } else if (SelectionStart == 5) {
    //            SelectionStart = 2;
    //        } else if (SelectionStart == 8) {
    //            if (Text.ToCharArray()[7] == ' ') SelectionStart = 7;
    //            else SelectionStart = 8;
    //        } else if (SelectionStart > 8) SelectionStart = 8;
    //    }
    //    public void SetText(char keyCode, int selectionStartOffset = 1) {
    //        char[] text = Text.ToCharArray();
    //        int i = SelectionStart;
    //        text[i] = keyCode;
    //        Text = new string(text);
    //        SelectionStart = i + selectionStartOffset;
    //        SetSelectionStart();
    //    }
    //    protected override void OnKeyDown(KeyEventArgs e) {
    //        if ((e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)) {
    //            int h = Hours, m = Minutes, d = (int)((char)e.KeyCode - '0');
    //            if (SelectionStart == 1) h = d * 10 + h % 10;
    //            else if (SelectionStart == 2) h = (h - h % 10) + d;
    //            if (h < 24) Hours = h;
    //            Text = " " + Hours.ToString().PadLeft(2, '0') + " : " + Minutes.ToString().PadLeft(2, '0');
    //            SelectionStart++;
    //        } else if (e.KeyCode == Keys.OemSemicolon) {
    //            if (SelectionStart == 3)
    //                SelectionStart = 6;
    //        } else if (e.KeyCode == Keys.Left) {
    //            SelectionStart--;
    //            SetSelectionStart();
    //        } else if (e.KeyCode == Keys.Right) {
    //            SelectionStart++;
    //            SetSelectionStart();
    //        } else if (e.KeyCode == Keys.Back) {
    //            if (SelectionStart == 2 || SelectionStart == 3 || SelectionStart == 7 || SelectionStart == 8) {
    //                SelectionStart--;
    //                SetText(' ', 0);
    //            }
    //        } else if (e.KeyCode == Keys.Delete) {
    //            if (SelectionStart == 1 || SelectionStart == 2 || SelectionStart == 6 || SelectionStart == 7) {
    //                SetText(' ', 0);
    //            }
    //        }
    //        e.SuppressKeyPress = true;
    //        base.OnKeyDown(e);
    //    }
    //    protected override void OnGotFocus(EventArgs e) {
    //        SelectionStart = 0;
    //        SetSelectionStart();
    //        base.OnGotFocus(e);
    //    }
    //    protected override void OnMouseDown(MouseEventArgs e) {
    //        SetSelectionStart();
    //        base.OnMouseDown(e);
    //    }
    //    protected override void OnClick(EventArgs e) {
    //        SetSelectionStart();
    //        base.OnClick(e);
    //    }
    //}

    public class Options {
        public static int LastGroupID, LastTaskID;
        public static string OptionsPath;
        public Options(string path) {
            try {
                OptionsPath = path;
                XmlDocument XMLDoc = new XmlDocument();
                XMLDoc.Load(path);
                if (XMLDoc.DocumentElement != null) {
                    LastGroupID = Convert.ToInt16(XMLDoc.DocumentElement.SelectSingleNode("lastGroupID").InnerText);
                    LastTaskID = Convert.ToInt16(XMLDoc.DocumentElement.SelectSingleNode("lastTaskID").InnerText);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        static public void SaveOptions() {
            try {
                XmlDocument XMLDoc = new XmlDocument();
                XmlElement XMLRoot = XMLDoc.CreateElement("options"),
                    LastGroupIDElement = XMLDoc.CreateElement("lastGroupID"),
                    LastTaskIDElement = XMLDoc.CreateElement("lastTaskID");
                LastGroupIDElement.InnerText = LastGroupID.ToString();
                LastTaskIDElement.InnerText = LastTaskID.ToString();
                XMLRoot.AppendChild(LastGroupIDElement);
                XMLRoot.AppendChild(LastTaskIDElement);
                XMLDoc.AppendChild(XMLRoot);
                XMLDoc.PreserveWhitespace = true;
                XMLDoc.Save(OptionsPath);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static class Program {
        public static GroupCollection GroupCollectionObject;
        public static Options OptionsObject;
        public static FileTypes FileTypesObject;
        public static FileAttributes FileAttributesObject;
        public static string GroupCollectionPath;
        public static Main MainFormObject;
        public static ServiceController FileOrganizerServiceControllerObject;
        public static bool FileOrganizerServiceControllerInstalled;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            GroupCollectionPath = Application.StartupPath + @"\FileOrganiserGroups.xml";
            GroupCollectionObject = new GroupCollection(GroupCollectionPath);
            OptionsObject = new Options(Application.StartupPath + @"\FileOrganiserOptions.xml");
            FileTypesObject = new FileTypes(Application.StartupPath + @"\FileTypes.txt");
            FileAttributesObject = new FileAttributes(Application.StartupPath + @"\FileAttributes.txt");
            FileOrganizerServiceControllerInstalled = (new List<ServiceController>(ServiceController.GetServices())).FindIndex(sO => sO.ServiceName == "File Organizer Service") != -1;
            if (FileOrganizerServiceControllerInstalled) FileOrganizerServiceControllerObject = new ServiceController("File Organizer Service");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainFormObject = new Main();
            Application.Run(MainFormObject);
        }
    }

}
