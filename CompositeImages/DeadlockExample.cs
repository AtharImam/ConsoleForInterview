using System;
using System.Drawing;
using System.Windows.Forms;

namespace CompositeImages
{
    public partial class DeadlockExample : Form
    {
        Button btn = new Button() { Text = "Download Text", Size = new Size(200, 100), Location=new Point(400,400) };
        public DeadlockExample()
        {
            InitializeComponent();
            btn.Click += Btn_Click;
            this.Controls.Add(btn);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private string DownloadUrl()
        {
            return "";
        }
    }
}
