using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListClass
{
    public class CustomList<T>
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
            T[] newListItems = new T[capacity];
            for (int i = 0; i < count; i++)
            {
                newListItems[i] = listItems[i];
            }
            return newListItems;
        }

        public void Add(T item)
        {
            if ( count * 2 >= capacity )
            {
                T[] newListItems = GetLargerArray();
                listItems = newListItems;
            }
            listItems[count] = item;
            count++;
        }

        public bool Remove(T item)
        {
            bool itemFound = false;
            int i = 0;
            int itemIndex = 0;
            while(!itemFound && i<count)
            {
                if ( listItems[i].Equals(item) )
                {
                    itemIndex = i;
                    itemFound = true;
                }
                i++;
            }
            if ( !itemFound )
            {
                return false;
            }
            else
            {
                T[] newListItems = new T[capacity];
                for ( int j=0; j<count; j++ )
                {
                    if ( j<itemIndex )
                    {
                        newListItems[j] = listItems[j];
                    }
                    else if (j>itemIndex) {
                        newListItems[j-1] = listItems[j];
                    }
                }
                count--;
                listItems = newListItems;
                return true;
            }

        }

    }
}
