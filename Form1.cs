using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagEdit.Properties;
using TagLib.Id3v1;
using System.IO;
using TagLib.Id3v2; 
using System.Windows.Forms;
using System.Windows.Documents;

namespace TagEdit
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {               
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                   
                    foreach (var file in Directory.GetFiles(dialog.SelectedPath))
                    {
                        var tFile = TagLib.File.Create(file);
                        var info = new FileInfo(file.ToString());

                        MessageBox.Show(info.Name);
                        MessageBox.Show(tFile.Tag.Album.ToString());
                    }
                }
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }

}
