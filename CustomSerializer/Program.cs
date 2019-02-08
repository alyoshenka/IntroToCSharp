using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace CustomSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1 t1 = new Test1();
            t1.Name = "alexi";
            t1.Number = 100;
            Serialize(t1, "t1.txt");
            Test2 t2 = new Test2();
            t2.name = "jonno";
            t2.Name = "jonno";
            t2.Serialized = false;
            Serialize(t2, "t2.txt");

            Test1 t3 = new Test1();
            t3 = Deserialize<Test1>("t1.txt"); //???
            Serialize(t3, "t3.txt");
        }

        public static void Serialize(object obj, string file)
        {
            // serialize
            var sb = new StringBuilder();
            var objType = obj.GetType();
            IList<FieldInfo> info = new List<FieldInfo>(objType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)); // GetMembers
            foreach (var line in info)
            {
                // if(line.GetCustomAttribute() == typeof(DNS)) { continue; }
                var val = line.GetValue(obj);
                sb.Append(line.Name + "=" + val);
                // Console.WriteLine(line.Name + "=" + val);
                sb.AppendLine();
            }
            sb.AppendLine();

            // save
            string toSave = sb.ToString();
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(toSave);
            // fs.Write(toSave);
            // do i need all these?
            fs.Flush();
            sw.Flush();
            sw.Close();
            fs.Close();

            // Console.WriteLine(toSave);
            // Console.Read();
        }

        public static T Deserialize<T>(string file)
        {
            var temp = Activator.CreateInstance<T>(); // does this create <t> object?
            try
            {                
                // var myType = obj.GetType();
                StreamReader sr = new StreamReader(file);
                // lines
                List<string> lines = new List<string>();
                while (sr.Peek() != -1)
                {
                    lines.Add(sr.ReadLine());
                } 
                // parse string
                foreach(string line in lines)
                {                   
                    // FieldInfo fi = 
                }

                sr.Close();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return temp;
  
        }
    }

    // THESE SHOULD NOT ALL HAVE TO BE PROPERTIES
    class Test1
    {
        public string name;
        private int number;
        public Test1() { name = "no name"; number = 0; }
        public void DoThings() { }
        public string Name { get => name; set => name = value; }
        public int Number { get => number; set => number = value; }
    }

    
    class Test2
    {
        public string name;
        [DNS]
        bool serialized;
        public Test2() { name = "no name"; serialized = true; }
        public string Name { get => name; set => name = value; }
        public bool Serialized { get => serialized; set => serialized = value; }
    }

    // [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class DNS : System.Attribute // FIX ME
    {
        bool IsSerialized = false;
    }
}
