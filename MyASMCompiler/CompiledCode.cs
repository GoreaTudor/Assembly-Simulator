﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASMCompiler {

    /// <summary>
    /// It's a representation of the code that is to be executed, it also memorizes labels for jumping throughout the code, 
    /// and labels for compilation phase defined data.
    /// </summary>
    public class CompiledCode {

        /// <summary>
        /// Each instruction represents a request to the assembler to do certain operations during the Runtime Phase.
        /// </summary>
        public List <Instruction> Instructions { get; set; }

        /// <summary>
        /// Instruction labels are used to memorize the address where IP will point to next, used by Jumps and Branches.
        /// </summary>
        public Dictionary <string, int> InstructionLabels { get; set; }

        /// <summary>
        /// Data labels are a lot like pointers, they give the address of a specific variable, beginning of a string.
        /// </summary>
        public Dictionary <string, int> DataLabels { get; set; }

        /// <summary>
        /// Starting values are defined using "DB" command, and will be present in Runtime Phase, to be used by the assembler.
        /// </summary>
        public int[] StartDataValues { get; set; }
        public int NextAddressPointer { get; set; }


        public CompiledCode () {
            this.Instructions = new List <Instruction> ();
            this.InstructionLabels = new Dictionary <string, int> ();
            this.DataLabels = new Dictionary <string, int> ();
            this.StartDataValues = new int[Runtime.setupProperties.MaxDataAddress];
            this.NextAddressPointer = 1; // 0 for null character

            for (int i = 0; i < StartDataValues.Length; i ++) {
                StartDataValues[i] = 0;
            }
        }


        public override string ToString () {
            string text = "code.ToString():";

            text += "\r\n>>> Code:";
            int i = 0;
            foreach (var instr in Instructions) {
                text += $"\r\ninstr {i++}: {instr.ToString()}";
            }

            text += "\r\n>>> Instruction Labels:";
            foreach (var pair in InstructionLabels) {
                text += $"\r\n{pair.Key} - {pair.Value}";
            }

            text += "\r\n>>> Data Labels:";
            foreach (var pair in DataLabels) {
                text += $"\r\n{pair.Key} - {pair.Value}";
            }

            return text;
        }
    }
}
