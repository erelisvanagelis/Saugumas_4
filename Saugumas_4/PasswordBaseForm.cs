using Saugumas_4.Models;
using Saugumas_4.Utilities;
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
            try
            {
                user.AddPassword(new PasswordEntry(
                    titleTextBox.Text, passwordTextBox.Text, urlTextBox.Text, commentTextBox.Text));

                MessageBox.Show("Pavyko pridėti slaptažodį");
                ClearFields();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void generationButton_Click(object sender, EventArgs e)
        {
            passwordTextBox.Text = EncryptionTool.GeneratePassword();
        }

        protected void ClearFields()
        {
            titleTextBox.Text = "";
            passwordTextBox.Text = "";
            urlTextBox.Text = "";
            commentTextBox.Text = "";
        }
    }
}
