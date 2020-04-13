using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLE
{
    class Program
    {
        static void Main(string[] args)
        {
            /*takes a string, returns compressed string
             aaabbbcccAAABBBCCC => 3a3b3c3A3B3C*/

            Console.WriteLine("Compression: \n"+
                RLComp("aaabbbcccaaaAAABBBCCC"));
            Console.WriteLine("Decompression: \n"+
                RLUcomp("3a3b3c3a3A3B3C"));
            Console.ReadKey();

        }
        static string RLComp(string uncompressed) {
            int c_count = 0;
           uncompressed.ToCharArray();
            int n = uncompressed.Length;
            char prev = uncompressed[0];
            StringBuilder ret_string = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                c_count = 1;
                while (i < n -1 && uncompressed[i] == uncompressed[i+1])
                {
                    c_count++;
                    i++;
                }
                    ret_string.Append($"{c_count}{uncompressed[i]}");
            }
            return ret_string.ToString();            
        }

        static string RLUcomp(string compressed) {
            char c_count = '\0';
            compressed.ToCharArray();
            StringBuilder ret_string = new StringBuilder();
            foreach(char c in compressed)
            {
                if (Char.IsNumber(c))
                {
                     //if char is numerical, append to the count
                    c_count += c;
                }
                else //else append char and reset counter
                {
                    for (int i = 0; i < (Convert.ToInt32(c_count)-48); i++)
                    {
                        ret_string.Append(c);

                    }
                    c_count = '\0';
                }
            }
            return ret_string.ToString();
        }
    }
}
