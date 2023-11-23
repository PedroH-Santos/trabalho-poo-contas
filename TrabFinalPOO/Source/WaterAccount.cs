using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabFinalPOO.Source
{
    public class WaterAccount : Account
    {

        public class TableTariff
        {
            public int startInterval;
            public int endInterval;
            public double tableWaterValue;
            public double tableSewageValue;

            public TableTariff(int startInterval, int endInterval, double tableWaterValue, double tableSewageValue)
            {
                this.startInterval = startInterval;
                this.endInterval = endInterval;
                this.tableWaterValue = tableWaterValue;
                this.tableSewageValue = tableSewageValue;
            }
        }


        private List<TableTariff> tariffsApplied;
        public WaterAccount(int id,double lastMonthReader, double currentMonthReader, DateTime effectiveDate, string typeCustomer) : base(id,lastMonthReader, currentMonthReader,  effectiveDate)
        {
            this.tariffsApplied = new List<TableTariff>();
            base.SetTax(3);
            this.SetTariffApllied(typeCustomer);
            this.SetValueWithOutTax();
            this.SetTotalValue();

        }

        public List<TableTariff> GetTariffApllied() { return tariffsApplied; }
        private void SetTariffApllied(string typeCustomer)
        {
            double currentWaterConsumption = this.GetConsumption();
            if (typeCustomer == CustomerType.TIPO_RESIDENCIAL || typeCustomer == CustomerType.TIPO_RESIDENCIAL_SOCIAL)
            {
                if (currentWaterConsumption > 0)
                {
                    this.tariffsApplied.Add(new TableTariff(0, 0, 10.08, 5.05));

                }
                if (currentWaterConsumption >= 6)
                {
                    this.tariffsApplied.Add(new TableTariff(0, 10, 2.241, 1.122));
                }
                if (currentWaterConsumption >= 10)
                {
                    this.tariffsApplied.Add(new TableTariff(10, 15, 5.447, 2.724));
                }
                if (currentWaterConsumption >= 15)
                {
                    this.tariffsApplied.Add(new TableTariff(15, 20, 5.461, 2.731));
                }
                if (currentWaterConsumption >= 20)
                {
                    this.tariffsApplied.Add(new TableTariff(20, 40, 5.487, 2.744));

                }
                if (currentWaterConsumption >= 40)
                {
                    this.tariffsApplied.Add(new TableTariff(40,0, 10.066, 5.035));

                }
            }
            else if (typeCustomer == CustomerType.TIPO_COMERCIAL)
            {
                if (currentWaterConsumption > 0)
                {
                    this.tariffsApplied.Add(new TableTariff(0, 0, 25.79, 12.90));

                }
                if (currentWaterConsumption >= 6)
                {
                    this.tariffsApplied.Add(new TableTariff(0, 10, 4.299, 2.149));
                }
                if (currentWaterConsumption >= 10)
                {
                    this.tariffsApplied.Add(new TableTariff(10, 40, 8.221, 4.111));
                }
                if (currentWaterConsumption >= 40)
                {
                    this.tariffsApplied.Add(new TableTariff(40, 100, 8.288, 4.144));

                }
                if (currentWaterConsumption >= 100)
                {
                    this.tariffsApplied.Add(new TableTariff(100, 0, 8.329, 4.165));
                }
            }
            else
            {
                throw new Exception("O Tipo de cliente não existe");
            }
        }
        public override void SetTotalValue()
        {
            if (this.GetTax() == 0)
            {
                throw new Exception("É preciso determinar a taxa para calcular o valor total com a mesma");
            }
            else if (this.GetValueWithOutTax() == 0)
            {
                throw new Exception("É preciso calcular o valor sem a taxa fixa");
            }

            this.totalValue = this.GetValueWithOutTax() * ((this.GetTax() / 100) + 1.0);
        }

        public override void SetValueWithOutTax()
        {
            double valueOfWaterTariff = 0;
            double valueOfSewageTariff = 0;
            double diffInterval = this.GetConsumption();
            for (int i = 0; i < tariffsApplied.Count; i++)
            {
               if(i == 0)
                {
                    valueOfWaterTariff += tariffsApplied[i].tableWaterValue;
                    valueOfSewageTariff += tariffsApplied[i].tableSewageValue;
                }
                else 
                {
                    double mathConsuption = (this.GetConsumption() > tariffsApplied[i].endInterval) ? (tariffsApplied[i].endInterval - tariffsApplied[i].startInterval) : diffInterval;
                    if (i < tariffsApplied.Count - 1)
                    {
                        diffInterval = (this.GetConsumption() > tariffsApplied[i].endInterval) ? diffInterval - (tariffsApplied[i].endInterval - tariffsApplied[i].startInterval) : diffInterval;

                    }
                    else
                    {
                        mathConsuption = diffInterval;
                    }
                    valueOfWaterTariff += tariffsApplied[i].tableWaterValue * mathConsuption;
                    valueOfSewageTariff += tariffsApplied[i].tableSewageValue * mathConsuption;
                }
            }

            this.valueWithOutTax = valueOfWaterTariff + valueOfSewageTariff;
        }

    }
}











