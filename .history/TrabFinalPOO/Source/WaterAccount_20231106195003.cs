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
                if (this.GetConsumption() > 10 && this.GetConsumption() < 15)
                {
                    this.tariffWater = 5.447 * this.GetConsumption();
                    this.tariffSewage = 2.724 * this.GetConsumption();
                }
                else if (this.GetConsumption() >= 15 && this.GetConsumption() < 20)
                {
                    this.tariffWater = 5.461 * this.GetConsumption();
                    this.tariffSewage = 2.731 * this.GetConsumption();
                }
                else if (this.GetConsumption() >= 20 && this.GetConsumption() < 40)
                {
                    this.tariffWater = 5.487 * this.GetConsumption();
                    this.tariffSewage = 2.744 * this.GetConsumption();
                }
                else if (this.GetConsumption() >= 40)
                {
                    this.tariffWater = 10.066 * this.GetConsumption();
                    this.tariffSewage = 5.035 * this.GetConsumption();
                }
            }
            else if (typeCustomer == CustomerType.TIPO_COMERCIAL)
            {
                if (this.GetConsumption() > 0 && this.GetConsumption() < 6)
                {
                    this.tariffWater = 25.79;
                    this.tariffSewage = 12.90;
                }
                else if (this.GetConsumption() >= 6 && this.GetConsumption() < 10)
                {
                    this.tariffWater = 4.299 * this.GetConsumption();
                    this.tariffSewage = 2.149 * this.GetConsumption();
                }
                else if (this.GetConsumption() >= 10 && this.GetConsumption() < 40)
                {
                    this.tariffWater = 8.221 * this.GetConsumption();
                    this.tariffSewage = 4.111 * this.GetConsumption();
                }
                else if (this.GetConsumption() >= 40 && this.GetConsumption() < 100)
                {
                    this.tariffWater = 8.288 * this.GetConsumption();
                    this.tariffSewage = 4.144 * this.GetConsumption();
                }
                else if (this.GetConsumption() >= 100)
                {
                    this.tariffWater = 8.329 * this.GetConsumption();
                    this.tariffSewage = 5.035 * this.GetConsumption();
                }
            }
            else if (typeCustomer == CustomerType.TIPO_RESIDENCIAL_SOCIAL)
            {
                if (this.GetConsumption() > 0 && this.GetConsumption() < 6)
                {
                    this.tariffWater = 10.08;
                    this.tariffSewage = 5.05;
                }else if(this.GetConsumption() > 6 && this.GetConsumption() < 10) {
                    this.tariffWater = 2.241 * this.GetConsumption();
                    this.tariffSewage = 1.122 * this.GetConsumption();
                }
            }
            else
            {
                throw new Exception("O Tipo de cliente não existe");
            }
        }
    }
}
