using System;
using System.Text.RegularExpressions;

namespace CustomTextTags
{
    // asi to vyřeším pomocí String.Substring() a String.IndexOf().
    // pomoci toho najdu otevírací string a zavírací string a jejich pozice 
    // potom si ulozim string mezi jejich pozicema a pak v původnim textu dam proste Replace() ty strigy co jsem nasel mezi tagama
    // jaký tag jsem nasel a co je mezi nim za string si ulozim do dictionary a potom proste budu mit metodu ReplaceStrings()

    // ok existuje Regex.Match() což vrací ten matchující string to řeší hodně

    public delegate string ReplaceString(string textToEdit);

    class Program
    {        
        public static Tag[] tags = new Tag[] { new Tag { tagName = "!", replaceLogic = new ReplaceString(replaceLogicExclamationMark) } }; // názvy tagů

        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
            //Edit(userInput);

            Console.WriteLine(Edit(userInput));
            Console.ReadLine();
        }

        public static string Edit(string textToEdit)
        {
            string finishedValue = "";

            Regex rgx;
            string pattern;

            foreach (Tag tag in tags)
            {
                pattern = @"<" + tag.tagName + @">\S*<\/" + tag.tagName + @"\>";
                rgx = new Regex(pattern);

                MatchCollection matches = rgx.Matches(textToEdit);

                foreach (Match match in matches)
                {
                    if (match.Success)
                    {
                        finishedValue = textToEdit.Replace(match.Value, tag.Replace(match.Value));
                        Console.WriteLine("match succes with tag " + tag.tagName);

                    }
                    else
                    {
                        Console.WriteLine("match not succes with tag " + tag.tagName);

                    }
                }
            }

            return finishedValue;
        }

        #region replace metohods
        public static string replaceLogicExclamationMark(string textForExclamation)
        {
            return $"!!{textForExclamation.ToUpper()}!!";
        }
        #endregion
    }
}
