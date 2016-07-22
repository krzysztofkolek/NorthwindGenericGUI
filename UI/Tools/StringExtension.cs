

namespace RAD_Project.UI.Tools
{
    using System;

    public static class StringExtension
    {
        public static String SplitOnCapitals(this string text)
        {
            string newstring = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                    newstring += " ";
                newstring += text[i].ToString();
            }
            return newstring;
        }
    }
}
