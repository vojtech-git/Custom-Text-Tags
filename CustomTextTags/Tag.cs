using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTextTags
{
    class Tag
    {
        public string tagName;

        public ReplaceString replaceLogic;

        public string Replace(string stringToReplace) // logika stejná pro všechny tagy
        {
            stringToReplace.Replace($"<{tagName}>", "");
            stringToReplace.Replace($"</{tagName}>", "");

            replaceLogic(stringToReplace);

            return stringToReplace;
        }
    }
}
