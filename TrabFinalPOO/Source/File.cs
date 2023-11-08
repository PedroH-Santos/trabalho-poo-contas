using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabFinalPOO.Source
{
    public static class File
    {


        public static List<Address> ReadAddressFile(string path)
        {
            try
            {

                List<Address> value = new List<Address>();
                     
                StreamReader reader = new StreamReader(path);
                string line = "";
                while((line = reader.ReadLine()) != null)
                {
                    string[] traitLine = line.Split('|');

                        string street = traitLine[0];
                        string zipCode = traitLine[1];
                        string neighborhood = traitLine[2];
                        string city = traitLine[3];
                        string country = traitLine[4];
                        Address address = new Address(street, zipCode, neighborhood, city, country);
                        value.Add(address);
                    

                }
                reader.Close();

                return value;
            }catch (FileNotFoundException ex)   
            {
                throw new Exception(ex.Message);

            }catch(Exception ex)            {
                throw new Exception(ex.Message);
            }
        }
    }
}
