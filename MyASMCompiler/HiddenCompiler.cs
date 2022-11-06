using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyASMCompiler.Errors;

namespace MyASMCompiler {
    class HiddenCompiler {

        private static SetupProperties setupProperties { get; set; }
        private static char[] delims = { ' ', ',' };
        private static char[] comment = { '#' };


        #region Compiler
        public static void Compiler_setup (SetupProperties setupProperties) {
            HiddenCompiler.setupProperties = setupProperties;
        }


        public static CompiledCode Compiler_compile (string[] lines) {
            CompiledCode compiledCode = new CompiledCode ();

            // for each line 
            for (int lineNr = 0; lineNr < lines.Length; lineNr++) {
                string line = lines[lineNr];

                // split line by comments
                string[] tokens = line.Split (comment, StringSplitOptions.RemoveEmptyEntries);

                // if tokens contains an instruction
                if ((tokens.Length == 2) ||                         // code and comment
                    (tokens.Length == 1 && !line.Contains ('#'))    // only code or blank space, no comment
                ) {
                    // generate instruction from code (or tokens[0])
                    Instruction instruction = toInstruction(tokens[0], lineNr);

                    // if it wasn't blank, then add it to instructions
                    if (instruction != null) {
                        compiledCode.instructions.Add (instruction);
                    }
                }
            }

            return compiledCode;
        }

        private static Instruction toInstruction (string code, int lineNr) {
            // split the code into tokens
            string[] tokens = code.Split (delims, StringSplitOptions.RemoveEmptyEntries);

            // check if code is blank
            if (tokens.Length == 0) {
                return null;
            }

            // TO DO: continue implementation
            return null;
        }


        public static string Compiler_run (CompiledCode code) {
            return null;
        }
        #endregion


        #region Debugger
        public static void Debug_start (CompiledCode code) {
            ;
        }


        public static Debugger.DebugStatus Debug_next (Instruction instruction) {
            return null;
        }


        public static Debugger.DebugStatus Debug_stop () {
            return null;
        }
        #endregion
    }
}
