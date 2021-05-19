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
    public partial class PasswordBaseForm : Form
    {
        protected User user;
        public PasswordBaseForm()
        {
            InitializeComponent();
        }

        public PasswordBaseForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void generationButton_Click(object sender, EventArgs e)
        {

        }
    }
}
