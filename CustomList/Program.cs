using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListClass
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> integerList = new CustomList<int>();
            integerList.Add(1);
            int test = integerList[1];

        }
    }
}
