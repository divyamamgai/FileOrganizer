using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TaggerControl;

namespace TaggerControlTest {
    public partial class Main : Form {
        public string[] TaggerList = { "Detective Conan", "Alphabets", "Digits", "String" };
        public List<Tagger> TaggerContols = new List<Tagger>();
        public void TaggerSelectChange(object tagger, bool selected) {
            Tagger TaggerObject = (Tagger)tagger;
            short i = 0;
            for (; i < 4; i++) if (TaggerContols[i].ID != TaggerObject.ID) TaggerContols[i].DeSelectTagger();
        }
        public void TaggerCrossClick(object tagger) {
            Tagger TaggerObject = (Tagger)tagger;
            DialogResult PerformRemove = MessageBox.Show("Do you really want to remove " + TaggerObject.Text + " tag?", "Remove Tag", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (PerformRemove == DialogResult.Yes) {
                TaggerObject.Dispose();
            }
        }
        public Main() {
            InitializeComponent();
            short i = 0;
            for (; i < 4; i++) {
                Tagger tagger = new Tagger(new TaggerOnSelectChange(TaggerSelectChange), new TaggerOnCrossClick(TaggerCrossClick), i);
                tagger.Text = TaggerList[i];
                tagger.Font = new Font(new FontFamily("Segoe UI"), 8);
                // Correction for Segoe UI
                tagger.CrossSizeCorrection = -5;
                tagger.CrossOffset = new Point(-2, 0);

                tagger.Padding = new Padding(3, 4, 3, 3);
                TagFlowPanel.Controls.Add(tagger);
                TaggerContols.Add(tagger);
            }            
        }
    }
}
