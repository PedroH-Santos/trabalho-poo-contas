using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabFinalPOO.Source;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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

            try
            {
                int idCustomer = insertCustomer();
                if(idCustomer == -1)
                {
                    return;
                }
                int idAddress = insertAddress();
                if (idAddress == -1)
                {
                    return;
                }
                int idImmobile = insertImmobile(idCustomer, idAddress);
                if (idImmobile == -1)
                {
                    return;
                }
                Thread.Sleep(2000);
                MessageBox.Show("Cadastro feito com sucesso ! Você será redirecionado para a tela principal");
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }
            catch (FormatException ex)
            {
    
            } 


        }


        private int insertCustomer()
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
                return -1;
            }

            try
            {
                int id = File.WriteCustomerFile(name, cpf, email, phone, password, type);
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
                return -1;
            }
        }

        private int insertImmobile(int idCustomer, int idAddress)
        {
            string name = NameImobTextBox.Text;
            double width = Convert.ToDouble(widthTextBox.Text);
            double heigth = Convert.ToDouble(HeightTextBox.Text);
            double length = Convert.ToDouble(LenghtTextBox.Text);
            double value = Convert.ToDouble(ValueTextBox.Text);

            if (name == "" || width == 0 || heigth == 0 || length == 0 || value == 0 )
            {
                MessageBox.Show("É necessário informar todas as informações do imóvel");
                return -1;
            }

            try
            {
                int id = File.WriteImmobileFile(name,width,heigth,length,value,idCustomer,idAddress);
                return id ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
                return -1;
            }

        }


        private int insertAddress()
        {
            string street = StreetTextBox.Text;
            string zipCode = ZipCodeTextBox.Text;
            string neighborhood = NeighborhoodTextBox.Text;
            string city = CityTextBox.Text;
            string country = ContryTextBox.Text;

            if (street == "" || zipCode == "" || neighborhood == "" || city == "" || country == "")
            {
                MessageBox.Show("É necessário informar todas as informações do endereço");
                return -1;
            }

            try
            {
                int id = File.WriteAddressFile(street, zipCode, neighborhood, city, country);
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
                return -1;
            }

        }


    }
}
