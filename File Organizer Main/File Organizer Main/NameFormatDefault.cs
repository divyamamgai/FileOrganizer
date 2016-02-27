using FileOrganizerFileTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TaggerControl;

namespace MatchCaseNameSpace {
    public partial class NameFormatDefault : Form {

        public string RegexFinal;
        List<Tuple<int, int, string>> GroupNumberedString = new List<Tuple<int, int, string>>();
        List<Tuple<int, int, string>> FinalString = new List<Tuple<int, int, string>>();
        public string FinalUserNameFormat;
        static int count = 0;
        Tagger CurrentSelected;

        public NameFormatDefault(List<Tuple<int, string>> TagGroupListArg, string RegexFinalArg, FileType FileTypePassed) {
            InitializeComponent();
            switch (FileTypePassed) {
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
            AttributeDropDown.SelectedIndex = 0;
            RegexFinal = RegexFinalArg;
            int i = 1;
            foreach (Tuple<int, string> t in TagGroupListArg) {
                Button NameButton = new Button();
                NameButton.Text = t.Item2;
                NameButton.AutoSize = true;
                NameButton.Margin = new Padding(2, 2, 2, 2);
                NameSelectPanel.Controls.Add(NameButton);
                GroupNumberedString.Add(new Tuple<int, int, string>(i, 0, NameButton.Text));
                i++;
                NameButton.Click += new EventHandler(NameButton_Click);
            }
        }

        private void CurrentSelected_PreviewKeyDown(object TaggerObject, PreviewKeyDownEventArgs e) {
            e.IsInputKey = true;
            Tagger SelectedObject = (Tagger)TaggerObject, SwappingObject;
            int AlphaIndex, BetaIndex;
            if (e.KeyCode == Keys.Left) {
                AlphaIndex = NameFinalPanel.Controls.GetChildIndex(CurrentSelected);
                BetaIndex = AlphaIndex - 1;
                if (AlphaIndex > 0) {
                    SwappingObject = (Tagger)NameFinalPanel.Controls[BetaIndex];
                    NameFinalPanel.Controls.SetChildIndex(SelectedObject, BetaIndex);
                    NameFinalPanel.Controls.SetChildIndex(SwappingObject, AlphaIndex);
                    Tuple<int, int, string> TempTuple = FinalString[AlphaIndex];
                    FinalString[AlphaIndex] = FinalString[BetaIndex];
                    FinalString[BetaIndex] = TempTuple;
                }
            }
            if (e.KeyCode == Keys.Right) {
                AlphaIndex = NameFinalPanel.Controls.GetChildIndex(CurrentSelected);
                BetaIndex = AlphaIndex + 1;
                if (AlphaIndex < count - 1) {
                    SwappingObject = (Tagger)NameFinalPanel.Controls[BetaIndex];
                    NameFinalPanel.Controls.SetChildIndex(SelectedObject, BetaIndex);
                    NameFinalPanel.Controls.SetChildIndex(SwappingObject, AlphaIndex);
                    Tuple<int, int, string> TempTuple = FinalString[AlphaIndex];
                    FinalString[AlphaIndex] = FinalString[BetaIndex];
                    FinalString[BetaIndex] = TempTuple;
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
                int index = FinalString.FindIndex(t => (t.Item2 == TaggerObject.ID) && (t.Item3 == TaggerObject.Text));
                FinalString.RemoveAt(index);
                TaggerObject.Dispose();
                count--;
            }
        }

        private void NameButton_Click(object sender, EventArgs e) {
            Tagger NameSelected = new Tagger(new TaggerOnSelectChange(TaggerSelectChange), new TaggerOnCrossClick(TaggerCrossClick), 0);
            Button temp = (Button)sender;
            NameSelected.Text = temp.Text;
            count++;
            NameSelected.Font = new Font(new FontFamily("Segoe UI"), 8);
            NameSelected.CrossSizeCorrection = -5;
            NameSelected.CrossOffset = new Point(-2, 0);
            NameSelected.Padding = new Padding(3, 4, 3, 3);
            NameFinalPanel.Controls.Add(NameSelected);
            int index = GroupNumberedString.FindIndex(t => t.Item3 == NameSelected.Text);
            FinalString.Add(new Tuple<int, int, string>(GroupNumberedString[index].Item1, GroupNumberedString[index].Item2, GroupNumberedString[index].Item3));
        }

        private void Done_Click(object sender, EventArgs e) {
            FinalUserNameFormat = "";
            foreach (Tuple<int, int, string> a in FinalString) {
                if (a.Item1 == 0) {
                    FinalUserNameFormat += a.Item3;
                } else {
                    FinalUserNameFormat += "?" + a.Item1 + "?";
                }
            }
            Close();
        }

        private void UserInputName_Click(object sender, EventArgs e) {
            Tagger NameSelected = new Tagger(new TaggerOnSelectChange(TaggerSelectChange), new TaggerOnCrossClick(TaggerCrossClick), 1);
            UserStringPopUp NameString = new UserStringPopUp();
            NameString.ShowDialog();
            if (NameString.UserString == null || NameString.UserString.Length == 0) {
                return;
            }
            NameSelected.Text = NameString.UserString;
            count++;
            NameSelected.Font = new Font(new FontFamily("Segoe UI"), 8);
            NameSelected.CrossSizeCorrection = -5;
            NameSelected.CrossOffset = new Point(-2, 0);
            NameSelected.Padding = new Padding(3, 4, 3, 3);
            NameFinalPanel.Controls.Add(NameSelected);
            FinalString.Add(new Tuple<int, int, string>(0, 1, NameSelected.Text));
            NameString.Close();
        }

        private void OKButton_Click(object sender, EventArgs e) {
            Tagger AddSelected = new Tagger(new TaggerOnSelectChange(TaggerSelectChange), new TaggerOnCrossClick(TaggerCrossClick), 1);
            AddSelected.Text = "|" + AttributeDropDown.SelectedItem.ToString() + "|";
            count++;
            AddSelected.Font = new Font(new FontFamily("Segoe UI"), 8);
            AddSelected.CrossSizeCorrection = -5;
            AddSelected.CrossOffset = new Point(-2, 0);
            AddSelected.Padding = new Padding(3, 4, 3, 3);
            NameFinalPanel.Controls.Add(AddSelected);
            FinalString.Add(new Tuple<int, int, string>(0, 1, AddSelected.Text));
        }
    }
}
