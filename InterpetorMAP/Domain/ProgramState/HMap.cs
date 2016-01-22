using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpretorMap.Domain.ProgramState
{
    [Serializable]
    public class HMap
    {   
            /**fields */
            public int address;
            public int content;

            /**constructor */
            public HMap(int address, int content)
            {
                this.address = address;
                this.content = content;
            }

            public String ToStr()
            {
                return address + "-> " + "" + content;
            }



            public int GetAddr()
            {
                return address;
            }

            public int GetCont()//get content
            {
                return content;
            }

            public void SetCont(int v)//set content
            {
                content = v;
            }


        public void SetAddr(int a)//set content
        {
            address = a;
        }




    }
    }