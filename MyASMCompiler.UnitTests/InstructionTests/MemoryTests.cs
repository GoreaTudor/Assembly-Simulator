using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using MyASMCompiler;
using MyASMCompiler.Errors;

namespace MyASMCompiler.UnitTests.InstructionTests {

    [TestClass]
    [TestCategory ("Memory")]
    public class MemoryTests {

        bool Memory_2_param (string[] lines, OpCodes opCode) {
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

        #region MOV
        [TestMethod]
        public void MOV_REG_NUMBER__test () {
            Assert.IsTrue (Memory_2_param (new string[] { "MOV A, 1" }, OpCodes.MOV_REG_NUMBER));
        }

        [TestMethod]
        public void MOV_REG_REG__test () {
            Assert.IsTrue (Memory_2_param (new string[] { "MOV A, B" }, OpCodes.MOV_REG_REG));
        }

        [TestMethod]
        public void MOV_REG_POINTER__test () {
            Assert.IsTrue (Memory_2_param (new string[] { "MOV A, [B]" }, OpCodes.MOV_REG_POINTER));
        }

        [TestMethod]
        public void MOV_REG_ADDRESS__test () {
            Assert.IsTrue (Memory_2_param (new string[] { "MOV A, [1]" }, OpCodes.MOV_REG_ADDRESS));
        }

        [TestMethod]
        public void MOV_POINTER_NUMBER__test () {
            Assert.IsTrue (Memory_2_param (new string[] { "MOV [A], 1" }, OpCodes.MOV_POINTER_NUMBER));
        }

        [TestMethod]
        public void MOV_POINTER_REG__test () {
            Assert.IsTrue (Memory_2_param (new string[] { "MOV [A], B" }, OpCodes.MOV_POINTER_REG));
        }

        [TestMethod]
        public void MOV_ADDRESS_NUMBER__test () {
            Assert.IsTrue (Memory_2_param (new string[] { "MOV [0], 1" }, OpCodes.MOV_ADDRESS_NUMBER));
        }

        [TestMethod]
        public void MOV_ADDRESS_REG__test () {
            Assert.IsTrue (Memory_2_param (new string[] { "MOV [0], B" }, OpCodes.MOV_ADDRESS_REG));
        }
        #endregion
    }
}
