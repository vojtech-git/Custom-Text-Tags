using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CustomTextTags
{
    // asi to vyřeším pomocí String.Substring() a String.IndexOf().
    // pomoci toho najdu otevírací string a zavírací string a jejich pozice 
    // potom si ulozim string mezi jejich pozicema a pak v původnim textu dam proste Replace() ty strigy co jsem nasel mezi tagama
    // jaký tag jsem nasel a co je mezi nim za string si ulozim do dictionary a potom proste budu mit metodu ReplaceStrings()

    class Program
    {
        static string userInput;
        static void Main(string[] args)
        {
            userInput = Console.ReadLine();
        }
    }
}
