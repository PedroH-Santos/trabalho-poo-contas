using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabFinalPOO.Source
{
    public class WaterAccount : Account
    {
        private double[] tariffWater;
        private double[] tariffSewage;
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


        private void SetWaterTariffAccount(string typeCustomer)
        {
            double currentWaterConsumption = this.GetConsumption();
            double currentSewagerConsumption = this.GetConsumptionSewage();
            if (typeCustomer == CustomerType.TIPO_RESIDENCIAL)
            {
                if (currentWaterConsumption > 10 && currentWaterConsumption < 15)
                {
                    this.tariffWater.push(5.447);
                }
                if (currentWaterConsumption >= 15 && currentWaterConsumption < 20)
                {
                    this.tariffWater.push(5.461) ;
                }
                else if (currentWaterConsumption >= 20 && currentWaterConsumption < 40)
                {
                    this.tariffWater.push(5.487);
                }
                else if (currentWaterConsumption >= 40)
                {
                    this.tariffWater.push(10.066) ;
                }
            }
            else if (typeCustomer == CustomerType.TIPO_COMERCIAL)
            {
                if (currentWaterConsumption > 0 && currentWaterConsumption < 6)
                {
                    this.tariffWater.push(25.79);
                }
                else if (currentWaterConsumption >= 6 && currentWaterConsumption < 10)
                {
                    this.tariffWater.push(4.299) ;
                }
                else if (currentWaterConsumption >= 10 && currentWaterConsumption < 40)
                {
                    this.tariffWater.push(8.221) ;
                }
                else if (currentWaterConsumption >= 40 && currentWaterConsumption < 100)
                {
                    this.tariffWater.push(8.288) ;
                }
                else if (currentWaterConsumption >= 100)
                {
                    this.tariffWater.push(8.329) ;
                }
            }
            else if (typeCustomer == CustomerType.TIPO_RESIDENCIAL_SOCIAL)
            {
                if (currentWaterConsumption > 0 && currentWaterConsumption < 6)
                {
                    this.tariffWater.push(10.08);
                }else if(currentWaterConsumption > 6 && currentWaterConsumption < 10) {
                    this.tariffWater.push(2.241 );
                }
            }
            else
            {
                throw new Exception("O Tipo de cliente não existe");
            }
        }


        // private void SetSewageTariffAccount(string typeCustomer)
        // {
        //     double currentWaterConsumption = this.GetConsumption();
        //     double currentSewagerConsumption = this.GetConsumptionSewage();
        //     if (typeCustomer == CustomerType.TIPO_RESIDENCIAL)
        //     {
        //         if (consumption > 10 && consumption < 15)
        //         {
        //             this.tariffWater = 5.447;
        //             this.tariffSewage = 2.724;
        //         }
        //         else if (consumption >= 15 && consumption < 20)
        //         {
        //             this.tariffWater = 5.461;
        //             this.tariffSewage = 2.731;
        //         }
        //         else if (consumption >= 20 && consumption < 40)
        //         {
        //             this.tariffWater = 5.487;
        //             this.tariffSewage = 2.744;
        //         }
        //         else if (consumption >= 40)
        //         {
        //             this.tariffWater = 10.066;
        //             this.tariffSewage = 5.035;
        //         }
        //     }
        //     else if (typeCustomer == CustomerType.TIPO_COMERCIAL)
        //     {
        //         if (consumption > 0 && consumption < 6)
        //         {
        //             this.tariffWater = 25.79;
        //             this.tariffSewage = 12.90;
        //         }
        //         else if (consumption >= 6 && consumption < 10)
        //         {
        //             this.tariffWater = 4.299;
        //             this.tariffSewage = 2.149;
        //         }
        //         else if (consumption >= 10 && consumption < 40)
        //         {
        //             this.tariffWater = 8.221;
        //             this.tariffSewage = 4.111;
        //         }
        //         else if (consumption >= 40 && consumption < 100)
        //         {
        //             this.tariffWater = 8.288;
        //             this.tariffSewage = 4.144;
        //         }
        //         else if (consumption >= 100)
        //         {
        //             this.tariffWater = 8.329;
        //             this.tariffSewage = 4.165;
        //         }
        //     }
        //     else if (typeCustomer == CustomerType.TIPO_RESIDENCIAL_SOCIAL)
        //     {
        //         if (consumption > 0 && consumption < 6)
        //         {
        //             this.tariffWater = 10.08;
        //             this.tariffSewage = 5.05;
        //         }
        //         else if (consumption > 6 && consumption < 10)
        //         {
        //             this.tariffWater = 2.241;
        //             this.tariffSewage = 1.122;
        //         }
        //     }
        //     else
        //     {
        //         throw new Exception("O Tipo de cliente não existe");
        //     }
        // }

        public override void SetValueWithOutTax()
        {


            double valueTariff = this.GetTariffEnergy() * this.GetConsumption();
            this.valueWithOutTax = valueTariff + this.additionalValue;
        }

    }
}
