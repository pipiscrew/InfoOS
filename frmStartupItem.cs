using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InfoOS
{
    public partial class frmStartupItem : Form
    {
        string userStartup;
        string alluserStartup;

        public frmStartupItem()
        {
            InitializeComponent();

            userStartup = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\";
            alluserStartup = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup) + "\\";

            ScanRegistryLocations();
            ScanStartUpFolders();
        }

        internal void ScanRegistryLocations()
        {
            IterateRegistryKey(RegistryHive.LocalMachine, RegistryView.Registry64, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Runonce\");
            IterateRegistryKey(RegistryHive.LocalMachine, RegistryView.Registry64, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer\Run\");
            IterateRegistryKey(RegistryHive.LocalMachine, RegistryView.Registry64, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\");
            IterateRegistryKey(RegistryHive.CurrentUser, RegistryView.Registry64, @"Software\Microsoft\Windows NT\CurrentVersion\Windows\Run\");
            IterateRegistryKey(RegistryHive.CurrentUser, RegistryView.Registry64, @"Software\Microsoft\Windows\CurrentVersion\Run\");
            IterateRegistryKey(RegistryHive.CurrentUser, RegistryView.Registry64, @"Software\Microsoft\Windows\CurrentVersion\RunOnce\");

        }

        internal void IterateRegistryKey(RegistryHive root, RegistryView architecture, string baseKey)
        {
            RegistryKey key = RegistryKey.OpenBaseKey(root, architecture).OpenSubKey(baseKey);
            if (key == null)
                return;
             
            //foreach (var v in key.GetSubKeyNames()){
            foreach (var v in key.GetValueNames())
            {
                ListViewItem l = new ListViewItem(v);

                string fl = null;
                if (key.GetValue(v) == null)
                    continue;
                else
                    fl = key.GetValue(v).ToString();

                string iconExtract = GetFilepath(fl).ToLower();

                if (iconExtract.EndsWith(".exe") || iconExtract.EndsWith(".com"))
                {
                    if (File.Exists(iconExtract))
                    {
                        Icon icon = Icon.ExtractAssociatedIcon(iconExtract);
                        imgL.Images.Add(icon);
                        l.ImageIndex = imgL.Images.Count - 1;
                    }
                }
                
                l.SubItems.Add(fl);
                l.SubItems.Add(root.ToString() + "\\" + baseKey);

                //add to lstv
                lstv.Items.Add(l);
            }

        }

        internal string GetFilepath(string fl)
        {
            Regex x = new Regex("^\"(.*)\"",RegexOptions.Compiled);

            MatchCollection m = x.Matches(fl);

            if (m.Count > 0)
                return (m[0].Groups[1].Value);
            else
                return fl;
        }

        internal void ScanStartUpFolders()
        {
            if (Directory.Exists(userStartup))
            {
                ScanFolder(userStartup);
            }

            if (Directory.Exists(alluserStartup))
            {
                ScanFolder(alluserStartup);
            }           
        }

        internal void ScanFolder(string path)
        {
            var files = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories);

            foreach (var item in files)
            {
                string fl = item;

                if (fl.ToLower().EndsWith(".ini"))
                    continue;

                ListViewItem l = new ListViewItem(Path.GetFileName(fl));

                //cion
                Icon icon = Icon.ExtractAssociatedIcon(fl);
                imgL.Images.Add(icon);
                l.ImageIndex = imgL.Images.Count - 1;

                //sub cols
                l.SubItems.Add(fl);
                l.SubItems.Add(Path.GetDirectoryName(fl));

                //add to lstv
                lstv.Items.Add(l);
            }
          
        }

        private void toolStripCopyTarget_Click(object sender, EventArgs e)
        {
            if (lstv.SelectedItems.Count == 0)
                return;

            General.Copy2Clipboard(lstv.SelectedItems[0].Text.ToStrinX());
        }

        private void toolStripFilepath_Click(object sender, EventArgs e)
        {
            if (lstv.SelectedItems.Count == 0)
                return;

            General.Copy2Clipboard(lstv.SelectedItems[0].SubItems[1].Text.ToStrinX());
        }

        private void toolStripLocation_Click(object sender, EventArgs e)
        {
            if (lstv.SelectedItems.Count == 0)
                return;

            General.Copy2Clipboard(lstv.SelectedItems[0].SubItems[2].Text.ToStrinX());
        }

        private void toolStripCopyAll_Click(object sender, EventArgs e)
        {
            if (lstv.SelectedItems.Count == 0)
                return;

            var d = lstv.Items.Cast<ListViewItem>()
                                  .Select(item => item.SubItems[1].Text.ToStrinX() + " | " + item.SubItems[2].Text.ToStrinX());

            General.Copy2Clipboard(string.Join("\r\n", d));
        }


        /// <summary>Opens RegEdit to the provided key
        /// <para><example>@"Computer\HKEY_CURRENT_USER\Software\MyCompanyName\MyProgramName\"</example></para>
        /// </summary>
        /// <param name="FullKeyPath"></param>
        //public static void OpenToKey(string FullKeyPath)
        //{ //https://stackoverflow.com/a/14417603
        //    RegistryKey rKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Applets\Regedit", true);
        //    rKey.SetValue("LastKey", FullKeyPath);

        //    Process.Start("regedit.exe");
        //}

    
    }
}
