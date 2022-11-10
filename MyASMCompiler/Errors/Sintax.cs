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

        public class InvalidOperationError : Exception {
            public InvalidOperationError (string message) : base (message) { }
        }

        public class InvalidParameterError : Exception {
            public InvalidParameterError (string message) : base (message) { }
        }

        public class InvalidLabelError : Exception {
            public InvalidLabelError (string message) : base (message) { }
        }
    }
}
