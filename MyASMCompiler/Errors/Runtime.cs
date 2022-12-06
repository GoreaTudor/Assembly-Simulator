using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASMCompiler.Errors {
    public class Runtime {
        public class RuntimeError : Exception {
            public RuntimeError (string message) : base (message) { }
        }

        public class StackOverflow : Exception {
            public StackOverflow () : base ("Stack Overflow") { }
        }

        public class StackUnderflow : Exception {
            public StackUnderflow () : base ("Stack Underflow") { }
        }

        public class InstrLabelNotFound : Exception {
            public InstrLabelNotFound (string message) : base (message) { }
        }

        public class IntToCharOverflow : Exception {
            public IntToCharOverflow (string message) : base (message) { }
        }

        public class InputError : Exception {
            public InputError (string message) : base (message) { }
        }
    }
}
