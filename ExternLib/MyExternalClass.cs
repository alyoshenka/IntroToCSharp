using System;
using System.Collections.Generic;
using System.IO;


namespace ExternLib
{
    class Level
    {         // get level from path
        public List<int> GetLevel(string path)
        {
            List<int> arr = new List<int>();
            StreamReader sr = new StreamReader(path);
            for(int i = 0; sr.Peek() != -1; i++)
            {                
                string nums = sr.ReadLine();
                foreach(char c in nums)
                {
                    arr.Add(Int32.Parse(c.ToString()));
                }
                arr.Add(-1); // new line

            }
            sr.Close();
            return arr;
        }
        public string Test() { return "test"; }
    }
}
