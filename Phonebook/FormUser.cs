using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phonebook
{
    public partial class FormUser : Form
    {
        public User user = new User();

        Form1 form;
        public FormUser()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        public FormUser(string imie, string nazwisko, string numer, string email)
        {
            InitializeComponent();
            tbImie.Text = imie;
            tbNazwisko.Text = nazwisko;
            tbNumer.Text = numer;
            tbEmail.Text = email;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            user.FirstName = tbImie.Text;
            user.LastName = tbNazwisko.Text;
            user.Phone = tbNumer.Text;
            user.Email = tbEmail.Text;
            Close();
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MailAddress mail = new MailAddress(tbEmail.Text);
                button1.Enabled = true;
            }
            catch
            {
                button1.Enabled = false;
            }
        }

        private void tbNumer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void tbNumer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Regex.IsMatch(tbNumer.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    tbNumer.Text = string.Empty;
                }
                button1.Enabled = true;
            }
            catch
            {
                button1.Enabled = false;
            }
        }

        private void tbImie_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            if(tbImie.Text == string.Empty)
            {
                button1.Enabled=false;
            }
        }

        private void tbNazwisko_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            if (tbNazwisko.Text == string.Empty)
            {
                button1.Enabled = false;
            }
        }
    }
}
