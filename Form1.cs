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
using System.Web;
using System.Text.RegularExpressions;
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
            listView1.Columns.Add("Title");
            listView1.Columns.Add("Album");
            listView1.Columns.Add("Extension");
            listView1.Columns.Add("Path");
            listView1.Columns[0].Width = 200;
            listView1.Columns[1].Width = 110;
            listView1.Columns[2].Width = 90;
            listView1.View = View.Details;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
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
                        string name = info.Name;
                        ListViewItem item = new ListViewItem(tFile.Tag.Title);
                        item.SubItems.Add(tFile.Tag.Album);
                        item.SubItems.Add(info.Extension);
                        item.SubItems.Add(Path.GetFullPath(file));
                        listView1.Items.Add(item);


                    }
                }
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                
                var tFile = TagLib.File.Create(item.SubItems[3].Text);
                albumBox.Text = tFile.Tag.Album.ToString();
                titleBox.Text = tFile.Tag.Title.ToString();
                artistBox.Text = tFile.Tag.Performers.ToString();
                pathBox.Text = item.SubItems[3].Text;
            }
        }
    }

    public class ListItem
    {
        public string Name;
        public string Album;
        public string Value;

        public override string ToString()
        {
            return Name;
        }
    }
    public class ChangeData
    {
        public void SaveChange()
        {
            // 
        }

    }
}


