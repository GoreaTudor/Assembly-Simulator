using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using MyASMCompiler;
using MyASMCompiler.Errors;

namespace MyASMCompiler.UnitTests.InstructionTests {

    [TestClass]
    [TestCategory ("Sets")]
    public class SetTests {

        bool Set_2_param (string[] lines, OpCodes opCode) {
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

        [TestMethod]
        public void SZ_REG_REG__test () {
            Assert.IsTrue (Set_2_param (new string[] { "SZ A, B" }, OpCodes.SZ_REG_REG));
        }

        [TestMethod]
        public void SNZ_REG_REG__test () {
            Assert.IsTrue (Set_2_param (new string[] { "SNZ A, B" }, OpCodes.SNZ_REG_REG));
        }

        [TestMethod]
        public void SLZ_REG_REG__test () {
            Assert.IsTrue (Set_2_param (new string[] { "SLZ A, B" }, OpCodes.SLZ_REG_REG));
        }

        [TestMethod]
        public void SLEZ_REG_REG__test () {
            Assert.IsTrue (Set_2_param (new string[] { "SLEZ A, B" }, OpCodes.SLEZ_REG_REG));
        }

        [TestMethod]
        public void SGZ_REG_REG__test () {
            Assert.IsTrue (Set_2_param (new string[] { "SGZ A, B" }, OpCodes.SGZ_REG_REG));
        }

        [TestMethod]
        public void SGEZ_REG_REG__test () {
            Assert.IsTrue (Set_2_param (new string[] { "SGEZ A, B" }, OpCodes.SGEZ_REG_REG));
        }

    }
}
