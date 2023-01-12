using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using MyASMCompiler;
using MyASMCompiler.Errors;

namespace MyASMCompiler.UnitTests.InstructionTests {

    [TestClass]
    [TestCategory ("Shift")]
    public class ShiftTests {
        bool Shift_1_param (string[] lines, OpCodes opCode) {
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

        [TestMethod]
        public void SHL_REG__test () {
            Assert.IsTrue (Shift_1_param (new string[] { "SHL A" }, OpCodes.SHL_REG));
        }

        [TestMethod]
        public void SHR_REG__test () {
            Assert.IsTrue (Shift_1_param (new string[] { "SHR A" }, OpCodes.SHR_REG));
        }
    }
}
