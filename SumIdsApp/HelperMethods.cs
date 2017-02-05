using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SumIdsApp
{
    public class HelperMethods
    {
        /// <summary>
        /// Returns true if this file exists
        /// </summary>
        public static bool IsFilePathValid(string path)
        {
            return System.IO.File.Exists(path);
        }

        /// <summary>
        /// Loads the data in the given file into the RootObject 
        /// Will print error message if the given file does not match the RootObject Schema
        /// </summary>
        public static bool LoadData(string path, RootObject ro)
        {
            if (!IsFilePathValid(path))
            {
                return false;
            }
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();

                try
                {
                    ro.Property1 = JsonConvert.DeserializeObject<RootObject.MenuHolder[]>(json);
                }
                catch (JsonException e)
                {
                    Console.WriteLine("The file given did not match our schema, error below:");
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Calculates the sum of ids with non null label for each list
        /// Returns list of ints
        /// </summary>
        public static List<int> CalculateSums(RootObject ro)
        {
            List<int> sumList = new List<int>();
            foreach (int sum in ro.Property1.Select(class1 => class1.Menu.Items.Where(x => x != null && x.Label != null).Sum(item => item.Id)))
            {
                //Console.WriteLine("Sum: {0}", sum);
                sumList.Add(sum);
            }
            return sumList;
        }
    }
}
