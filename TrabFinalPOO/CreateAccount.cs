using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabFinalPOO.Source;
using File = TrabFinalPOO.Source.File;

namespace TrabFinalPOO.BD
{
    public partial class CreateAccount : Form
    {
        private Immobile immobile;
        private Customer customer;
        public CreateAccount()
        {
            InitializeComponent();
        }
        public CreateAccount(Customer customer,Immobile immobile)
        {
            this.customer = customer;
            this.immobile = immobile;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                double lastMonthReader = Convert.ToDouble(textBox1.Text);
                double currentMonthReader = Convert.ToDouble(textBox2.Text);
                DateTime effectiveDate = dateTimePicker1.Value;
                string type = comboBox1.Text;

                if (lastMonthReader == 0 || currentMonthReader == 0 || effectiveDate == null || type == "")
                {
                    MessageBox.Show("É necessário informar todas as informações da conta");
                    return;
                }

                try
                {
                    int id = File.WriteAccountFile(type,currentMonthReader,lastMonthReader,effectiveDate.ToString(),this.immobile.getId());
                    Thread.Sleep(2000);
                    MessageBox.Show("Cadastro feito com sucesso ! Você será redirecionado para a tela de detalhes");
                    this.Hide();
                    DetailCustomer detail = new DetailCustomer(this.customer);
                    detail.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERRO: " + ex.Message);
                    return;
                }


            }
            catch (FormatException ex)
            {
                MessageBox.Show("ERRO: formato de um campo está incorreto !");
                return;

            }




        }
    }
}
