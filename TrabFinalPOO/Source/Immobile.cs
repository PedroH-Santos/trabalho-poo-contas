using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabFinalPOO.Source
{
    public class Immobile
    {
        private int id;
        private Address address;
        private string name;
        private double area;
        private double width;
        private double height;
        private double length;
        private double value;
        private Customer customer;
        private List<Account> accounts;
       
        public Immobile(int id,Address address, string name, double width, double height, double length, double value, Customer customer, List<Account> accounts)
        {
            this.id = id;
            this.address = address;
            this.name = name;
            this.width = width;
            this.height = height;
            this.length = length;
            this.value = value;
            this.customer = customer;
            this.accounts = accounts;
            this.SetArea();
        }

        public Address getAddress() { return this.address; }
        public string getName() { return this.name; }
        public double getArea() { return this.area;}
        public double getWidth() { return this.width;}
        public double getHeight() { return this.height;}
        public double getLength() { return this.length;}
        public double getValue() { return this.value; }
        public Customer getCustomer() { return this.customer;}

        public List<Account> getAccounts() {  return this.accounts; }
        public void SetAddress(Address address) { this.address = address;}
        public void SetName(string name) {  this.name = name; }
        public void SetArea() { 
            if(this.length == 0 || this.width== 0 || this.height == 0)
            {
                throw new Exception("Para calcular a área é preciso determinar os valores da altura, largura e comprimento do imóvel");
            }
            
            this.area = this.length * this.width * this.height; 
        }
        public void SetWidth(double width) {  this.width = width; }
        public void SetHeight(double height) {  this.height = height; }
        public void SetLength(double length) {  this.length = length; }
        public void SetValue(double value) {  this.value = value; }
        public void SetCustomer(Customer customer) {  this.customer = customer; }
           
    }
}
