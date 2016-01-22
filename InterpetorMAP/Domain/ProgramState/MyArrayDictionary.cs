using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpretorMap.Domain.Statement
{
    [Serializable]
    public class MyLibDictionary:MyIDictionary<MyMap>
    {
        private MyMap[] items; // the items in the stack
        private int numItems;   // the number of items in the stack

        public MyLibDictionary()
        {
            items = new MyMap[20];
            numItems = 0;

        }

        public bool IsEmpty()
        {
            if (numItems == 0)
                return true;
            return false;
        }

        public int GetLength() { return numItems; }
        public MyMap Get(int i) { return items[i]; }

        public int Lookup(String id)
        {
            for (int k = 0; k < numItems; k++)
                if (items[k].getId() == id)
                    return items[k].getVal();
            return 0;//return error later :)
        }

        public bool IsDefined(String id)
        {
            for (int k = 0; k < numItems; k++)
                if (items[k].getId() == id)
                    return true;
            return false;
        }

        public void Update(String id, int val)
        {
            for (int k = 0; k < numItems; k++)
                if (items[k].getId() == id)
                    items[k].setVal(val);
        }

        public void Add(MyMap item)
        {
            if (items.Length == numItems)
            {
                ExpandArray();
            }
            items[numItems] = item;
            numItems++;
        }


        private void ExpandArray()
        {
            MyMap[] newArray = (MyMap[])(new MyMap[numItems * 2]);
            for (int k = 0; k < numItems; k++)
            {
                newArray[k] = items[k];
            }
            items = newArray;
        }


    }
}
