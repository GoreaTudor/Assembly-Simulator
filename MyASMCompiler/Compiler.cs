using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASMCompiler {

    /// <summary>
    /// Compiler class offers the main utilities that a IDE needs to build and run the code. It offers:
    /// <list type="bullet">
    ///     <item> setup() - prepares the compiler with building parameters </item>
    ///     <item> compile() - builds the code </item>
    ///     <item> run() - runs the code and returns the output of the code </item>
    /// </list>
    /// </summary>
    public class Compiler {

        private static char[] instruction_delim = { ' ', ',' };
        private static char[] comment_delim = { '#' };


        /// <summary>
        /// Prepares the compiler with compiling and running parameters.
        /// </summary>
        /// <param name="maxAddress"> represents the maximum address that can be used in the program </param>
        public static void setup (int maxAddress) {
            HiddenCompiler.setupProperties = new SetupProperties {
                MaxAddress = maxAddress
            };
        }


        /// <summary>
        /// Takes the given lines of a text representing the MyASM code and compiles it to an executable code.
        /// </summary>
        /// <param name="lines"> the given lines of a text representing the MyASM code </param>
        /// <returns> the executable code </returns>
        public static CompiledCode compile (string[] lines) {
            CompiledCode compiledCode = new CompiledCode ();

            // for each line 
            for (int lineNr = 0; lineNr < lines.Length; lineNr++) {
                string line = lines[lineNr];

                // split line by comments
                string[] tokens = line.Split (comment_delim, StringSplitOptions.RemoveEmptyEntries);

                // if tokens contains an instruction
                if ((tokens.Length == 2) ||                         // code (or blank space) and comment
                    (tokens.Length == 1 && !line.Contains ('#'))    // only code (or blank space), no comment
                ) {
                    // generate instruction from code (or tokens[0])
                    Instruction instruction = toInstruction (tokens[0]);

                    // if it wasn't blank, then add it to instructions
                    if (instruction != null) {
                        compiledCode.instructions.Add (instruction);
                    }
                }
            }

            return compiledCode;
        }


        /// <summary>
        /// Instruction set:
        /// <list type="number">
        ///     <item>
        ///         Memory:
        ///         <list type="bullet">
        ///             <item> MOV dest, src => dest = src </item>
        ///         </list>
        ///     </item>
        /// 
        ///     <item>
        ///         Arithmetic:
        ///         <list type="bullet">
        ///             <item> ADD dest, src => dest += src </item>
        ///             <item> SUB dest, src => dest -= src </item>
        ///             <item> MULT dest, src => dest *= src </item>
        ///             <item> DIV dest, src => dest /= src </item>
        ///             <item> MOD dest, src => dest %= src </item>
        ///             <item> INC dest => dest ++ </item>
        ///             <item> DEC dest => dest -- </item>
        ///             <item> NEG dest => dest = -dest </item>
        ///         </list>
        ///     </item>
        ///     
        ///     <item>
        ///         Logic:
        ///         <list type="bullet">
        ///             <item> AND dest, src  => dest &= src </item>
        ///             <item> OR dest, src => dest |= src </item>
        ///             <item> XOR dest, src => dest ^= src </item>
        ///             <item> NOT dest => dest = !dest </item>
        ///         </list>
        ///     </item>
        ///     
        ///     <item>
        ///         Shifts:
        ///         <list type="bullet">
        ///             <item> SHL dest => shifts contents one time to the left </item>
        ///             <item> SHR dest => shifts contents one time to the right </item>
        ///             <item> ROL dest => rotates contents one time to the left </item>
        ///             <item> ROR dest => rotates contents one time to the right </item>
        ///         </list>
        ///     </item>
        ///     
        ///     <item>
        ///         Jumps and branches:
        ///         <list type="bullet">
        ///             <item> JMP label => jumps to label address </item>
        ///             <item> BZ src, label => if src == 0 jumps to label address </item>
        ///             <item> BNZ src, label => if src != 0 jumps to label addressv </item>
        ///             <item> BLZ src, label => if src < 0 jumps to label address </item>
        ///             <item> BLEZ src, label => if src <= 0 jumps to label address </item>
        ///             <item> BGZ src, label => if src > 0 jumps to label address </item>
        ///             <item> BGEZ src, label => if src >= 0 jumps to label address </item>
        ///         </list>
        ///     </item>
        ///     
        ///     <item>
        ///         Sets:
        ///         <list type="bullet">
        ///             <item> SZ src, dest => if src == 0 sets dest value to 1, else to 0 </item>
        ///             <item> SNZ src, dest => if src != 0 sets dest value to 1, else to 0 </item>
        ///             <item> SLZ src, dest => if src < 0 sets dest value to 1, else to 0 </item>
        ///             <item> SLEZ src, dest => if src <= 0 sets dest value to 1, else to 0 </item>
        ///             <item> SGZ src, dest => if src > 0 sets dest value to 1, else to 0 </item>
        ///             <item> SGEZ src, dest => if src >= 0 sets dest value to 1, else to 0 </item>
        ///         </list>
        ///     </item>
        ///     
        ///     <item>
        ///         Functions and stack:
        ///         <list type="bullet">
        ///             <item> PUSH src => stack.push(src) </item>
        ///             <item> POP dest => dest = stack.pop() </item>
        ///             <item> CALL label => pushes to the stach the next instruction address, then jumps to label address </item>
        ///             <item> RET => pops the stack, and returns execution to the instruction </item>
        ///         </list>
        ///     </item>
        ///     
        ///     
        /// </list>
        /// </summary>
        /// <param name="code"> the code of the instruction </param>
        /// <returns> an instruction based on the string </returns>
        private static Instruction toInstruction (string code) {
            // split the code into tokens
            string[] tokens = code.Split (instruction_delim, StringSplitOptions.RemoveEmptyEntries);

            // check if code is blank
            if (tokens.Length == 0) {
                return null;
            }

            // TO DO: continue implementation
            return null;
        }


        /// <summary>
        /// Runs the code and returns the output of the code.
        /// </summary>
        /// <param name="code"> the set of instructions that will be executed. </param>
        /// <returns> the output of the code </returns>
        public static string run (CompiledCode code) {
            return null;
        }

        public static string hello () {
            return "Hello";
        }
    }
}
