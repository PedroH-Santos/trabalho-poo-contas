using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabFinalPOO.Source
{
    public class Customer
    {
        private string name;
        private string cpf;
        private string email;
        private string phone;
        private string password;
        private string typeCustomer;
        public Customer(string name, string cpf, string email, string phone, string password, string typeCustomer) {

            try {
                this.ValidateTypeCustomer(name);
                this.name = name;
                this.cpf = cpf;
                this.email = email;
                this.phone = phone;
                this.password = password;
                this.typeCustomer = typeCustomer;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public string GetName() { return this.name; }
        public string GetCpf() { return this.cpf; }
        public string GetEmail() { return this.email; }
        public string GetPhone() { return this.phone; }
        public string GetTypeCustomer() { return this.typeCustomer; }

        public void SetName(string name) {  this.name = name; }
        public void SetCpf(string cpf) { this.cpf = cpf; }
        public void SetEmail(string email) { this.email = email; }
        public void SetPhone(string phone) { this.phone= phone; }
        public void SetPassword(string password) { this.password = password; }

        public bool ValidateTypeCustomer(string value)
        {
            if(value != CustomerType.TIPO_RESIDENCIAL && value != CustomerType.TIPO_RESIDENCIAL_SOCIAL && value != CustomerType.TIPO_COMERCIAL)
            {
                throw new Exception("Tipo de cliente informado não existe");
            }
            return true;
        }


    }
}
