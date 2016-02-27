using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TaggerControl;
using FileOrganizerFileTypes;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace MatchCaseNameSpace {
    public partial class MatchCase : Form {

        public List<Tuple<int, string>> TagGroupList = new List<Tuple<int, string>>();
        Tagger CurrentSelected;
        static int count = 0;
        public string RegexFinal = "", EnteredUserNameFormat = "";
        FileType FileTypeForPassing;

        public MatchCase(FileType SelectedFileType) {
            InitializeComponent();
            FileTypeForPassing = SelectedFileType;
        }

        private void CurrentSelected_PreviewKeyDown(object TaggerObject, PreviewKeyDownEventArgs e) {
            e.IsInputKey = true;
            Tagger SelectedObject = (Tagger)TaggerObject, SwappingObject;
            int AlphaIndex, BetaIndex;
            if (e.KeyCode == Keys.Left) {
                AlphaIndex = StringCollection.Controls.GetChildIndex(CurrentSelected);
                BetaIndex = AlphaIndex - 1;
                if (AlphaIndex > 0) {
                    SwappingObject = (Tagger)StringCollection.Controls[BetaIndex];
                    StringCollection.Controls.SetChildIndex(SelectedObject, BetaIndex);
                    StringCollection.Controls.SetChildIndex(SwappingObject, AlphaIndex);
                    Tuple<int, string> TempTuple = TagGroupList[AlphaIndex];
                    TagGroupList[AlphaIndex] = TagGroupList[BetaIndex];
                    TagGroupList[BetaIndex] = TempTuple;
                }
            }
            if (e.KeyCode == Keys.Right) {
                AlphaIndex = StringCollection.Controls.GetChildIndex(CurrentSelected);
                BetaIndex = AlphaIndex + 1;
                if (AlphaIndex < count - 1) {
                    SwappingObject = (Tagger)StringCollection.Controls[BetaIndex];
                    StringCollection.Controls.SetChildIndex(SelectedObject, BetaIndex);
                    StringCollection.Controls.SetChildIndex(SwappingObject, AlphaIndex);
                    Tuple<int, string> TempTuple = TagGroupList[AlphaIndex];
                    TagGroupList[AlphaIndex] = TagGroupList[BetaIndex];
                    TagGroupList[BetaIndex] = TempTuple;
                }
            }
            CurrentSelected.Focus();
        }

        public void TaggerSelectChange(object tagger, bool selected) {
            Tagger TaggerObject = (Tagger)tagger;
            if (selected == true) {
                if (CurrentSelected != null) {
                    CurrentSelected.DeSelectTagger();
                }
                CurrentSelected = TaggerObject;
                CurrentSelected.Focus();
                CurrentSelected.PreviewKeyDown += new PreviewKeyDownEventHandler(CurrentSelected_PreviewKeyDown);
            }
            if (selected == false) {
                CurrentSelected = null;
            }
        }

        public void TaggerCrossClick(object tagger) {
            Tagger TaggerObject = (Tagger)tagger;
            DialogResult PerformRemove = MessageBox.Show("Do you really want to remove " + TaggerObject.Text + " tag?", "Remove Tag", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (PerformRemove == DialogResult.Yes) {
                count--;
                int index = TagGroupList.FindIndex(t => t.Item1 == TaggerObject.ID);
                TagGroupList.RemoveAt(index);
                TaggerObject.Dispose();
            }
        }

        private void String_Click(object sender, EventArgs e) {
            StringPopUp stringform = new StringPopUp();
            stringform.ShowDialog();
            if (stringform.UserInputString == null) {
                return;
            }
            Tagger UserInput = new Tagger(new TaggerOnSelectChange(TaggerSelectChange), new TaggerOnCrossClick(TaggerCrossClick), 0);
            UserInput.Text = stringform.UserInputString;
            UserInput.Font = new Font(new FontFamily("Segoe UI"), 8);
            UserInput.CrossSizeCorrection = -5;
            UserInput.CrossOffset = new Point(-2, 0);
            UserInput.Padding = new Padding(3, 4, 3, 3);
            StringCollection.Controls.Add(UserInput);
            count++;
            TagGroupList.Add(new Tuple<int, string>(UserInput.ID, UserInput.Text));
            stringform.Close();
        }

        private void Number_Click(object sender, EventArgs e) {
            Tagger VarNum = new Tagger(new TaggerOnSelectChange(TaggerSelectChange), new TaggerOnCrossClick(TaggerCrossClick), 1);
            VarNum.Text = "Digit";
            VarNum.Font = new Font(new FontFamily("Segoe UI"), 8);
            VarNum.CrossSizeCorrection = -5;
            VarNum.CrossOffset = new Point(-2, 0);
            VarNum.Padding = new Padding(3, 4, 3, 3);
            StringCollection.Controls.Add(VarNum);
            count++;
            TagGroupList.Add(new Tuple<int, string>(VarNum.ID, VarNum.Text));
        }

        private void VariableSting_Click(object sender, EventArgs e) {
            Tagger VarString = new Tagger(new TaggerOnSelectChange(TaggerSelectChange), new TaggerOnCrossClick(TaggerCrossClick), 3);
            VarString.Text = "String";
            VarString.Font = new Font(new FontFamily("Segoe UI"), 8);
            VarString.CrossSizeCorrection = -5;
            VarString.CrossOffset = new Point(-2, 0);
            VarString.Padding = new Padding(3, 4, 3, 3);
            StringCollection.Controls.Add(VarString);
            count++;
            TagGroupList.Add(new Tuple<int, string>(VarString.ID, VarString.Text));
        }

        private void DoneExit_Click(object sender, EventArgs e) {
            RegexFinal = "";
            if (DefaultAndAdvancedTab.SelectedTab == DefaultAndAdvancedTab.TabPages["Default"]) {
                foreach (var a in TagGroupList) {
                    if (a.Item1 == 0) {
                        RegexFinal += "(" + Regex.Escape(a.Item2) + ")";
                    }
                    if (a.Item1 == 1) {
                        RegexFinal += "([0-9]*)";
                    }
                    if (a.Item1 == 2) {
                        RegexFinal += "([a-zA-Z]*)";
                    }
                    if (a.Item1 == 3) {
                        RegexFinal += "(.*)";
                    }
                    if (a.Item1 == 4) {
                        RegexFinal += "([^a-zA-Z]*)";
                    }
                    if (a.Item1 == 5) {
                        RegexFinal += "([^0-9]*)";
                    }
                }
                if (count != 0) {
                    NameFormatDefault NameSpecifierDefault = new NameFormatDefault(TagGroupList, RegexFinal, FileTypeForPassing);
                    NameSpecifierDefault.ShowDialog();
                    NameSpecifierDefault.Close();
                    EnteredUserNameFormat = NameSpecifierDefault.FinalUserNameFormat;
                    Close();
                }
            } else {
                if (UserRegexBox.Text != "") {
                    RegexFinal = UserRegexBox.Text;
                    NameFormatAdvanced NameSpecifierAdvanced = new NameFormatAdvanced(FileTypeForPassing);
                    NameSpecifierAdvanced.ShowDialog();
                    NameSpecifierAdvanced.Close();
                    EnteredUserNameFormat = NameSpecifierAdvanced.FinalUserNameFormat;
                    Close();
                }
            }
        }

        private void Alphabets_Click(object sender, EventArgs e) {
            Tagger VarAlphabet = new Tagger(new TaggerOnSelectChange(TaggerSelectChange), new TaggerOnCrossClick(TaggerCrossClick), 2);
            VarAlphabet.Text = "Alphabet";
            VarAlphabet.Font = new Font(new FontFamily("Segoe UI"), 8);
            VarAlphabet.CrossSizeCorrection = -5;
            VarAlphabet.CrossOffset = new Point(-2, 0);
            VarAlphabet.Padding = new Padding(3, 4, 3, 3);
            StringCollection.Controls.Add(VarAlphabet);
            count++;
            TagGroupList.Add(new Tuple<int, string>(VarAlphabet.ID, VarAlphabet.Text));
        }

        private void NotAlphabet_Click(object sender, EventArgs e) {
            Tagger NotAlphabet = new Tagger(new TaggerOnSelectChange(TaggerSelectChange), new TaggerOnCrossClick(TaggerCrossClick), 4);
            NotAlphabet.Text = "Not Alphabet";
            NotAlphabet.Font = new Font(new FontFamily("Segoe UI"), 8);
            NotAlphabet.CrossSizeCorrection = -5;
            NotAlphabet.CrossOffset = new Point(-2, 0);
            NotAlphabet.Padding = new Padding(3, 4, 3, 3);
            StringCollection.Controls.Add(NotAlphabet);
            count++;
            TagGroupList.Add(new Tuple<int, string>(NotAlphabet.ID, NotAlphabet.Text));
        }

        private void NotNumber_Click(object sender, EventArgs e) {
            Tagger NotNumber = new Tagger(new TaggerOnSelectChange(TaggerSelectChange), new TaggerOnCrossClick(TaggerCrossClick), 5);
            NotNumber.Text = "Not Digit";
            NotNumber.Font = new Font(new FontFamily("Segoe UI"), 8);
            NotNumber.CrossSizeCorrection = -5;
            NotNumber.CrossOffset = new Point(-2, 0);
            NotNumber.Padding = new Padding(3, 4, 3, 3);
            StringCollection.Controls.Add(NotNumber);
            count++;
            TagGroupList.Add(new Tuple<int, string>(NotNumber.ID, NotNumber.Text));
        }

        private void UserRegexBox_Leave(object sender, EventArgs e) {
            try {
                Regex regex = new Regex(@UserRegexBox.Text);
            } catch (Exception ex) {
                MessageBox.Show("The Regex you provided seems to have generated an error." + Environment.NewLine + "Exception Message : " + ex.Message, "Invalid Regex", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserRegexBox.Text = "";
                UserRegexBox.Focus();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://msdn.microsoft.com/en-us/library/ae5bf541(v=vs.90).aspx");
        }

        private void UserRegexBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                try {
                    Regex regex = new Regex(@UserRegexBox.Text);
                } catch (Exception ex) {
                    MessageBox.Show("The Regex you provided seems to have generated an error." + Environment.NewLine + "Exception Message : " + ex.Message, "Invalid Regex", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UserRegexBox.Text = "";
                    UserRegexBox.Focus();
                }
                if (UserRegexBox.Text != "") {
                    RegexFinal = UserRegexBox.Text;
                    NameFormatAdvanced NameSpecifierAdvanced = new NameFormatAdvanced(FileTypeForPassing);
                    NameSpecifierAdvanced.ShowDialog();
                    NameSpecifierAdvanced.Close();
                    EnteredUserNameFormat = NameSpecifierAdvanced.FinalUserNameFormat;
                    Close();
                }
            }
        }
    }
}
