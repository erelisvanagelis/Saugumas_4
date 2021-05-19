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
    public partial class RegistrationLoginForm : Form
    {
        public RegistrationLoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User(nameTextBox.Text, passwordTextBox.Text);
                FileManager fileManager = new FileManager();
                fileManager.Register(user);

                MessageBox.Show("Pavyko prisiregistruoti");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                MessageBox.Show(exc.Message);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                FileManager fileManager = new FileManager();
                string[] data = fileManager.ReadFile(nameTextBox.Text + ".txt");
                User user = UserStringConverter.GetStringToUser(data);
                if (user.GetAccountPassword() != passwordTextBox.Text)
                    throw new Exception("Slaptazodziai nesutampa");

                Console.WriteLine(user.ToString());
                Form form = new ManagementForm(user);
                form.ShowDialog();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
