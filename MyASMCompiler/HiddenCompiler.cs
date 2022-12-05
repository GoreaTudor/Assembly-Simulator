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

        private static bool isRunning = false;
        private static int[] registers = new int[4];  // 4 registers
        private static int[] memory = null;
        private static Stack stack = null;

        public static void start () {
            if (isRunning) { throw new Exception ("Cannot Start: application already running"); }
            registers[0] = registers[1] = registers[2] = registers[3] = 0;
            memory = new int[setupProperties.MaxDataAddress];
            stack = new Stack (setupProperties.MaxStackLength);
            isRunning = true;
        }

        public static void stop () {
            if (! isRunning) { throw new Exception ("Cannot Stop: no application is running"); }
            memory = null;
            stack = null;
            isRunning = false;
        }

        public static void step (Instruction instr) {
            if (! isRunning) { throw new Exception ("Cannot Step: no application is running"); }

            OpCodes opcode = instr.Opcode;
            int param1 = (instr.Param1.HasValue) ? instr.Param1.Value : 0;
            int param2 = (instr.Param2.HasValue) ? instr.Param2.Value : 0;
            string label = instr.Label;

            switch (opcode) {
                case OpCodes.HLT: {
                    ;
                } break;

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

                default: {
                    throw new Runtime.RuntimeError ("Invalid OpCode");
                }
            }
        }
    }
}
