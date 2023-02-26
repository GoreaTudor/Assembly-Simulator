using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASMCompiler {
    class Process {
        private CompiledCode code;
        private int IP; // Instruction Pointer
        
        private int[] registers;
        private int[] memory;
        private Stack stack;

        private string input;
        private int inputIndex;


        public Process (CompiledCode code, SetupProperties properties, string input = "") {
            this.code = code;
            this.IP = 0;

            this.registers = new int[4]; // all are init to 0
            this.memory = code.StartDataValues;
            this.stack = new Stack (properties.MaxStackLength);

            this.input = (input == null)? "\0" : input + "\0";
            this.inputIndex = 0;
        }


        public CurrentStatus next() {
            if (IP >= code.Instructions.Count) {
                return new CurrentStatus {
                    instruction = null,
                    registers = registers,
                    memory = memory,
                    stack = stack,
                    stop = true,
                    hasOutput = false,
                    output = null
                };
            }

            Instruction instr = code.Instructions[IP];

            OpCodes opcode = instr.Opcode;
            int param1 = (instr.Param1.HasValue) ? instr.Param1.Value : 0;
            int param2 = (instr.Param2.HasValue) ? instr.Param2.Value : 0;
            string label = (instr.Label != null) ? instr.Label : "";

            bool stop = false;
            bool hasOutput = false;
            bool jumpWasMade = false;
            bool inputHasFinished = false;
            int nextIP = 0;
            string output = null;

            switch (opcode) {

                #region Halt
                case OpCodes.HLT: {
                    stop = true;
                }
                break;
                #endregion


                /// Memory ///
                #region MOV
                case OpCodes.MOV_REG_NUMBER:    { registers[param1] = param2; } break;
                case OpCodes.MOV_REG_REG:       { registers[param1] = registers[param2]; } break;
                case OpCodes.MOV_REG_POINTER:   { registers[param1] = memory[registers[param2]]; } break;
                case OpCodes.MOV_REG_ADDRESS:   { registers[param1] = memory[param2]; } break;
                case OpCodes.MOV_POINTER_NUMBER:{ memory[registers[param1]] = param2; } break;
                case OpCodes.MOV_POINTER_REG:   { memory[registers[param1]] = registers[param2]; } break;
                case OpCodes.MOV_ADDRESS_NUMBER:{ memory[param1] = param2; } break;
                case OpCodes.MOV_ADDRESS_REG:   { memory[param1] = registers[param2]; } break;
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
                case OpCodes.INC_REG: { registers[param1]++; } break;
                #endregion

                #region Decrement
                case OpCodes.DEC_REG: { registers[param1]--; } break;
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
                        nextIP = code.InstructionLabels[label];
                        jumpWasMade = true;
                    } catch (KeyNotFoundException e) {
                        throw new Errors.RuntimeErrors.InstrLabelNotFound ($"Instruction label not found: {label}");
                    }
                }
                break;
                #endregion

                #region Jump if zero
                case OpCodes.JZ_REG_LABEL: {
                    if (registers[param1] == 0) {
                        try {
                            nextIP = code.InstructionLabels[label];
                            jumpWasMade = true;
                        } catch (KeyNotFoundException e) {
                            throw new Errors.RuntimeErrors.InstrLabelNotFound ($"Instruction label not found: {label}");
                        }
                    }
                }
                break;
                #endregion

                #region Jump if not zero
                case OpCodes.JNZ_REG_LABEL: {
                    if (registers[param1] != 0) {
                        try {
                            nextIP = code.InstructionLabels[label];
                            jumpWasMade = true;
                        } catch (KeyNotFoundException e) {
                            throw new Errors.RuntimeErrors.InstrLabelNotFound ($"Instruction label not found: {label}");
                        }
                    }
                }
                break;
                #endregion

                #region Jump if less than zero
                case OpCodes.JLZ_REG_LABEL: {
                    if (registers[param1] < 0) {
                        try {
                            nextIP = code.InstructionLabels[label];
                            jumpWasMade = true;
                        } catch (KeyNotFoundException e) {
                            throw new Errors.RuntimeErrors.InstrLabelNotFound ($"Instruction label not found: {label}");
                        }
                    }
                }
                break;
                #endregion

                #region Jump if less than or equal to zero
                case OpCodes.JLEZ_REG_LABEL: {
                    if (registers[param1] <= 0) {
                        try {
                            nextIP = code.InstructionLabels[label];
                            jumpWasMade = true;
                        } catch (KeyNotFoundException e) {
                            throw new Errors.RuntimeErrors.InstrLabelNotFound ($"Instruction label not found: {label}");
                        }
                    }
                }
                break;
                #endregion

                #region Jump if greater than zero
                case OpCodes.JGZ_REG_LABEL: {
                    if (registers[param1] > 0) {
                        try {
                            nextIP = code.InstructionLabels[label];
                            jumpWasMade = true;
                        } catch (KeyNotFoundException e) {
                            throw new Errors.RuntimeErrors.InstrLabelNotFound ($"Instruction label not found: {label}");
                        }
                    }
                }
                break;
                #endregion

                #region Jump if greater than or equal to zero
                case OpCodes.JGEZ_REG_LABEL: {
                    if (registers[param1] >= 0) {
                        try {
                            nextIP = code.InstructionLabels[label];
                            jumpWasMade = true;
                        } catch (KeyNotFoundException e) {
                            throw new Errors.RuntimeErrors.InstrLabelNotFound ($"Instruction label not found: {label}");
                        }
                    }
                }
                break;
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
                    for (int i = 0; i < param1; i++) { stack.pop (); }
                } break;

                case OpCodes.POP_REG: { registers[param1] = stack.pop (); } break;
                #endregion

                #region Stack read
                case OpCodes.STR_REG_NUMBER: { registers[param1] = stack.read (param2); } break;
                case OpCodes.STR_REG_REG: { registers[param1] = stack.read (registers[param2]); } break;
                #endregion

                #region Stack write
                case OpCodes.STW_REG_NUMBER: { stack.write (registers[param1], param2); } break;
                case OpCodes.STW_REG_REG: { stack.write (registers[param1], registers[param2]); } break;
                #endregion

                #region Call
                case OpCodes.CALL_LABEL: {
                    stack.push (this.IP + 1);  // push return address
                    try {  // jump to label
                        nextIP = code.InstructionLabels[label];
                        jumpWasMade = true;
                    } catch (KeyNotFoundException e) {
                        throw new Errors.RuntimeErrors.InstrLabelNotFound ($"Instruction label not found: {label}");
                    }
                } break;
                #endregion

                #region Return
                case OpCodes.RET: {
                    nextIP = stack.pop ();  // pop return address
                    jumpWasMade = true;
                } break;
                #endregion


                /// IO ///
                #region Input
                case OpCodes.INP_REG: {
                    try { registers[param1] = (int) input[inputIndex++]; } 
                    catch (IndexOutOfRangeException e) { throw new Errors.RuntimeErrors.InputError ("Input already finished"); }
                }
                break;
                #endregion

                #region Output Integer
                case OpCodes.OUTI_NUMBER: {
                    output = $"{param1}";
                    hasOutput = true;
                } break;

                case OpCodes.OUTI_REG: {
                    output = $"{registers[param1]}";
                    hasOutput = true;
                } break;
                #endregion

                #region Output Character
                case OpCodes.OUTC_NUMBER: {
                    try {
                        output = Convert.ToChar (param1).ToString ();
                        hasOutput = true;
                    } catch (OverflowException e) {
                        throw new Errors.RuntimeErrors.IntToCharOverflow ($"Value {param1} cannot be converted to char");
                    }
                } break;

                case OpCodes.OUTC_REG: {
                    try {
                        output = Convert.ToChar (registers[param1]).ToString ();
                        hasOutput = true;
                    } catch (OverflowException e) {
                        throw new Errors.RuntimeErrors.IntToCharOverflow ($"Value {registers[param1]} cannot be converted to char");
                    }
                } break;
                #endregion


                default: {
                    throw new Errors.RuntimeErrors.RuntimeError ("Invalid OpCode");
                }
            }

            if (!jumpWasMade) { nextIP = this.IP + 1; }
            this.IP = nextIP;

            return new CurrentStatus {
                instruction = ((IP < code.Instructions.Count) ? code.Instructions[IP] : null),
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
