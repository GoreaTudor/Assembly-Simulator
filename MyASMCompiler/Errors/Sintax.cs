using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASMCompiler.Errors {
    public class Sintax {
        public class SintaxError : Exception {
            public SintaxError (string message) : base (message) { }
        }

        public class OperationError : Exception {
            public OperationError (string message) : base (message) { }
        }

        public class ParameterError : Exception {
            public ParameterError (string message) : base (message) { }
        }
    }
}
