﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyASMCompiler;

namespace MyASMCompiler.UnitTests {
    class CompilerChild : Compiler {
        public static Parameter _getParamTypeAndValue (CompiledCode compiledCode, string param_str) {
            return getParamTypeAndValue (compiledCode, param_str);
        }

        public static int? _parseNumber (string input) {
            return parseNumber (input);
        }

        public static int? _parseRegister (string input) {
            return parseRegister (input);
        }

        public static List<string> _tokenize (string text) {
            return tokenize (text);
        }
    }
}
