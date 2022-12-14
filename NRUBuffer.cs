using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRU_LIFO_library {
    public class NruBuffer : IBuffer {
        public List<Page> Buffer { get; set; }

        public int AmountOfPrefilledPages { get; set; }
        public int MaxBufferSize { get; set; }

        private int ToRemove() {
            for (int i = 0; i < this.Buffer.Count; i++) {
                if (!this.Buffer[i].IsModified) {
                    return i;
                }
            }

            return 0;
        }

        public bool IsFault(Page page) {

            if (this.Buffer.Contains(page)) {
                this.Buffer.Remove(page);
                this.Buffer.Add(page);
                return false;
            }

            if (this.Buffer.Count == this.MaxBufferSize) {
                int indexToRemove = this.ToRemove();
                this.Buffer.RemoveAt(indexToRemove);
            }


            this.Buffer.Add(page);

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

        public NruBuffer(List<Page> buffer, int maxBufferSize, int amountOfPrefilledPages) {
            this.Buffer = new List<Page>(buffer);
            this.AmountOfPrefilledPages = amountOfPrefilledPages;
            this.MaxBufferSize = maxBufferSize;
        }
    }
}