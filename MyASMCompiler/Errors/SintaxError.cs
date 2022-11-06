using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASMCompiler.Errors {
    public class SintaxError : Exception {
        public SintaxError (string message) : base (message) { }
    }
}
