﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabFinalPOO.Source
{
    public class EnergyAccount : Account 
    {
        private double additionalValue;
        private double tariffEnergy;


        public EnergyAccount(int id, double lastMonthReader, double currentMonthReader, DateTime effectiveDate, string typeCustomer) : base(id,lastMonthReader, currentMonthReader, effectiveDate)
        {
            this.additionalValue = 13.25;
            this.SetTariffEnergy(typeCustomer);
            this.SetValueWithOutTax();
            this.SetTax(typeCustomer);
            this.SetTotalValue();
        }

        public double GetAdditionalValue() { return additionalValue;}
        public double GetTariffEnergy() {  return tariffEnergy;}
        public void SetTariffEnergy(string typeCustomer) {
            double valueTariffEnergy = 0;
        
            if (typeCustomer == CustomerType.TIPO_RESIDENCIAL || typeCustomer == CustomerType.TIPO_RESIDENCIAL_SOCIAL)
            {
                valueTariffEnergy = 0.46;
            }else if(typeCustomer == CustomerType.TIPO_COMERCIAL)
            {
                valueTariffEnergy = 0.41;
            }else {
                throw new Exception("O Tipo de cliente não existe");
            }
            this.tariffEnergy = valueTariffEnergy; 
        }
        public override void SetTotalValue()
        {
            if(this.GetValueWithOutTax() == 0)
            {
                throw new Exception("É preciso calcular o valor sem a taxa fixa");
            }

            this.totalValue = this.GetValueWithOutTax() * ((this.GetTax() / 100) + 1.0);
        }

        public void SetTax(string typeCustomer)
        {
            double valueTax = 0;
            if (typeCustomer == CustomerType.TIPO_RESIDENCIAL || typeCustomer == CustomerType.TIPO_RESIDENCIAL_SOCIAL)
            {
                if (this.GetConsumption() >= 90)
                {
                    valueTax = 42.85;
                }
            }
            else if (typeCustomer == CustomerType.TIPO_COMERCIAL)
            {
                valueTax = 21.95;
            }
            base.SetTax(valueTax);
        }

        public override void SetValueWithOutTax()
        {
            double valueTariff = this.GetTariffEnergy() * this.GetConsumption();
            this.valueWithOutTax = valueTariff + this.additionalValue;
        }
    }
}
