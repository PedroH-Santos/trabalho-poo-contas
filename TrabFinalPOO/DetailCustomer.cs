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
                this.immobile = File.SearchImmobileByIdCustomer(customer.GetId());

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
                    sumValueAccount+= account.GetTotalValue();
                    if(account.GetConsumption() > greaterConsumption)
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
            catch (Exception ex) { }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
