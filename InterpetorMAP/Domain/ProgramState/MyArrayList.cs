using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.Statement;
namespace InterpretorMap.Domain.Statement
{
    [Serializable]
    public class MyArrayList:MyIList<String>
    {
        private String[] items; // the items in the List
        private int numItems;   // the number of items in the List

        // *** constructor ***
        private static int INITSIZE = 10;
        public MyArrayList()
        {
            numItems = 0;
            items = new String[INITSIZE];
        }

      

        public void Add1(String item)
        {
           
            if (items.Length == numItems)
            {
                ExpandArray();
            }
            // add new item; update numItems
            items[numItems] = item;
            numItems++;
        }
        
       
        private void ExpandArray()
        {
            String[] newArray = new String[numItems * 2];
            for (int k = 0; k < numItems; k++)
            {
                newArray[k] = items[k];
            }
            items = newArray;
        } 


        // remove items
        public String Remove(int pos)
        {
            // check for bad pos
            if (pos < 0 || pos >= numItems)
            {
                // throw new IndexOutOfBoundsException();
            }

            // get the item to be removed from pos
            String ob = items[pos];

            // move items over to fill removed pos
            for (int k = pos; k < numItems - 1; k++)
            {
                items[k] = items[k + 1];
            }

           
            numItems--;
            return ob;
        }

        // get items
        public String Get(int pos)
        {
            // check for bad pos
            if (pos < 0 || pos >= numItems)
            {
                //throw new IndexOutOfBoundsException();
            }
            return items[pos];
        }

        public int Size() { return numItems; }

        public bool IsEmpty()
        {
            if (numItems == 0)
                return true;
            return false;
        }

    }
}
