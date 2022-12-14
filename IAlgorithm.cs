using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NRU_LIFO_library {
    [ServiceContract]
    public interface IAlgorithm {
        [DataMember]
        List<List<Page>> BufferHistory { get; set; }
        [DataMember]
        List<String> StringBufferHistory { get; set; }
        [DataMember]
        List<Boolean> FaultsHistory { get; set; }

        [MessageBodyMember]
        List<Page> Pages { get; set; }
        [MessageBodyMember]
 
        string CurrentAlg { get; set; }
        [MessageBodyMember]
        IBuffer Buffer { get; set; }




        [OperationContract]
        int CountOfFault(string algName, List<Page> pages, List<Page> currentBuffer, int maxBufferSize, int amountOfPrefilledPages);
        [OperationContract]
        bool IsConnected();
        [OperationContract]
        List<List<Page>> GetBufferHistory();
        [OperationContract]
        List<String> GetStringBufferHistory();
        [OperationContract]
        List<Boolean> GetFaultsHistory();
    }
}