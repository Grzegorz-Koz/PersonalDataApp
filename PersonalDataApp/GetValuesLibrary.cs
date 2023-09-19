namespace PersonalDataApp
{
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