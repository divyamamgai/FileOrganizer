using System.Windows.Forms;

namespace AboutUs
{
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();
            VersionLabel.Text = Application.ProductVersion;
        }
    }
}
