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
                instr.Param1 == 1 &&
                instr.Param2 == null &&
                instr.Label == null
            );
        }

        [TestMethod]
        public void INP_REG__test () {
            Assert.IsTrue (IO_1_param (new string[] { "INP B" }, OpCodes.INP_REG));
        }


        [TestMethod]
        public void OUTD_NR__test () {
            Assert.IsTrue (IO_1_param (new string[] { "OUTD 1" }, OpCodes.OUTD_NUMBER));
        }

        [TestMethod]
        public void OUTD_REG__test () {
            Assert.IsTrue (IO_1_param (new string[] { "OUTD B" }, OpCodes.OUTD_REG));
        }


        [TestMethod]
        public void OUTC_NR__test () {
            Assert.IsTrue (IO_1_param (new string[] { "OUTC 1" }, OpCodes.OUTC_NUMBER));
        }

        [TestMethod]
        public void OUTC_REG__test () {
            Assert.IsTrue (IO_1_param (new string[] { "OUTC B" }, OpCodes.OUTC_REG));
        }


        [TestMethod]
        public void OUTB_NR__test () {
            Assert.IsTrue (IO_1_param (new string[] { "OUTB 1" }, OpCodes.OUTB_NUMBER));
        }

        [TestMethod]
        public void OUTB_REG__test () {
            Assert.IsTrue (IO_1_param (new string[] { "OUTB B" }, OpCodes.OUTB_REG));
        }


        [TestMethod]
        public void OUTH_NR__test () {
            Assert.IsTrue (IO_1_param (new string[] { "OUTH 1" }, OpCodes.OUTH_NUMBER));
        }

        [TestMethod]
        public void OUTH_REG__test () {
            Assert.IsTrue (IO_1_param (new string[] { "OUTH B" }, OpCodes.OUTH_REG));
        }
    }
}
