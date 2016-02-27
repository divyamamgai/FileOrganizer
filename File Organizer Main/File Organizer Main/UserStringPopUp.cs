using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchCaseNameSpace {
    public partial class UserStringPopUp : Form {
        public UserStringPopUp() {
            InitializeComponent();
        }

        public string UserString;
        public Regex WildCards = new Regex(@"^[\w\-.\s]*$");

        private void UserEnteredName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (UserEnteredName.Text == null) {
                    DialogResult = DialogResult.Cancel;
                    Close();
                } else {
                    UserString = UserEnteredName.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void UserEnteredName_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '?' || e.KeyChar == '\\' || e.KeyChar == '/' || e.KeyChar == ':' || e.KeyChar == '*' || e.KeyChar == '"' || e.KeyChar == '<' || e.KeyChar == '>' || e.KeyChar == '|') {
                e.Handled = true;
            }
        }

        private void UserEnteredName_TextChanged(object sender, EventArgs e) {
            if (!WildCards.IsMatch(UserEnteredName.Text)) {
                UserEnteredName.Text = "";
                MessageBox.Show("Some characters are not allowed in this field as part of file name validation.", "Illegal Character", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
