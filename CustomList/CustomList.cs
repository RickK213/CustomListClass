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

        //Add to end of array
        public void Add(T item)
        {
            if ( count * 2 >= capacity )
            {
                capacity *= 2;
                T[] newListItems = new T[capacity];
                for (int i=0; i<count; i++)
                {
                    newListItems[i] = listItems[i];
                }
                newListItems[count] = item;
                listItems = newListItems;
                count++;
            }
            else
            {
                listItems[count] = item;
                count++;
            }
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

            //PLAN OF ATTACK:
            //search for the index of item by using a while loop that ends when the item is found or count is reached
            //if the item is not found, return false
            //else
                //create a new array based on listItems but skip the index found above - use a for loop and decrement i at the correct spot?
                //set listItems to the new array
                //return true

        }

    }
}
