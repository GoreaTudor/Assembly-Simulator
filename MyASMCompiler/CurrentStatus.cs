using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASMCompiler {
    public class CurrentStatus {
        public Instruction instruction { get; set; }
        public int[] registers { get; set; }
        public int[] memory { get; set; }
        public Stack stack { get; set; }
        public bool stop { get; set; }
        public bool hasOutput { get; set; }
        public string output { get; set; }
    }
}
