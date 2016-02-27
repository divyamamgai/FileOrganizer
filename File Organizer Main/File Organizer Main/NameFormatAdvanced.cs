using System;
using FileOrganizerFileTypes;
using System.Windows.Forms;

namespace MatchCaseNameSpace {
    public partial class NameFormatAdvanced : Form
    {
        public NameFormatAdvanced(FileType FileTypePassed)
        {
            InitializeComponent();
            switch(FileTypePassed)
            {
                case FileType.Compressed:
                    AttributeDropDown.Items.Add("Name");
                    AttributeDropDown.Items.Add("Size");
                    AttributeDropDown.Items.Add("Item Type");
                    break;
                case FileType.Audio:
                    AttributeDropDown.Items.Add("Name");
                    AttributeDropDown.Items.Add("Contributing Artists");
                    AttributeDropDown.Items.Add("Album");
                    AttributeDropDown.Items.Add("Year");
                    AttributeDropDown.Items.Add("Genre");
                    AttributeDropDown.Items.Add("Title");
                    AttributeDropDown.Items.Add("Track Number");
                    AttributeDropDown.Items.Add("Bit Rate");
                    AttributeDropDown.Items.Add("Album Artist");
                    break;
                case FileType.Document:
                    AttributeDropDown.Items.Add("Name");
                    AttributeDropDown.Items.Add("Size");
                    AttributeDropDown.Items.Add("Item Type");
                    AttributeDropDown.Items.Add("Author");
                    AttributeDropDown.Items.Add("Pages");
                    AttributeDropDown.Items.Add("Word Count");
                    AttributeDropDown.Items.Add("File Version");
                    AttributeDropDown.Items.Add("Encryption Status");
                    AttributeDropDown.Items.Add("Language");
                    break;
                case FileType.Image:
                    AttributeDropDown.Items.Add("Name");
                    AttributeDropDown.Items.Add("Size");
                    AttributeDropDown.Items.Add("Title");
                    AttributeDropDown.Items.Add("Camera Model");
                    AttributeDropDown.Items.Add("Dimensions");
                    AttributeDropDown.Items.Add("Camera Maker");
                    AttributeDropDown.Items.Add("Exposure Time");
                    AttributeDropDown.Items.Add("F-Stop");
                    AttributeDropDown.Items.Add("35mm focal length");
                    AttributeDropDown.Items.Add("ISO speed");
                    AttributeDropDown.Items.Add("Lens model");
                    AttributeDropDown.Items.Add("Max aperture");
                    break;
                case FileType.SourceCode:
                    AttributeDropDown.Items.Add("Name");
                    AttributeDropDown.Items.Add("Size");
                    AttributeDropDown.Items.Add("Item Type");
                    AttributeDropDown.Items.Add("File Version");
                    break;
                case FileType.Executable:
                    AttributeDropDown.Items.Add("Name");
                    AttributeDropDown.Items.Add("Size");
                    AttributeDropDown.Items.Add("Item Type");
                    AttributeDropDown.Items.Add("File Version");
                    AttributeDropDown.Items.Add("Language");
                    break;
                case FileType.Video:
                    AttributeDropDown.Items.Add("Name");
                    AttributeDropDown.Items.Add("Size");
                    AttributeDropDown.Items.Add("Year");
                    AttributeDropDown.Items.Add("Title");
                    AttributeDropDown.Items.Add("Data Rate");
                    AttributeDropDown.Items.Add("Frame Height");
                    AttributeDropDown.Items.Add("Frame Rate");
                    AttributeDropDown.Items.Add("Frame Width");
                    AttributeDropDown.Items.Add("Total Bitrate");
                    break;
            }
        }

        public string FinalUserNameFormat;
        int cursor_click = 0;

        private void Done_Click(object sender, EventArgs e)
        {
            if(UserEnteredFormat.Text != "")
            {
                FinalUserNameFormat = UserEnteredFormat.Text;
                Close();
            }
        }

        private void UserEnteredFormat_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (UserEnteredFormat.Text != "" && e.KeyCode == Keys.Enter)
            {
                FinalUserNameFormat = UserEnteredFormat.Text;
                Close();
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            string item = this.AttributeDropDown.GetItemText(this.AttributeDropDown.SelectedItem);
            if(item != "")
            {
                if(cursor_click != 0)
                {
                    UserEnteredFormat.Text = UserEnteredFormat.Text.Insert(cursor_click,"|" + item + "|");
                }
                else
                {
                    UserEnteredFormat.Text += "|" + item + "|";
                }
            }
        }

        private void UserEnteredFormat_Leave(object sender, EventArgs e)
        {
            cursor_click = UserEnteredFormat.SelectionStart;
        }
    }
}
