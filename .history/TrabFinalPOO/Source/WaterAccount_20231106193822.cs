﻿using System;
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

        public double GetTariffWater() {  return tariffWater; }
        public double GetTariffSewage() {  return tariffSewage; }
        public double GetConsumptionSewage(){  return consumptionSewage; }

        public void SetTariffWater(double tariff) {  this.tariffWater = tariff; }
        public void SetTariffSewage(double tariff) {  this.tariffSewage=tariff; }
        public void SetConsumptionSewage(double consumption) {  this.consumptionSewage = consumption; }
    

        private void SetTariffAccount(type){

        }
    }
}
