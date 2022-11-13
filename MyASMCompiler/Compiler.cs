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

                if (!String.IsNullOrWhiteSpace(line_withoutCommentsAndLabels)) {
                    // generate instruction from text and add it to the compiled code
                    Instruction instruction = toInstruction (line_withoutCommentsAndLabels);
                    compiledCode.instructions.Add (instruction);
                }
            } // END for each line

            return compiledCode;
        }


        protected static Instruction toInstruction (string instructionText) {
            string[] tokens = instructionText.Split (new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            string operation_str = tokens[0].ToUpper();
            string param1_str = (tokens.Length >= 2) ? tokens[1] : null;
            string param2_str = (tokens.Length >= 3) ? tokens[2] : null;

            if (tokens.Length >= 4) {
                throw new Sintax.SintaxError ("There are no instructions with more than 2 parameters");
            }

            Instruction instruction = new Instruction {
                Operation = OpCodes.HLT,
                Param1 = null,
                Param2 = null,
                Label = null
            };

            switch (operation_str) {

                case "HLT": {
                    if (param1_str != null || param2_str != null) {
                        throw new Sintax.InvalidParameterError ("HLT has no parameters");
                    }
                    instruction.Operation = OpCodes.HLT;
                } break;

                #region Arithmetic  ***** Being Implemented *****
                case "ADD": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.InvalidParameterError ("ADD must have 2 parameters"); }
                    Parameter param1 = getParamTypeAndValue (param1_str);

                } break;

                case "SUB": {
                    ;

                } break;

                case "MULT": {
                    ;

                } break;

                case "DIV": {
                    ;

                } break;

                case "MOD": {
                    ;

                } break;

                case "INC": {
                    ;

                } break;

                case "DEC": {
                    ;

                }  break;

                case "NEG": {
                    ;

                } break;
                #endregion

                #region Logic  ***Not Implemented Yet***
                case "AND": {
                    ;

                } break;

                case "OR": {
                    ;

                } break;

                case "XOR": {
                    ;

                } break;

                case "NOT": {
                    ;

                } break;
                #endregion

                #region Jumps and Branches  ***Not Implemented Yet***
                case "JMP": {
                    ;

                } break;

                case "JZ":
                case "BZ": {
                    ;

                } break;

                case "JNZ":
                case "BNZ": {
                    ;

                } break;

                case "JLZ":
                case "BLZ": {
                    ;

                } break;

                case "JLEZ":
                case "BLEZ": {
                    ;

                } break;

                case "JGZ":
                case "BGZ": {
                    ;

                } break;

                case "JGEZ":
                case "BGEZ": {
                    ;

                } break;
                #endregion

                #region Sets  ***Not Implemented Yet***
                case "SZ": {
                    ;

                } break;

                case "SNZ": {
                    ;

                } break;

                case "SLZ": {
                    ;

                } break;

                case "SLEZ": {
                    ;

                } break;

                case "SGZ": {
                    ;

                } break;

                case "SGEZ": {
                    ;

                } break;
                #endregion

                #region Shifts  ***Not Implemented Yet***
                case "SHL": {
                    ;

                } break;

                case "SHR": {
                    ;

                } break;

                case "ROL": {
                    ;

                } break;

                case "ROR": {
                    ;

                } break;
                #endregion

                #region Stack and Functions  ***Not Implemented Yet***
                case "PUSH": {
                    ;

                } break;

                case "POP": {
                    ;

                } break;

                case "PEEK": {
                    ;

                } break;

                case "CALL": {
                    ;

                } break;

                case "RET": {
                    ;

                } break;
                #endregion

                #region IO  ***Not Implemented Yet***
                case "INPI": {
                    ;

                } break;

                case "INPC": {
                    ;

                } break;

                case "OUTI": {
                    ;

                } break;

                case "OUTC": {
                    ;

                } break;
                #endregion

                default: {
                    throw new Sintax.InvalidOperationError($"Invalid operation: {operation_str}");
                }
            }
            
            return instruction;
        }

        protected static Parameter getParamTypeAndValue (string param_str) {
            switch (param_str[0]) {
                case '[': { // [register] or [number]  -- no offset allowed
                    string address = param_str.Substring(startIndex: 1, length: param_str.Length - 2);

                    int? register = parseRegister (address);
                    if (register.HasValue) {
                        return new Parameter { Type = ParamType.pointer, Value = register.Value};
                    }

                    int? number = parseNumber (address);
                    if (number.HasValue) {
                        return new Parameter { Type = ParamType.address, Value = number.Value};
                    }

                    throw new Sintax.InvalidParameterError ("Invalid format for address type (with [])");
                }

                case '\'': { // 'C'
                    string character = param_str.Substring(startIndex: 1, length: param_str.Length - 2);

                    if (character.Length != 1) {
                        throw new Sintax.InvalidParameterError ($"Invalid character type \'{character}\'");
                    }

                    return new Parameter { Type = ParamType.number, Value = character[0]};
                }

                default: { // register, number
                    int? register = parseRegister (param_str);
                    if (register.HasValue) {
                        return new Parameter { Type = ParamType.register, Value = register.Value };
                    }

                    int? number = parseNumber (param_str);
                    if (number.HasValue) {
                        return new Parameter { Type = ParamType.number, Value = number.Value };
                    }

                    throw new Sintax.InvalidParameterError ("Invalid format for simple type (without [])");
                }
            }
        }

        protected static int? parseRegister (string input) {
            switch (input) {
                case "A":
                    return 0;

                case "B":
                    return 1;

                case "C":
                    return 2;

                case "D":
                    return 3;

                default:
                    return null;
            }
        }

        protected static int? parseNumber (string input) {
            if (input.StartsWith("0x")) {                                   // Hexa
                return Convert.ToInt32 (value: input, fromBase: 16);

            } else if (input.StartsWith("b")) {                             // Binary
                return Convert.ToInt32 (value: input.Substring(1), fromBase: 2);

            } else if (HiddenCompiler.regex_validNumber.IsMatch(input)) {   // Decimal
                return int.Parse (input);

            } else {                                                        // Invalid format
                return null;
            }
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
