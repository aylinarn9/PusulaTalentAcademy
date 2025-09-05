using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class soru2
    {

        public static string LongestVowelSubsequenceAsJson(List<string> words)
        {
            if (words == null || words.Count == 0)
                return "[]"; 

            string sesli_ayrac = "aeıioöuü";

            
            var sonucList = new List<object>();

            foreach (var word in words)
            {
                string en_uzun_subarr = "";
                string temp = "";

                foreach (char c in word)
                {
                    if (sesli_ayrac.Contains(c))
                    {
                        temp += c;
                        if (temp.Length > en_uzun_subarr.Length)
                            en_uzun_subarr = temp;
                    }
                    else
                    {
                        temp = ""; 
                    }
                }
                sonucList.Add(new
                {
                    word = word,
                    sequence = en_uzun_subarr,
                    length = en_uzun_subarr.Length
                });
            }

            return JsonSerializer.Serialize(sonucList, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
