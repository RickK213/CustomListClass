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
            //arrange
            CustomList<string> stringListOne = new CustomList<string>();
            stringListOne.Add("alpha");
            stringListOne.Add("beta");

            CustomList<string> numberListTwo = new CustomList<string>();
            numberListTwo.Add("charlie");
            numberListTwo.Add("delta");

            CustomList<string> expectedResult = new CustomList<string>();
            expectedResult.Add("alpha");
            expectedResult.Add("beta");
            expectedResult.Add("charlie");
            expectedResult.Add("delta");

            //act
            CustomList<string> addedList = stringListOne + numberListTwo;
            for (int i = 0; i < addedList.Count; i++)
            {
                Console.WriteLine(addedList[i]);
            }
            Console.ReadKey();
        }
    }
}
