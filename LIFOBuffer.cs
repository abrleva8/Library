using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRU_LIFO_library {
    public class LifoBuffer : IBuffer {
        public List<Page> Buffer { get; set; }

        public int AmountOfPrefilledPages { get; set; }
        public int MaxBufferSize { get; set; }

        public LifoBuffer(List<Page> buffer, int maxBufferSize, int amountOfPrefilledPages) {
            this.Buffer = new List<Page>(buffer);
            this.AmountOfPrefilledPages = amountOfPrefilledPages;
            this.MaxBufferSize = maxBufferSize;
        }

        public bool IsFault(Page page) {
            if (this.Buffer.Contains(page)) {
                return false;
            }

            if (this.Buffer.Count == this.MaxBufferSize) {
                this.Buffer.RemoveAt(0);
            }

            this.Buffer.Insert(0, page);

            return true;
        }

        public bool Contains(Page page) {
            return this.Buffer.Contains(page);
        }

        public int Count => this.Buffer.Count;

        public string PrintBuffer() {
            string res = "";
            foreach (var page in this.Buffer) {
                res += (page + "->");
            }
            Console.WriteLine(res);
            return res;
        }

    }
}