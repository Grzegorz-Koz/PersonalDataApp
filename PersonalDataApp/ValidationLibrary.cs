using System.Text.RegularExpressions;

namespace PersonalDataApp
{
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
}