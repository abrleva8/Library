using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NRU_LIFO_library {
    public class Counter : IAlgorithm {
        public List<Page> Pages { get; set; }

        //public List<Page> CurrentBuffer { get; set; }

        public string CurrentAlg { get; set; }
        public IBuffer Buffer { get; set; }

        public List<List<Page>> BufferHistory { get; set; }

        public List<String> StringBufferHistory { get; set; }

        public List<Boolean> FaultsHistory { get; set; }

        public Counter() {}

        public void Init(string algName, List<Page> pages, List<Page> currentBuffer, int maxBufferSize, int amountOfPrefilledPages) {
            //this.CurrentBuffer = currentBuffer;
            this.Pages = pages;
            switch (algName) {
                case "LIFO":
                    this.Buffer = new LifoBuffer(currentBuffer, maxBufferSize, amountOfPrefilledPages);
                    break;
                case "NRU":
                    this.Buffer = new NruBuffer(currentBuffer, maxBufferSize, amountOfPrefilledPages);
                    break;
                default:
                    throw new ArgumentException();
            }

            this.CurrentAlg = algName;
        }

        public int CountOfFault(string algName, List<Page> pages, List<Page> currentBuffer, int maxBufferSize, int amountOfPrefilledPages) {
            Init(algName, pages, currentBuffer, maxBufferSize, amountOfPrefilledPages);
            int result = 0;
            this.StringBufferHistory = new List<String>();
            this.FaultsHistory = Enumerable.Repeat(false, this.Pages.Count).ToList();
            for (int i = 0; i < this.Pages.Count; i++) {
                Console.WriteLine($"Adding {i}");
                Page currentPage = this.Pages[i];
                Console.WriteLine($"Adding {currentPage}");
                bool isFault = this.Buffer.IsFault(currentPage);
                string tmpRes = this.Buffer.PrintBuffer();
                if (isFault && i >= this.Buffer.AmountOfPrefilledPages) {
                    result++;
                    FaultsHistory[i] = true;
                    tmpRes += "    Fault!";
                }
                this.StringBufferHistory.Add(tmpRes);
            }
            return result;
        }

        public bool IsConnected() {
            return true;
        }

        public List<List<Page>> GetBufferHistory() {
            return this.BufferHistory;
        }

        public List<String> GetStringBufferHistory() {
            return this.StringBufferHistory;
        }

        public List<Boolean> GetFaultsHistory() {
            return this.FaultsHistory;
        }
    }
}