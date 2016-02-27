using System.IO;
using System.Collections.Generic;
using Shell32;
using System;
using System.Text;

namespace FileTagExtract {
    public struct FileTag {
        public string TagName,
                      TagValue;
        public FileTag(string name, string value) {
            TagName = name;
            TagValue = value;
        }
    }
    public class GenerateFileInfo {
        public static List<FileTag> GetFileTag(string path) {
            List<FileTag> arrTags = new List<FileTag>();
            List<string> Headers = new List<string>();
            dynamic shell = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
            Folder folder = shell.NameSpace(Path.GetDirectoryName(@path));
            FolderItem folderItem = folder.ParseName(Path.GetFileName(@path));
            string FileType = folder.GetDetailsOf(folderItem, 9);
            switch (FileType) {
                case "Audio":
                    AudioFileInfo(ref arrTags, folder, folderItem);
                    break;
                case "Video":
                    VideoFileInfo(ref arrTags, folder, folderItem);
                    break;
                case "Image":
                    ImageFileInfo(ref arrTags, folder, folderItem);
                    break;
                default:
                    GeneralFileInfo(ref arrTags, folder, folderItem);
                    break;
            }
            return arrTags;
        }
        static public void AudioFileInfo(ref List<FileTag> arr, Folder Folder, FolderItem FolderItem) {
            FileTag temp = new FileTag();
            int[] index = { 0, 13, 14, 15, 16, 21, 26, 28, 230 };
            string[] name = { "Name", "Contributing artists", "Album", "Year", "Genre", "Title", "Track number", "Bit rate", "Album artist" };
            for (int i = 0; i < 9; i++) {
                temp.TagName = name[i];
                temp.TagValue = Folder.GetDetailsOf(FolderItem, index[i]).ToString();
                if (i == 7) temp.TagValue = temp.TagValue.Substring(1, temp.TagValue.Length - 1);
                arr.Add(temp);
            }
        }
        static public void VideoFileInfo(ref List<FileTag> arr, Folder Folder, FolderItem FolderItem) {
            FileTag temp = new FileTag();
            int[] index = { 0, 1, 15, 21, 303, 304, 305, 306, 308 };
            string[] name = { "File name", "File size", "Year", "Title", "Data rate", "Frame height", "Frame rate", "Frame width", "Total Bitrate" };
            for (int i = 0; i < 9; i++) {
                temp.TagName = name[i];
                temp.TagValue = Folder.GetDetailsOf(FolderItem, index[i]).ToString();
                arr.Add(temp);
            }
        }
        static public void ImageFileInfo(ref List<FileTag> arr, Folder Folder, FolderItem FolderItem) {
            FileTag temp = new FileTag();
            int[] index = { 0, 1, 21, 30, 31, 32, 251, 252, 255, 256, 258, 260 };
            string[] name = { "File name", "File size", "Title", "Camera model", "Dimensions", "Camera maker", "Exposure time", "F-stop", "35mm focal length", "ISO speed", "Lens model", "Max aperture" };
            for (int i = 0; i < 12; i++) {
                temp.TagName = name[i];
                temp.TagValue = Folder.GetDetailsOf(FolderItem, index[i]).ToString();
                arr.Add(temp);
            }
        }
        static public void CompressedFileInfo(ref List<FileTag> arr, Folder Folder, FolderItem FolderItem) {
            FileTag temp = new FileTag();
            int[] index = { 0, 1, 2 };
            string[] name = { "File name", "File size", "Item type" };
            for (int i = 0; i < 11; i++) {
                temp.TagName = name[i];
                temp.TagValue = Folder.GetDetailsOf(FolderItem, index[i]).ToString();
                arr.Add(temp);
            }
        }
        static public void GeneralFileInfo(ref List<FileTag> arr, Folder Folder, FolderItem FolderItem) {
            FileTag temp = new FileTag();
            int[] index = { 0, 1, 2, 20, 150, 153, 158, 175, 192 };
            string[] name = { "File name", "File size", "Item type", "Authors", "Pages", "Word count", "File version", "Encryption status", "Language" };
            for (int i = 0; i < 9; i++) {
                temp.TagName = name[i];
                temp.TagValue = (Folder.GetDetailsOf(FolderItem, index[i])).ToString();
                arr.Add(temp);
            }
        }
    }
}
