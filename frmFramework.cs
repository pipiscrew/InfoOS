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
                                string release = subKey.GetValue("Release", "").ToString();
                                if (release.Length > 0)
                                    release = "rel" + release;

                                if (!(string.IsNullOrEmpty(sp)) && install == "1")
                                {
                                    AddItem(name + string.Format(" ({0}) rel{1}", subKeyName, release), sp);
                                }
                                else if (install == "1")
                                {
                                    AddItem(name + string.Format(" ({0}) {1}", subKeyName, release));
                                }
                            }
                        }
                    }
                }
            }

            /*  refs :
                https://www.reddit.com/r/TronScript/comments/9fufo7/suggestion_to_executequeueditems_for_net/
                https://appuals.com/fix-high-cpu-usage-by-net-runtime-optimization-service/
                https://kb.vmware.com/s/article/2069188
                explained - https://www.pipiscrew.com/2021/09/net-runtime-optimization-service-to-improve-performance/
            */

            int x86=0, x64 = 0;
            using (RegistryKey ndpKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\.NETFramework\NGenQueue\WIN32\Default\"))
            {
                if (ndpKey != null)
                    x86 = ndpKey.GetSubKeyNames().Count();
            }
            using (RegistryKey ndpKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\.NETFramework\NGenQueue\WIN64\Default\"))
            {
                if (ndpKey!=null)
                    x64 = ndpKey.GetSubKeyNames().Count();
            }

            string info = ".NET Runtime Optimization Service needed to run for :\r\n\r\n";
            if (x86 > 0)
            {
                info += string.Format(@"x86 ({0} items waiting)
cd /d C:\Windows\Microsoft.NET\Framework\v4.0.30319
ngen.exe executeQueuedItems

", x86);
            }
            if (x64 > 0)
            {
                info += string.Format(@"x64 ({0} items waiting)
cd /d C:\Windows\Microsoft.NET\Framework64\v4.0.30319
ngen.exe executeQueuedItems", x64);
            }

            if (x86 > 0 || x64 > 0)
                MessageBox.Show(info, Application.ProductName, MessageBoxButtons.OK,MessageBoxIcon.Information);
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
