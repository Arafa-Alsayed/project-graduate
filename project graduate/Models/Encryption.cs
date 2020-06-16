using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_graduate.Models
{
    public class Encryption
    {

        public string[] split_binary(string binarystring)
        {

            int count = 2;
            int countarr = 0;
            string _binary = binarystring;
            string[] arr = new string[_binary.Length / 2];
            for (int i = 0; i < _binary.Length; i += 2)
            {
                arr[countarr] = _binary.Substring(i, count);

                countarr++;
            }
            return arr;
        }
        public string[] convert_to_dna(string[] binaryarr)
        {
            string[] dna_arr = new string[binaryarr.Length];
            for (int i = 0; i < binaryarr.Length; i++)
            {
                if (binaryarr[i] == "00")
                    dna_arr[i] = "A";
                else if (binaryarr[i] == "01")
                    dna_arr[i] = "C";
                else if (binaryarr[i] == "10")
                    dna_arr[i] = "G";
                else if (binaryarr[i] == "11")
                    dna_arr[i] = "T";
                else { }


            }
            return dna_arr;
        }
        public string convert_to_RNA(string[] dna_arr)
        {
            string RNA = "";
            for (int i = 0; i < dna_arr.Length; i++)
            {
                RNA += dna_arr[i] + "AAAAA";
            }
            return RNA;
        }
        public string StringToBinary(string stringdata)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in stringdata.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }
    }
}
