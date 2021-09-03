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
       // var results = name.Split(new string[] { " - ", ".m4a" }, StringSplitOptions.RemoveEmptyEntries);
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



        // MessageBox.Show(tFile.Name.Substring(0, 20));
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


