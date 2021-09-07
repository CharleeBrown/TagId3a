using System;
using System.IO;
using System.Windows.Forms;

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
            //saveDataBtn.Enabled = false;
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
        /*
         * The function below receives the path from the third column
         * and writes the information to the file and then saves the file.
         */
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                var tFile = TagLib.File.Create(item.SubItems[3].Text);
                tFile.Tag.Album = albumBox.Text;
                tFile.Tag.Title = titleBox.Text;
                tFile.Tag.Performers = new string[] { artistBox.Text };
                //pathBox.Text = item.SubItems[3].Text;
                tFile.Save();
                

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

}


