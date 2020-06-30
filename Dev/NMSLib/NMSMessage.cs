using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NMSLib
{
    [DataContract]
    public class NMSMessage
    {
        [DataMember]
        public int ID;
        [DataMember]
        public String[] data;
        [DataMember]
        public String[] keys;


        public NMSMessage()
        {

        }
    }
}
