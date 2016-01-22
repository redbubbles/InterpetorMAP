using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.Statement;


namespace InterpretorMap.Domain.Statement
{
    [Serializable]
    public class MyArrayStack : MyIStack<IStmt>
    {
        // *** fields ***
        private static int INITSIZE = 10;  // initial array size
        private IStmt[] items; // the items in the stack
        private int numItems;   // the number of items in the stack


       // *** constructor ***
        public MyArrayStack()
        {
            items = (IStmt[])(new IStmt[INITSIZE]);
            numItems = 0;
        }

        // *** required StackADT methods ***

        // add items
        public void Push(IStmt item)
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
            IStmt[] newArray = (IStmt[])(new IStmt[numItems * 2]);
            for (int k = 0; k < numItems; k++)
            {
                newArray[k] = items[k];
            }
            items = newArray;
        }

        // remove items
        public IStmt Pop()
        {
            if (numItems == 0)
            {
                //throw new EmptyStackException();
                Console.WriteLine("pop empty list");
            }
            else
            {
                numItems--;
                return items[numItems];
            }

            return null;
        }




        public bool IsEmpty()
        {
            if (numItems == 0)
                return true;
            return false;
        }
        public int GetLength() { return numItems; }
        public IStmt Get(int i) { return items[i]; }
    }
}
