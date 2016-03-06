using System;
using FileOrganizerFileTypes;
using System.Windows.Forms;

namespace MatchCaseNameSpace {
    public partial class NameFormatAdvanced : Form {

        public string FinalUserNameFormat;
        int cursor_click = 0;

        public NameFormatAdvanced(FileType FileTypePassed) {
            InitializeComponent();
            foreach (string Attribute in FileAttributes.GetAttributeList(FileTypePassed)) AttributeDropDown.Items.Add(Attribute);
        }

        private void Done_Click(object sender, EventArgs e) {
            if (UserEnteredFormat.Text != "") {
                FinalUserNameFormat = UserEnteredFormat.Text;
                Close();
            }
        }

        private void UserEnteredFormat_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (UserEnteredFormat.Text != "" && e.KeyCode == Keys.Enter) {
                FinalUserNameFormat = UserEnteredFormat.Text;
                Close();
            }
        }

        private void OKButton_Click(object sender, EventArgs e) {
            string item = this.AttributeDropDown.GetItemText(this.AttributeDropDown.SelectedItem);
            if (item != "") {
                if (cursor_click != 0) {
                    UserEnteredFormat.Text = UserEnteredFormat.Text.Insert(cursor_click, "|" + item + "|");
                } else {
                    UserEnteredFormat.Text += "|" + item + "|";
                }
            }
        }

        private void UserEnteredFormat_Leave(object sender, EventArgs e) {
            cursor_click = UserEnteredFormat.SelectionStart;
        }
    }
}
