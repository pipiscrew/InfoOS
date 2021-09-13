using System.Windows.Forms;
using System.Drawing;

namespace InfoOS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            this.Text = Application.ProductName + " v" + Application.ProductVersion;
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            addform2tabpage(new frmStartupItem(), tabStartup);
            addform2tabpage(new frmProcess(), tabProcesses);
            addform2tabpage(new frmFolderSize(), tabFolderSizes);
            addform2tabpage(new frmFramework(), tabFrameworks);
            addform2tabpage(new frmTasks(), tabTasks);
        }

        internal void addform2tabpage(Form frm, TabPage tab)
        {
            frm.TopLevel = false;
            frm.Visible = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            tab.Controls.Add(frm);
        }
    }
}
