using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomListClass;

namespace CustomListTesting
{
    [TestClass]
    public class CustomListTest
    {

        //Add method tests=====================================================================================================
        [TestMethod]
        public void Add_AddFirstString_FirstItemEqualsStringAdded()
        {
            //arrange
            string testString = "Rick";
            CustomList<string> myList = new CustomList<string>();

            //act
            myList.Add(testString);

            //assert
            //How to reference an index of a custom class? Refer to the internal array.
            //answer: LOOK UP C# indexer!!
            //also, will need to use IEnumerable interface later on!!!
            Assert.AreEqual(myList[0], testString);
        }

        [TestMethod]
        public void Add_AddFirstItem_CountEqualsOne()
        {
            //arrange
            string testString = "Rick";
            CustomList<string> myList = new CustomList<string>();

            //act
            myList.Add(testString);

            //assert
            Assert.AreEqual(myList.Count, 1); //Need to set up Count as a property!!! Read-only!
        }

        [TestMethod]
        public void Add_AddFiveItems_CountEqualsFive()
        {
            //arrange
            string testString = "Rick";
            CustomList<string> myList = new CustomList<string>();

            //act
            for (int i = 0; i < 5; i++)
            {
                myList.Add(testString);
            }

            //assert
            Assert.AreEqual(myList.Count, 5); //Need to set up Count as a property!!!
        }

        [TestMethod]
        public void Add_AddTwentyItems_CountEqualsTwenty()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();

            //act
            for (int i = 0; i < 5; i++)
            {
                myList.Add(i);
            }

            //assert
            Assert.AreEqual(myList.Count, 5); //Need to set up Count as a property!!!
        }

        [TestMethod]
        public void Add_AddFirstObject_FirstItemEqualsObjectAdded()
        {
            //arrange
            Object obj = new Object();
            CustomList<Object> myList = new CustomList<Object>();

            //act
            myList.Add(obj);

            //assert
            Assert.AreEqual(myList[0], obj);
        }

        [TestMethod]
        public void Add_AddNullValueType_FirstItemEqualsNull()
        {
            //arrange
            int? number = null;
            CustomList<int?> myList = new CustomList<int?>();

            //act
            myList.Add(number);

            //assert
            Assert.IsNull(myList[0]);
        }

        [TestMethod]
        public void Add_AddThreeItems_LastItemInListIsLastOneAdded()
        {
            //arrange
            string itemOne = "Item1";
            string itemTwo = "Item2";
            string itemThree = "Item3";
            CustomList<string> myList = new CustomList<string>();

            //act
            myList.Add(itemOne);
            myList.Add(itemTwo);
            myList.Add(itemThree);

            //assert
            Assert.AreEqual(myList[2], itemThree);
        }

        [TestMethod]
        public void Add_AddThirtyNumbersAsStrings_IndexesEqualStringValue()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();

            //act
            for ( int i=0; i<30; i++ )
            {
                myList.Add( i.ToString() );
            }

            //assert
            Assert.AreEqual(Int32.Parse(myList[12]), 12);
        }

        //Remove method tests=================================================================================================
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Remove_AddAndRemoveOneObject_CustomListZeroIndexThrowsException()
        {
            //arrange
            CustomList<Object> myList = new CustomList<Object>();
            Object obj = new Object();
            myList.Add(obj);

            //act
            myList.Remove(obj);
            Object newObj = myList[0];
        }

        [TestMethod]
        public void Remove_AddAndRemoveOneObject_CustomListCountIsZero()
        {
            //arrange
            CustomList<Object> myList = new CustomList<Object>();
            Object obj = new Object();
            myList.Add(obj);

            //act
            myList.Remove(obj);


            //assert
            Assert.AreEqual(myList.Count, 0);
        }

        [TestMethod]
        public void Remove_AddFiveObjectsAndRemoveOneObject_CustomListCountIsFour()
        {
            //arrange
            CustomList<Object> myList = new CustomList<Object>();
            Object obj = new Object();
            for (int i = 0; i < 5; i++)
            {
                myList.Add(obj);
            }

            //act
            myList.Remove(obj);

            //assert
            Assert.AreEqual(myList.Count, 4);
        }

        [TestMethod]
        public void Remove_AddFourStringsAndRemoveOneString_LastItemInCustomListIsThirdAdded()
        {
            //arrange
            CustomList<Object> myList = new CustomList<Object>();
            myList.Add("string 1");
            myList.Add("string 2");
            myList.Add("string 3");
            myList.Add("string 4");

            //act
            myList.Remove("string 4");

            //assert
            Assert.AreEqual(myList[myList.Count - 1], "string 3");
        }

        [TestMethod]
        public void Remove_AddAndRemoveOneObject_MethodReturnsTrue()
        {
            //arrange
            CustomList<Object> myList = new CustomList<Object>();
            Object obj = new Object();
            myList.Add(obj);

            //act
            bool didRemove = myList.Remove(obj);

            //assert
            Assert.IsTrue(didRemove);
        }

        [TestMethod]
        public void Remove_AddStringAndRemoveUnfindableString_MethodReturnsFalse()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("Findable String");

            //act
            bool didRemove = myList.Remove("Unfindable String");

            //assert
            Assert.IsFalse(didRemove);
        }

        [TestMethod]
        public void Remove_AddFourIntegersAndRemoveSecondInteger_ThirdIntegerShiftsToIndexOne()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);

            //act
            myList.Remove(2);

            //assert
            Assert.AreEqual(myList[1], 3);
        }

        [TestMethod]
        public void Remove_AddFourIntegersAndRemoveSecondInteger_FourthIntegerShiftsToIndexTwo()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);

            //act
            myList.Remove(2);

            //assert
            Assert.AreEqual(myList[2], 4);
        }

        [TestMethod]
        public void Remove_RemoveIntegerZeroFromEmptyList_RemoveReturnsFalse()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();

            //act
            bool result = myList.Remove(0);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Contains_AddIntegerRunContainsForThatInteger_ResultIsTrue()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();
            myList.Add(0);

            //act
            bool result = myList.Contains(0);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Contains_RunContainsOnEmptyList_ResultIsFalse()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();

            //act
            bool result = myList.Contains("literally anything");

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Contains_AddFindableRunsContainsOnUnfindable_ResultIsFalse()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("Findable String");

            //act
            bool result = myList.Contains("Unfindable String");

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IndexOf_AddFourIntegersRunIndexOfOnThird_ResultIsTwo()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);

            //act
            int result = myList.IndexOf(3);

            //assert
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void IndexOf_AddFourIntegersRunIndexOfUnfindable_ResultIsNegativeOne()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);

            //act
            int result = myList.IndexOf(84);

            //assert
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void IndexOf_AddFourStringsRunIndexOfOnFourth_ResultIsThree()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("alpha");
            myList.Add("beta");
            myList.Add("charlie");
            myList.Add("delta");

            //act
            int result = myList.IndexOf("delta");

            //assert
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void IndexOf_AddDuplicateStringsRunIndexOfOnString_ResultIsIndexOfFirstOccurance()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("alpha");
            myList.Add("beta");
            myList.Add("charlie");
            myList.Add("delta");
            myList.Add("beta");

            //act
            int result = myList.IndexOf("beta");

            //assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void RemoveAt_AddItemRemoveAtIndexZero_CountOfCustomListIsZero()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("alpha");

            //act
            myList.RemoveAt(0);

            //assert
            Assert.AreEqual(myList.Count, 0);
        }

        [TestMethod]
        public void RemoveAt_AddFourItemsRemoveIndexTwo_ContainsReturnsFalse()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("alpha");
            myList.Add("beta");
            myList.Add("charlie");
            myList.Add("delta");

            //act
            myList.RemoveAt(2);
            bool result = myList.Contains("charlie");

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetEnumerator_AddTwoIntegersToListForeachToCalculateSum_SumIsAllCorrectSumOfAllListItems()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();
            myList.Add(1);
            myList.Add(1);

            //act
            int sum = 0;
            foreach (int number in myList)
            {
                sum += number;
            }

            //assert
            Assert.AreEqual(sum, 2);
        }

        [TestMethod]
        public void GetEnumerator_UseForEachToLookForString_StringIsFound()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("alpha");
            myList.Add("beta");
            myList.Add("charlie");
            myList.Add("delta");

            //act
            bool charlieFound = false;
            foreach (string word in myList)
            {
                if (word == "charlie")
                {
                    charlieFound = true;
                }
            }

            //assert
            Assert.IsTrue(charlieFound);
        }

        [TestMethod]
        public void GetEnumerator_UseForEachToActOnObject_ObjectsInListEqualsOriginal()
        {
            //arrange
            CustomList<Object> myList = new CustomList<Object>();
            Object obj = new object();
            for (int i=0; i<5; i++)
            {
                myList.Add(obj);
            }

            //act
            bool objectsEqualObject = true;
            foreach (Object genericObject in myList)
            {
                if(!genericObject.Equals(obj))
                {
                    objectsEqualObject = false;
                }
            }

            //assert
            Assert.IsTrue(objectsEqualObject);
        }

        [TestMethod]
        public void ToString_AddFourStrings_ResultIsConcatenatedString()
        {
            //arrange
            CustomList<string> myList = new CustomList<string>();
            myList.Add("alpha");
            myList.Add("beta");
            myList.Add("charlie");
            myList.Add("delta");

            //act
            string result = myList.ToString();

            //assert
            Assert.AreEqual(result, "alphabetacharliedelta");
        }

        [TestMethod]
        public void ToString_AddFourIntegers_ResultIsConcatenatedString()
        {
            //arrange
            CustomList<int> myList = new CustomList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);

            //act
            string result = myList.ToString();

            //assert
            Assert.AreEqual(result, "1234");
        }

    }
}
