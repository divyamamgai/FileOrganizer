using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MatchCaseNameSpace {
    public partial class StringPopUp : Form
    {
        public Regex WildCards = new Regex(@"^[\w\-.\s]*$");
        public StringPopUp()
        {
            InitializeComponent();
        }

        public string UserInputString
        {
            get;
            set;
        }

        private void UserInputTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(UserInputTextBox.Text == "")
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
                else
                {
                    UserInputString = UserInputTextBox.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void UserInputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '?' || e.KeyChar == '\\' || e.KeyChar == '/' || e.KeyChar == ':' || e.KeyChar == '*' || e.KeyChar == '"' || e.KeyChar == '<' || e.KeyChar == '>' || e.KeyChar == '|')
            {
                e.Handled = true;
            }
        }

        private void UserInputTextBox_TextChanged(object sender, System.EventArgs e) {
            if (!WildCards.IsMatch(UserInputTextBox.Text)) {
                UserInputTextBox.Text = "";
                MessageBox.Show("Some characters are not allowed in this field as part of file name validation.", "Illegal Character", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
