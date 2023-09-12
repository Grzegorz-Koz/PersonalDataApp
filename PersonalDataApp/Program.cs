using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace PersonalDataApp
{
    internal class Program
    {

        GetValuesLibrary gvl = new GetValuesLibrary();
       
        string namePersonalData;
        string surnamePersonalData;
        int agePersonalData;
        char genderPersonalData;
        string peselPersonalData;
        string telMobileNumberPersonalData;
        string emailPersonalData;
        int growthPersonalData;
        decimal weightPersonalData;
        string addressPersonalData;
        string zipCodePersonalData;
        string cityPersonalData;
        string countryPersonalData;

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

            Console.WriteLine($"Name: {program.namePersonalData}");
            Console.WriteLine($"Surname: {program.surnamePersonalData}");
            Console.WriteLine($"Age: {program.agePersonalData}");
            //Console.WriteLine($"Gender: {program.genderPersonalData}");
            if (program.genderPersonalData == 'm')
            {
                Console.WriteLine("Gender: male");
            }
            else
            {
                Console.WriteLine("Gender: female");
            }

            Console.WriteLine($"PESEL: {program.peselPersonalData}");
            Console.WriteLine($"Mobile: {program.telMobileNumberPersonalData}");
            Console.WriteLine($"Email: {program.emailPersonalData}");
            Console.WriteLine($"Growth: {program.growthPersonalData}");
            Console.WriteLine($"Weight: {program.weightPersonalData}");
            Console.WriteLine($"Address: {program.addressPersonalData}");
            Console.WriteLine($"Zip Code: {program.zipCodePersonalData}");
            Console.WriteLine($"City: {program.cityPersonalData}");
            Console.WriteLine($"Country: {program.countryPersonalData}");
        }
        
        public void SelectPersonalDetails(string caseOption)
        {
            string inputData = Console.ReadLine();
            switch (caseOption)
            {
                case "name":
                    namePersonalData = inputData;
                    break;

                case "surname":
                    surnamePersonalData = inputData;
                    break;

                case "age":
                    agePersonalData = gvl.GetIntValue(inputData);
                    break;

                case "gender":
                    genderPersonalData = gvl.GetGender(inputData);
                    break;

                case "pesel":
                    peselPersonalData = gvl.GetPesel(inputData);
                    break;

                case "tel_mobile_number":
                    telMobileNumberPersonalData = gvl.GetMobileNumber(inputData);
                    break;

                case "email":
                    emailPersonalData = inputData;
                    break;

                case "growth":
                    growthPersonalData = gvl.GetIntValue(inputData);
                    break;

                case "weight":
                    weightPersonalData = gvl.GetWeight(inputData);
                    break;

                case "address":
                    addressPersonalData = inputData;
                    break;

                case "zip_code":
                    zipCodePersonalData = gvl.GetZipCode(inputData);
                    break;

                case "city":
                    cityPersonalData = inputData;
                    break;

                case "country":
                    countryPersonalData = inputData;
                    break;

            }
        }


    }

    public class ValidationLibrary
    {
        /*
         * With firstCharacter you can decide which range of numers you are interested in. Like:
         * 0-9
         * 1-9
         * 2-9
         * etc ...       
         */
        public bool ContainsOnlyNumbers (string inputString, string firstCharacter)
        {
            firstCharacter = Regex.Escape(firstCharacter);
            return Regex.IsMatch(inputString, @"^[" + firstCharacter + "-9]+$") ? true : false;
        }

        public bool CanConvertToInt(string inputString)
        {
            int inputStringLength = inputString.Length;
            string firstCharacter = inputString.Substring(0, 1);
            if (inputStringLength ==1)
            {
                return ContainsOnlyNumbers(firstCharacter, "0") ? true : false;
            } 
            else
            {
                string restOfString = inputString.Substring(1);
                bool canConvert = ContainsOnlyNumbers(firstCharacter, "1") && ContainsOnlyNumbers(restOfString, "0");
                return canConvert ? true : false;
            }                                                
        }

        public bool IsZipCode(string inputString)
        {
            if (inputString.Length == 6)
            {                
                string twoNumbersSection = inputString.Substring(0,2);
                string dashSection = inputString.Substring(2, 1);
                string threeNumbersSection = inputString.Substring(3, 3);
                bool isZipCode = ContainsOnlyNumbers(twoNumbersSection, "0")
                    && dashSection == "-"
                    && ContainsOnlyNumbers(threeNumbersSection, "0");
                return isZipCode ? true : false;
            }
            return false;
        }

        public bool IsPesel(string inputString)
        {
            //^\d{11}$
            return Regex.IsMatch(inputString, @"^\d{11}") ? true : false;
        }

        public bool IsGender (string inputString)
        {
            bool correctLength = (inputString.Length == 1) ? true : false;
            bool isMorF = (inputString == "m" || inputString == "f");
            return correctLength && isMorF;
        }

        public bool IsMobileNumber (string inputString)
        {
            bool correctLength = (inputString.Length == 9) ? true : false;
            bool onlyNumbers = ContainsOnlyNumbers(inputString, "0");
            return correctLength && onlyNumbers;
        }

        public bool canConvertToDecimal(string inputString)
        {
            decimal decimalValue; 
            return Decimal.TryParse(inputString, out decimalValue) ? true : false;
        }

    }

    public class GetValuesLibrary
    {
        ValidationLibrary vl = new ValidationLibrary();

        
        
        public int GetIntValue(string inputString)
        {
            bool correctValue = false;
            string errorInfo;            
            while (!correctValue)
            {
                if (!vl.CanConvertToInt(inputString))
                {
                    errorInfo = "Entered value is not a number. Try once again:";
                    Console.WriteLine($"{errorInfo}");
                    inputString = Console.ReadLine();
                }
                else
                {
                    correctValue = true;
                }
            }
            return int.Parse(inputString);
        }

        public string GetPesel (string inputString)
        {
            bool correctValue = false;
            string errorInfo;
            while (!correctValue)
            {
                if (!vl.IsPesel(inputString))
                {
                    errorInfo = "Entered value is not a PESEL (11 digits). Try once again:";
                    Console.WriteLine($"{errorInfo}");
                    inputString = Console.ReadLine();
                }
                else
                {
                    correctValue = true;
                }
            }
            return inputString;
        }

        public char GetGender(string inputString)
        {
            bool correctValue = false;
            string errorInfo;
            while (!correctValue)
            {
                if (!vl.IsGender(inputString))
                {
                    errorInfo = "Entered value is not a symbol of gender (m or f). Try once again:";
                    Console.WriteLine($"{errorInfo}");
                    inputString = Console.ReadLine();
                }
                else
                {
                    correctValue = true;
                }
            }
            return char.Parse(inputString);
        }

        public string GetMobileNumber (string inputString)
        {
            bool correctValue = false;
            string errorInfo;
            while (!correctValue)
            {
                if (!vl.IsMobileNumber(inputString))
                {
                    errorInfo = "Entered value is not a mobile number (it should consist of 9 digits). Try once again:";
                    Console.WriteLine($"{errorInfo}");
                    inputString = Console.ReadLine();
                }
                else
                {
                    correctValue = true;
                }
            }
            return inputString;
        }

        public decimal GetWeight(string inputString)
        {
            bool correctValue = false;
            string errorInfo;
            //inputString = inputString;            
            while (!correctValue)
            {
                if (!vl.canConvertToDecimal(inputString))
                {
                    errorInfo = "Entered value is not a decimal number. Try once again:";
                    Console.WriteLine($"{errorInfo}");
                    inputString = Console.ReadLine();
                }
                else
                {
                    
                    correctValue = true;
                }
            }
            return decimal.Parse(inputString);
        }

        public string GetZipCode(string inputString)
        {
            bool correctValue = false;
            string errorInfo;
            while (!correctValue)
            {
                if (!vl.IsZipCode(inputString))
                {
                    errorInfo = "Entered value is not a zip code (format nn-nnn). Try once again:";
                    Console.WriteLine($"{errorInfo}");
                    inputString = Console.ReadLine();
                }
                else
                {
                    correctValue = true;
                }
            }
            return inputString;
        }
    }
}