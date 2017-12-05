using System;
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
                return listItems[i];
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

        //Remove first instance from array
        public void Remove(T item)
        {

        }

    }
}
