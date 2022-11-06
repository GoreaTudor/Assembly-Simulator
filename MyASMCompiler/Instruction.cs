using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASMCompiler {
    public class Instruction {
        public int LineNumber { get; set; }
        public string Name { get; set; }
        public int param1 { get; set; }
        public int param2 { get; set; }
        public string label { get; set; }
    }
}
