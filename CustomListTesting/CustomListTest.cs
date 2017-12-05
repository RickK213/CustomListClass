using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomListClass;

namespace CustomListTesting
{
    [TestClass]
    public class CustomListTest
    {

        //Add method tests================================================================================================================
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

        //Remove method tests================================================================================================================
        [TestMethod]
        public void Remove_AddAndRemoveOneObject_CustomListDoesNotContainObject()
        {
            //When I add to and remove one object from my CustomList, I expect the CustomList to not contain the object 

            //arrange
            CustomList<Object> myList = new CustomList<Object>();
            Object obj = new Object();
            myList.Add(obj);

            //act
            myList.Remove(obj);

            //assert
            //YOU ARE HERE! NEED TO WRITE YOUR ASSERT!
        }


    }
}
