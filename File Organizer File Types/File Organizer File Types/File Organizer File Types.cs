using System;
using System.Collections.Generic;
using System.IO;

namespace FileOrganizerFileTypes {
    public enum FileType {
        Compressed,
        Audio,
        Document,
        Image,
        SourceCode,
        Executable,
        Video
    };
    public class FileTypes {
        public static List<List<string>> TypesList;
        public static int TypesCount;
        static bool Initialized;
        public FileTypes(string path) {
            if (!Initialized) {
                try {
                    StreamReader FileTypeStream = new StreamReader(@path);
                    string Line;
                    TypesList = new List<List<string>>();
                    while ((Line = FileTypeStream.ReadLine()) != null) {
                        TypesList.Add(new List<string>());
                        foreach (string Token in Line.Split('|')) {
                            TypesList[TypesCount].Add(Token);
                        }
                        TypesCount++;
                    }
                    FileTypeStream.Close();
                    Initialized = true;
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static List<string> GetTypeList(FileType type) {
            short i = 0;
            switch (type) {
                case FileType.Compressed:
                    i = 0;
                    break;
                case FileType.Audio:
                    i = 1;
                    break;
                case FileType.Document:
                    i = 2;
                    break;
                case FileType.Image:
                    i = 3;
                    break;
                case FileType.SourceCode:
                    i = 4;
                    break;
                case FileType.Executable:
                    i = 5;
                    break;
                case FileType.Video:
                    i = 6;
                    break;
            }
            return TypesList[i];
        }
    }
    public class FileAttributes {
        public static List<List<string>> AttributesList;
        public static int AttributesCount = 0;
        public static bool Initialized = false;
        public FileAttributes(string path) {
            if (!Initialized) {
                try {
                    StreamReader FileTypeStream = new StreamReader(@path);
                    string Line;
                    AttributesList = new List<List<string>>();
                    while ((Line = FileTypeStream.ReadLine()) != null) {
                        AttributesList.Add(new List<string>());
                        foreach (string Token in Line.Split('|')) {
                            AttributesList[AttributesCount].Add(Token);
                        }
                        AttributesCount++;
                    }
                    FileTypeStream.Close();
                    Initialized = true;
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static List<string> GetAttributeList(FileType type) {
            short i = 0;
            switch (type) {
                case FileType.Compressed:
                    i = 0;
                    break;
                case FileType.Audio:
                    i = 1;
                    break;
                case FileType.Document:
                    i = 2;
                    break;
                case FileType.Image:
                    i = 3;
                    break;
                case FileType.SourceCode:
                    i = 4;
                    break;
                case FileType.Executable:
                    i = 5;
                    break;
                case FileType.Video:
                    i = 6;
                    break;
            }
            return AttributesList[i];
        }
    }
}
