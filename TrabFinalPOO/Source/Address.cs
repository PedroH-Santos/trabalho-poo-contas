using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabFinalPOO.Source
{
    public class Address
    {
        private string street;
        private string cep;
        private string neighborhood;
        private string city;
        private string country;

        public Address(string street, string cep, string neighborhood, string city, string country)
        {
            this.street = street;
            this.cep = cep;
            this.neighborhood = neighborhood;
            this.city = city;
            this.country = country;
        }

        public string GetStreet() { return this.street; }
        public string GetCep() { return this.cep; }
        public string GetNeighbordhood() { return this.neighborhood; }
        public string GetCity() { return this.city; }
        public string GetCountry() { return this.country; }

        public void SetStreet(string street) {  this.street = street; }
        public void SetCep(string cep) { this.cep = cep; }
        public void SetNeighborhodd(string street) { this.street = street; }
        public void SetCity(string city) { this.city= city; }
        public void SetCountry(string country) { this.country = country; }

    }
}
