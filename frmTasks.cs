using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoOS
{
    public partial class frmTasks : Form
    {
        public frmTasks()
        {
            InitializeComponent();
        }
        private static Regex lineRegex = new Regex("\\s*(\\\"(?<item>[^\\\"]*)\\\"|(?<item>[^,]*))\\s*,?", RegexOptions.Compiled);
        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.WaitCursor;

            lstv.Items.Clear();

            string j = RunAndGetOutput("schtasks.exe", "/query /fo csv");
            
            if (string.IsNullOrEmpty(j))
                return;

            Regex r = new Regex("\r\n", RegexOptions.Compiled);

            string[] res = r.Split(j);

            string header = null;
            foreach (string item in res)
            {
                if (header == null)
                    header = item;
                else if (item.Equals(header))
                    continue;
                else
                    GetTaskLines(item);
            }

            Cursor = System.Windows.Forms.Cursors.Default;
        }

        internal void GetTaskLines(string line)
        {
            ListViewItem l = new ListViewItem();

            foreach (Match m in lineRegex.Matches(line))
            {
                string v = m.Groups["item"].Value.Trim();
                if (string.IsNullOrEmpty(v))
                    continue;

                if (string.IsNullOrEmpty(l.Text))
                    l.Text = v;
                else
                    l.SubItems.Add(v);
            }

            if (l.Text.Length > 0)
                lstv.Items.Add(l);
        }

        public static string RunAndGetOutput(string pathName, string arg)
        {

            ProcessStartInfo psi = new ProcessStartInfo(pathName);
            psi.RedirectStandardOutput = true;
            psi.Arguments = arg;
            psi.CreateNoWindow = false; //when rum as guest possible needed to close the window manually!!
            psi.StandardOutputEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage);
            psi.UseShellExecute = false;
            String returnvalue;
            using (Process runningProcess = Process.Start(psi))
            {
                runningProcess.WaitForExit();
                using (StreamReader OutReader = runningProcess.StandardOutput)
                {
                    return OutReader.ReadToEnd();
                }
            }
            //      return returnvalue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //start task scheduler
            Process.Start("taskschd.msc");
        }

    }
}
