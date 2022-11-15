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
                MaxDataAddress = maxAddress
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
                        int nextInstrAddr = compiledCode.Instructions.Count;
                        compiledCode.InstructionLabels.Add (label, nextInstrAddr);
                    }
                }

                if (!String.IsNullOrWhiteSpace(line_withoutCommentsAndLabels)) {
                    // generate instruction from text and add it to the compiled code
                    Instruction instruction = toInstruction (compiledCode, line_withoutCommentsAndLabels);

                    if (instruction.Opcode != OpCodes.DEF) {
                        compiledCode.Instructions.Add (instruction);
                    }
                }
            } // END for each line

            return compiledCode;
        }


        protected static Instruction toInstruction (CompiledCode compiledCode, string instructionText) {
            string[] tokens = instructionText.Split (new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            string operation_str = tokens[0].ToUpper();
            string param1_str = (tokens.Length >= 2) ? tokens[1] : null;
            string param2_str = (tokens.Length >= 3) ? tokens[2] : null;

            if (tokens.Length >= 4) {
                throw new Sintax.SintaxError ("There are no instructions with more than 2 parameters");
            }

            Instruction instruction = new Instruction {
                Opcode = OpCodes.HLT,
                Param1 = null,
                Param2 = null,
                Label = null
            };

            switch (operation_str) {

                #region Memory
                case "HLT": { // format: HLT
                    if (param1_str != null || param2_str != null) {
                        throw new Sintax.OperationError ("HLT has no parameters");
                    }
                    instruction.Opcode = OpCodes.HLT;
                } break;

                case "DEF": { // format: DEF label, "String"/'C'/number     // has to be created before it is used
                    if (param1_str == null || param2_str == null) {
                        throw new Sintax.OperationError ("DEF has 2 parameters: <label> <\"String\"/\'C\'/number>");
                    }
                    instruction.Opcode = OpCodes.DEF;

                    /// param 1 ///
                    string label = (HiddenCompiler.regex_validLabel.IsMatch(param1_str)) ? param1_str : null;
                    if (label == null) {
                        throw new Sintax.ParameterError ($"Invalid label: {param1_str}");
                    }
                    compiledCode.DataLabels.Add (label, compiledCode.NextAddressPointer); // saves the label with the corresponding address

                    /// param 2 ///
                    if (HiddenCompiler.regex_validNumber.IsMatch(param2_str)) { // Number
                        int number = int.Parse(param2_str);
                        compiledCode.StartDataValues[compiledCode.NextAddressPointer ++] = number;

                    } else if (param2_str[0] == '\'' ) { // 'C'
                        if (param2_str[param2_str.Length - 1] != '\'') {
                            throw new Sintax.ParameterError ("Missing \'");
                        }

                        string chars = param2_str.Substring (startIndex: 1, length: param2_str.Length - 2);
                        if (chars.Length == 0) {
                            throw new Sintax.ParameterError ("Empty character");
                        } else if (chars.Length > 1) {
                            throw new Sintax.ParameterError ("Too many characters, use String instead");
                        }

                        compiledCode.StartDataValues[compiledCode.NextAddressPointer ++] = chars[0];

                    } else if (param2_str[0] == '\"') { // "String"
                        if (param2_str[param2_str.Length - 1] != '\"') {
                            throw new Sintax.ParameterError ("Missing \"");
                        }

                        string chars = param2_str.Substring (startIndex: 1, length: param2_str.Length - 2);
                        foreach (char character in chars) {
                            int number = (int) character;
                            compiledCode.StartDataValues[compiledCode.NextAddressPointer ++] = number;
                        }

                    } else {
                        throw new Sintax.ParameterError ($"DEF Second parameter should be: \"String\"/\'C\'/number, but is: {param2_str}");
                    }
                } break;
                #endregion

                #region Arithmetic  ***** Being Implemented *****
                case "ADD": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.ParameterError ("ADD must have 2 parameters"); }
                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);

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
                    throw new Sintax.OperationError($"Invalid operation: {operation_str}");
                }
            }
            
            return instruction;
        }

        protected static Parameter getParamTypeAndValue (CompiledCode compiledCode, string input) {
            switch (input[0]) {
                case '[': { // [register] or [number]  -- no offset allowed
                    if (input[input.Length - 1] != ']') {
                        throw new Sintax.ParameterError ("Missing ]");
                    }

                    string address = input.Substring(startIndex: 1, length: input.Length - 2);

                    int? register = parseRegister (address);
                    if (register.HasValue) {
                        return new Parameter { Type = ParamType.pointer, Value = register.Value};
                    }

                    int? number = parseNumber (address);
                    if (number.HasValue) {
                        return new Parameter { Type = ParamType.address, Value = number.Value};
                    }

                    throw new Sintax.ParameterError ("Invalid format for address type (with [])");
                }

                case '\'': { // 'C'
                    if (input[input.Length - 1] != '\'') {
                        throw new Sintax.ParameterError ("Missing \'");
                    }

                    string character = input.Substring(startIndex: 1, length: input.Length - 2);

                    if (character.Length != 1) {
                        throw new Sintax.ParameterError ($"Invalid character type \'{character}\'");
                    }

                    return new Parameter { Type = ParamType.number, Value = (int) character[0]};
                }

                default: { // register, number, data_label
                    int? register = parseRegister (input);
                    if (register.HasValue) {
                        return new Parameter { Type = ParamType.register, Value = register.Value };
                    }

                    int? number = parseNumber (input);
                    if (number.HasValue) {
                        return new Parameter { Type = ParamType.number, Value = number.Value };
                    }

                    int? dataLabelValue = parseDataLabel (compiledCode, input);
                    if (dataLabelValue.HasValue) {
                        return new Parameter { Type = ParamType.number, Value = dataLabelValue.Value };
                    }

                    throw new Sintax.ParameterError ("Invalid format for simple type (without [])");
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

        protected static int? parseDataLabel (CompiledCode compiledCode, string input) {
            string label = (HiddenCompiler.regex_validLabel.IsMatch (input)) ? input : null;
            if (label == null) { return null; }

            try {
                return compiledCode.DataLabels[label];

            } catch (KeyNotFoundException) {
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
