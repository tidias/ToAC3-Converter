using System.Windows.Forms;

namespace ToAC3
{
    public partial class AudioStreams : Form
    {
        public AudioStreams()
        {
            InitializeComponent();
        }

        private void AdvancedOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
