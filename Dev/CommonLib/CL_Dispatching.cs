using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class CL_Dispatching : i_Dispatching
    {
        public MSG dispatching(MSG msg)
        {
            if(msg.op_name == "add")
            {
                int result = m_add((int)msg.data[0], (int)msg.data[1]);

                msg.data = new object[1] { (object)result };
            }
            else
            {
                
            }

            return msg;


        }

        public int m_add(int n, int m)
        {
            return n + m;
        }
    }
}
