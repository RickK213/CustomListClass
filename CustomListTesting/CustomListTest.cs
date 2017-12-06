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
            //When I call the Add method and pass in a string, I expect the first item in the CustomList to be equal to the string I added

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
            //When I call the Add method for the first time, I expect the count property of the CustomList object to be equal to 1

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
            //When I call the Add method five times, I expect the count property of the CustomList object to be equal to 5

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
            //When I call the Add method twenty times, I expect the count property of the CustomList object to be equal to 20

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
            //When I call the Add method and pass in an object, I expect the first item in the CustomList to be equal to the object I added

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
            //When I call the Add method and pass in an null value type, I expect the first item in the CustomList to be equal to null

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
            //When I add three items to the custom list, I expect the last item added to be equal to the last index in the list

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
            //When I add number.ToString() to CustomList, I expect the indexes to be equal to the Int32.Parse value

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
            //When I add to and remove one object from my CustomList, I expect CustomList[0] to throw an exception

            //NOTE!!! what if we have a list of integers? Intantiation of the list creates a list of 5 0's
            //Modify the indexer to throw an exception if you try to access any list index when the list (should) be empty
            //or when you try to access and index lower than the count
            //Note! You need to be sure that legitimate 0 values remain

            //arrange
            CustomList<Object> myList = new CustomList<Object>();
            Object obj = new Object();
            myList.Add(obj);

            //act
            myList.Remove(obj);

            //assert
            //NO ASSERT WHEN TESTING FOR AN EXCEPTION! See [ExpectedException...] above
            //this test passes because we are expecting an exception. You can be more specific about what type of exception you expect
            //the type of exception I expect is 'System.Exception' according to my indexer

        }

        [TestMethod]
        public void Remove_AddAndRemoveOneObject_CustomListCountIsZero()
        {
            //When I add to and remove one object from my CustomList, I expect the Count of the CustomList to be zero 

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
            //When I add 5 objects and remove one object from my CustomList, I expect the Count of the CustomList to be four 

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
            //When I add 4 strings and remove one string from my CustomList, I expect the last item in the CustomList to be third one added 

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
            //When I add to and remove one object from my CustomList, I expect the Remove method to return true 

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
            //When I add a string and remove an unfindable string from my CustomList, I expect the Remove method to return false

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
            //When I add 4 integers to my CustomList and Remove the 2nd integer added, I expect the third integer to shift to index 1 

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
            //When I add 4 integers to my CustomList and Remove the 2nd integer added, I expect the fourth integer added to shift to index 2 

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

    }
}
