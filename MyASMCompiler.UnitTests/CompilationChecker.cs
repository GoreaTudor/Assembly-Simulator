using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using MyASMCompiler;
using MyASMCompiler.Errors;

namespace MyASMCompiler.UnitTests {

    [TestClass]
    public class CompilationChecker {

        /*[TestMethod]
        public void TestingWorks() {
            Assert.IsTrue (true);
        }*/

        bool Anything_1_param_REG (string[] lines, OpCodes opCode) {
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

        bool Arithmetic_Logic_2_param (string[] lines, OpCodes opCode) {
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


        #region General  *** NOT IMPLEMENTED YET ***
        #endregion

        #region Memory  *** NOT IMPLEMENTED YET ***
        #endregion

        #region Arithmetic
        #region ADD
        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void ADD_REG_NUMBER__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "ADD A, 1" }, OpCodes.ADD_REG_NUMBER));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void ADD_REG_REG__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "ADD A, B" }, OpCodes.ADD_REG_REG));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void ADD_REG_POINTER__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "ADD A, [B]" }, OpCodes.ADD_REG_POINTER));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void ADD_REG_ADDRESS__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "ADD A, [1]" }, OpCodes.ADD_REG_ADDRESS));
        }
        #endregion

        #region SUB
        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void SUB_REG_NUMBER__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "SUB A, 1" }, OpCodes.SUB_REG_NUMBER));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void SUB_REG_REG__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "SUB A, B" }, OpCodes.SUB_REG_REG));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void SUB_REG_POINTER__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "SUB A, [B]" }, OpCodes.SUB_REG_POINTER));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void SUB_REG_ADDRESS__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "SUB A, [1]" }, OpCodes.SUB_REG_ADDRESS));
        }
        #endregion

        #region MULT
        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void MULT_REG_NUMBER__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "MULT A, 1" }, OpCodes.MULT_REG_NUMBER));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void MULT_REG_REG__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "MULT A, B" }, OpCodes.MULT_REG_REG));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void MULT_REG_POINTER__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "MULT A, [B]" }, OpCodes.MULT_REG_POINTER));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void MULT_REG_ADDRESS__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "MULT A, [1]" }, OpCodes.MULT_REG_ADDRESS));
        }
        #endregion

        #region DIV
        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void DIV_REG_NUMBER__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "DIV A, 1" }, OpCodes.DIV_REG_NUMBER));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void DIV_REG_REG__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "DIV A, B" }, OpCodes.DIV_REG_REG));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void DIV_REG_POINTER__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "DIV A, [B]" }, OpCodes.DIV_REG_POINTER));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void DIV_REG_ADDRESS__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "DIV A, [1]" }, OpCodes.DIV_REG_ADDRESS));
        }
        #endregion

        #region MOD
        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void MOD_REG_NUMBER__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "MOD A, 1" }, OpCodes.MOD_REG_NUMBER));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void MOD_REG_REG__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "MOD A, B" }, OpCodes.MOD_REG_REG));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void MOD_REG_POINTER__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "MOD A, [B]" }, OpCodes.MOD_REG_POINTER));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void MOD_REG_ADDRESS__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "MOD A, [1]" }, OpCodes.MOD_REG_ADDRESS));
        }
        #endregion

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void INC_REG__ () {
            Assert.IsTrue (Anything_1_param_REG (new string[] { "INC A" }, OpCodes.INC_REG));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void DEC_REG__ () {
            Assert.IsTrue (Anything_1_param_REG (new string[] { "DEC A" }, OpCodes.DEC_REG));
        }

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void NEG_REG__ () {
            Assert.IsTrue (Anything_1_param_REG (new string[] { "NEG A" }, OpCodes.NEG_REG));
        }
        #endregion

        #region Logic
        #region AND
        [TestMethod]
        [TestCategory ("Logic")]
        public void AND_REG_NUMBER__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "AND A, 1" }, OpCodes.AND_REG_NUMBER));
        }

        [TestMethod]
        [TestCategory ("Logic")]
        public void AND_REG_REG__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "AND A, B" }, OpCodes.AND_REG_REG));
        }

        [TestMethod]
        [TestCategory ("Logic")]
        public void AND_REG_POINTER__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "AND A, [B]" }, OpCodes.AND_REG_POINTER));
        }

        [TestMethod]
        [TestCategory ("Logic")]
        public void AND_REG_ADDRESS__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "AND A, [1]" }, OpCodes.AND_REG_ADDRESS));
        }
        #endregion

        #region OR
        [TestMethod]
        [TestCategory ("Logic")]
        public void OR_REG_NUMBER__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "OR A, 1" }, OpCodes.OR_REG_NUMBER));
        }

        [TestMethod]
        [TestCategory ("Logic")]
        public void OR_REG_REG__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "OR A, B" }, OpCodes.OR_REG_REG));
        }

        [TestMethod]
        [TestCategory ("Logic")]
        public void OR_REG_POINTER__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "OR A, [B]" }, OpCodes.OR_REG_POINTER));
        }

        [TestMethod]
        [TestCategory ("Logic")]
        public void OR_REG_ADDRESS__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "OR A, [1]" }, OpCodes.OR_REG_ADDRESS));
        }
        #endregion

        #region XOR
        [TestMethod]
        [TestCategory ("Logic")]
        public void XOR_REG_NUMBER__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "XOR A, 1" }, OpCodes.XOR_REG_NUMBER));
        }

        [TestMethod]
        [TestCategory ("Logic")]
        public void XOR_REG_REG__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "XOR A, B" }, OpCodes.XOR_REG_REG));
        }

        [TestMethod]
        [TestCategory ("Logic")]
        public void XOR_REG_POINTER__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "XOR A, [B]" }, OpCodes.XOR_REG_POINTER));
        }

        [TestMethod]
        [TestCategory ("Logic")]
        public void XOR_REG_ADDRESS__ () {
            Assert.IsTrue (Arithmetic_Logic_2_param (new string[] { "XOR A, [1]" }, OpCodes.XOR_REG_ADDRESS));
        }
        #endregion

        [TestMethod]
        [TestCategory ("Arithmetic")]
        public void NOT_REG__ () {
            Assert.IsTrue (Anything_1_param_REG (new string[] { "NOT A" }, OpCodes.NOT_REG));
        }
        #endregion

        #region Jumps and Branches  *** NOT IMPLEMENTED YET ***
        #endregion

        #region Sets  *** NOT IMPLEMENTED YET ***
        #endregion

        #region Shifts  *** NOT IMPLEMENTED YET ***
        #endregion

        #region Stack and Functions  *** NOT IMPLEMENTED YET ***
        #region PUSH
        #endregion
        #endregion

        #region IO  *** NOT IMPLEMENTED YET ***
        #endregion
    }
}
