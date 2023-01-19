using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using MyASMCompiler;
using MyASMCompiler.Errors;

namespace MyASMCompiler.UnitTests.InstructionTests {

    [TestClass]
    [TestCategory ("Jumps & Branches")]
    public class JumpTests {

        bool Jump_2_param (string[] lines, OpCodes opCode) {
            Compiler.setup (memorySize: 32, stackSize: 32);
            CompiledCode compiledCode = Compiler.compile (lines);
            Instruction instr = compiledCode.Instructions[0];
            Console.WriteLine (instr.ToString ());
            return (
                instr.Opcode == opCode &&
                instr.Param1 == 0 &&
                instr.Param2 == null &&
                instr.Label == "label"
            );
        }


        [TestMethod]
        public void JMP_label__test () {
            Compiler.setup (memorySize: 32, stackSize: 32);
            CompiledCode compiledCode = Compiler.compile (new string[] { "JMP label" });
            Instruction instr = compiledCode.Instructions[0];
            Console.WriteLine (instr.ToString ());
            Assert.IsTrue (
                instr.Opcode == OpCodes.JMP_LABEL &&
                instr.Param1 == null &&
                instr.Param2 == null &&
                instr.Label == "label"
            );
        }

        [TestMethod]
        public void JZ_REG_label__test () {
            Assert.IsTrue (Jump_2_param (new string[] { "JZ A, label" }, OpCodes.JZ_REG_LABEL));
        }

        [TestMethod]
        public void JNZ_REG_label__test () {
            Assert.IsTrue (Jump_2_param (new string[] { "JNZ A, label" }, OpCodes.JNZ_REG_LABEL));
        }

        [TestMethod]
        public void JLZ_REG_label__test () {
            Assert.IsTrue (Jump_2_param (new string[] { "JLZ A, label" }, OpCodes.JLZ_REG_LABEL));
        }

        [TestMethod]
        public void JLEZ_REG_label__test () {
            Assert.IsTrue (Jump_2_param (new string[] { "JLEZ A, label" }, OpCodes.JLEZ_REG_LABEL));
        }

        [TestMethod]
        public void JGZ_REG_label__test () {
            Assert.IsTrue (Jump_2_param (new string[] { "JGZ A, label" }, OpCodes.JGZ_REG_LABEL));
        }

        [TestMethod]
        public void JGEZ_REG_label__test () {
            Assert.IsTrue (Jump_2_param (new string[] { "JGEZ A, label" }, OpCodes.JGEZ_REG_LABEL));
        }
    }
}
