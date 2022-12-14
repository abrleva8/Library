using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NRU_LIFO_library {
    [DataContractAttribute]
    public class Page : IComparable<Page> {
        [DataMemberAttribute]
        public string NameOfPage { get; set; }
        [DataMemberAttribute]
        public bool IsModified { get; set; }
        public Page(string nameOfPage, bool isModified = false) {
            this.IsModified = isModified;
            this.NameOfPage = nameOfPage;
        }

        public int CompareTo(Page other) {
            switch (this.IsModified) {
                case true when !other.IsModified:
                    return 1;
                case false when other.IsModified:
                    return -1;
                default:
                    return 0;
            }
        }

        public override string ToString() {
            return this.NameOfPage;
        }
 
        public override bool Equals(object obj) {
            //if (obj is not Page toPage) return false;
            Page toPage = obj as Page;
            return this.NameOfPage == toPage.NameOfPage;
        }
    }
}