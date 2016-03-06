using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Linq;
using System.Text;
using FileTagExtract;

namespace FileOrganizerTask {

    public delegate void TaskDetail(int NumberOfFiles, int CurrentFile, string FileName, string FileExtension, string FileNewName);
    public enum PerformTaskType { Copy, Move, Rename, Delete }

    public class Log {

        public static string LogPath = AppDomain.CurrentDomain.BaseDirectory + @"\FileOrganizerTasksLog.txt";
        public static bool PrintTime = true;

        /// <summary>
        /// Write(string): To log messages to the defined file path in the LogPath static string member of Log Class.
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="PrintTime"></param>
        /// 
        public static void Write(string Message) {
            try {
                StreamWriter LogFile = new StreamWriter(LogPath, true);
                LogFile.WriteLine(PrintTime ? DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt :: ") + Message : Message);
                LogFile.Close();
            } catch { }
        }

    }

    public class Task {

        public int ID, FileTypeIndex;
        public string Name, Format, LogPath = @"C:\FileOrganizerTask.txt";
        public bool Enabled;
        public DirectoryInfo Source, Destination;
        public Regex ExtensionRegex, NameRegex;
        public PerformTaskType PerformType;
        public List<FileTag> AttributeMatchList;
        static public FileTag DefaultFileTagObject = new FileTag("", "");
        private Regex FormatGroupsRegex = new Regex(@"\?([0-9]*)\?"),
                      FormatAttributesRegex = new Regex(@"\|([^\|]*)\|");

        public Task(int id, string name, string source, string destination, string extensionRegex, string nameRegex,
            string attributeMatch, string format, string perform, int fileType, bool enabled) {
            Initialize(id, name, source, destination, extensionRegex, nameRegex, attributeMatch, format, perform, fileType, enabled);
        }

        public void Initialize(int id, string name, string source, string destination, string extensionRegex, string nameRegex,
            string attributeMatch, string format, string perform, int fileType, bool enabled) {
            try {
                ID = id;
                Name = name;
                Source = new DirectoryInfo(source);
                Destination = new DirectoryInfo(destination);
                ExtensionRegex = new Regex(extensionRegex);
                NameRegex = new Regex(nameRegex);
                Format = format;
                perform = perform.ToLower();
                FileTypeIndex = fileType;
                Enabled = enabled;
                switch (perform) {
                    case "copy":
                        PerformType = PerformTaskType.Copy;
                        break;
                    case "move":
                        PerformType = PerformTaskType.Move;
                        break;
                    case "rename":
                        PerformType = PerformTaskType.Rename;
                        break;
                    case "delete":
                        PerformType = PerformTaskType.Delete;
                        break;
                    default:
                        PerformType = PerformTaskType.Copy;
                        break;
                }
                if (attributeMatch.Length > 0) {
                    AttributeMatchList = new List<FileTag>();
                    List<string> AttributeGroups = new List<string>(attributeMatch.Split('|'));
                    string[] AttributeField;
                    foreach (string AttributeGroup in AttributeGroups) {
                        if (AttributeGroup.Length > 0) {
                            AttributeField = AttributeGroup.Split('?');
                            if (AttributeField.Length == 2) AttributeMatchList.Add(new FileTag(AttributeField[0], AttributeField[1]));
                        }
                    }
                }
            } catch (Exception ex) {
                Log.Write("Task::Initialize() Error -> " + ex.Message);
            }
        }

        public string GetFormattedName(string fileName, IEnumerable<FileTag> fileTagList) {
            string FileNewName = Format;
            fileTagList.DefaultIfEmpty(DefaultFileTagObject);
            try {
                System.Text.RegularExpressions.GroupCollection NameRegexMatchGroups = NameRegex.Match(fileName).Groups;
                Match FormatGroupsRegexMatch = FormatGroupsRegex.Match(FileNewName), FormatAttributesRegexMatch;
                while (FormatGroupsRegexMatch.Success) {
                    FileNewName = FileNewName.Replace(FormatGroupsRegexMatch.ToString(),
                        NameRegexMatchGroups[Convert.ToInt32(FormatGroupsRegexMatch.Groups[1].Value)].ToString());
                    FormatGroupsRegexMatch = FormatGroupsRegexMatch.NextMatch();
                }
                FormatAttributesRegexMatch = FormatAttributesRegex.Match(FileNewName);
                FileTag FileTagObject;
                while (FormatAttributesRegexMatch.Success) {
                    FileTagObject = fileTagList.FirstOrDefault(fO => fO.TagName == FormatAttributesRegexMatch.Groups[1].Value);
                    FileNewName = FileNewName.Replace(FormatAttributesRegexMatch.ToString(), FileTagObject.TagValue);
                    FormatAttributesRegexMatch = FormatAttributesRegexMatch.NextMatch();
                }
            } catch (Exception ex) {
                Log.Write("Task::GetFormattedName() Error -> " + ex.Message);
                FileNewName = fileName;
            }
            return FileNewName;
        }

        public void PerformTask(TaskDetail taskDetail, UIOption Verbose = UIOption.OnlyErrorDialogs) {
            try {

                int TotalCount = 0, CurrentCount = 0;
                string FileName, FileExtension, FileNewName;
                taskDetail(-1, 0, "", "", ""); // Loading...
                List<FileInfo> FileInfoList = new List<FileInfo>(Source.GetFiles());
                FileInfoList = FileInfoList.FindAll(delegate (FileInfo fileInfoObject) {
                    return ExtensionRegex.IsMatch(fileInfoObject.Extension.ToLower())
                            && NameRegex.IsMatch(Path.GetFileNameWithoutExtension(fileInfoObject.Name));
                });
                TotalCount = FileInfoList.Count;
                List<Tuple<FileInfo, IEnumerable<FileTag>>> FileList = new List<Tuple<FileInfo, IEnumerable<FileTag>>>();
                if (AttributeMatchList != null) {
                    IEnumerable<FileTag> FileTagInfoList, FileTagInfoListIntersected;
                    foreach (FileInfo FileInfoObject in FileInfoList) {
                        FileTagInfoList = GenerateFileInfo.GetFileTag(FileInfoObject.FullName);
                        FileTagInfoListIntersected = FileTagInfoList;
                        FileTagInfoListIntersected = FileTagInfoListIntersected.Intersect(AttributeMatchList);
                        if (FileTagInfoListIntersected.Count() > 0) FileList.Add(new Tuple<FileInfo, IEnumerable<FileTag>>(FileInfoObject, FileTagInfoList));
                    }
                } else {
                    foreach (FileInfo FileInfoObject in FileInfoList)
                        FileList.Add(new Tuple<FileInfo, IEnumerable<FileTag>>(FileInfoObject, GenerateFileInfo.GetFileTag(FileInfoObject.FullName)));
                }
                TotalCount = FileList.Count;
                CurrentCount = 0;
                taskDetail(TotalCount, 0, "", "", ""); // Loading Done...
                foreach (Tuple<FileInfo, IEnumerable<FileTag>> FileListObject in FileList) {
                    FileName = Path.GetFileNameWithoutExtension(FileListObject.Item1.Name);
                    FileExtension = Path.GetExtension(FileListObject.Item1.Name);
                    FileNewName = GetFormattedName(FileName, FileListObject.Item2);
                    taskDetail(TotalCount, CurrentCount, FileName, FileExtension, FileNewName);
                    switch (PerformType) {
                        case PerformTaskType.Copy:
                            FileSystem.CopyFile(FileListObject.Item1.FullName, Destination + "/" + FileNewName + FileExtension, Verbose);
                            break;
                        case PerformTaskType.Move:
                            FileSystem.MoveFile(FileListObject.Item1.FullName, Destination + "/" + FileNewName + FileExtension, Verbose);
                            break;
                        case PerformTaskType.Rename:
                            FileSystem.RenameFile(FileListObject.Item1.FullName, FileNewName + FileExtension);
                            break;
                        case PerformTaskType.Delete:
                            FileSystem.DeleteFile(FileListObject.Item1.FullName, Verbose, RecycleOption.SendToRecycleBin);
                            break;
                        default:
                            Log.Write("PerformTask() Warning -> Invalid PerformType Given In " + Name);
                            break;
                    }
                    taskDetail(TotalCount, ++CurrentCount, FileName, FileExtension, FileNewName);
                }
            } catch (Exception ex) {
                Log.Write("Task::PerformTask() Error -> Task - " + Name + " [" + ex.Message + "]");
            }
        }

    }

    public class TaskCollection {

        public int ID;
        public string Name, Path;
        public List<Task> TaskList;

        public TaskCollection() {
            TaskList = new List<Task>();
        }

        public TaskCollection(string path, int id) {
            if (File.Exists(path)) {
                Path = path;
                ID = id;
                TaskList = new List<Task>();
                Initialize(path);
            } else Log.Write("TaskCollection::TaskCollection() Error -> Path Given Doesn't Exists. [" + path + "]");
        }

        public void Initialize(string path, bool force = false) {
            try {
                if (force) TaskList = new List<Task>();
                XmlDocument XMLDoc = new XmlDocument();
                XMLDoc.Load(path);
                Name = System.IO.Path.GetFileNameWithoutExtension(path);
                foreach (XmlNode TaskElement in XMLDoc.DocumentElement.SelectNodes("task")) {
                    XmlNode ID = TaskElement.SelectSingleNode("id"),
                        Name = TaskElement.SelectSingleNode("name"),
                        Source = TaskElement.SelectSingleNode("source"),
                        Destination = TaskElement.SelectSingleNode("destination"),
                        ExtensionRegex = TaskElement.SelectSingleNode("extensionRegex"),
                        NameRegex = TaskElement.SelectSingleNode("nameRegex"),
                        AttributeMatch = TaskElement.SelectSingleNode("attributeMatch"),
                        NameFormat = TaskElement.SelectSingleNode("format"),
                        Perform = TaskElement.SelectSingleNode("perform"),
                        FileTypeIndex = TaskElement.SelectSingleNode("fileType"),
                        Enabled = TaskElement.SelectSingleNode("enabled");
                    if (ID != null && Source != null && Destination != null && ExtensionRegex != null && NameRegex != null && NameFormat != null && FileTypeIndex != null) {
                        TaskList.Add(new Task(Convert.ToInt32(ID.InnerText),
                                    Name != null ? Name.InnerText : "Unknown",
                                    Source.InnerText,
                                    Destination.InnerText,
                                    ExtensionRegex.InnerText,
                                    NameRegex.InnerText,
                                    AttributeMatch.InnerText,
                                    NameFormat.InnerText,
                                    Perform != null ? Perform.InnerText : "Copy",
                                    Convert.ToInt16(FileTypeIndex.InnerText),
                                    Enabled != null ? Convert.ToBoolean(Enabled.InnerText) : true));
                    }
                }
            } catch (Exception ex) {
                Log.Write("TaskCollection::ReadGroup() Error -> Failed To Read TaskCollection XML Path - " + path + " [" + ex.Message + "]");
            }
        }

        public void SaveGroup() {
            PerformSave(Path);
        }

        public void SaveGroup(string path) {
            PerformSave(path);
        }

        public void PerformSave(string path) {
            try {
                XmlDocument XMLDoc = new XmlDocument();
                XmlElement XMLRoot = XMLDoc.CreateElement("group");
                foreach (Task TaskObject in TaskList) {
                    XmlElement TaskElement = XMLDoc.CreateElement("task"),
                        ID = XMLDoc.CreateElement("id"),
                        Name = XMLDoc.CreateElement("name"),
                        Source = XMLDoc.CreateElement("source"),
                        Destination = XMLDoc.CreateElement("destination"),
                        ExtensionRegex = XMLDoc.CreateElement("extensionRegex"),
                        NameRegex = XMLDoc.CreateElement("nameRegex"),
                        AttributeMatch = XMLDoc.CreateElement("attributeMatch"),
                        NameFormat = XMLDoc.CreateElement("format"),
                        Perform = XMLDoc.CreateElement("perform"),
                        FileTypeIndex = XMLDoc.CreateElement("fileType"),
                        Enabled = XMLDoc.CreateElement("enabled");
                    StringBuilder AttributeMatchBuilder = new StringBuilder();

                    ID.InnerText = TaskObject.ID.ToString();
                    Name.InnerText = TaskObject.Name;
                    Source.InnerText = TaskObject.Source.FullName;
                    Destination.InnerText = TaskObject.Destination.FullName;
                    ExtensionRegex.InnerText = TaskObject.ExtensionRegex.ToString();
                    NameRegex.InnerText = TaskObject.NameRegex.ToString();
                    if (TaskObject.AttributeMatchList != null)
                        foreach (FileTag Attribute in TaskObject.AttributeMatchList) AttributeMatchBuilder.AppendFormat("{0}?{1}|", Attribute.TagName, Attribute.TagValue);
                    AttributeMatch.InnerText = AttributeMatchBuilder.ToString();
                    NameFormat.InnerText = TaskObject.Format;
                    FileTypeIndex.InnerText = TaskObject.FileTypeIndex.ToString();
                    Enabled.InnerText = TaskObject.Enabled.ToString().ToLower();
                    switch (TaskObject.PerformType) {
                        case PerformTaskType.Copy:
                            Perform.InnerText = "copy";
                            break;
                        case PerformTaskType.Move:
                            Perform.InnerText = "move";
                            break;
                        case PerformTaskType.Rename:
                            Perform.InnerText = "rename";
                            break;
                        case PerformTaskType.Delete:
                            Perform.InnerText = "delete";
                            break;
                        default:
                            Perform.InnerText = "copy";
                            break;
                    }

                    TaskElement.AppendChild(ID);
                    TaskElement.AppendChild(Name);
                    TaskElement.AppendChild(Source);
                    TaskElement.AppendChild(Destination);
                    TaskElement.AppendChild(ExtensionRegex);
                    TaskElement.AppendChild(NameRegex);
                    TaskElement.AppendChild(NameFormat);
                    TaskElement.AppendChild(AttributeMatch);
                    TaskElement.AppendChild(Perform);
                    TaskElement.AppendChild(FileTypeIndex);
                    TaskElement.AppendChild(Enabled);

                    XMLRoot.AppendChild(TaskElement);
                }
                XMLDoc.AppendChild(XMLRoot);
                XMLDoc.PreserveWhitespace = true;
                XMLDoc.Save(path);
            } catch (Exception ex) {
                Log.Write("TaskCollection::PerformSave() Error -> Failed To Save TaskCollection XML Path - " + Path + " [" + ex.Message + "]");
            }
        }


    }

    public struct GroupDetails {

        public string Name, Path, ScheduleOccurrence;
        public int ID, ScheduleInterval, ScheduleDay;
        public DateTime ScheduleTime;
        public bool Enabled;

        public GroupDetails(int id, string name, string path, string scheduleOccurrence, int scheduleDay,
            int scheduleInterval, DateTime scheduleTime, bool enabled) {
            ID = id;
            Name = name;
            Path = path;
            ScheduleOccurrence = scheduleOccurrence;
            ScheduleDay = scheduleDay;
            ScheduleInterval = scheduleInterval;
            ScheduleTime = scheduleTime;
            Enabled = enabled;
        }

    }

    public class GroupCollection {

        public string Path;
        public List<Tuple<GroupDetails, TaskCollection, Timer>> GroupListWithTimer;
        public List<Tuple<GroupDetails, TaskCollection>> GroupWithoutTimerList;
        public TaskDetail GroupTaskDetailDelegate;

        public GroupCollection(string path, TaskDetail groupTaskDetailDelegate) {
            if (File.Exists(path)) {
                Path = path;
                GroupTaskDetailDelegate = groupTaskDetailDelegate;
                InitializeWithTimer(path);
            } else Log.Write("GroupCollection::GroupCollection() Error -> Path Given Doesn't Exists. [" + path + "]");
        }

        public GroupCollection(string path) {
            if (File.Exists(path)) {
                Path = path;
                InitializeWithoutTimer(path);
            } else Log.Write("GroupCollection::GroupCollection() Error -> Path Given Doesn't Exists. [" + path + "]");
        }

        ~GroupCollection() {
            if (GroupListWithTimer != null) foreach (Tuple<GroupDetails, TaskCollection, Timer> GroupListObject in GroupListWithTimer) GroupListObject.Item3.Dispose();
        }

        public void InitializeWithTimer(string path) {
            try {
                GroupListWithTimer = new List<Tuple<GroupDetails, TaskCollection, Timer>>();
                XmlDocument XMLDoc = new XmlDocument();
                XMLDoc.Load(path);
                if (XMLDoc.DocumentElement != null) {
                    int GroupID;
                    string GroupPath;
                    XmlNode GroupScheduleNode;
                    TaskCollection TaskCollectionObject;
                    foreach (XmlNode GroupElement in XMLDoc.DocumentElement.SelectNodes("group")) {
                        GroupPath = GroupElement.SelectSingleNode("path").InnerText;
                        GroupScheduleNode = GroupElement.SelectSingleNode("schedule");
                        GroupID = Convert.ToInt32(GroupElement.SelectSingleNode("id").InnerText);
                        TaskCollectionObject = new TaskCollection(@GroupPath, GroupID);
                        GroupListWithTimer.Add(new Tuple<GroupDetails, TaskCollection, Timer>(new GroupDetails(GroupID,
                            GroupElement.SelectSingleNode("name").InnerText,
                            GroupPath,
                            GroupScheduleNode.SelectSingleNode("occurrence").InnerText.ToLower(),
                            Convert.ToInt16(GroupScheduleNode.SelectSingleNode("day").InnerText),
                            Convert.ToInt32(GroupScheduleNode.SelectSingleNode("interval").InnerText),
                            DateTime.Parse(GroupScheduleNode.SelectSingleNode("time").InnerText),
                            Convert.ToBoolean(GroupElement.SelectSingleNode("enabled").InnerText)), TaskCollectionObject,
                            new Timer(new TimerCallback(PerformTasks), TaskCollectionObject, Timeout.Infinite, Timeout.Infinite)));
                    }
                }
            } catch (Exception ex) {
                Log.Write("GroupCollection::Initialize() Error -> " + ex.Message);
            }
        }

        public void InitializeWithoutTimer(string path) {
            try {
                GroupWithoutTimerList = new List<Tuple<GroupDetails, TaskCollection>>();
                XmlDocument XMLDoc = new XmlDocument();
                XMLDoc.Load(path);
                if (XMLDoc.DocumentElement != null) {
                    int GroupID;
                    string GroupPath;
                    XmlNode GroupScheduleNode;
                    TaskCollection TaskCollectionObject;
                    foreach (XmlNode GroupElement in XMLDoc.DocumentElement.SelectNodes("group")) {
                        GroupPath = GroupElement.SelectSingleNode("path").InnerText;
                        GroupScheduleNode = GroupElement.SelectSingleNode("schedule");
                        GroupID = Convert.ToInt32(GroupElement.SelectSingleNode("id").InnerText);
                        TaskCollectionObject = new TaskCollection(@GroupPath, GroupID);
                        GroupWithoutTimerList.Add(new Tuple<GroupDetails, TaskCollection>(new GroupDetails(GroupID,
                            GroupElement.SelectSingleNode("name").InnerText,
                            GroupPath,
                            GroupScheduleNode.SelectSingleNode("occurrence").InnerText.ToLower(),
                            Convert.ToInt16(GroupScheduleNode.SelectSingleNode("day").InnerText),
                            Convert.ToInt32(GroupScheduleNode.SelectSingleNode("interval").InnerText),
                            DateTime.Parse(GroupScheduleNode.SelectSingleNode("time").InnerText),
                            Convert.ToBoolean(GroupElement.SelectSingleNode("enabled").InnerText)), TaskCollectionObject));
                    }
                }
            } catch (Exception ex) {
                Log.Write("GroupCollection::Initialize() Error -> " + ex.Message);
            }
        }

        public void SaveGroupCollection() {
            PerformSave(Path);
        }

        public void SaveGroupCollection(string path) {
            PerformSave(path);
        }

        public void PerformSave(string path) {
            try {
                XmlDocument XMLDoc = new XmlDocument();
                XmlElement XMLRoot = XMLDoc.CreateElement("groups");
                foreach (Tuple<GroupDetails, TaskCollection, Timer> GroupListObject in GroupListWithTimer) {
                    XmlElement GroupElement = XMLDoc.CreateElement("group"),
                        ID = XMLDoc.CreateElement("id"),
                        Name = XMLDoc.CreateElement("name"),
                        TaskCollectionPath = XMLDoc.CreateElement("path"),
                        Enabled = XMLDoc.CreateElement("enabled"),
                        Schedule = XMLDoc.CreateElement("schedule"),
                        ScheduleOccurrence = XMLDoc.CreateElement("occurrence"),
                        ScheduleDay = XMLDoc.CreateElement("day"),
                        ScheduleTime = XMLDoc.CreateElement("time"),
                        ScheduleInterval = XMLDoc.CreateElement("interval");

                    ID.InnerText = GroupListObject.Item1.ID.ToString();
                    Name.InnerText = GroupListObject.Item1.Name;
                    TaskCollectionPath.InnerText = GroupListObject.Item1.Path;
                    Enabled.InnerText = GroupListObject.Item1.Enabled.ToString().ToLower();
                    ScheduleOccurrence.InnerText = GroupListObject.Item1.ScheduleOccurrence;
                    ScheduleDay.InnerText = GroupListObject.Item1.ScheduleDay.ToString();
                    ScheduleTime.InnerText = GroupListObject.Item1.ScheduleTime.Hour + ":" + GroupListObject.Item1.ScheduleTime.Minute;
                    ScheduleInterval.InnerText = GroupListObject.Item1.ScheduleInterval.ToString();

                    Schedule.AppendChild(ScheduleOccurrence);
                    Schedule.AppendChild(ScheduleDay);
                    Schedule.AppendChild(ScheduleTime);
                    Schedule.AppendChild(ScheduleInterval);
                    GroupElement.AppendChild(ID);
                    GroupElement.AppendChild(Name);
                    GroupElement.AppendChild(TaskCollectionPath);
                    GroupElement.AppendChild(Enabled);
                    GroupElement.AppendChild(Schedule);

                    XMLRoot.AppendChild(GroupElement);
                }
                XMLDoc.AppendChild(XMLRoot);
                XMLDoc.PreserveWhitespace = true;
                XMLDoc.Save(path);
            } catch (Exception ex) {
                Log.Write("GroupCollection::PerformSave() Error -> Failed To Save GroupCollection XML Path - " + Path + " [" + ex.Message + "]");
            }
        }

        public void PerformSaveWithoutTimer(string path) {
            try {
                XmlDocument XMLDoc = new XmlDocument();
                XmlElement XMLRoot = XMLDoc.CreateElement("groups");
                foreach (Tuple<GroupDetails, TaskCollection> GroupListObject in GroupWithoutTimerList) {
                    XmlElement GroupElement = XMLDoc.CreateElement("group"),
                        ID = XMLDoc.CreateElement("id"),
                        Name = XMLDoc.CreateElement("name"),
                        TaskCollectionPath = XMLDoc.CreateElement("path"),
                        Enabled = XMLDoc.CreateElement("enabled"),
                        Schedule = XMLDoc.CreateElement("schedule"),
                        ScheduleOccurrence = XMLDoc.CreateElement("occurrence"),
                        ScheduleDay = XMLDoc.CreateElement("day"),
                        ScheduleTime = XMLDoc.CreateElement("time"),
                        ScheduleInterval = XMLDoc.CreateElement("interval");

                    ID.InnerText = GroupListObject.Item1.ID.ToString();
                    Name.InnerText = GroupListObject.Item1.Name;
                    TaskCollectionPath.InnerText = GroupListObject.Item1.Path;
                    Enabled.InnerText = GroupListObject.Item1.Enabled.ToString().ToLower();
                    ScheduleOccurrence.InnerText = GroupListObject.Item1.ScheduleOccurrence;
                    ScheduleDay.InnerText = GroupListObject.Item1.ScheduleDay.ToString();
                    ScheduleTime.InnerText = GroupListObject.Item1.ScheduleTime.Hour + ":" + GroupListObject.Item1.ScheduleTime.Minute;
                    ScheduleInterval.InnerText = GroupListObject.Item1.ScheduleInterval.ToString();

                    Schedule.AppendChild(ScheduleOccurrence);
                    Schedule.AppendChild(ScheduleDay);
                    Schedule.AppendChild(ScheduleTime);
                    Schedule.AppendChild(ScheduleInterval);
                    GroupElement.AppendChild(ID);
                    GroupElement.AppendChild(Name);
                    GroupElement.AppendChild(TaskCollectionPath);
                    GroupElement.AppendChild(Enabled);
                    GroupElement.AppendChild(Schedule);

                    XMLRoot.AppendChild(GroupElement);
                }
                XMLDoc.AppendChild(XMLRoot);
                XMLDoc.PreserveWhitespace = true;
                XMLDoc.Save(path);
            } catch (Exception ex) {
                Log.Write("GroupCollection::PerformSaveWithoutTimer() Error -> Failed To Save GroupCollection XML Path - " + Path + " [" + ex.Message + "]");
            }
        }

        public void PerformTasks(object taskCollectionObject) {
            TaskCollection TaskCollectionObject = (TaskCollection)taskCollectionObject;
            foreach (Task TaskObject in TaskCollectionObject.TaskList) TaskObject.PerformTask(GroupTaskDetailDelegate);
            Thread ScheduleGroupThread = new Thread(() => ScheduleGroup(GroupListWithTimer.Find(delegate (Tuple<GroupDetails, TaskCollection, Timer> groupListObject) {
                return groupListObject.Item2.Name == TaskCollectionObject.Name;
            })));
            ScheduleGroupThread.IsBackground = true;
            ScheduleGroupThread.Start();
        }

        public void ScheduleGroup(object groupTuppleObjectObject) {
            Tuple<GroupDetails, TaskCollection, Timer> GroupTuppleObject = (Tuple<GroupDetails, TaskCollection, Timer>)groupTuppleObjectObject;
            try {
                GroupDetails GroupDetailsObject = GroupTuppleObject.Item1;
                TaskCollection TaskCollectionObject = GroupTuppleObject.Item2;
                Timer GroupTimerObject = GroupTuppleObject.Item3;
                DateTime GroupScheduleTime = DateTime.MinValue;
                TimeSpan ScheduledIn = new TimeSpan();
                switch (GroupDetailsObject.ScheduleOccurrence) {
                    case "weekly":
                        GroupScheduleTime = GroupDetailsObject.ScheduleTime;
                        GroupScheduleTime = GroupScheduleTime.AddDays(Math.Abs(GroupDetailsObject.ScheduleDay - (int)DateTime.Now.DayOfWeek));
                        ScheduledIn = GroupScheduleTime.Subtract(DateTime.Now);
                        GroupTimerObject.Change(Convert.ToInt32(ScheduledIn.TotalMilliseconds), Timeout.Infinite);
                        break;
                    case "daily":
                        GroupScheduleTime = GroupDetailsObject.ScheduleTime;
                        if (DateTime.Now > GroupScheduleTime) GroupScheduleTime = GroupScheduleTime.AddDays(1);
                        ScheduledIn = GroupScheduleTime.Subtract(DateTime.Now);
                        GroupTimerObject.Change(Convert.ToInt32(ScheduledIn.TotalMilliseconds), Timeout.Infinite);
                        break;
                    case "interval":
                        GroupScheduleTime = DateTime.Now.AddMinutes(GroupDetailsObject.ScheduleInterval);
                        ScheduledIn = GroupScheduleTime.Subtract(DateTime.Now);
                        GroupTimerObject.Change(Convert.ToInt32(ScheduledIn.TotalMilliseconds), Timeout.Infinite);
                        break;
                    default:
                        Log.Write("ScheduleService() Error :: Invalid ScheduleOccurrence Given - " + GroupDetailsObject.ScheduleOccurrence + " In - " + GroupDetailsObject.Name);
                        break;
                }
                Log.Write("ScheduleGroup() -> Scheduled Group - " + TaskCollectionObject.Name + " Tasks - " + TaskCollectionObject.TaskList.Count.ToString() + " In - " + ScheduledIn.ToString());
            } catch (Exception ex) {
                Log.Write("ScheduleGroup() Error -> " + ex.Message);
            }
        }

        public void ScheduleGroups() {
            foreach (Tuple<GroupDetails, TaskCollection, Timer> GroupTuppleObject in GroupListWithTimer) {
                if (GroupTuppleObject.Item1.Enabled && GroupTuppleObject.Item2.TaskList.Count > 0) {
                    //ScheduleGroup(GroupTuppleObject);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ScheduleGroup), GroupTuppleObject);
                }
            }
        }

    }

}
