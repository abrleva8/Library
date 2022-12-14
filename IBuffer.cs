using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NRU_LIFO_library {
    [ServiceContract]
    public interface IBuffer {
        [MessageBodyMember]
        List<Page> Buffer { get; set; }
        [MessageBodyMember]
        int AmountOfPrefilledPages { get; set; }
        [MessageBodyMember]
        int MaxBufferSize { get; set; }


        [OperationContract]
        bool IsFault(Page page);
        [OperationContract]
        bool Contains(Page page);
        [OperationContract]
        string PrintBuffer();
    }
}