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
    public partial class CretateCustomer : Form
    {
        public CretateCustomer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string email = EmailTextBox.Text;
            string cpf = cpfTextBox.Text;
            string password = senhaTextBox.Text;
            string type = typeCollection.Text;
            string phone = phoneTextBox.Text;

            if (name == "" || email == "" || cpf == "" || password == "" || type == "" || phone == "")
            {
                MessageBox.Show("É necessário informar todas as informações");
                return;
            } 

            try {
                File.WriteCustomerFile(name, cpf, email, phone, password, type);
                MessageBox.Show("Cadastro feito com sucesso ! Você será redirecionado para a tela principal");
                return;
            } catch(Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
                return;
            }

        }

 
    }
}
