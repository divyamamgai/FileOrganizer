using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaggerControl {
    public struct TaggerFlags {
        public bool Initialized, Hover, Selected, CrossHover, CrossSelected;
    };
    public delegate void TaggerOnSelectChange(object tagger, bool selected);
    public delegate void TaggerOnCrossClick(object tagger);
    public partial class Tagger : Control {
        Size SizeOfTagger;
        Rectangle BorderRectangle, CrossRectangle, CrossOverlayRectangle;
        public TaggerFlags Flags;
        public SolidBrush NormalBackground, HoverBackground, SelectedBackground, FontColor, CrossBackground, CrossHoverBackground, CrossSelectedBackground;
        public Pen NormalBorder, HoverBorder, SelectedNormalBorder, SelectedHoverBorder;
        public Point CrossOffset;
        public int CrossSizeCorrection, ID;
        public bool CrossFillOnTop;
        public TaggerOnSelectChange OnSelectChange;
        public TaggerOnCrossClick OnCrossClick;
        public Tagger(TaggerOnSelectChange onSelectChange, TaggerOnCrossClick onCrossClick, int id = -1) {
            // Somehow is needed if you want to set the Size according to the text.
            Width = 1;
            Height = 1;
            Flags.Hover = false;
            Flags.Selected = false;
            Flags.Initialized = false;
            NormalBackground = new SolidBrush(Color.FromArgb(144, 202, 249));
            HoverBackground = new SolidBrush(Color.FromArgb(187, 222, 251));
            SelectedBackground = new SolidBrush(Color.FromArgb(174, 213, 129));
            FontColor = new SolidBrush(Color.FromArgb(0, 0, 0));
            CrossBackground = new SolidBrush(Color.FromArgb(220, 198, 40, 40));
            CrossHoverBackground = new SolidBrush(Color.FromArgb(255, 229, 57, 53));
            CrossSelectedBackground = new SolidBrush(Color.FromArgb(255, 183, 28, 28));
            NormalBorder = new Pen(new SolidBrush(Color.FromArgb(25, 118, 210)), 2);
            HoverBorder = new Pen(new SolidBrush(Color.FromArgb(66, 165, 245)), 2);
            SelectedNormalBorder = new Pen(new SolidBrush(Color.FromArgb(85, 139, 47)), 2);
            SelectedHoverBorder = new Pen(new SolidBrush(Color.FromArgb(124, 179, 66)), 2);
            CrossOffset = new Point(-1, 0);
            CrossSizeCorrection = -3;
            CrossFillOnTop = false;
            OnSelectChange = onSelectChange;
            OnCrossClick = onCrossClick;
            ID = id < 0 ? new Random().Next() : id;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe) {
            // No need to initialize again and again.
            if (!Flags.Initialized) {
                SizeOfTagger = pe.Graphics.MeasureString(Text, Font).ToSize();
                CrossRectangle = new Rectangle(0, 0, SizeOfTagger.Height + CrossSizeCorrection, SizeOfTagger.Height + CrossSizeCorrection);
                SizeOfTagger.Width += Padding.Left + Padding.Right + 15 - CrossSizeCorrection;
                SizeOfTagger.Height += Padding.Top + Padding.Bottom;
                Width = SizeOfTagger.Width;
                Height = SizeOfTagger.Height;
                CrossRectangle.X = Width - Padding.Right - CrossRectangle.Width + CrossOffset.X;
                CrossRectangle.Y = Convert.ToInt16((Height - CrossRectangle.Height) / 2) + CrossOffset.Y;
                CrossOverlayRectangle = new Rectangle(CrossRectangle.X - 3, 0, Width - CrossRectangle.X + 3, Height);
                BorderRectangle = new Rectangle(1, 1, Width - Convert.ToInt16(NormalBorder.Width), Height - Convert.ToInt16(NormalBorder.Width));
                Flags.Initialized = true;
            }
            pe.Graphics.FillRectangle(Flags.Selected ? SelectedBackground : Flags.Hover ? HoverBackground : NormalBackground, 0, 0, Width, Height);
            pe.Graphics.DrawRectangle(Flags.Selected ? Flags.Hover ? SelectedHoverBorder : SelectedNormalBorder : Flags.Hover ? HoverBorder : NormalBorder, BorderRectangle);
            pe.Graphics.DrawString(Text, Font, FontColor, Padding.Left, Padding.Top);
            if (CrossFillOnTop) {
                pe.Graphics.DrawImage(Properties.Resources.CrossRed, CrossRectangle);
                pe.Graphics.FillRectangle(Flags.CrossSelected ? CrossSelectedBackground : Flags.Hover ? Flags.CrossHover ? CrossHoverBackground : CrossBackground : CrossBackground, CrossOverlayRectangle);
            } else {
                pe.Graphics.FillRectangle(Flags.CrossSelected ? CrossSelectedBackground : Flags.Hover ? Flags.CrossHover ? CrossHoverBackground : CrossBackground : CrossBackground, CrossOverlayRectangle);
                pe.Graphics.DrawImage(Properties.Resources.CrossRed, CrossRectangle);
            }
            if (Flags.CrossSelected) Flags.CrossSelected = false;
            base.OnPaint(pe);
        }
        protected override void OnMouseEnter(EventArgs e) {
            Flags.Hover = true;
            base.OnMouseEnter(e);
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e) {
            Flags.Hover = false;
            base.OnMouseEnter(e);
            Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e) {
            if (e.X >= CrossOverlayRectangle.X) {
                if (!Flags.CrossHover) {
                    Flags.CrossHover = true;
                    Invalidate();
                }
            } else if (Flags.CrossHover) {
                Flags.CrossHover = false;
                Invalidate();
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseClick(MouseEventArgs e) {
            if (Flags.CrossHover) {
                Flags.CrossSelected = !Flags.CrossSelected;
                OnCrossClick(this);
            } else {
                Flags.Selected = !Flags.Selected;
                OnSelectChange(this, Flags.Selected);
            }
            base.OnMouseClick(e);
            Invalidate();
        }
        public void SelectTagger() {
            if (!Flags.Selected) {
                Flags.Selected = true;
                Invalidate();
            }
        }
        public void DeSelectTagger() {
            if (Flags.Selected) {
                Flags.Selected = false;
                Invalidate();
            }
        }
    }
}
