using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using MyASMCompiler.Errors;

namespace MyASMCompiler {
    class HiddenCompiler {
        public static SetupProperties setupProperties { get; set; }

        public static readonly Regex regex_validParam = new Regex (@"^([A-D]|(SP)|(BP)|([%]{0,1}[0-9]+))$");
        public static readonly Regex regex_validLabel = new Regex (@"^[_a-zA-Z][\._a-zA-Z0-9]+$");
        public static readonly Regex regex_validNumber = new Regex (@"^[\d]+$");

        private static CompiledCode code = null;
        private static string input = null;
        private static int inputIndex = 0;
        private static bool isRunning = false;
        private static int[] registers = new int[4];  // 4 registers
        private static int[] memory = null;
        private static Stack stack = null;

        public static void start (CompiledCode compiledCode, string input) {
            if (compiledCode == null) { throw new Exception ("Compiled code is null"); }
            if (isRunning) { throw new Exception ("Cannot Start: application already running"); }
            code = compiledCode;
            HiddenCompiler.input = (input != null) ? input : "";
            inputIndex = 0;
            registers[0] = registers[1] = registers[2] = registers[3] = 0;
            memory = new int[setupProperties.MaxDataAddress];
            stack = new Stack (setupProperties.MaxStackLength);
            isRunning = true;
        }

        public static void stop () {
            if (! isRunning) { throw new Exception ("Cannot Stop: no application is running"); }
            code = null;
            input = null;
            memory = null;
            stack = null;
            isRunning = false;
        }

        public static CurrentStatus step (Instruction instr, int currInstrAddr) {
            if (! isRunning) { throw new Exception ("Cannot Step: no application is running"); }

            OpCodes opcode = instr.Opcode;
            int param1 = (instr.Param1.HasValue) ? instr.Param1.Value : 0;
            int param2 = (instr.Param2.HasValue) ? instr.Param2.Value : 0;
            string label = (instr.Label != null) ? instr.Label : "";

            bool stop = false;
            bool hasOutput = false;
            bool jumpWasMade = false;
            int nextInstrAddr = 0;
            string output = null;

            switch (opcode) {

                #region Halt
                case OpCodes.HLT: {
                    stop = true;
                } break;
                #endregion


                /// Arithmetic ///
                #region Add
                case OpCodes.ADD_REG_NUMBER: { registers[param1] += param2; } break;

                case OpCodes.ADD_REG_REG: { registers[param1] += registers[param2]; } break;

                case OpCodes.ADD_REG_POINTER: { registers[param1] += memory[registers[param2]]; } break;

                case OpCodes.ADD_REG_ADDRESS: { registers[param1] += memory[param2]; } break;
                #endregion

                #region Subtract
                case OpCodes.SUB_REG_NUMBER: { registers[param1] -= param2; } break;

                case OpCodes.SUB_REG_REG: { registers[param1] -= registers[param2]; } break;

                case OpCodes.SUB_REG_POINTER: { registers[param1] -= memory[registers[param2]]; } break;

                case OpCodes.SUB_REG_ADDRESS: { registers[param1] -= memory[param2]; } break;
                #endregion

                #region Multiply
                case OpCodes.MULT_REG_NUMBER: { registers[param1] *= param2; } break;

                case OpCodes.MULT_REG_REG: { registers[param1] *= registers[param2]; } break;

                case OpCodes.MULT_REG_POINTER: { registers[param1] *= memory[registers[param2]]; } break;

                case OpCodes.MULT_REG_ADDRESS: { registers[param1] *= memory[param2]; } break;
                #endregion

                #region Divide
                case OpCodes.DIV_REG_NUMBER: { registers[param1] /= param2; } break;

                case OpCodes.DIV_REG_REG: { registers[param1] /= registers[param2]; } break;

                case OpCodes.DIV_REG_POINTER: { registers[param1] /= memory[registers[param2]]; } break;

                case OpCodes.DIV_REG_ADDRESS: { registers[param1] /= memory[param2]; } break;
                #endregion

                #region Modulo
                case OpCodes.MOD_REG_NUMBER: { registers[param1] %= param2; } break;

                case OpCodes.MOD_REG_REG: { registers[param1] %= registers[param2]; } break;

                case OpCodes.MOD_REG_POINTER: { registers[param1] %= memory[registers[param2]]; } break;

                case OpCodes.MOD_REG_ADDRESS: { registers[param1] %= memory[param2]; } break;
                #endregion

                #region Increment
                case OpCodes.INC_REG: { registers[param1] ++; } break;
                #endregion

                #region Decrement
                case OpCodes.DEC_REG: { registers[param1] --; } break;
                #endregion

                #region Negate
                case OpCodes.NEG_REG: { registers[param1] = -registers[param1]; } break;
                #endregion


                /// Logic ///
                #region And
                case OpCodes.AND_REG_NUMBER: { registers[param1] &= param2; } break;

                case OpCodes.AND_REG_REG: { registers[param1] &= registers[param2]; } break;

                case OpCodes.AND_REG_POINTER: { registers[param1] &= memory[registers[param2]]; } break;

                case OpCodes.AND_REG_ADDRESS: { registers[param1] &= memory[param2]; } break;
                #endregion

                #region Or
                case OpCodes.OR_REG_NUMBER: { registers[param1] |= param2; } break;

                case OpCodes.OR_REG_REG: { registers[param1] |= registers[param2]; } break;

                case OpCodes.OR_REG_POINTER: { registers[param1] |= memory[registers[param2]]; } break;

                case OpCodes.OR_REG_ADDRESS: { registers[param1] |= memory[param2]; } break;
                #endregion

                #region Xor
                case OpCodes.XOR_REG_NUMBER: { registers[param1] ^= param2; } break;

                case OpCodes.XOR_REG_REG: { registers[param1] ^= registers[param2]; } break;

                case OpCodes.XOR_REG_POINTER: { registers[param1] ^= memory[registers[param2]]; } break;

                case OpCodes.XOR_REG_ADDRESS: { registers[param1] ^= memory[param2]; } break;
                #endregion

                #region Not
                case OpCodes.NOT_REG: { registers[param1] = ~registers[param1]; } break;
                #endregion


                /// Jumps & Branches ///
                #region Jump
                case OpCodes.JMP_LABEL: {
                    try {
                        nextInstrAddr = code.InstructionLabels[label];
                        jumpWasMade = true;
                    } catch (KeyNotFoundException e) {
                        throw new Runtime.InstrLabelNotFound ($"Instruction label not found: {label}");
                    }
                } break;
                #endregion

                #region Jump if zero
                case OpCodes.JZ_REG_LABEL: {
                    if (registers[param1] == 0) {
                        try {
                            nextInstrAddr = code.InstructionLabels[label];
                            jumpWasMade = true;
                        } catch (KeyNotFoundException e) {
                            throw new Runtime.InstrLabelNotFound ($"Instruction label not found: {label}");
                        }
                    }
                } break;
                #endregion

                #region Jump if not zero
                case OpCodes.JNZ_REG_LABEL: {
                    if (registers[param1] != 0) {
                        try {
                            nextInstrAddr = code.InstructionLabels[label];
                            jumpWasMade = true;
                        } catch (KeyNotFoundException e) {
                            throw new Runtime.InstrLabelNotFound ($"Instruction label not found: {label}");
                        }
                    }
                } break;
                #endregion

                #region Jump if less than zero
                case OpCodes.JLZ_REG_LABEL: {
                    if (registers[param1] < 0) {
                        try {
                            nextInstrAddr = code.InstructionLabels[label];
                            jumpWasMade = true;
                        } catch (KeyNotFoundException e) {
                            throw new Runtime.InstrLabelNotFound ($"Instruction label not found: {label}");
                        }
                    }
                } break;
                #endregion

                #region Jump if less than or equal to zero
                case OpCodes.JLEZ_REG_LABEL: {
                    if (registers[param1] <= 0) {
                        try {
                            nextInstrAddr = code.InstructionLabels[label];
                            jumpWasMade = true;
                        } catch (KeyNotFoundException e) {
                            throw new Runtime.InstrLabelNotFound ($"Instruction label not found: {label}");
                        }
                    }
                } break;
                #endregion

                #region Jump if greater than zero
                case OpCodes.JGZ_REG_LABEL: {
                    if (registers[param1] > 0) {
                        try {
                            nextInstrAddr = code.InstructionLabels[label];
                            jumpWasMade = true;
                        } catch (KeyNotFoundException e) {
                            throw new Runtime.InstrLabelNotFound ($"Instruction label not found: {label}");
                        }
                    }
                } break;
                #endregion

                #region Jump if greater than or equal to zero
                case OpCodes.JGEZ_REG_LABEL: {
                    if (registers[param1] >= 0) {
                        try {
                            nextInstrAddr = code.InstructionLabels[label];
                            jumpWasMade = true;
                        } catch (KeyNotFoundException e) {
                            throw new Runtime.InstrLabelNotFound ($"Instruction label not found: {label}");
                        }
                    }
                } break;
                #endregion


                /// Sets ///
                #region Set if zero
                case OpCodes.SZ_REG_REG: { registers[param2] = (registers[param1] == 0) ? 1 : 0; } break;
                #endregion

                #region Set if not zero
                case OpCodes.SNZ_REG_REG: { registers[param2] = (registers[param1] != 0) ? 1 : 0; } break;
                #endregion

                #region Set if less than zero
                case OpCodes.SLZ_REG_REG: { registers[param2] = (registers[param1] < 0) ? 1 : 0; } break;
                #endregion

                #region Set if less than or equal to zero
                case OpCodes.SLEZ_REG_REG: { registers[param2] = (registers[param1] <= 0) ? 1 : 0; } break;
                #endregion

                #region Set if greater than zero
                case OpCodes.SGZ_REG_REG: { registers[param2] = (registers[param1] > 0) ? 1 : 0; } break;
                #endregion

                #region Set if greater than or equal to zero
                case OpCodes.SGEZ_REG_REG: { registers[param2] = (registers[param1] >= 0) ? 1 : 0; } break;
                #endregion


                /// Shifts ///
                #region Shift left
                case OpCodes.SHL_REG: { registers[param1] <<= 1; } break;
                #endregion

                #region Shift right
                case OpCodes.SHR_REG: { registers[param1] >>= 1; } break;
                #endregion


                /// Stack & Functions ///
                #region Push
                case OpCodes.PUSH_NUMBER: { stack.push (param1); } break;

                case OpCodes.PUSH_REG: { stack.push (registers[param1]); } break;

                case OpCodes.PUSH_POINTER: { stack.push (memory[registers[param1]]); } break;

                case OpCodes.PUSH_ADDRESS: { stack.push (memory[param1]); } break;
                #endregion

                #region Pop
                case OpCodes.POP_NUMBER: { 
                    for (int i = 0; i < param1; i ++) { stack.pop (); }
                } break;

                case OpCodes.POP_REG: { registers[param1] = stack.pop (); } break;
                #endregion

                #region Stack read
                case OpCodes.STR_REG_NUMBER: { registers[param1] = stack.read (param2); } break;
                #endregion

                #region Stack write
                case OpCodes.STW_REG_NUMBER: { stack.write (registers[param1], param2); } break;
                #endregion

                #region Call
                case OpCodes.CALL_LABEL: {
                    stack.push (currInstrAddr + 1);  // push return address
                    try {  // jump to label
                        nextInstrAddr = code.InstructionLabels[label];
                        jumpWasMade = true;
                    } catch (KeyNotFoundException e) {
                        throw new Runtime.InstrLabelNotFound ($"Instruction label not found: {label}");
                    }
                } break;
                #endregion

                #region Return
                case OpCodes.RET: {
                    nextInstrAddr = stack.pop ();  // pop return address
                    jumpWasMade = true;
                } break;
                #endregion


                /// IO ///
                #region Input
                case OpCodes.INP_REG: { 
                    try { registers[param1] = (int) input[inputIndex++]; } 
                    catch (IndexOutOfRangeException e) { throw new Runtime.InputError ("Input already finished"); }
                } break;
                #endregion

                #region Output Integer
                case OpCodes.OUTI_REG: {
                    output = (registers[param1]).ToString();
                    hasOutput = true;
                } break;
                #endregion

                #region Output Character
                case OpCodes.OUTC_REG: {
                    try {
                        output = Convert.ToChar (registers[param1]).ToString ();
                        hasOutput = true;
                    } catch (OverflowException e) {
                        throw new Runtime.IntToCharOverflow ($"Value {registers[param1]} cannot be converted to char");
                    }
                } break;
                #endregion


                default: {
                    throw new Runtime.RuntimeError ("Invalid OpCode");
                }
            }

            if (! jumpWasMade) {
                nextInstrAddr = currInstrAddr + 1;
            }

            return new CurrentStatus { 
                nextInstructionAddress = nextInstrAddr,
                registers = registers,
                memory = memory,
                stack = stack,
                stop = stop,
                hasOutput = hasOutput,
                output = output
            };
        }
    }
}
