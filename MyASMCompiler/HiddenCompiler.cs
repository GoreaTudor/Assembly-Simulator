using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyASMCompiler {
    class HiddenCompiler {
        public static SetupProperties setupProperties { get; set; }

        public static readonly string[] InstructionSet_Memory       = { "MOV" };
        public static readonly string[] InstructionSet_Arithmetic   = { "ADD", "SUB", "MULT", "DIV", "MOD", "INC", "DEC", "NEG" };
        public static readonly string[] InstructionSet_Logic        = { "AND", "OR", "XOR", "NOT" };
        public static readonly string[] InstructionSet_Shifts       = { "SHL", "SHR", "ROL", "ROR" };
        public static readonly string[] InstructionSet_Branches     = { "JMP", "BZ", "BNZ", "BLZ", "BLEZ", "BGZ", "BGEZ" };
        public static readonly string[] InstructionSet_Sets         = { "SMP", "SZ", "SNZ", "SLZ", "SLEZ", "SGZ", "SGEZ" };
        public static readonly string[] InstructionSet_Stack        = { "PUSH", "POP", "CALL", "RET" };
        public static readonly string[] InstructionSet_IO           = { "INPI", "INPC", "OUTI", "OUTC" };
        public static readonly string[] InstructionSet_Other        = { "HLT" };

        public static readonly Regex regex_validParam = new Regex (@"^([A-D]|(SP)|(BP)|([%]{0,1}[0-9]+))$");
        public static readonly Regex regex_number = new Regex (@"[0-9]+");
    }
}
