using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_graduate.Models
{
    public class Decryption_Class
    {
        public string[] convert_finalDNA_to_DNA(string[] Final_DNA)
        {
            string[] DNA_arr = new string[Final_DNA.Length / 5];
            int count = 0;
            for (int i = 0; i < Final_DNA.Length; i += 6)
            {
                DNA_arr[count] = Final_DNA[i];
                count++;
            }
            return DNA_arr;
        }

        public string[] split_DNA(string finalDNA)
        {


            int countarr = 0;

            string[] arr = new string[finalDNA.Length];
            for (int i = 0; i < finalDNA.Length; i++)
            {
                arr[countarr] = finalDNA.Substring(i, 1);

                countarr++;
            }
            return arr;
        }
        public string convert_DNA_to_binary(string[] DNA_arr)
        {
            string binary = "";
            for (int i = 0; i < DNA_arr.Length; i++)
            {
                if (DNA_arr[i] == "A")
                    binary += "00";
                else if (DNA_arr[i] == "C")
                    binary += "01";
                else if (DNA_arr[i] == "G")
                    binary += "10";
                else if (DNA_arr[i] == "T")
                    binary += "11";
                else { }
            }
            return binary;
        }
        public string BinaryToString(string binarydata)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < binarydata.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(binarydata.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }
    }
}

