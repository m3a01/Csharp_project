using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class En_DeCrypte
    {
        public static string encryote(string text)
        {
            char[] txt = text.ToCharArray();
            for (int count = 0; count < text.Length; count++)
            
                {
                    for (int i = 0; i < 3; i++)
                    {
                    if (txt[count] == 'z')
                        txt[count] = 'a';
                    else
                        txt[count]++;
                    }
                
                }
            return new String(txt);
        }
        public static string dcryote(string text)
        {
            char[] txt = text.ToCharArray();
            for (int count = 0; count < text.Length; count++)

            {
                for (int i = 0; i < 3; i++)
                {
                    if (txt[count] == 'a')
                        txt[count] = 'z';
                    else
                        txt[count]--;
                }

            }
            return new String(txt);
        }
    }
    }

