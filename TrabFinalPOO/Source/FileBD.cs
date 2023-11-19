using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TrabFinalPOO.Source
{
    public static class FileBD
    {

        static string pathFileCustomer = "C:\\Users\\major\\source\\repos\\TrabFinalPOO\\TrabFinalPOO\\BD\\cliente.txt";
        static string pathFileAddress = "C:\\Users\\major\\source\\repos\\TrabFinalPOO\\TrabFinalPOO\\BD\\endereco.txt";
        static string pathFileImmobile = "C:\\Users\\major\\source\\repos\\TrabFinalPOO\\TrabFinalPOO\\BD\\imovel.txt";
        static string pathFileAccount = "C:\\Users\\major\\source\\repos\\TrabFinalPOO\\TrabFinalPOO\\BD\\conta.txt";

        public static Account SearchAccountFileById(int idAccount, string typeCustomer)
        {
            try
            {


                StreamReader reader = new StreamReader(FileBD.pathFileAccount);
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] traitLine = line.Split('|');
                    int id = Convert.ToInt32(traitLine[0]);
                    if(id == idAccount)
                    {
                        int type = Convert.ToInt32(traitLine[1]);
                        double currentMonthReader = Convert.ToDouble(traitLine[2]);
                        double lastMonthReader = Convert.ToDouble(traitLine[3]);
                        DateTime effectiveDate = Convert.ToDateTime(traitLine[4]);
                        int idImmobile = Convert.ToInt32(traitLine[5]);
                        if (type == 1) //Water
                        {
                            WaterAccount account = new WaterAccount(id,lastMonthReader, currentMonthReader, effectiveDate, typeCustomer);
                            reader.Close();
                            return account;
                        }
                        else if (type == 2) //Energy
                        {
                            EnergyAccount account = new EnergyAccount(id,lastMonthReader, currentMonthReader, effectiveDate, typeCustomer);
                            reader.Close();
                            return account;
                        }
                    }


                }
                reader.Close();

                throw new Exception("Conta Não foi encontrado");
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Customer SearchCustomerFileById(int idCustomer)
        {
            try
            {


                StreamReader reader = new StreamReader(FileBD.pathFileCustomer);
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] traitLine = line.Split('|');

                    int id = Convert.ToInt32(traitLine[0]);

                    if (id == idCustomer)
                    {

                        string name = traitLine[1];
                        string cpf = traitLine[2];
                        string email = traitLine[3];
                        string phone = traitLine[4];
                        string password = traitLine[5];
                        string type = traitLine[6];
                        Customer customer = new Customer(id,name, cpf, email, phone, password, type) ;
                        reader.Close();
                        return customer;
                    }
                }
                reader.Close();

                throw new Exception("Cliente Não foi encontrado");
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Customer SearchCustomerFileByEmailAndPassword(string emailFind, string passwordFind)
        {
            try
            {


                StreamReader reader = new StreamReader(FileBD.pathFileCustomer);
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] traitLine = line.Split('|');

                    int id = Convert.ToInt32(traitLine[0]);
                    string name = traitLine[1];
                    string cpf = traitLine[2];
                    string email = traitLine[3];
                    string phone = traitLine[4];
                    string password = traitLine[5];
                    string type = traitLine[6];
                    if (email == emailFind.Trim() && password == passwordFind.Trim())
                    {
                        Customer customer = new Customer(id,name, cpf, email, phone, password, type);
                        reader.Close();
                        return customer;
                    }
                }
                reader.Close();

                throw new Exception("Cliente Não foi encontrado");
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Immobile SearchImmobileByIdCustomer(int findIdCustomer) 
        {
            try
            {

                StreamReader reader = new StreamReader(FileBD.pathFileImmobile);
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] traitLine = line.Split('|');

                    int id = Convert.ToInt32(traitLine[0]);
                    int idAddress = Convert.ToInt32(traitLine[1]);
                    Address address = FileBD.SearchAddressFileById(idAddress);
                    string name = traitLine[2];
                    double width = Convert.ToDouble(traitLine[3]);
                    double height = Convert.ToDouble(traitLine[4]);
                    double length = Convert.ToDouble(traitLine[5]);
                    double valueImmobile = Convert.ToDouble(traitLine[6]);
                    int idCustomer = Convert.ToInt32(traitLine[7]);
                    Customer customer = FileBD.SearchCustomerFileById(idCustomer);
                    string[] listIdsAccount = traitLine[8].Split(';');
                    List<Account> accounts = new List<Account>();
                    if (listIdsAccount != null && listIdsAccount[0] != "")
                    {
                        foreach (string idAccount in listIdsAccount)
                        {
                            accounts.Add(FileBD.SearchAccountFileById(Convert.ToInt32(idAccount), customer.GetTypeCustomer()));
                        }
                    }
                    if (idCustomer == findIdCustomer)
                    {
                        Immobile immobile = new Immobile(id, address, name, width, height, length, valueImmobile, customer, accounts);
                        reader.Close();
                        return immobile;
                    }
                }
                reader.Close();

                throw new Exception("Imóvel Não foi encontrado");
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static Address SearchAddressFileById(int idAddress)
        {
            try
            {


                StreamReader reader = new StreamReader(FileBD.pathFileAddress);
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] traitLine = line.Split('|');

                    int id = Convert.ToInt32(traitLine[0]);

                    if (id == idAddress) {

                        string street = traitLine[1];
                        string zipCode = traitLine[2];
                        string neighborhood = traitLine[3];
                        string city = traitLine[4];
                        string country = traitLine[5];
                        Address address = new Address(street, zipCode, neighborhood, city, country);
                        return address;
                    }
                }
                reader.Close();

                throw new Exception("Endereço Não foi encontrado");
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static List<Immobile> ReadImmobileFile()
        {
            try
            {

                List<Immobile> value = new List<Immobile> ();
                StreamReader reader = new StreamReader(FileBD.pathFileImmobile);
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] traitLine = line.Split('|');

                        int id = Convert.ToInt32(traitLine[0]);
                        int idAddress = Convert.ToInt32(traitLine[1]);
                        Address address = FileBD.SearchAddressFileById(idAddress);
                        string name = traitLine[2];
                        double width = Convert.ToDouble(traitLine[3]);
                        double height = Convert.ToDouble(traitLine[4]);
                        double length = Convert.ToDouble(traitLine[5]);
                        double valueImmobile = Convert.ToDouble(traitLine[6]);
                        int idCustomer = Convert.ToInt32(traitLine[7]);
                        Customer customer = FileBD.SearchCustomerFileById( idCustomer);
                        string[] listIdsAccount = traitLine[8].Split(';');
                        List<Account> accounts = new List<Account>();
                        if (listIdsAccount != null && listIdsAccount[0] != "")
                        {
                            foreach (string idAccount in listIdsAccount)
                            {
                                accounts.Add(FileBD.SearchAccountFileById(Convert.ToInt32(idAccount), customer.GetTypeCustomer()));
                            }
                        }
                        Immobile immobile = new Immobile(id,address,name,width,height,length,valueImmobile,customer,accounts);
                        value.Add(immobile);
                    
                }
                reader.Close();

                return value;
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static int WriteCustomerFile(string name, string cpf, string email, string phone, string password, string typeCustomer)
        {
            try
            {
                int id = FileBD.getLines(FileBD.pathFileCustomer) + 1;
                using (StreamWriter writer = new StreamWriter(FileBD.pathFileCustomer,true))
                {
                    string line = id + "|" + name + "|" + cpf + "|" + email + "|" + phone + "|" + password + "|" + typeCustomer;
                    writer.WriteLine(line);
                    writer.Close();
                }
                return id;


            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int WriteImmobileFile(string name, double width, double height, double length, double value, int idCustomer, int idAddress )
        {
            try
            {
                int id = FileBD.getLines(FileBD.pathFileImmobile) + 1;
                using (StreamWriter writer = new StreamWriter(FileBD.pathFileImmobile, true))
                {
                    string line = id + "|" + idAddress + "|" + name + "|" + width + "|" + height + "|" + length + "|" + value + "|" + idCustomer + "|" + null;
                    writer.WriteLine(line);
                    writer.Close();
                }
                return id;


            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int WriteAddressFile(string street, string zipcode, string neighborhood, string city, string country)
        {
            try
            {
                int id = FileBD.getLines(FileBD.pathFileAddress) + 1;
                using (StreamWriter writer = new StreamWriter(FileBD.pathFileAddress, true))
                {
                    string line = id + "|" + street + "|" + zipcode + "|" + neighborhood + "|" + city + "|" + country;
                    writer.WriteLine(line);
                    writer.Close();
                }
                return id;


            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int WriteAccountFile(string type, double currentMonthReader, double lastMonthReader, string effectiveDate, int idImmobile)
        {
            try
            {
                int id = FileBD.getLines(FileBD.pathFileAccount) + 1;
                using (StreamWriter writer = new StreamWriter(FileBD.pathFileAccount, true))
                {
                    string line = id + "|" + (type == "Agua" ? 1 : 2) + "|" + currentMonthReader + "|" + lastMonthReader + "|" + effectiveDate + "|" + idImmobile;
                    writer.WriteLine(line);
                    writer.Close();

                }
                
                return id;

               
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static int getLines(string file)
        {
            var lineCount = 0;
            StreamReader reader = new StreamReader(file);

            using (var stream = reader)
            {
                while (stream.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            reader.Close();

            return lineCount;
        }

        public static void updateFileImmobile(int idImmobile, int idNewAccount)
        {
            string[] arrLine = File.ReadAllLines(FileBD.pathFileImmobile);
            string a = arrLine[idImmobile - 1].Split('|')[8];
            string content = (arrLine[idImmobile - 1].Split('|')[8] != "") ? arrLine[idImmobile - 1] + ";" + idNewAccount : arrLine[idImmobile - 1] + idNewAccount.ToString();

            arrLine[idImmobile - 1] = content;
            File.WriteAllLines(FileBD.pathFileImmobile, arrLine);
        }

    }
}
