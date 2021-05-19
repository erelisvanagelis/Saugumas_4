using Saugumas_4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saugumas_4
{
    public partial class ManagementForm : Form
    {
        private User user;
        public ManagementForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void addPasswordButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            Form form = new PasswordBaseForm() { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            flowLayoutPanel1.Controls.Add(form);
            form.Show();
        }

        private void manageButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            Form form = new PasswordManagementForm() {TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            flowLayoutPanel1.Controls.Add(form);
            form.Show();
        }
    }
}
