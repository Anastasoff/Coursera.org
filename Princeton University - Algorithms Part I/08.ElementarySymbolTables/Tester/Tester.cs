using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SymbolTables;

namespace Tester
{
    class Tester
    {
        static void Main()
        {
            TestSequentialSearchST();
        }

        public static void TestSequentialSearchST()
        {
            var st = new SequentialSearchST<string, int>();
            string[] keys = { "S", "E", "A", "R", "C", "H", "E", "X", "A", "M", "P", "L", "E" };
            for (int i = 0; i < keys.Length; i++)
            {
                st.Put(keys[i], i);
            }

            string[] expectedKeys = { "A", "C", "E", "H", "L", "M", "P", "R", "S", "X" };
            foreach (var s in st.Keys())
            {
                Console.WriteLine(s + " " + st.Get(s));
            }


            int[] expectedValues = { 8, 4, 12, 5, 11, 9, 10, 3, 0, 7 };
        }
    }
}
