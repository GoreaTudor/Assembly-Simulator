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
            int min_addressValue = 32;
            int max_addressValue = 2048;
            int default_addressValue = 256;

            HiddenCompiler.setupProperties = new SetupProperties {
                MaxDataAddress = (min_addressValue <= maxAddress && maxAddress <= max_addressValue) ? maxAddress : default_addressValue
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
                    try {
                        // generate instruction from text and add it to the compiled code
                        Instruction instruction = toInstruction (compiledCode, line_withoutCommentsAndLabels);

                        if (instruction.Opcode != OpCodes.DEF) {
                            compiledCode.Instructions.Add (instruction);
                        }
                    } catch (Sintax.SintaxError error) {
                        throw new Sintax.SintaxError (error.Message + $" at line {lineNr + 1}");
                    } catch (Sintax.OperationError error) {
                        throw new Sintax.OperationError (error.Message + $" at line {lineNr + 1}");
                    } catch (Sintax.ParameterError error) {
                        throw new Sintax.ParameterError (error.Message + $" at line {lineNr + 1}");
                    } catch (Exception e) {
                        throw new Exception (e.Message + $" at line {lineNr + 1}");
                    }
                }
            } // END for each line

            return compiledCode;
        }

        // receives "instruction   param1 ,    param2"  -- can have many spaces in between
        protected static Instruction toInstruction (CompiledCode compiledCode, string instructionText) {
            

            Instruction instruction = new Instruction {
                Opcode = OpCodes.DEF,
                Param1 = null,
                Param2 = null,
                Label = null
            };

            List <string> tokens = tokenize(instructionText);
            string operation_str = tokens[0].ToUpper();
            string param1_str = (tokens.Count >= 2) ? tokens[1] : null;
            string param2_str = (tokens.Count >= 3) ? tokens[2] : null;

            switch (operation_str) {

                case "HLT": { // format: HLT
                    if (param1_str != null || param2_str != null) {
                        throw new Sintax.OperationError ("HLT should have no parameters");
                    }
                    instruction.Opcode = OpCodes.HLT;
                } break;

                #region Memory
                case "MOV": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("MOV should have 2 parameters"); }

                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);
                    Parameter param2 = getParamTypeAndValue (compiledCode, param2_str);
                    instruction.Param1 = param1.Value;
                    instruction.Param2 = param2.Value;

                    if (param1.Type == ParamType.register && param2.Type == ParamType.number) { instruction.Opcode = OpCodes.MOV_REG_NUMBER; }
                    else if (param1.Type == ParamType.register && param2.Type == ParamType.register) { instruction.Opcode = OpCodes.MOV_REG_REG; } 
                    else if (param1.Type == ParamType.register && param2.Type == ParamType.pointer) { instruction.Opcode = OpCodes.MOV_REG_POINTER; } 
                    else if (param1.Type == ParamType.register && param2.Type == ParamType.address) { instruction.Opcode = OpCodes.MOV_REG_ADDRESS; } 
                    else if (param1.Type == ParamType.pointer && param2.Type == ParamType.number) { instruction.Opcode = OpCodes.MOV_POINTER_NUMBER; } 
                    else if (param1.Type == ParamType.pointer && param2.Type == ParamType.register) { instruction.Opcode = OpCodes.MOV_POINTER_REG; } 
                    else if (param1.Type == ParamType.address && param2.Type == ParamType.number) { instruction.Opcode = OpCodes.MOV_ADDRESS_NUMBER; } 
                    else if (param1.Type == ParamType.address && param2.Type == ParamType.register) { instruction.Opcode = OpCodes.MOV_ADDRESS_REG; } 
                    else { throw new Sintax.ParameterError ("MOV cannot have this types of parameters"); }
                } break;

                case "DB":
                case "DEF": { // format: DEF label, "String"/'C'/number     // has to be created before it is used
                    if (param1_str == null) {
                        throw new Sintax.OperationError ("DEF/DB should have 1 or 2 parameters: <label> <\"String\"/\'C\'/number>");
                    }
                    instruction.Opcode = OpCodes.DEF;

                    /// param 1 ///
                    if (HiddenCompiler.regex_validNumber.IsMatch (param1_str)) {         // Number
                        int number = int.Parse (param1_str);
                        compiledCode.StartDataValues[compiledCode.NextAddressPointer++] = number;

                    } else if (param1_str[0] == '\'') {                                // 'C'
                        if (param1_str[param1_str.Length - 1] != '\'') {
                            throw new Sintax.ParameterError ("Missing \'");
                        }

                        string chars = param1_str.Substring (startIndex: 1, length: param1_str.Length - 2);
                        if (chars.Length == 0) {
                            throw new Sintax.ParameterError ("Empty character");
                        } else if (chars.Length > 1) {
                            throw new Sintax.ParameterError ("Too many characters, use String instead");
                        }

                        compiledCode.StartDataValues[compiledCode.NextAddressPointer++] = chars[0];

                    } else if (param1_str[0] == '\"') {                                 // "String"
                        if (param1_str[param1_str.Length - 1] != '\"') {
                            throw new Sintax.ParameterError ("Missing \"");
                        }

                        string chars = param1_str.Substring (startIndex: 1, length: param1_str.Length - 2);
                        foreach (char character in chars) {
                            int number = (int) character;
                            compiledCode.StartDataValues[compiledCode.NextAddressPointer++] = number;
                        }

                    } else {
                        throw new Sintax.ParameterError ($"DEF/DB Second parameter should be: \"String\"/\'C\'/Number, but is: {param2_str}");
                    }

                    /// param 2 ///
                    if (param2_str != null) {
                        string data_label = (HiddenCompiler.regex_validLabel.IsMatch (param2_str)) ? param2_str : null;
                        if (data_label == null) {
                            throw new Sintax.ParameterError ($"Invalid label: {param2_str}");
                        }

                        // check if the data_label already exists
                        try {
                            int dataAddress = compiledCode.DataLabels[data_label];
                            throw new Sintax.SintaxError ($"Data label \"{data_label}\" (-> {dataAddress}) already exists");

                        } catch (KeyNotFoundException) {
                            // all good
                        }
                        // saves the label with the corresponding address
                        compiledCode.DataLabels.Add (data_label, compiledCode.NextAddressPointer);
                    }
                } break;
                #endregion

                #region Arithmetic
                case "ADD": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("ADD should have 2 parameters"); }

                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);
                    if (param1.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("ADD first parameter should be a Register");
                    }
                    instruction.Param1 = param1.Value;

                    Parameter param2 = getParamTypeAndValue (compiledCode, param2_str);
                    instruction.Param2 = param2.Value;

                    if (param2.Type == ParamType.number) { instruction.Opcode = OpCodes.ADD_REG_NUMBER; }
                    else if (param2.Type == ParamType.register) { instruction.Opcode = OpCodes.ADD_REG_REG; }
                    else if (param2.Type == ParamType.pointer) { instruction.Opcode = OpCodes.ADD_REG_POINTER; }
                    else if (param2.Type == ParamType.address) { instruction.Opcode = OpCodes.ADD_REG_ADDRESS; }
                    else { throw new Sintax.ParameterError ("ADD second parameter type is Invalid"); }
                } break;

                case "SUB": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("SUB should have 2 parameters"); }

                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);
                    if (param1.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("SUB first parameter should be a Register");
                    }
                    instruction.Param1 = param1.Value;

                    Parameter param2 = getParamTypeAndValue (compiledCode, param2_str);
                    instruction.Param2 = param2.Value;

                    if (param2.Type == ParamType.number) { instruction.Opcode = OpCodes.SUB_REG_NUMBER; } 
                    else if (param2.Type == ParamType.register) { instruction.Opcode = OpCodes.SUB_REG_REG; } 
                    else if (param2.Type == ParamType.pointer) { instruction.Opcode = OpCodes.SUB_REG_POINTER; }
                    else if (param2.Type == ParamType.address) { instruction.Opcode = OpCodes.SUB_REG_ADDRESS; } 
                    else { throw new Sintax.ParameterError ("SUB second parameter type is Invalid"); }
                } break;

                case "MULT": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("MULT should have 2 parameters"); }

                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);
                    if (param1.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("MULT first parameter should be a Register");
                    }
                    instruction.Param1 = param1.Value;

                    Parameter param2 = getParamTypeAndValue (compiledCode, param2_str);
                    instruction.Param2 = param2.Value;

                    if (param2.Type == ParamType.number) { instruction.Opcode = OpCodes.MULT_REG_NUMBER; } 
                    else if (param2.Type == ParamType.register) { instruction.Opcode = OpCodes.MULT_REG_REG; } 
                    else if (param2.Type == ParamType.pointer) { instruction.Opcode = OpCodes.MULT_REG_POINTER; }
                    else if (param2.Type == ParamType.address) { instruction.Opcode = OpCodes.MULT_REG_ADDRESS; } 
                    else { throw new Sintax.ParameterError ("MULT second parameter type is Invalid"); }
                } break;

                case "DIV": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("DIV should have 2 parameters"); }

                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);
                    if (param1.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("DIV first parameter should be a Register");
                    }
                    instruction.Param1 = param1.Value;

                    Parameter param2 = getParamTypeAndValue (compiledCode, param2_str);
                    instruction.Param2 = param2.Value;

                    if (param2.Type == ParamType.number) { instruction.Opcode = OpCodes.DIV_REG_NUMBER; } 
                    else if (param2.Type == ParamType.register) { instruction.Opcode = OpCodes.DIV_REG_REG; } 
                    else if (param2.Type == ParamType.pointer) { instruction.Opcode = OpCodes.DIV_REG_POINTER; } 
                    else if (param2.Type == ParamType.address) { instruction.Opcode = OpCodes.DIV_REG_ADDRESS; }
                    else { throw new Sintax.ParameterError ("DIV second parameter type is Invalid"); }
                } break;

                case "MOD": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("MOD should have 2 parameters"); }

                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);
                    if (param1.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("MOD first parameter should be a Register");
                    }
                    instruction.Param1 = param1.Value;

                    Parameter param2 = getParamTypeAndValue (compiledCode, param2_str);
                    instruction.Param2 = param2.Value;

                    if (param2.Type == ParamType.number) { instruction.Opcode = OpCodes.MOD_REG_NUMBER; } 
                    else if (param2.Type == ParamType.register) { instruction.Opcode = OpCodes.MOD_REG_REG; } 
                    else if (param2.Type == ParamType.pointer) { instruction.Opcode = OpCodes.MOD_REG_POINTER; } 
                    else if (param2.Type == ParamType.address) { instruction.Opcode = OpCodes.MOD_REG_ADDRESS; } 
                    else { throw new Sintax.ParameterError ("MOD second parameter type is Invalid"); }
                } break;

                case "INC": {
                    if (param1_str == null || param2_str != null) { throw new Sintax.OperationError ("INC should have 1 parameter"); }

                    Parameter param = getParamTypeAndValue (compiledCode, param1_str);
                    if (param.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("INC parameter must be a Register");
                    }
                    instruction.Param1 = param.Value;
                    instruction.Opcode = OpCodes.INC_REG;
                } break;

                case "DEC": {
                    if (param1_str == null || param2_str != null) { throw new Sintax.OperationError ("DEC should have 1 parameter"); }

                    Parameter param = getParamTypeAndValue (compiledCode, param1_str);
                    if (param.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("DEC parameter must be a Register");
                    }
                    instruction.Param1 = param.Value;
                    instruction.Opcode = OpCodes.DEC_REG;
                }  break;

                case "NEG": {
                    if (param1_str == null || param2_str != null) { throw new Sintax.OperationError ("NEG should have 1 parameter"); }

                    Parameter param = getParamTypeAndValue (compiledCode, param1_str);
                    if (param.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("NEG parameter must be a Register");
                    }
                    instruction.Param1 = param.Value;
                    instruction.Opcode = OpCodes.NEG_REG;
                } break;
                #endregion

                #region Logic
                case "AND": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.ParameterError ("AND should have 2 parameters"); }

                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);
                    if (param1.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("AND first parameter should be a Register");
                    }
                    instruction.Param1 = param1.Value;

                    Parameter param2 = getParamTypeAndValue (compiledCode, param2_str);
                    instruction.Param2 = param2.Value;

                    if (param2.Type == ParamType.number) { instruction.Opcode = OpCodes.AND_REG_NUMBER; } 
                    else if (param2.Type == ParamType.register) { instruction.Opcode = OpCodes.AND_REG_REG; } 
                    else if (param2.Type == ParamType.pointer) { instruction.Opcode = OpCodes.AND_REG_POINTER; } 
                    else if (param2.Type == ParamType.address) { instruction.Opcode = OpCodes.AND_REG_ADDRESS; } 
                    else { throw new Sintax.ParameterError ("AND second parameter type is Invalid"); }
                } break;

                case "OR": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.ParameterError ("OR should have 2 parameters"); }

                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);
                    if (param1.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("OR first parameter should be a Register");
                    }
                    instruction.Param1 = param1.Value;

                    Parameter param2 = getParamTypeAndValue (compiledCode, param2_str);
                    instruction.Param2 = param2.Value;

                    if (param2.Type == ParamType.number) { instruction.Opcode = OpCodes.OR_REG_NUMBER; } 
                    else if (param2.Type == ParamType.register) { instruction.Opcode = OpCodes.OR_REG_REG; } 
                    else if (param2.Type == ParamType.pointer) { instruction.Opcode = OpCodes.OR_REG_POINTER; } 
                    else if (param2.Type == ParamType.address) { instruction.Opcode = OpCodes.OR_REG_ADDRESS; } 
                    else { throw new Sintax.ParameterError ("OR second parameter type is Invalid"); }
                } break;

                case "XOR": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.ParameterError ("XOR should have 2 parameters"); }

                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);
                    if (param1.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("XOR first parameter should be a Register");
                    }
                    instruction.Param1 = param1.Value;

                    Parameter param2 = getParamTypeAndValue (compiledCode, param2_str);
                    instruction.Param2 = param2.Value;

                    if (param2.Type == ParamType.number) { instruction.Opcode = OpCodes.XOR_REG_NUMBER; } 
                    else if (param2.Type == ParamType.register) { instruction.Opcode = OpCodes.XOR_REG_REG; } 
                    else if (param2.Type == ParamType.pointer) { instruction.Opcode = OpCodes.XOR_REG_POINTER; } 
                    else if (param2.Type == ParamType.address) { instruction.Opcode = OpCodes.XOR_REG_ADDRESS; } 
                    else { throw new Sintax.ParameterError ("XOR second parameter type is Invalid"); }
                } break;

                case "NOT": {
                    if (param1_str == null || param2_str != null) { throw new Sintax.OperationError ("NOT should have 1 parameter"); }

                    Parameter param = getParamTypeAndValue (compiledCode, param1_str);
                    if (param.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("NOT parameter must be a Register");
                    }
                    instruction.Param1 = param.Value;
                    instruction.Opcode = OpCodes.NOT_REG;
                } break;
                #endregion

                #region Jumps and Branches
                case "JMP": {
                    if (param1_str == null || param2_str != null) { throw new Sintax.OperationError ("JMP should have only one parameter"); }

                    string label = parseInstrLabel (param1_str);
                    if (label == null) {
                        throw new Sintax.ParameterError ($"Invalid label: {label}");
                    }
                    instruction.Label = label;
                    instruction.Opcode = OpCodes.JMP_LABEL;
                } break;

                case "JZ":
                case "BZ": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("JZ/BZ should have 2 parameters"); }

                    Parameter reg = getParamTypeAndValue (compiledCode, param1_str);
                    if (reg.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("JZ/BZ first parameter must be a Register");
                    }
                    instruction.Param1 = reg.Value;

                    string label = parseInstrLabel (param2_str);
                    if (label == null) {
                        throw new Sintax.ParameterError ($"JZ/BZ second parameter invalid label: {label}");
                    }
                    instruction.Label = label;
                    instruction.Opcode = OpCodes.JZ_REG_LABEL;
                } break;

                case "JNZ":
                case "BNZ": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("JNZ/BNZ should have 2 parameters"); }

                    Parameter reg = getParamTypeAndValue (compiledCode, param1_str);
                    if (reg.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("JNZ/BNZ first parameter must be a Register");
                    }
                    instruction.Param1 = reg.Value;

                    string label = parseInstrLabel (param2_str);
                    if (label == null) {
                        throw new Sintax.ParameterError ($"JNZ/BNZ second parameter invalid label: {label}");
                    }
                    instruction.Label = label;
                    instruction.Opcode = OpCodes.JNZ_REG_LABEL;
                } break;

                case "JLZ":
                case "BLZ": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("JLZ/BLZ should have 2 parameters"); }

                    Parameter reg = getParamTypeAndValue (compiledCode, param1_str);
                    if (reg.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("JLZ/BLZ first parameter must be a Register");
                    }
                    instruction.Param1 = reg.Value;

                    string label = parseInstrLabel (param2_str);
                    if (label == null) {
                        throw new Sintax.ParameterError ($"JLZ/BLZ second parameter invalid label: {label}");
                    }
                    instruction.Label = label;
                    instruction.Opcode = OpCodes.JLZ_REG_LABEL;
                } break;

                case "JLEZ":
                case "BLEZ": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("JLEZ/BLEZ should have 2 parameters"); }

                    Parameter reg = getParamTypeAndValue (compiledCode, param1_str);
                    if (reg.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("JLEZ/BLEZ first parameter must be a Register");
                    }
                    instruction.Param1 = reg.Value;

                    string label = parseInstrLabel (param2_str);
                    if (label == null) {
                        throw new Sintax.ParameterError ($"JLEZ/BLEZ second parameter invalid label: {label}");
                    }
                    instruction.Label = label;
                    instruction.Opcode = OpCodes.JLEZ_REG_LABEL;
                } break;

                case "JGZ":
                case "BGZ": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("JGZ/BGZ should have 2 parameters"); }

                    Parameter reg = getParamTypeAndValue (compiledCode, param1_str);
                    if (reg.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("JGZ/BGZ first parameter must be a Register");
                    }
                    instruction.Param1 = reg.Value;

                    string label = parseInstrLabel (param2_str);
                    if (label == null) {
                        throw new Sintax.ParameterError ($"JGZ/BGZ second parameter invalid label: {label}");
                    }
                    instruction.Label = label;
                    instruction.Opcode = OpCodes.JGZ_REG_LABEL;
                } break;

                case "JGEZ":
                case "BGEZ": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("JGEZ/BGEZ should have 2 parameters"); }

                    Parameter reg = getParamTypeAndValue (compiledCode, param1_str);
                    if (reg.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("JGEZ/BGEZ first parameter must be a Register");
                    }
                    instruction.Param1 = reg.Value;

                    string label = parseInstrLabel (param2_str);
                    if (label == null) {
                        throw new Sintax.ParameterError ($"JGEZ/BGEZ second parameter invalid label: {label}");
                    }
                    instruction.Label = label;
                    instruction.Opcode = OpCodes.JGEZ_REG_LABEL;
                } break;
                #endregion

                #region Sets
                case "SZ": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("SZ should have 2 parameters"); }

                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);
                    if (param1.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("SZ first parameter must be a Register");
                    }
                    instruction.Param1 = param1.Value;

                    Parameter param2 = getParamTypeAndValue (compiledCode, param2_str);
                    if (param2.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("SZ second parameter must be a Register");
                    }
                    instruction.Param2 = param2.Value;
                    instruction.Opcode = OpCodes.SZ_REG_REG;
                } break;

                case "SNZ": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("SNZ should have 2 parameters"); }

                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);
                    if (param1.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("SNZ first parameter must be a Register");
                    }
                    instruction.Param1 = param1.Value;

                    Parameter param2 = getParamTypeAndValue (compiledCode, param2_str);
                    if (param2.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("SNZ second parameter must be a Register");
                    }
                    instruction.Param2 = param2.Value;
                    instruction.Opcode = OpCodes.SNZ_REG_REG;
                } break;

                case "SLZ": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("SLZ should have 2 parameters"); }

                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);
                    if (param1.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("SLZ first parameter must be a Register");
                    }
                    instruction.Param1 = param1.Value;

                    Parameter param2 = getParamTypeAndValue (compiledCode, param2_str);
                    if (param2.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("SLZ second parameter must be a Register");
                    }
                    instruction.Param2 = param2.Value;
                    instruction.Opcode = OpCodes.SLZ_REG_REG;
                } break;

                case "SLEZ": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("SLEZ should have 2 parameters"); }

                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);
                    if (param1.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("SLEZ first parameter must be a Register");
                    }
                    instruction.Param1 = param1.Value;

                    Parameter param2 = getParamTypeAndValue (compiledCode, param2_str);
                    if (param2.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("SLEZ second parameter must be a Register");
                    }
                    instruction.Param2 = param2.Value;
                    instruction.Opcode = OpCodes.SLEZ_REG_REG;
                } break;

                case "SGZ": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("SGZ should have 2 parameters"); }

                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);
                    if (param1.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("SGZ first parameter must be a Register");
                    }
                    instruction.Param1 = param1.Value;

                    Parameter param2 = getParamTypeAndValue (compiledCode, param2_str);
                    if (param2.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("SGZ second parameter must be a Register");
                    }
                    instruction.Param2 = param2.Value;
                    instruction.Opcode = OpCodes.SGZ_REG_REG;
                } break;

                case "SGEZ": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("SGEZ should have 2 parameters"); }

                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);
                    if (param1.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("SGEZ first parameter must be a Register");
                    }
                    instruction.Param1 = param1.Value;

                    Parameter param2 = getParamTypeAndValue (compiledCode, param2_str);
                    if (param2.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("SGEZ second parameter must be a Register");
                    }
                    instruction.Param2 = param2.Value;
                    instruction.Opcode = OpCodes.SGEZ_REG_REG;
                } break;
                #endregion

                #region Shifts
                case "SHL": {
                    if (param1_str == null || param2_str != null) { throw new Sintax.OperationError ("SHL should have 1 parameter"); }

                    Parameter param = getParamTypeAndValue (compiledCode, param1_str);
                    if (param.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("SHL parameter must be a Register");
                    }
                    instruction.Param1 = param.Value;
                    instruction.Opcode = OpCodes.SHL_REG;
                } break;

                case "SHR": {
                    if (param1_str == null || param2_str != null) { throw new Sintax.OperationError ("SHR should have 1 parameter"); }

                    Parameter param = getParamTypeAndValue (compiledCode, param1_str);
                    if (param.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("SHR parameter must be a Register");
                    }
                    instruction.Param1 = param.Value;
                    instruction.Opcode = OpCodes.SHR_REG;
                } break;
                #endregion

                #region Stack and Functions
                case "PUSH": {
                    if (param1_str == null || param2_str != null) { throw new Sintax.OperationError ("PUSH should have 1 parameter"); }

                    Parameter param = getParamTypeAndValue (compiledCode, param1_str);
                    instruction.Param1 = param.Value;

                    if (param.Type == ParamType.number) { instruction.Opcode = OpCodes.PUSH_NUMBER; }
                    else if (param.Type == ParamType.register) { instruction.Opcode = OpCodes.PUSH_REG; }
                    else if (param.Type == ParamType.pointer) { instruction.Opcode = OpCodes.PUSH_POINTER; }
                    else if (param.Type == ParamType.address) { instruction.Opcode = OpCodes.PUSH_ADDRESS; }
                    else { throw new Sintax.ParameterError ("PUSH parameter type Invalid"); }
                } break;

                case "POP": {
                    if (param1_str == null || param2_str != null) { throw new Sintax.OperationError ("POP should have 1 parameter"); }

                    Parameter param = getParamTypeAndValue (compiledCode, param1_str);
                    instruction.Param1 = param.Value;

                    if (param.Type == ParamType.number) { instruction.Opcode = OpCodes.POP_NUMBER; }
                    else if (param.Type == ParamType.number) { instruction.Opcode = OpCodes.POP_REG; }
                    else { throw new Sintax.ParameterError ("POP parameter must be a Register or a Number"); }
                } break;

                case "PEEK": {
                    if (param1_str == null || param2_str == null) { throw new Sintax.OperationError ("PEEK should have 2 parameters"); }

                    Parameter param1 = getParamTypeAndValue (compiledCode, param1_str);
                    if (param1.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("PEEK first parameter must be a Register");
                    }
                    instruction.Param1 = param1.Value;

                    Parameter param2 = getParamTypeAndValue (compiledCode, param2_str);
                    if (param2.Type != ParamType.number) {
                        throw new Sintax.ParameterError ("PEEK second parameter must be a Number");
                    }
                    instruction.Param2 = param2.Value;
                    instruction.Opcode = OpCodes.PEEK_REG_NUMBER;
                } break;

                case "CALL": {
                    if (param1_str == null || param2_str != null) { throw new Sintax.OperationError ("CALL should have only one parameter"); }

                    string label = parseInstrLabel (param1_str);
                    if (label == null) {
                        throw new Sintax.ParameterError ($"Invalid label: {label}");
                    }
                    instruction.Label = label;
                    instruction.Opcode = OpCodes.CALL_LABEL;
                } break;

                case "RET": {
                    if (param1_str != null || param2_str != null) {
                        throw new Sintax.OperationError ("RET should have no parameters");
                    }
                    instruction.Opcode = OpCodes.RET;
                } break;
                #endregion

                #region IO
                case "INPI": {
                    if (param1_str == null || param2_str != null) { throw new Sintax.OperationError ("INPI should have 1 parameter"); }

                    Parameter param = getParamTypeAndValue (compiledCode, param1_str);
                    if (param.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("INPI parameter must be a Register");
                    }
                    instruction.Param1 = param.Value;
                    instruction.Opcode = OpCodes.INPI_REG;
                } break;

                case "INPC": {
                    if (param1_str == null || param2_str != null) { throw new Sintax.OperationError ("INPC should have 1 parameter"); }

                    Parameter param = getParamTypeAndValue (compiledCode, param1_str);
                    if (param.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("INPC parameter must be a Register");
                    }
                    instruction.Param1 = param.Value;
                    instruction.Opcode = OpCodes.INPC_REG;
                } break;

                case "OUTI": {
                    if (param1_str == null || param2_str != null) { throw new Sintax.OperationError ("OUTI should have 1 parameter"); }

                    Parameter param = getParamTypeAndValue (compiledCode, param1_str);
                    if (param.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("OUTI parameter must be a Register");
                    }
                    instruction.Param1 = param.Value;
                    instruction.Opcode = OpCodes.OUTI_REG;
                } break;

                case "OUTC": {
                    if (param1_str == null || param2_str != null) { throw new Sintax.OperationError ("OUTC should have 1 parameter"); }

                    Parameter param = getParamTypeAndValue (compiledCode, param1_str);
                    if (param.Type != ParamType.register) {
                        throw new Sintax.ParameterError ("OUTC parameter must be a Register");
                    }
                    instruction.Param1 = param.Value;
                    instruction.Opcode = OpCodes.OUTC_REG;
                } break;
                #endregion

                default: {
                    throw new Sintax.OperationError($"Invalid operation: {operation_str}");
                }
            }
            
            return instruction;
        }

        /// <summary>
        /// receives "instruction   param1 ,    param2"  -- can have many spaces in between, but no spaces at end
        /// </summary>
        /// <param name="text"></param>
        /// <returns> a list of tokens </returns>
        protected static List<string> tokenize (string text) {
            List<string> tokens = new List<string> ();
            const char inv_sign = (char) 0;
            const int inv_begin = -1;

            bool isSection = false;
            char sign = inv_sign;
            int begin = inv_begin;
            int i = 0;

            while (i < text.Length) {
                if (isSection) {  // section is between "..." or '...'

                    if (text[i] == sign) {  // current char is a string / char terminator, sign is NOT invalid
                        tokens.Add (text.Substring (startIndex: begin, length: i - begin + 1));  // save section as token, including signs
                        isSection = false;
                        begin = inv_begin;
                        sign = inv_sign;
                    }
                    // else don't do anything, just go through the section

                } else {  // is not section

                    if (text[i] == '\'' || text[i] == '\"') {  // beginning of a section

                        if (begin != inv_begin) {  // something went wrong, begin should be invalid
                            throw new Exception ("token not finished at the beginning of section");
                        }

                        begin = i;
                        sign = text[i];
                        isSection = true;

                    } else {  // normal region, no section 

                        if (text[i] == ' ' || text[i] == ',' || text[i] == '\t') {  // is a delimiter

                            if (begin != inv_begin) {  // a token is finished
                                tokens.Add (text.Substring (startIndex: begin, length: i - begin));
                                begin = inv_begin;
                            }
                            // else don't do anything, just go to next character

                        } else { // not a delimiter, then it's a part of a token

                            if (begin == inv_begin) { // it's the beginning of the token
                                begin = i;
                            }
                            // else don't do anything, just go to next character
                        }
                    }

                }

                i++;
            }

            if (isSection) { // unfinnished section
                throw new Exception ("Unfinnished section");
            }

            if (begin != inv_begin) { // unfinished token, finish it,  i == text.Length
                tokens.Add (text.Substring (startIndex: begin, length: i - begin));
            }

            return tokens;
        }

        protected static Parameter getParamTypeAndValue (CompiledCode compiledCode, string input) {
            switch (input[0]) {
                case '[': { // [register], [number], [data_label]  -- no offset allowed
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

                    int? dataLabelValue = parseDataLabel (compiledCode, input);
                    if (dataLabelValue.HasValue) {
                        return new Parameter { Type = ParamType.address, Value = dataLabelValue.Value };
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
            // check if it's a valid label format
            string label = (HiddenCompiler.regex_validLabel.IsMatch (input)) ? input : null;
            if (label == null) { return null; }

            // check if the data label exists
            try {
                return compiledCode.DataLabels[label];

            } catch (KeyNotFoundException) {
                return null;
            }
        }

        protected static string parseInstrLabel (string input) {
            // check if it's a valid label format
            return (HiddenCompiler.regex_validLabel.IsMatch (input)) ? input : null;
        }

        /// hasCharOrStr is true only for:  <DB "Hello World", hello>  or  <DB "Hello World">  or  <DB 'C', char>  or  <DB 'C'>
        /// but not for:  <DB 12, nr>  or  <DB 0>   -- those will be split like normal instructions
        /// same goes for DEF, since DB is equivalent to DEF
        protected static (string str1, string str2, string str3, bool hasCharOrStr) mySplitter (string s) {
            bool found = false;

            int index_1 = 0; // index of first quotation mark / apostrophe
            while (index_1 < s.Length && !found) {
                if (s[index_1] == '\'' || s[index_1] == '\"') { found = true; } 
                else { index_1++; }
            }

            if (! found) {  // no quotation mark or apostrophe found, cannot be specially split, only normal split
                return (null, null, null, false);
            }

            found = false;
            int index_2 = 0; // index of last quotation mark / apostrophe
            while (index_2 < s.Length && !found) {
                if (s[index_2] == '\'' || s[index_2] == '\"') { found = true; } 
                else { index_2--; }
            }

            if (index_1 == index_2) { throw new Sintax.ParameterError ("Missing \' or \""); }

            string str1 = s.Substring (startIndex: 0, length: index_1 - 0);
            string str2 = s.Substring (startIndex: index_1, length: index_2 - index_1 + 1);

            string str3 = null;
            try {
                str3 = s.Substring (startIndex: index_2 + 1);

            } catch (Exception e) {

            }

            return (str1, str2, null, false);
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
