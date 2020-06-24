using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    [ServiceContract(Namespace = "http:eXia_A4_WCF1")]
    public interface i_Dispatching
    {
        [OperationContract]
        MSG dispatching(MSG msg);
    }

    [DataContract]
    public class MSG
    {
        [DataMember]
        public string op_statut;

        [DataMember]
        public string op_name;

        [DataMember]
        public string op_infos;

        [DataMember]
        public string op_version;

        [DataMember]
        public string app_version;

        [DataMember]
        public string app_tocken;

        [DataMember]
        public string user_token;

        [DataMember]
        public object[] data;
    }


}
