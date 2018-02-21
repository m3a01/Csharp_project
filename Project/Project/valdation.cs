using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class valdation
    {
        public static int Vald(string text)
        {
            int count = 0;
            char[] txt = text.ToCharArray();
            for(int i =0; i< text.Length; i++)
            {
                if((txt[i] >=33 && txt[i]<=74))
                    count++;
                
            }

            return count;
        }
    }
}
