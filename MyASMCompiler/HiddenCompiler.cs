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
        private static bool isRunning = false;
        private static int[] registers = new int[4];  // 4 registers
        private static int[] memory = null;
        private static Stack stack = null;

        public static void start (CompiledCode compiledCode, string input_s) {
            if (isRunning) { throw new Exception ("Cannot Start: application already running"); }
            code = compiledCode;
            input = input_s;
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
                #region HLT
                case OpCodes.HLT: {
                    stop = true;
                } break;
                #endregion


                #region ADD
                case OpCodes.ADD_REG_NUMBER: { registers[param1] += param2; } break;

                case OpCodes.ADD_REG_REG: { registers[param1] += registers[param2]; } break;

                case OpCodes.ADD_REG_POINTER: { registers[param1] += memory[registers[param2]]; } break;

                case OpCodes.ADD_REG_ADDRESS: { registers[param1] += memory[param2]; } break;
                #endregion

                #region SUB
                case OpCodes.SUB_REG_NUMBER: { registers[param1] -= param2; } break;

                case OpCodes.SUB_REG_REG: { registers[param1] -= registers[param2]; } break;

                case OpCodes.SUB_REG_POINTER: { registers[param1] -= memory[registers[param2]]; } break;

                case OpCodes.SUB_REG_ADDRESS: { registers[param1] -= memory[param2]; } break;
                #endregion

                #region MULT
                case OpCodes.MULT_REG_NUMBER: { registers[param1] *= param2; } break;

                case OpCodes.MULT_REG_REG: { registers[param1] *= registers[param2]; } break;

                case OpCodes.MULT_REG_POINTER: { registers[param1] *= memory[registers[param2]]; } break;

                case OpCodes.MULT_REG_ADDRESS: { registers[param1] *= memory[param2]; } break;
                #endregion

                #region DIV
                case OpCodes.DIV_REG_NUMBER: { registers[param1] /= param2; } break;

                case OpCodes.DIV_REG_REG: { registers[param1] /= registers[param2]; } break;

                case OpCodes.DIV_REG_POINTER: { registers[param1] /= memory[registers[param2]]; } break;

                case OpCodes.DIV_REG_ADDRESS: { registers[param1] /= memory[param2]; } break;
                #endregion

                #region MOD
                case OpCodes.MOD_REG_NUMBER: { registers[param1] %= param2; } break;

                case OpCodes.MOD_REG_REG: { registers[param1] %= registers[param2]; } break;

                case OpCodes.MOD_REG_POINTER: { registers[param1] %= memory[registers[param2]]; } break;

                case OpCodes.MOD_REG_ADDRESS: { registers[param1] %= memory[param2]; } break;
                #endregion

                #region INC
                case OpCodes.INC_REG: { registers[param1] ++; } break;
                #endregion

                #region DEC
                case OpCodes.DEC_REG: { registers[param1] --; } break;
                #endregion

                #region NEG
                case OpCodes.NEG_REG: { registers[param1] = -registers[param1]; } break;
                #endregion


                #region AND
                case OpCodes.AND_REG_NUMBER: { registers[param1] &= param2; } break;

                case OpCodes.AND_REG_REG: { registers[param1] &= registers[param2]; } break;

                case OpCodes.AND_REG_POINTER: { registers[param1] &= memory[registers[param2]]; } break;

                case OpCodes.AND_REG_ADDRESS: { registers[param1] &= memory[param2]; } break;
                #endregion

                #region OR
                case OpCodes.OR_REG_NUMBER: { registers[param1] |= param2; } break;

                case OpCodes.OR_REG_REG: { registers[param1] |= registers[param2]; } break;

                case OpCodes.OR_REG_POINTER: { registers[param1] |= memory[registers[param2]]; } break;

                case OpCodes.OR_REG_ADDRESS: { registers[param1] |= memory[param2]; } break;
                #endregion

                #region XOR
                case OpCodes.XOR_REG_NUMBER: { registers[param1] ^= param2; } break;

                case OpCodes.XOR_REG_REG: { registers[param1] ^= registers[param2]; } break;

                case OpCodes.XOR_REG_POINTER: { registers[param1] ^= memory[registers[param2]]; } break;

                case OpCodes.XOR_REG_ADDRESS: { registers[param1] ^= memory[param2]; } break;
                #endregion

                #region NOT
                case OpCodes.NOT_REG: { registers[param1] = ~registers[param1]; } break;
                #endregion


                #region JMP
                case OpCodes.JMP_LABEL: {
                    try {
                        nextInstrAddr = code.InstructionLabels[label];
                        jumpWasMade = true;
                    } catch (KeyNotFoundException e) {
                        throw new Runtime.InstrLabelNotFound ($"Instruction label not found: {label}");
                    }
                } break;
                #endregion

                #region JZ
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

                #region JNZ
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

                #region JLZ
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

                #region JLEZ
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

                #region JGZ
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

                #region JGEZ
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


                #region SZ
                case OpCodes.SZ_REG_REG: { registers[param2] = (registers[param1] == 0) ? 1 : 0; } break;
                #endregion

                #region SNZ
                case OpCodes.SNZ_REG_REG: { registers[param2] = (registers[param1] != 0) ? 1 : 0; } break;
                #endregion

                #region SLZ
                case OpCodes.SLZ_REG_REG: { registers[param2] = (registers[param1] < 0) ? 1 : 0; } break;
                #endregion

                #region SLEZ
                case OpCodes.SLEZ_REG_REG: { registers[param2] = (registers[param1] <= 0) ? 1 : 0; } break;
                #endregion

                #region SGZ
                case OpCodes.SGZ_REG_REG: { registers[param2] = (registers[param1] > 0) ? 1 : 0; } break;
                #endregion

                #region SGEZ
                case OpCodes.SGEZ_REG_REG: { registers[param2] = (registers[param1] >= 0) ? 1 : 0; } break;
                #endregion


                #region SHL
                case OpCodes.SHL_REG: { registers[param1] <<= 1; } break;
                #endregion

                #region SHR
                case OpCodes.SHR_REG: { registers[param1] >>= 1; } break;
                #endregion


                #region PUSH
                case OpCodes.PUSH_NUMBER: { stack.push (param1); } break;

                case OpCodes.PUSH_REG: { stack.push (registers[param1]); } break;

                case OpCodes.PUSH_POINTER: { stack.push (memory[registers[param1]]); } break;

                case OpCodes.PUSH_ADDRESS: { stack.push (memory[param1]); } break;
                #endregion

                #region POP
                case OpCodes.POP_NUMBER: { 
                    for (int i = 0; i < param1; i ++) { stack.pop (); }
                } break;

                case OpCodes.POP_REG: { registers[param1] = stack.pop (); } break;
                #endregion

                #region PEEK
                case OpCodes.PEEK_REG_NUMBER: {
                    registers[param1] = stack.peek (param2);
                } break;
                #endregion

                #region CALL
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

                #region RET
                case OpCodes.RET: {
                    nextInstrAddr = stack.pop ();  // pop return address
                    jumpWasMade = true;
                } break;
                #endregion


                #region INPI
                case OpCodes.INPI_REG: {
                    ;
                } break;
                #endregion

                #region INPC
                case OpCodes.INPC_REG: {
                    ;
                } break;
                #endregion

                #region OUTI
                case OpCodes.OUTI_REG: {
                    output = (registers[param1]).ToString();
                    hasOutput = true;
                } break;
                #endregion

                #region OUTC
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
