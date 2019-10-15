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

namespace Replace
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                var fromText = FromTextBox.Text;
                var toText = ToTextBox.Text;
                var folderPath = FolderTextBox.Text;
                var extension = ExtensionTextBox.Text;

                var folder = new DirectoryInfo(folderPath);
                var files = folder.GetFiles(extension, SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    var content = File.ReadAllText(file.FullName);

                    content = content.Replace(fromText, toText);

                    File.WriteAllText(file.FullName, content);
                }

                MessageBox.Show("操作完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
