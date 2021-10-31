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

        public string Replace(string stringToTag) // logika stejná pro všechny tagy
        {
            stringToTag = stringToTag.Replace($"<{tagName}>", "");
            stringToTag = stringToTag.Replace($"</{tagName}>", "");

            stringToTag = replaceLogic(stringToTag);

            return stringToTag;
        }
    }
}
