using System;
using System.Text.RegularExpressions;

namespace PhanMemQLTV
{
    class Validation
    {
        const string REGEX_NAME = "^[^\\d!@#$%^&*()_+<>?/\\|{}[\\]~-]{1,100}$";
        const string REGEX_ADDRESS = "^[a-zA-Z0-9][^!@#$%^&*()_+<>?/\\|{}[\\]~-]{1,100}$";
        const string REGEX_PHONE = "^((0[35789])|(84[35789]))([0-9]{8})$";
        const string REGEX_PASS = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,10}$";
        const string REGEX_QUANTITY = "^(?:[1-9]|[1-9][0-9]|[1-9][0-9]{2}|999)$";
        const string REGEX_PRICE = "^[0-9]+$";        
        string REGEX_YEAR = Validation.setRegexYear();

        private static string setRegexYear()
        {
            int currentYear = DateTime.Now.Year;
            string currentY = currentYear.ToString();
            char[] yArray = currentY.ToCharArray();
            string regexYear = @"^(19[0-9]{2}|200[0-9]|201[0-9]|" + yArray[0] + yArray[1] + "[0-" + yArray[2] + "][0-" + yArray[3] + "])$";
            Console.WriteLine(regexYear);
            return regexYear;
        }
        public static bool isNameValid(string name)
        {
            if(!Regex.Match(name.Trim(), REGEX_NAME).Success)
            {   
                return false;
            }
            return true;
        }
        public static bool isPhoneValid(string phone)
        {
            if (!Regex.Match(phone, REGEX_PHONE).Success)
            {
                return false;
            }
            return true;
        }
        public static bool isAddressValid(string address)
        {
            if (!Regex.Match(address, REGEX_ADDRESS).Success)
            {
                return false;
            }
            return true;
        }
        public static bool isUserNameValid(string username)
        {
            return true;
        }
        public static bool isPassValid(string pass)
        {
            if (!Regex.Match(pass, REGEX_PASS).Success)
            {
                return false;
            }
            return true;
        }
        public static bool isQuantityValid(string quantity)
        {
            if (!Regex.Match(quantity, REGEX_QUANTITY).Success)
            {
                return false;
            }
            return true;
        }

        public static bool isYearValid(string year)
        {
            Validation validation = new Validation();
            if (!Regex.Match(year, validation.REGEX_YEAR).Success)
            {
                return false;
            }
            return true;
        }

        public static bool isPriceValid(string price)
        {
            if (!Regex.Match(price, REGEX_PRICE).Success)
            {
                return false;
            }
            return true;
        }
    }
}
