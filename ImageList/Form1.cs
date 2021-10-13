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

namespace ImageList
{
    public partial class Form1 : Form
    {
        int selected;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void abrirPastaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            FileInfo fileInfo; 
            if(folderBrowser.ShowDialog()==DialogResult.OK)
            {
                int count = 0;

                foreach (string item in Directory.GetFiles(folderBrowser.SelectedPath))
                {
                    fileInfo = new FileInfo(item);
                    if(fileInfo.Extension==".png")
                    {
                        imageList1.Images.Add(Image.FromFile(item));
                        listView1.Items.Add(item.Substring(item.LastIndexOf("\\")+1),count);
                        count++;
                    }
                }
                    
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            selected = listView1.SelectedItems[0].Index;
            pictureBox1.Image = imageList1.Images[selected];
        }
    }
}
