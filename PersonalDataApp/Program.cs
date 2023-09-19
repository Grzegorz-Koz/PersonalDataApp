using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace PersonalDataApp
{
    internal class Program
    {

        GetValuesLibrary gvl = new GetValuesLibrary();
       
        string name;
        string surname;
        int age;
        char gender;
        string pesel;
        string telMobileNumber;
        string email;
        int growth;
        decimal weight;
        string address;
        string zipCode;
        string city;
        string country;

        static void Main(string[] args)
        {
            GetValuesLibrary gvl = new GetValuesLibrary();
            Program program = new Program();

            Console.WriteLine("\r"); 
            Console.WriteLine("Welcome to PersonalDataApp!");
            Console.WriteLine("\r");
            Console.WriteLine("Please complete your personal data:");
                        
            const int NUBER_OF_DATA_ROWS = 13;
            const int NUBER_OF_DATA_COLUMNS = 2;
            string [,] data = new string [NUBER_OF_DATA_ROWS, NUBER_OF_DATA_COLUMNS] {
                {"name","Enter your name:"},
                {"surname","Enter your surname:"},
                {"age","Enter your age:"},
                {"gender","Enter your gender (m or f):"},
                {"pesel","Enter your PESEL:"},
                {"tel_mobile_number","Enter your mobile number (it should consist of 9 digits):"},
                {"email","Enter your email:"},
                {"growth","Enter your growth:"},
                {"weight","Enter your weight (format like 23,88):"},
                {"address","Enter your address:"},
                {"zip_code","Enter your zip code (like nn-nnn):"},
                {"city","Enter your city:"},
                {"country","Enter your country:"}
            };            

            for (int i = 0; i < NUBER_OF_DATA_ROWS; i++)           
            {                
                Console.WriteLine($"{data[i, 1]}"); // 2 column of dataFields table
                program.SelectPersonalDetails(data[i, 0]);
            }

            Console.WriteLine("\r");
            Console.WriteLine("Your personal data:");

            Console.WriteLine($"Name: {program.name}");
            Console.WriteLine($"Surname: {program.surname}");
            Console.WriteLine($"Age: {program.age}");
            //Console.WriteLine($"Gender: {program.genderPersonalData}");
            if (program.gender == 'm')
            {
                Console.WriteLine("Gender: male");
            }
            else
            {
                Console.WriteLine("Gender: female");
            }

            Console.WriteLine($"PESEL: {program.pesel}");
            Console.WriteLine($"Mobile: {program.telMobileNumber}");
            Console.WriteLine($"Email: {program.email}");
            Console.WriteLine($"Growth: {program.growth}");
            Console.WriteLine($"Weight: {program.weight}");
            Console.WriteLine($"Address: {program.address}");
            Console.WriteLine($"Zip Code: {program.zipCode}");
            Console.WriteLine($"City: {program.city}");
            Console.WriteLine($"Country: {program.country}");
        }
        
        public void SelectPersonalDetails(string caseOption)
        {
            string inputData = Console.ReadLine();
            switch (caseOption)
            {
                case "name":
                    name = inputData;
                    break;

                case "surname":
                    surname = inputData;
                    break;

                case "age":
                    age = gvl.GetIntValue(inputData);
                    break;

                case "gender":
                    gender = gvl.GetGender(inputData);
                    break;

                case "pesel":
                    pesel = gvl.GetPesel(inputData);
                    break;

                case "tel_mobile_number":
                    telMobileNumber = gvl.GetMobileNumber(inputData);
                    break;

                case "email":
                    email = inputData;
                    break;

                case "growth":
                    growth = gvl.GetIntValue(inputData);
                    break;

                case "weight":
                    weight = gvl.GetWeight(inputData);
                    break;

                case "address":
                    address = inputData;
                    break;

                case "zip_code":
                    zipCode = gvl.GetZipCode(inputData);
                    break;

                case "city":
                    city = inputData;
                    break;

                case "country":
                    country = inputData;
                    break;

            }
        }


    }
}