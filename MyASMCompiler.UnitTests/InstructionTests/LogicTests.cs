using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using MyASMCompiler;
using MyASMCompiler.Errors;

namespace MyASMCompiler.UnitTests.InstructionTests {

    [TestClass]
    [TestCategory ("Logic")]
    public class LogicTests {
        bool Logic_1_param (string[] lines, OpCodes opCode) {
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

        bool Logic_2_param (string[] lines, OpCodes opCode) {
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

        #region AND
        [TestMethod]
        public void AND_REG_NUMBER__ () {
            Assert.IsTrue (Logic_2_param (new string[] { "AND A, 1" }, OpCodes.AND_REG_NUMBER));
        }

        [TestMethod]
        public void AND_REG_REG__ () {
            Assert.IsTrue (Logic_2_param (new string[] { "AND A, B" }, OpCodes.AND_REG_REG));
        }

        [TestMethod]
        public void AND_REG_POINTER__ () {
            Assert.IsTrue (Logic_2_param (new string[] { "AND A, [B]" }, OpCodes.AND_REG_POINTER));
        }

        [TestMethod]
        public void AND_REG_ADDRESS__ () {
            Assert.IsTrue (Logic_2_param (new string[] { "AND A, [1]" }, OpCodes.AND_REG_ADDRESS));
        }
        #endregion

        #region OR
        [TestMethod]
        public void OR_REG_NUMBER__ () {
            Assert.IsTrue (Logic_2_param (new string[] { "OR A, 1" }, OpCodes.OR_REG_NUMBER));
        }

        [TestMethod]
        public void OR_REG_REG__ () {
            Assert.IsTrue (Logic_2_param (new string[] { "OR A, B" }, OpCodes.OR_REG_REG));
        }

        [TestMethod]
        public void OR_REG_POINTER__ () {
            Assert.IsTrue (Logic_2_param (new string[] { "OR A, [B]" }, OpCodes.OR_REG_POINTER));
        }

        [TestMethod]
        public void OR_REG_ADDRESS__ () {
            Assert.IsTrue (Logic_2_param (new string[] { "OR A, [1]" }, OpCodes.OR_REG_ADDRESS));
        }
        #endregion

        #region XOR
        [TestMethod]
        public void XOR_REG_NUMBER__ () {
            Assert.IsTrue (Logic_2_param (new string[] { "XOR A, 1" }, OpCodes.XOR_REG_NUMBER));
        }

        [TestMethod]
        public void XOR_REG_REG__ () {
            Assert.IsTrue (Logic_2_param (new string[] { "XOR A, B" }, OpCodes.XOR_REG_REG));
        }

        [TestMethod]
        public void XOR_REG_POINTER__ () {
            Assert.IsTrue (Logic_2_param (new string[] { "XOR A, [B]" }, OpCodes.XOR_REG_POINTER));
        }

        [TestMethod]
        public void XOR_REG_ADDRESS__ () {
            Assert.IsTrue (Logic_2_param (new string[] { "XOR A, [1]" }, OpCodes.XOR_REG_ADDRESS));
        }
        #endregion


        #region NOT
        [TestMethod]
        public void NOT_REG__ () {
            Assert.IsTrue (Logic_1_param (new string[] { "NOT A" }, OpCodes.NOT_REG));
        }
        #endregion
    }
}
