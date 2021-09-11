using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoOS
{
    public partial class frmFramework : Form
    {
        //https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed
        // for the history - https://github.com/justin0522/FrameworkDetect

        public frmFramework()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstv.Items.Clear();
            GetFrmRegistry();
        }

        internal void GetFrmRegistry()
        {  // https://github.com/jmalarcon/DotNetVersions
            using (RegistryKey ndpKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                {
                    if (versionKeyName.StartsWith("v"))
                    {

                        RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                        string name = (string)versionKey.GetValue("Version", "");
                        string sp = versionKey.GetValue("SP", "").ToString();

                        string install = versionKey.GetValue("Install", "").ToString();
                        if (!string.IsNullOrEmpty(install))
                        {
                            if (!(string.IsNullOrEmpty(sp)) && install == "1")
                            {
                                AddItem(name, sp);
                            }
                        }
                        if (!string.IsNullOrEmpty(name))
                        {
                            continue;
                        }
                        foreach (string subKeyName in versionKey.GetSubKeyNames())
                        {
                            RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                            name = (string)subKey.GetValue("Version", "");
                            if (!string.IsNullOrEmpty(name))
                                sp = subKey.GetValue("SP", "").ToString();

                            install = subKey.GetValue("Install", "").ToString();
                            if (!string.IsNullOrEmpty(install))
                            {
                                if (!(string.IsNullOrEmpty(sp)) && install == "1")
                                {
                                    AddItem(name + string.Format(" ({0})", subKeyName), sp);
                                }
                                else if (install == "1")
                                {
                                    AddItem(name + string.Format(" ({0})", subKeyName));
                                }
                            }
                        }
                    }
                }
            }
        }


        internal void AddItem(string col1, string col23 = "-")
        {
            ListViewItem l = new ListViewItem("v" + col1);
            l.SubItems.Add(col23);

            lstv.Items.Add(l);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/jmalarcon/DotNetVersions");
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                 ctx.Show(System.Windows.Forms.Cursor.Position);
            }
        }

        private void toolStripCopy_Click(object sender, EventArgs e)
        {
            General.Copy2Clipboard(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP");
        }
    }
}
