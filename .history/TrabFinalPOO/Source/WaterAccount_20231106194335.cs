using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabFinalPOO.Source
{
    public class WaterAccount : Account
    {
        private double tariffWater;
        private double tariffSewage;
        private double consumptionSewage;
        public WaterAccount(double lastMonthReader, double currentMonthReader, double consumption, double totalValue, double valueWithTax, double tax, DateTime effectiveDate, Immobile immobile, double tariffWater, double tariffSewage, double consumptionSewage) : base(lastMonthReader, currentMonthReader, consumption, totalValue, valueWithTax, tax, effectiveDate, immobile)
        {
            this.tariffWater = tariffWater;
            this.tariffSewage = tariffSewage;
            this.consumptionSewage = consumptionSewage;
        }

        public double GetTariffWater() { return tariffWater; }
        public double GetTariffSewage() { return tariffSewage; }
        public double GetConsumptionSewage() { return consumptionSewage; }

        public void SetTariffWater(double tariff) { this.tariffWater = tariff; }
        public void SetTariffSewage(double tariff) { this.tariffSewage = tariff; }
        public void SetConsumptionSewage(double consumption) { this.consumptionSewage = consumption; }


        private void SetTariffAccount(string typeCustomer)
        {
            if (typeCustomer == CustomerType.TIPO_RESIDENCIAL)
            {

            }
            else if (typeCustomer == CustomerType.TIPO_COMERCIAL)
            {
                valueTariffEnergy = 0.41;
            }
            else if (typeCustomer == CustomerType.TIPO_RESIDENCIAL_SOCIAL)
            {
                if (this.GetConsumption() > 0 && this.GetConsumption() < 6)
                {
                    this.tariffWater = 10.08;
                    this.tariffSewage = 5.05;
                }else if(this.GetConsumption() > 6 && this.GetConsumption() < 10) {
                    this.tariffWater = 2.241 + ;
                    this.tariffSewage = 5.05;
                }
            }
            else
            {
                throw new Exception("O Tipo de cliente não existe");
            }
        }
    }
}
