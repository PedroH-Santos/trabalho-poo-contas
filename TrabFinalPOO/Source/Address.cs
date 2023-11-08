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
        private string zipCode;
        private string neighborhood;
        private string city;
        private string country;


        public Address(string street, string zipCode, string neighborhood, string city, string country)
        {
            this.street = street;
            this.zipCode = zipCode;
            this.neighborhood = neighborhood;
            this.city = city;
            this.country = country;
        }

        public string GetStreet() { return this.street; }
        public string GetZipCode() { return this.zipCode; }
        public string GetNeighbordhood() { return this.neighborhood; }
        public string GetCity() { return this.city; }
        public string GetCountry() { return this.country; }

        public void SetStreet(string street) {  this.street = street; }
        public void SetZipCode(string ZipCode) { this.zipCode = ZipCode; }
        public void SetNeighborhodd(string street) { this.street = street; }
        public void SetCity(string city) { this.city= city; }
        public void SetCountry(string country) { this.country = country; }

    }
}
