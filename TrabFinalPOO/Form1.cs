using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabFinalPOO.Source;

namespace TrabFinalPOO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void P_Click(object sender, EventArgs e)
        {
            this.Hide();
            CretateCustomer cs = new CretateCustomer();
            cs.Show();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            if(email == "" || password == "")
            {
                MessageBox.Show("É necessário informar o e-mail e a senha para encontrar o cliente");
                return;
            }
            

            try
            {
                Customer customer = File.SearchCustomerFileByEmailAndPassword(email,password);
                this.Hide();
                DetailCustomer cs = new DetailCustomer(customer);
                cs.Show();
                // Abrir a página de detalhes
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
