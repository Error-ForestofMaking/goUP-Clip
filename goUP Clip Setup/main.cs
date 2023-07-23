using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace goUP_Clip_Setup
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            string folderPath = @"C:\goUP";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                MessageBox.Show("폴더를 만들었습니다");
            }
            folderPath = @"C:\goUP\Clip";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                MessageBox.Show("폴더를 만들었습니다");
            }



            MessageBox.Show("프로그램 파일을 만들었습니다");
            MessageBox.Show("설치가 완료되었습니다");
            MessageBox.Show("삭제를 원하는경우\nC:\\goUP\\Clip\\Clip.exe를\n삭제해 주세요","삭제 안내");
        }
    }
}
