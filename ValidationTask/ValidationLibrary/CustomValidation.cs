using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationLibrary
{
    public class CustomValidator
    {
        public bool wordLength(string word)
        {

            if (word.Length < 2) return false;

            else return true;

        }
        public bool age(int age)
        {
            if (age > 0) return true;

            else return false;
        }

        public bool birthday(int birthday)
        {
            if (birthday < 1970) return true;

            else return false;
        }

        public bool ValidatePassword(string password)
        {

            int checkNum = 0;
            int checkUpper = 0;
            int checkLower = 0;
            int checkSpecial = 0;

            if (password.Length < 8) return false;

            foreach (char c in password)
            {

                if (c >= '0' && c <= '9')
                {
                    checkNum++;
                }
                if (c >= 'A' && c <= 'Z')
                {
                    checkUpper++;
                }
                if (c >= 'a' && c <= 'z')
                {
                    checkLower++;
                }

                if ((c >= 33 && c <= 47) ||  // ! " # $ % & ' ( ) * + , - . /
                (c >= 58 && c <= 64) ||  // : ; < = > ? @
                (c >= 91 && c <= 96) ||  // [ \ ] ^ _ `
                (c >= 123 && c <= 126))  // { | } ~
                {
                    checkSpecial++;
                }
            }



            if (checkNum == 0 || checkUpper == 0 || checkLower == 0 || checkSpecial == 0) return false;

            return true;


        }
    }
}
