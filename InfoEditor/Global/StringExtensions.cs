using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoEditor.Global
{
    public static class StringExtensions
    {
        public static char[] ToAceCharArray(this string str)
        {
            char[] arr = new char[20];
            for(int i = 0; i < 20;i++)
                if (i < str.Length)
                    arr[i] = str[i];
                else
                    arr[i] = '\0';

            return arr;
        }

       
    }
}
