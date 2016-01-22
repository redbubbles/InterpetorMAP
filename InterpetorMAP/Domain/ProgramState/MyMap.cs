using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpretorMap.Domain.Statement
{
    [Serializable]
    public class MyMap
    {
        /**fields */
        public int val;
        public String id;

        /**constructor */
        public MyMap(String id, int val)
        {
            this.id = id;
            this.val = val;
        }

        /**other methods */
         
        public String ToStr()
        {
            return id + "-> " + "" + val;
        }



        public String getId()
        {
            return id;
        }

        public int getVal()
        {
            return val;
        }

        public void setVal(int v)
        {
            val = v;
        }




    }
}
