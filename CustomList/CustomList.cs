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
        T[] listItems;

        //properties
        public int Count
        {
            get { return count; }
        }

        //The below is an indexer================================================================
        //Notes on indexers:
        //An indexer is a class property
        //It is a 'parameterized' property  - it has parameters
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

        }

        //member methods

        //Add to end of array
        public void Add(T item)
        {
            T[] newListItems = new T[count+1];
            newListItems[count] = item;
            listItems = newListItems;
            count++;
        }

        //Remove first instance from array
        public void Remove()
        {

        }

    }
}
