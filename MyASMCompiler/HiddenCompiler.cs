using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyASMCompiler {
    class HiddenCompiler {
        public static SetupProperties setupProperties { get; set; }

        private static readonly string[] InstructionSet_Memory       = { "MOV" };
        private static readonly string[] InstructionSet_Arithmetic   = { "ADD", "SUB", "MULT", "DIV", "MOD", "INC", "DEC", "NEG" };
        private static readonly string[] InstructionSet_Logic        = { "AND", "OR", "XOR", "NOT" };
        private static readonly string[] InstructionSet_Shifts       = { "SHL", "SHR", "ROL", "ROR" };
        private static readonly string[] InstructionSet_Branches     = { "JMP", "BZ", "BNZ", "BLZ", "BLEZ", "BGZ", "BGEZ" };
        private static readonly string[] InstructionSet_Sets         = { "SMP", "SZ", "SNZ", "SLZ", "SLEZ", "SGZ", "SGEZ" };
        private static readonly string[] InstructionSet_Stack        = { "PUSH", "POP", "PEEK", "CALL", "RET" };
        private static readonly string[] InstructionSet_IO           = { "INPI", "INPC", "OUTI", "OUTC" };
        private static readonly string[] InstructionSet_Other        = { "HLT" };

        public static readonly string[] InstructionSet = {
            "MOV", "DEF",                                               // Memory
            "ADD", "SUB", "MULT", "DIV", "MOD", "INC", "DEC", "NEG",    // Arithmetic
            "AND", "OR", "XOR", "NOT",                                  // Logic
            "SHL", "SHR", "ROL", "ROR",                                 // Shift
            "JMP", "BZ", "BNZ", "BLZ", "BLEZ", "BGZ", "BGEZ",           // Branch
            "SMP", "SZ", "SNZ", "SLZ", "SLEZ", "SGZ", "SGEZ",           // Set
            "PUSH", "POP", "CALL", "RET",                               // Stack
            "INPI", "INPC", "OUTI", "OUTC",                             // IO
            "HLT"                                                       // Other
        };

        public static readonly Regex regex_validParam = new Regex (@"^([A-D]|(SP)|(BP)|([%]{0,1}[0-9]+))$");
        public static readonly Regex regex_validLabel = new Regex (@"^[_a-zA-Z][_a-zA-Z0-9]+$");
        public static readonly Regex regex_validNumber = new Regex (@"^[\d]+$");
    }
}
