using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyASMCompiler;

namespace MyASMCompiler.UnitTests {
    class CompilerChild : Compiler {
        public static Parameter _getParamTypeAndValue (string param_str) {
            return getParamTypeAndValue (param_str);
        }

        public static int? _parseNumber (string input) {
            return parseNumber (input);
        }

        public static int? _parseRegister (string input) {
            return parseRegister (input);
        }
    }
}
