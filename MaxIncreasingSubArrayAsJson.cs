using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    public class subarray
    {
        public static string MaxIncreasingSubArrayAsJson(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                return JsonSerializer.Serialize(new { Sonuc = new List<int>() }, new JsonSerializerOptions { WriteIndented = true });

            List<int> subArr = null;
            int Sum1 = int.MinValue;

            for (int i = 0; i < numbers.Count; i++)
            {
                List<int> temp_sub = new List<int>();

                for (int j = i; j < numbers.Count; j++)
                {
                    if (temp_sub.Count == 0 || numbers[j] > temp_sub[temp_sub.Count - 1])
                    {
                        temp_sub.Add(numbers[j]);

                        int sum = temp_sub.Sum();
                        if (sum > Sum1)
                        {
                            Sum1 = sum;
                            subArr = new List<int>(temp_sub);
                        }
                    }
                    else break;
                }
            }

            var result = new { Sonuc = subArr };
            return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });

        }

    }
}
