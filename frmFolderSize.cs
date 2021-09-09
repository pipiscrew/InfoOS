using System;
using System.IO;
using System.Windows.Forms;

namespace InfoOS
{
    public partial class frmFolderSize : Form
    {
        public frmFolderSize()
        { //https://docs.microsoft.com/en-us/dotnet/api/system.environment.specialfolder

            InitializeComponent();

        }

        private long GetDirectorySize(string dirPath)
        { //https://stackoverflow.com/a/62143304
            if (Directory.Exists(dirPath) == false)
            {
                return 0;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);

            long size = 0;

            // Add file sizes.
            FileInfo[] fis = dirInfo.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }

            // Add subdirectory sizes.
            DirectoryInfo[] dis = dirInfo.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                try
                {
                    size += GetDirectorySize(di.FullName);
                }
                catch (Exception d)
                {

                    txtLog.AppendText(d.Message + "\r\n");
                }
            }

            return size;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstv.Items.Count > 0)
                lstv.Items.Clear();

            Cursor = System.Windows.Forms.Cursors.WaitCursor;

            string[] dirs = new string[] {
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Path.GetFullPath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"..\")),
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                Environment.GetFolderPath(Environment.SpecialFolder.System),
                Environment.GetFolderPath(Environment.SpecialFolder.SystemX86)
            };

            foreach (string item in dirs)
            {
                string size = General.FormatBytes(GetDirectorySize(item));

                ListViewItem l = new ListViewItem(item);

                l.SubItems.Add(size);

                lstv.Items.Add(l);
            }

            Cursor = System.Windows.Forms.Cursors.Default;
        }

        //https://stackoverflow.com/a/22111211
        //long sizeInBytes = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories).Sum(fileInfo => new FileInfo(fileInfo).Length);
    }
}
