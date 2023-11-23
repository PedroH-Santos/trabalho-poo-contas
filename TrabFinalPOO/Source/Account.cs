using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabFinalPOO.Source
{
    public abstract class Account
    {

        public double id;
        private double lastMonthReader;
        private double currentMonthReader;
        private DateTime effectiveDate;
        protected double consumption;
        protected double totalValue;
        protected double valueWithOutTax;
        protected double tax;
        public Account(double id,double lastMonthReader, double  currentMonthReader, DateTime effectiveDate) {
            this.id = id;
            this.lastMonthReader = lastMonthReader;
            this.currentMonthReader = currentMonthReader;
            this.effectiveDate = effectiveDate;
            this.SetConsumption();
        }

        public double GetLastMonthReader() {  return lastMonthReader; }
        public double GetCurrentMonthReader() { return currentMonthReader; }
        public double GetConsumption() { return consumption; }
        public double GetTotalValue() { return totalValue;}
        public double GetValueWithOutTax() {  return valueWithOutTax; }                                   
        public  double GetTax() { return tax; }  
        public DateTime GetEffectiveDate() {  return effectiveDate; }

        public void SetLastMonthReader(double value) { this.lastMonthReader = value; }
        public void SetCurrentMonthReader(double value) {  this.currentMonthReader= value; }
        public void SetConsumption() {  
            if(this.lastMonthReader == 0 || this.currentMonthReader == 0)
            {
                throw new Exception("É preciso configurar quais foram as leituras do mês anterior e atual.");
            }
            consumption = (this.lastMonthReader >= this.currentMonthReader) ? this.lastMonthReader - this.currentMonthReader : this.currentMonthReader - this.lastMonthReader; 
        
        }
        public void SetEffectiveDate(DateTime value) {  effectiveDate = value; }
        public virtual void SetTax(double value) { tax = value; }

        public abstract void SetTotalValue();
        public abstract void SetValueWithOutTax();

    }
}
