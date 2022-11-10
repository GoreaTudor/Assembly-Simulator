using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyASMCompiler.Errors;

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

            /// Each line looks like:
            /// label: instruction param1, param2  # comment
            /// where commas, label (with ':'), param1, param2, comment are optional

            // for each line 
            for (int lineNr = 0; lineNr < lines.Length; lineNr++) {
                string line = lines[lineNr];

                /// Comments ///
                string line_withoutComments;

                if (line.Contains ('#')) { // if contains a comment
                    string[] tokens = line.Split ('#');
                    line_withoutComments = tokens[0];

                } else {
                    line_withoutComments = line;
                }


                /// Labels ///
                string line_withoutCommentsAndLabels = null;
                string possible_label = null;

                if (line_withoutComments.Contains (':')) { // if contains a label
                    string[] tokens = line_withoutComments.Split (':');

                    possible_label = tokens[0];
                    line_withoutCommentsAndLabels = tokens[1];

                } else {
                    line_withoutCommentsAndLabels = line_withoutComments;
                }

                if (possible_label != null) {
                    // remove leading and trailing whitespace
                    string possible_label_trimmed = possible_label.Trim ();

                    // check if it is still label
                    if (!(String.IsNullOrWhiteSpace (possible_label_trimmed) || possible_label_trimmed.Contains (' '))) {
                        string label = possible_label_trimmed;

                        // add the label to the table
                        int nextInstrAddr = compiledCode.instructions.Count;
                        compiledCode.labelsTable.Add (label, nextInstrAddr);
                    }
                }

                // generate instruction from text and add it to the compiled code
                Instruction instruction = toInstruction (line_withoutCommentsAndLabels);
                compiledCode.instructions.Add (instruction);

            } // END for each line

            return compiledCode;
        }


        /// <summary>
        /// <para> Registers: </para>
        /// <list type="bullet">
        ///     <item> A </item>
        ///     <item> B </item>
        ///     <item> C </item>
        ///     <item> D </item>
        ///     <item> SP (Stack Pointer) </item>
        ///     <item> BP (Base Pointer) </item>
        /// </list>
        /// 
        /// <para> Instruction set: </para>
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
        ///     <item>
        ///         IO:
        ///         <list type="bullet">
        ///             <item> INPI dest => reads the next item, as an integer, and saves the value into dest </item>
        ///             <item> INPC dest => reads the next item, as an character, and saves the value into dest </item>
        ///             <item> OUTI src => displays the char value of the src contents </item>
        ///             <item> OUTC src => displays the char value of the src contents </item>
        ///         </list>
        ///     </item>
        ///     
        ///     <item>
        ///         Other:
        ///         <list type="bullet">
        ///             <item> HLT => stops the code execution </item>
        ///         </list>
        ///     </item>
        ///     
        /// </list>
        /// </summary>
        /// <param name="code"> the code of the instruction </param>
        /// <returns> an instruction based on the string </returns>
        private static Instruction toInstruction (string instructionText) {
            string[] tokens = instructionText.Split (new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            string operation = tokens[0];
            string param1 = (tokens.Length >= 2) ? tokens[1] : null;
            string param2 = (tokens.Length >= 3) ? tokens[2] : null;

            if (!HiddenCompiler.InstructionSet.Contains(operation)) {
                throw new Sintax.InvalidOperationError($"Invalid operation \"{operation}\"");
            }

            Instruction instruction = new Instruction { 
                Operation = operation,
                Param1 = param1,
                Param2 = param2
            };
            
            return instruction;
        }


        /// <summary>
        /// Runs the code and returns the output of the code.
        /// </summary>
        /// <param name="code"> the set of instructions that will be executed. </param>
        /// <returns> the output of the code </returns>
        public static string run (CompiledCode code, string input) {
            return null;
        }
    }
}
