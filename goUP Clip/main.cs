using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace goUP_Clip
{
    public partial class main : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        //
        private Point mCurrentPosition = new Point(0, 0);
        int miniloca = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Size.Height) - 30;
        //

        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            int ro = 30;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, ro, ro));

            textbox.Text = Properties.Settings.Default.textdata;

            Properties.Settings.Default.textload = true;
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.textload == true)
            {
                Properties.Settings.Default.textdata = textbox.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void title_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mCurrentPosition = new Point(-e.X, -e.Y);
            }
        }

        private void title_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Location.Y + (mCurrentPosition.Y + e.Y) > miniloca - 50)
                {
                    Location = new Point(Location.X + (mCurrentPosition.X + e.X), miniloca);
                }
                else
                {
                    Location = new Point(Location.X + (mCurrentPosition.X + e.X), Location.Y + (mCurrentPosition.Y + e.Y));
                }
            }
        }

        private void 다크모드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (다크모드ToolStripMenuItem.Checked == false)
            {
                textbox.BackColor = Color.White;
                textbox.ForeColor = Color.Black;

                this.BackColor = Color.White;

                //contextMenuStrip.BackColor = Color.White;
                //contextMenuStrip.ForeColor = Color.Black;
            }
            else
            {
                textbox.BackColor = Color.Black;
                textbox.ForeColor = Color.White;

                this.BackColor = Color.Black;

                //contextMenuStrip.BackColor = Color.Black;
                //contextMenuStrip.ForeColor = Color.White;
            }
        }

        private void 정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("버전 : 1.0\n개인 사용자용");
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
