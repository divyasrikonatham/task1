using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        public static bool checkPalin(string word)
        {
            int n = word.Length;
            word = word.ToLower();
            for (int i = 0; i < n; i++, n--)
            {
                if (word[i] != word[n - 1])
                {
                    return false;
                }
            }
            return true;
        }
        public static int countPalin(string str)
        {

            str = str + " ";
            string word = "";
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                if (ch != ' ')
                {
                    word = word + ch;
                }
                else
                {
                    if (checkPalin(word))
                    {
                        count++;
                    }
                    word = "";
                }
            }

            return count;
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("Please enter atleast 500 words description ");
            string str = Console.ReadLine();
            Regex regex = new Regex("[!@#$%^&*]");
            bool hasSpecialChars = regex.IsMatch(str);
            if (hasSpecialChars == true)
            {
                Console.WriteLine("Please re-enter 500 words description without any of the !@#$%^&* special characters");
            }
            else
            {
                int i = 0, wordCount = 1;
                while (i <= str.Length - 1)
                {
                    if (str[i] == ' ' || str[i] == '\n' || str[i] == '\t')
                    {
                        wordCount++;
                    }
                    i++;
                }
                Console.WriteLine("Number of words in the description is {0}", wordCount);
                Console.WriteLine("Number of palindromes in the description is {0}", countPalin(str));
                var outputPath = @"D:\filesIntro\user_input.txt";
                File.AppendAllText(outputPath, str);
            }
            Console.ReadKey();

        }
    }
}
        
    

