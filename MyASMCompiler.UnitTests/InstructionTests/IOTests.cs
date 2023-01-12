using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using MyASMCompiler;
using MyASMCompiler.Errors;

namespace MyASMCompiler.UnitTests.InstructionTests {

    [TestClass]
    [TestCategory ("IO")]
    public class IOTests {
        bool IO_1_param (string[] lines, OpCodes opCode) {
            Compiler.setup (memorySize: 32, stackSize: 32);
            CompiledCode compiledCode = Compiler.compile (lines);
            Instruction instr = compiledCode.Instructions[0];
            Console.WriteLine (instr.ToString());
            return (
                instr.Opcode == opCode &&
                instr.Param1 == 0 &&
                instr.Param2 == null &&
                instr.Label == null
            );
        }

        [TestMethod]
        public void INP_REG__test () {
            Assert.IsTrue (IO_1_param (new string[] { "INP A" }, OpCodes.INP_REG));
        }

        [TestMethod]
        public void OUTI_REG__test () {
            Assert.IsTrue (IO_1_param (new string[] { "OUTI A" }, OpCodes.OUTI_REG));
        }

        [TestMethod]
        public void OUTC_REG__test () {
            Assert.IsTrue (IO_1_param (new string[] { "OUTC A" }, OpCodes.OUTC_REG));
        }

    }
}
