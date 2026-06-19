using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;


namespace UserAuth
{
    class Program
    {
        public static void Main(string[] args)
        {
            User newUser = new User();
            newUser.username = "Muhammad Soliman";
            Console.WriteLine(newUser.ValidatePassword("01254899987iE@"));
            Console.WriteLine(newUser.ValidatePassword("012sjklsdl5dfhkjdfhk4899987iE@"));
            newUser.SetPassword("012sjklsdl5dfhkjdfhk4899987iE@");
            newUser.SetEmail("msaied@gmail.com");
            newUser.ShowUserInfo();
        }
    }

    class User
    {
        private string password = "";
        public string username = "";
        private string email = "";

        private bool ValidateEmail(string email)
        {
            /**
            * Regular expression in js follow literal syntax pattern
            *  const regStrictEmail = /^[A-Za-z0-9+%_.-]+@[A-Za-z0-9.-]+\.[A-Za-z0-9]{2,}$/i;
            *  const regLooseEmail = /^[^\s@]+@[^\s@]+\.[A-Za-z0-9]{2,}$/i;
            */
            /// Regalur Expression in C# follow object pattern
            /// using System.Text.RegularExpression;
            /// Regex regStrictEmail = new Regex(@"[A-Za-z0-9+%_.-]+@[A-Za-z0-9.-]+\.[A-Za-z0-9]{2,}", RegexOptions.Compiled)
            /// RegexOptions.Compiled => to get better performance, under the hood c# compiler deals with regular expression as array of characters => char [] not string to catch more performance for RAM  (bitwise operation process)
            Regex regStrictEmail = new Regex(@"^[A-Za-z0-9+%_.-]+@[A-Za-z0-9.-]+\.[A-Za-z0-9]{2,}$", RegexOptions.Compiled);
            return regStrictEmail.IsMatch(email);
        }

        public bool ValidatePassword(string pwd)
        {
            // {1,} => one or more and + => one or more 
            // difference @"[0-9]+" one or more not continuous but also can be separated by other chars or special like 12345678 correct and 12dshgs3456@###78 also correct
            // difference @"[0-9]{8,}" must be followed direclty 8 digits without any separators so 12345678 correct but 12dshgs3456@###78 wrong (fails always)  
            Regex regLower = new Regex(@"[a-z]+", RegexOptions.Compiled);
            Regex regUpper = new Regex(@"[A-Z]+", RegexOptions.Compiled);
            Regex regDigits = new Regex(@"[0-9]+", RegexOptions.Compiled);
            Regex regSpecial = new Regex(@"[~!#$%&*()+/?@]+", RegexOptions.Compiled);

            return regLower.IsMatch(pwd) && regUpper.IsMatch(pwd) && regDigits.IsMatch(pwd) && regSpecial.IsMatch(pwd);
        }
        public void SetPassword(string pass)
        {
            this.password = ValidatePassword(pass) ? pass : "";
        }

        public void SetEmail(string eml)
        {
            this.email = ValidateEmail(eml) ? eml : "";
        }

        public void ShowUserInfo()
        {
            string result = string.IsNullOrEmpty(this.password) ? "fails update must have one or more upper, lower, special characters like \"~!#$%&*()+/?@\" and at least 8 digits" : "updated successfully!";
            Console.WriteLine($"Username = {this.username}\nEmail = {this.email}\nYour password {result}");
        }
    }
}
