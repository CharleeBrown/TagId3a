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
            listView1.Columns.Add("Path");
            listView1.View = View.Details;
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

                        // MessageBox.Show(tFile.Name.Substring(0, 20));
                        string name = info.Name;
                        var results = name.Split(new string[] { " - ", ".m4a" }, StringSplitOptions.RemoveEmptyEntries);
                       
                       // tFile.Tag.Comment = results[1];
                        info = results[1];
                        tFile.Save();
                        //string pattern = @"[aeiotu]_[a-z]";
                        //Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
                        //r.Match(results[1].ToString());
                        //foreach (Match mat in r.Matches(name))
                        //{
                        //    mat.Value.Replace("_", "'");
                        //    MessageBox.Show(mat.Value.Replace("_", "'").ToString());
                        //    MessageBox.Show(mat.Value);
                        //   // tFile.Tag.Comment = newMat;
                        //    //tFile.Save();
                        //}




                        //tFile.Tag.Album = "Persona 4 OST";

                        // tFile.Tag.Track = 0;

                        //tFile.Tag.Track = Convert.ToUInt32(Convert.ToString(info.Name[16]) + Convert.ToString(info.Name[17]));

                        //MessageBox.Show(info.Name);
                        //MessageBox.Show(tFile.Tag.Album.ToString());
                        //ListViewItem item = new ListViewItem(tFile.Tag.Title);
                        //item.SubItems.Add(tFile.Tag.Album);
                        //item.SubItems.Add(Path.GetFullPath(info.FullName));
                        //listView1.Items.Add(item);
                        //tFile.Save();

                        // listView1.Items.Add(new ListItem { Name = tFile.Tag.Title, Album = tFile.Tag.Album,Value=Path.GetFullPath(info.FullName) });

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

}
