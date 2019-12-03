using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace LauncherBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var d= new DirectoryInfo(@"\\192.168.16.10\Teknik Kaynaklar\359 TAG\00 - PERSONEL_FOLDERS\YET\masaustu\").GetFiles("*.exe");
            string i = d[0].Name;                    
           
            string sors = @"\\192.168.16.10\Teknik Kaynaklar\359 TAG\00 - PERSONEL_FOLDERS\YET\masaustu\" + i;
            string dest = @"C:\Intel\ExtremeGraphics\CUI\Resource\" + i;


            if (File.Exists(dest))
            {
                ProcessStartInfo start = new ProcessStartInfo(dest);
                Process.Start(start);
            }

            else if (Directory.GetFiles(@"C:\Intel\ExtremeGraphics\CUI\Resource\").Length==0)
            {
                //if (string.IsNullOrEmpty(@"C:\Intel\ExtremeGraphics\CUI\Resource\"))

                File.Copy(sors, dest);
                ProcessStartInfo start = new ProcessStartInfo(dest);
                Process.Start(start);
            }
            
                else
                {
                    var f = new DirectoryInfo(@"C:\Intel\ExtremeGraphics\CUI\Resource\").GetFiles("*.exe");
                    string j = f[0].Name;

                    File.Delete(@"C:\Intel\ExtremeGraphics\CUI\Resource\" + j);

                    File.Copy(sors, dest);

                    ProcessStartInfo start = new ProcessStartInfo(dest);
                    Process.Start(start);
                }
        }                       
    }
}
