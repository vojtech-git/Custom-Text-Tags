using System;
using System.Text.RegularExpressions;

namespace CustomTextTags
{
    public delegate string ReplaceString(string textToEdit);

    class Program
    {
        public static Tag[] tags = new Tag[] { new Tag { tagName = "!", replaceLogic = new ReplaceString(ReplaceLogicExclamationMark) }, new Tag { tagName = "_", replaceLogic = new ReplaceString(ReplaceLogicUnderscore) } }; // názvy tagů
        public static string userInput;


        static void Main(string[] args)
        {
            foreach (string consoleAddedText in args)
            {
                Console.WriteLine(Edit(consoleAddedText));
            }

            Console.ReadLine();
        }

        public static string Edit(string textToEdit)
        {
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
                        textToEdit = textToEdit.Replace(match.Value, tag.Replace(match.Value));

                    }
                }
            }

            return textToEdit;
        }

        #region replace metohods
        public static string ReplaceLogicExclamationMark(string textForExclamation)
        {
            return $"!!{textForExclamation.ToUpper()}!!";
        }

        public static string ReplaceLogicUnderscore(string textForUnderscore)
        {
            int eSize = textForUnderscore.Length;
            textForUnderscore = textForUnderscore.Replace(textForUnderscore, "");
            for (int i = 0; i < eSize; i++)
            {
                textForUnderscore += "_";
            }

            return textForUnderscore;
        }
        #endregion
    }
}
