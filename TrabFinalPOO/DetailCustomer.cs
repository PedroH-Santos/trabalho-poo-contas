using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabFinalPOO.BD;
using TrabFinalPOO.Source;

namespace TrabFinalPOO
{
    public partial class DetailCustomer : Form
    {
        private Customer customer;
        private Immobile immobile;
        public DetailCustomer()
        {
            InitializeComponent();
        }
        public DetailCustomer(Customer customer)
        { 
            InitializeComponent();
            try
            {


                this.customer = customer;
                this.immobile = FileBD.SearchImmobileByIdCustomer(customer.GetId());

                if(this.immobile.getAccounts().Count > 0 )
                {
                    label2.Text = "Consumo do último mês: " + this.immobile.getAccounts().LastOrDefault().GetConsumption();
                    label3.Text = "Valor total da conta do mês: " + this.immobile.getAccounts().LastOrDefault().GetTotalValue();
                    label4.Text = "Valor sem impostos da conta do mês: " + this.immobile.getAccounts().LastOrDefault().GetValueWithOutTax();

                    double sumValueAccount = 0;
                    Account accountForGreaterConsumption = null;
                    double greaterConsumption = -50;
                    Account accountForGreaterValue = null;
                    double greaterValue = -50;
                    foreach (Account account in this.immobile.getAccounts())
                    {
                        sumValueAccount += account.GetTotalValue();
                        if (account.GetConsumption() > greaterConsumption)
                        {
                            greaterConsumption = account.GetConsumption();
                            accountForGreaterConsumption = account;
                        }
                        if (account.GetTotalValue() > greaterValue)
                        {
                            greaterValue = account.GetTotalValue();
                            accountForGreaterValue = account;
                        }

                    }
                    label5.Text = "Valor médio das contas: " + sumValueAccount / this.immobile.getAccounts().Count;
                    label6.Text = "Mês de maior valor em reais: " + accountForGreaterValue.GetEffectiveDate();
                    label7.Text = "Mês de maior valor em consumo: " + accountForGreaterConsumption.GetEffectiveDate();
                }



            }
            catch (Exception ex) {
                MessageBox.Show("ERRO: " + ex.Message);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PesquisarDatasButton_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTimeStart.Value;
            DateTime endDate = DateTimeEnd.Value;
            double variationConsumption = 0;
            double variationValue = 0;
            Account firstDate = null;
            Account secondDate = null;
            foreach (Account account in this.immobile.getAccounts() )
            {
                if (account.GetEffectiveDate().Month == startDate.Month)
                {
                    firstDate = account;
                }
                if(account.GetEffectiveDate().Month == endDate.Month)
                {
                    secondDate = account;

                }
            }
            if(firstDate == null || secondDate == null)
            {            
               MessageBox.Show("Não foi encontrado nenhuma conta no mês escolhido.");
               return;

            }
            variationConsumption = firstDate.GetConsumption() - secondDate.GetConsumption();
            variationValue = firstDate.GetTotalValue() - secondDate.GetTotalValue();
            label10.Text = "Valor variado entre os meses escolhidos: " + ((variationValue < 0) ? variationValue * -1 : variationValue);
            label11.Text = "Consumo variado entre os meses escolhidos: : " + ((variationConsumption < 0) ? variationConsumption * -1 : variationConsumption);


        }

        private void DateTimeStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CriarContaButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateAccount account = new CreateAccount(this.customer,this.immobile);
            account.Show();
        }
    }
}
