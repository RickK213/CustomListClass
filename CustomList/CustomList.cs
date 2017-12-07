using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListClass
{
    public class CustomList<T> : IEnumerable<T>
    {
        //member variables
        int count;
        int capacity;
        T[] listItems;

        //properties
        public int Count
        {
            get { return count; }
        }

        public int Capacity
        {
            get { return capacity; }
        }

        //The below is an indexer================================================================
        //Notes on indexers:
        //An indexer is a class property
        //It is a 'parameterized' property - it has parameters
        //'ref' and 'out' paramter modifiers are now allowed
        //at least one parameter should be specified
        public T this [int i]
        {
            get
            {
                if ( i > count-1 )
                {
                    throw new Exception("Index out of range of CustomList");
                }
                else
                {
                    return listItems[i];
                }
            }
            set
            {
                listItems[i] = value;
            }
        }
        //End of indexer==========================================================================

        //constructor
        public CustomList()
        {
            count = 0;
            capacity = 5;
            listItems = new T[capacity];
        }

        //member methods

        T[] GetLargerArray()
        {
            capacity *= 2;
            T[] largerArray = new T[capacity];
            for (int i = 0; i < count; i++)
            {
                largerArray[i] = listItems[i];
            }
            return largerArray;
        }

        public void Add(T item)
        {
            if ( count * 2 >= capacity )
            {
                T[] largerArray = GetLargerArray();
                listItems = largerArray;
            }
            listItems[count] = item;
            count++;
        }

        public bool Contains(T item)
        {
            for ( int i=0; i<count; i++ )
            {
                if ( listItems[i].Equals(item) )
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i=0; i<count; i++)
            {
                if ( listItems[i].Equals(item) )
                {
                    return i;
                }
            }
            return -1;
        }

        public void RemoveAt(int itemIndex)
        {
            for (int i = 0; i < count; i++)
            {
                if (i < itemIndex)
                {
                    listItems[i] = listItems[i];
                }
                else if (i > itemIndex)
                {
                    listItems[i - 1] = listItems[i];
                }
            }
            count--;
        }

        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }
            int itemIndex = IndexOf(item);
            RemoveAt(itemIndex);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for ( int i=0; i<count; i++ )
            {
                yield return listItems[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += listItems[i].ToString();
            }
            return result;
        }

        public static CustomList<T> operator+(CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> addedList = new CustomList<T>;
            for ( int i=0; i<listTwo.Count; i++ )
            {
                addedList.Add(listTwo[i]);
            }
            return listOne;
        }

    }
}
