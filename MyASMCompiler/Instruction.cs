using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASMCompiler {
    public class Instruction {
        public enum Type { Memory, Arithmetic, Logic, Shift, Branch, Set, Stack, IO, Other};

        public string Operation { get; set; }
        public string param1 { get; set; }
        public string param2 { get; set; }
        public string label { get; set; }
    }
}
