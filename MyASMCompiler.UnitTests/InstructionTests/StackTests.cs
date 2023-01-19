using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using MyASMCompiler;
using MyASMCompiler.Errors;

namespace MyASMCompiler.UnitTests.InstructionTests {

    [TestClass]
    [TestCategory ("Stack & Functions")]
    public class StackTests {

        bool Stack_1_param (string[] lines, OpCodes opCode) {
            Compiler.setup (memorySize: 32, stackSize: 32);
            CompiledCode compiledCode = Compiler.compile (lines);
            Instruction instr = compiledCode.Instructions[0];
            Console.WriteLine (instr.ToString ());
            return (
                instr.Opcode == opCode &&
                instr.Param1 == 0 &&
                instr.Param2 == null &&
                instr.Label == null
            );
        }

        bool Stack_2_param (string[] lines, OpCodes opCode) {
            Compiler.setup (memorySize: 32, stackSize: 32);
            CompiledCode compiledCode = Compiler.compile (lines);
            Instruction instr = compiledCode.Instructions[0];
            Console.WriteLine (instr.ToString ());
            return (
                instr.Opcode == opCode &&
                instr.Param1 == 0 &&
                instr.Param2 == 1 &&
                instr.Label == null
            );
        }


        #region PUSH
        [TestMethod]
        public void PUSH_NUMBER__test () {
            Assert.IsTrue (Stack_1_param (new string[] { "PUSH 0" }, OpCodes.PUSH_NUMBER));
        }

        [TestMethod]
        public void PUSH_REG__test () {
            Assert.IsTrue (Stack_1_param (new string[] { "PUSH A" }, OpCodes.PUSH_REG));
        }

        [TestMethod]
        public void PUSH_POINTER__test () {
            Assert.IsTrue (Stack_1_param (new string[] { "PUSH [A]" }, OpCodes.PUSH_POINTER));
        }

        [TestMethod]
        public void PUSH_ADDRESS__test () {
            Assert.IsTrue (Stack_1_param (new string[] { "PUSH [0]" }, OpCodes.PUSH_ADDRESS));
        }
        #endregion

        #region POP
        [TestMethod]
        public void POP_NUMBER__test () {
            Assert.IsTrue (Stack_1_param (new string[] { "POP 0" }, OpCodes.POP_NUMBER));
        }

        [TestMethod]
        public void POP_REG__test () {
            Assert.IsTrue (Stack_1_param (new string[] { "POP A" }, OpCodes.POP_REG));
        }
        #endregion

        #region STR
        [TestMethod]
        public void STR_REG_NUMBER__test () {
            Assert.IsTrue (Stack_2_param (new string[] { "STR A, 1" }, OpCodes.STR_REG_NUMBER));
        }

        [TestMethod]
        public void STR_REG_REG__test () {
            Assert.IsTrue (Stack_2_param (new string[] { "STR A, B" }, OpCodes.STR_REG_REG));
        }
        #endregion

        #region STW
        [TestMethod]
        public void STW_REG_NUMBER__test () {
            Assert.IsTrue (Stack_2_param (new string[] { "STW A, 1" }, OpCodes.STW_REG_NUMBER));
        }

        [TestMethod]
        public void STW_REG_REG__test () {
            Assert.IsTrue (Stack_2_param (new string[] { "STW A, B" }, OpCodes.STW_REG_REG));
        }
        #endregion

        #region CALL
        [TestMethod]
        public void CALL_label__test () {
            Compiler.setup (memorySize: 32, stackSize: 32);
            CompiledCode compiledCode = Compiler.compile (new string[] { "CALL label" });
            Instruction instr = compiledCode.Instructions[0];
            Console.WriteLine (instr.ToString ());
            Assert.IsTrue (
                instr.Opcode == OpCodes.CALL_LABEL &&
                instr.Param1 == null &&
                instr.Param2 == null &&
                instr.Label == "label"
            );
        }
        #endregion

        #region RET
        [TestMethod]
        public void RET__test () {
            Compiler.setup (memorySize: 32, stackSize: 32);
            CompiledCode compiledCode = Compiler.compile (new string[] { "RET" });
            Instruction instr = compiledCode.Instructions[0];
            Console.WriteLine (instr.ToString ());
            Assert.IsTrue (
                instr.Opcode == OpCodes.RET &&
                instr.Param1 == null &&
                instr.Param2 == null &&
                instr.Label == null
            );
        }
        #endregion
    }
}
