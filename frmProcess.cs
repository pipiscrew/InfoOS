using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace InfoOS
{
    public partial class frmProcess : Form
    {
        public frmProcess()
        {
            InitializeComponent();

            var h = Process.GetProcesses().GroupBy(x => x.ProcessName).Select(g => g.First()).Select(t => new
            {
                name = t.ProcessName,
                total = (from p in Process.GetProcesses()
                         where p.ProcessName.Equals(t.ProcessName)
                         select p.PrivateMemorySize64).Count(),
                totalSize = General.FormatBytes((from p in Process.GetProcesses()
                                                 where p.ProcessName.Equals(t.ProcessName)
                                                 select p.PrivateMemorySize64).Sum())
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstv.Items.Count > 0)
                lstv.Items.Clear();

            Cursor = System.Windows.Forms.Cursors.WaitCursor;

            var h = Process.GetProcesses().GroupBy(x => x.ProcessName).Select(g => g.First()).Select(t => new
            {
                name = t.ProcessName,
                total = (from p in Process.GetProcesses()
                         where p.ProcessName.Equals(t.ProcessName)
                         select p.PrivateMemorySize64).Count(),
                totalSize = (from p in Process.GetProcesses()
                             where p.ProcessName.Equals(t.ProcessName)
                             select p.PrivateMemorySize64).Sum()
            }).OrderByDescending(x => x.totalSize);

            long totalMem = 0;
            int total = 0;
            foreach (var item in h)
            {
                totalMem += item.totalSize;
                total += item.total;
                ListViewItem l = new ListViewItem(item.name);

                l.SubItems.Add(General.FormatBytes(item.totalSize).ToString());
                l.SubItems.Add(item.total.ToString());

                lstv.Items.Add(l);
            }

            lstv.Columns[3].Text = string.Format("{0} in {1} processes", General.FormatBytes(totalMem), total);
            this.Text = General.FormatBytes(totalMem);

            Cursor = System.Windows.Forms.Cursors.Default;
        }
    }
}
