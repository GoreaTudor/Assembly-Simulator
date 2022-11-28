using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using MyASMCompiler;
using MyASMCompiler.Errors;

namespace MyASMCompiler.UnitTests.InstructionTests {

    [TestClass]
    [TestCategory ("Arithmetic")]
    public class ArithmeticTests {
        bool Arithmetic_1_param (string[] lines, OpCodes opCode) {
            Compiler.setup (maxAddress: 32);
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

        bool Arithmetic_2_param (string[] lines, OpCodes opCode) {
            Compiler.setup (maxAddress: 32);
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

        #region ADD
        [TestMethod]
        public void ADD_REG_NUMBER__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "ADD A, 1" }, OpCodes.ADD_REG_NUMBER));
        }

        [TestMethod]
        public void ADD_REG_REG__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "ADD A, B" }, OpCodes.ADD_REG_REG));
        }

        [TestMethod]
        public void ADD_REG_POINTER__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "ADD A, [B]" }, OpCodes.ADD_REG_POINTER));
        }

        [TestMethod]
        public void ADD_REG_ADDRESS__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "ADD A, [1]" }, OpCodes.ADD_REG_ADDRESS));
        }
        #endregion

        #region SUB
        [TestMethod]
        public void SUB_REG_NUMBER__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "SUB A, 1" }, OpCodes.SUB_REG_NUMBER));
        }

        [TestMethod]
        public void SUB_REG_REG__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "SUB A, B" }, OpCodes.SUB_REG_REG));
        }

        [TestMethod]
        public void SUB_REG_POINTER__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "SUB A, [B]" }, OpCodes.SUB_REG_POINTER));
        }

        [TestMethod]
        public void SUB_REG_ADDRESS__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "SUB A, [1]" }, OpCodes.SUB_REG_ADDRESS));
        }
        #endregion

        #region MULT
        [TestMethod]
        public void MULT_REG_NUMBER__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "MULT A, 1" }, OpCodes.MULT_REG_NUMBER));
        }

        [TestMethod]
        public void MULT_REG_REG__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "MULT A, B" }, OpCodes.MULT_REG_REG));
        }

        [TestMethod]
        public void MULT_REG_POINTER__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "MULT A, [B]" }, OpCodes.MULT_REG_POINTER));
        }

        [TestMethod]
        public void MULT_REG_ADDRESS__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "MULT A, [1]" }, OpCodes.MULT_REG_ADDRESS));
        }
        #endregion

        #region DIV
        [TestMethod]
        public void DIV_REG_NUMBER__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "DIV A, 1" }, OpCodes.DIV_REG_NUMBER));
        }

        [TestMethod]
        public void DIV_REG_REG__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "DIV A, B" }, OpCodes.DIV_REG_REG));
        }

        [TestMethod]
        public void DIV_REG_POINTER__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "DIV A, [B]" }, OpCodes.DIV_REG_POINTER));
        }

        [TestMethod]
        public void DIV_REG_ADDRESS__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "DIV A, [1]" }, OpCodes.DIV_REG_ADDRESS));
        }
        #endregion

        #region MOD
        [TestMethod]
        public void MOD_REG_NUMBER__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "MOD A, 1" }, OpCodes.MOD_REG_NUMBER));
        }

        [TestMethod]
        public void MOD_REG_REG__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "MOD A, B" }, OpCodes.MOD_REG_REG));
        }

        [TestMethod]
        public void MOD_REG_POINTER__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "MOD A, [B]" }, OpCodes.MOD_REG_POINTER));
        }

        [TestMethod]
        public void MOD_REG_ADDRESS__test () {
            Assert.IsTrue (Arithmetic_2_param (new string[] { "MOD A, [1]" }, OpCodes.MOD_REG_ADDRESS));
        }
        #endregion


        #region INC
        [TestMethod]
        public void INC_REG__test () {
            Assert.IsTrue (Arithmetic_1_param (new string[] { "INC A" }, OpCodes.INC_REG));
        }
        #endregion

        #region DEC
        [TestMethod]
        public void DEC_REG__test () {
            Assert.IsTrue (Arithmetic_1_param (new string[] { "DEC A" }, OpCodes.DEC_REG));
        }
        #endregion

        #region NEG
        [TestMethod]
        public void NEG_REG__test () {
            Assert.IsTrue (Arithmetic_1_param (new string[] { "NEG A" }, OpCodes.NEG_REG));
        }
        #endregion
    }
}
