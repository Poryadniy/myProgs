using System;

namespace passGen
{
    class Program
    {
        static void Main(string[] args)
        {
            string symbols = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890!@#$%^&*()_+-=[];',./";
            string res = "";

            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                res += symbols[rnd.Next(symbols.Length - 1)];
            }
        }
    }
}
  
