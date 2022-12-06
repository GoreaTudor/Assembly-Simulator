using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using MyASMCompiler;
using MyASMCompiler.Errors;

namespace MyASMCompiler.UnitTests {

    [TestClass]
    public class CompilerTests {

        #region parseNumber
        [TestMethod]
        [TestCategory ("parseNumber")]
        public void parseNumber_hexa_int () {
            string hexaValue = "1f23e";
            int expected = Convert.ToInt32 (value: hexaValue, fromBase: 16);
            int? actual = CompilerChild._parseNumber ($"0x{hexaValue}");

            Console.WriteLine ($"expected: {expected}");
            Console.WriteLine ($"actual: {actual}");

            Assert.AreEqual (expected, actual);
        }

        [TestMethod]
        [TestCategory ("parseNumber")]
        public void parseNumber_binary_int () {
            string binaryValue = "110101001";
            int expected = Convert.ToInt32 (value: binaryValue, fromBase: 2);
            int? actual = CompilerChild._parseNumber ($"0b{binaryValue}");

            Console.WriteLine ($"expected: {expected}");
            Console.WriteLine ($"actual: {actual}");

            Assert.AreEqual (expected, actual);
        }

        [TestMethod]
        [TestCategory ("parseNumber")]
        public void parseNumber_decimal_int () {
            string value = "1234";
            int expected = int.Parse (value);
            int? actual = CompilerChild._parseNumber ($"{value}");

            Console.WriteLine ($"expected: {expected}");
            Console.WriteLine ($"actual: {actual}");

            Assert.AreEqual (expected, actual);
        }

        [TestMethod]
        [TestCategory ("parseNumber")]
        public void parseNumber_badFormat_null () {
            string value = "a02afgh3";
            int? expected = null;
            int? actual = CompilerChild._parseNumber ($"{value}");

            Console.WriteLine ($"expected: {expected}");
            Console.WriteLine ($"actual: {actual}");

            Assert.AreEqual (expected, actual);
        }
        #endregion

        #region parseRegister
        [TestMethod]
        [TestCategory ("parseRegister")]
        public void parseRegister_A_0 () {
            string register = "A";
            int expected = 0;
            int? actual = CompilerChild._parseRegister (register);

            Console.WriteLine ($"expected: {expected}");
            Console.WriteLine ($"actual: {actual}");

            Assert.AreEqual (expected, actual);
        }

        [TestMethod]
        [TestCategory ("parseRegister")]
        public void parseRegister_B_1 () {
            string register = "B";
            int expected = 1;
            int? actual = CompilerChild._parseRegister (register);

            Console.WriteLine ($"expected: {expected}");
            Console.WriteLine ($"actual: {actual}");

            Assert.AreEqual (expected, actual);
        }

        [TestMethod]
        [TestCategory ("parseRegister")]
        public void parseRegister_C_2 () {
            string register = "C";
            int expected = 2;
            int? actual = CompilerChild._parseRegister (register);

            Console.WriteLine ($"expected: {expected}");
            Console.WriteLine ($"actual: {actual}");

            Assert.AreEqual (expected, actual);
        }

        [TestMethod]
        [TestCategory ("parseRegister")]
        public void parseRegister_D_3 () {
            string register = "D";
            int expected = 3;
            int? actual = CompilerChild._parseRegister (register);

            Console.WriteLine ($"expected: {expected}");
            Console.WriteLine ($"actual: {actual}");

            Assert.AreEqual (expected, actual);
        }

        [TestMethod]
        [TestCategory ("parseRegister")]
        public void parseRegister_badRegister_null () {
            string register = "SP";
            int? expected = null;
            int? actual = CompilerChild._parseRegister (register);

            Console.WriteLine ($"expected: {expected}");
            Console.WriteLine ($"actual: {actual}");

            Assert.AreEqual (expected, actual);
        }
        #endregion

        #region getParamTypeAndValue
        [TestMethod]
        [TestCategory ("getParamTypeAndValue")]
        public void getParamTypeAndValue_register_register () {
            string input = "A";
            Parameter expected = new Parameter { Type = ParamType.register, Value = 0 };
            Parameter actual = CompilerChild._getParamTypeAndValue (null, input);
            bool condition = (expected.Type == actual.Type && expected.Value == actual.Value);

            Console.WriteLine ($"expected: {expected.ToString ()}");
            Console.WriteLine ($"actual: {actual.ToString ()}");
            Console.WriteLine ($"condition: {condition.ToString ()}");

            Assert.IsTrue (condition);
        }

        [TestMethod]
        [TestCategory ("getParamTypeAndValue")]
        public void getParamTypeAndValue_pointer_pointer () {
            string input = "[B]";
            Parameter expected = new Parameter { Type = ParamType.pointer, Value = 1 };
            Parameter actual = CompilerChild._getParamTypeAndValue (null, input);
            bool condition = (expected.Type == actual.Type && expected.Value == actual.Value);

            Console.WriteLine ($"expected: {expected.ToString ()}");
            Console.WriteLine ($"actual: {actual.ToString ()}");
            Console.WriteLine ($"condition: {condition.ToString ()}");

            Assert.IsTrue (condition);
        }

        [TestMethod]
        [TestCategory ("getParamTypeAndValue")]
        public void getParamTypeAndValue_address_address () {
            string input = "[100]";
            Parameter expected = new Parameter { Type = ParamType.address, Value = 100 };
            Parameter actual = CompilerChild._getParamTypeAndValue (null, input);
            bool condition = (expected.Type == actual.Type && expected.Value == actual.Value);

            Console.WriteLine ($"expected: {expected.ToString ()}");
            Console.WriteLine ($"actual: {actual.ToString ()}");
            Console.WriteLine ($"condition: {condition.ToString ()}");

            Assert.IsTrue (condition);
        }

        [TestMethod]
        [TestCategory ("getParamTypeAndValue")]
        public void getParamTypeAndValue_number_number () {
            string input = "243";
            Parameter expected = new Parameter { Type = ParamType.number, Value = 243 };
            Parameter actual = CompilerChild._getParamTypeAndValue (null, input);
            bool condition = (expected.Type == actual.Type && expected.Value == actual.Value);

            Console.WriteLine ($"expected: {expected.ToString ()}");
            Console.WriteLine ($"actual: {actual.ToString ()}");
            Console.WriteLine ($"condition: {condition.ToString ()}");

            Assert.IsTrue (condition);
        }

        [TestMethod]
        [TestCategory ("getParamTypeAndValue")]
        public void getParamTypeAndValue_character_character () {
            string input = "'C'";
            Parameter expected = new Parameter { Type = ParamType.number, Value = (int) 'C' };
            Parameter actual = CompilerChild._getParamTypeAndValue (null, input);
            bool condition = (expected.Type == actual.Type && expected.Value == actual.Value);

            Console.WriteLine ($"expected: {expected.ToString ()}");
            Console.WriteLine ($"actual: {actual.ToString ()}");
            Console.WriteLine ($"condition: {condition.ToString ()}");

            Assert.IsTrue (condition);
        }

        [TestMethod]
        [TestCategory ("getParamTypeAndValue")]
        public void getParamTypeAndValue_badCondition_throwsException () {
            string input = "some text";
            Console.WriteLine ($"given: {input}");

            try {
                CompilerChild._getParamTypeAndValue (null, input);
                Assert.Fail (); // if it gets here, no exception was thrown

            } catch (Exception e) {
                Console.WriteLine (e.Message);
                Assert.IsTrue (true);
            }
        }
        #endregion

        #region tokenize
        /*[DataTestMethod]
        [DataRow ("ADD A, 2", "ADD", "A", "2")]
        public void tokenize_tests (string text, string[] tokens) {
            Console.WriteLine ($"text: {text}");

            Console.Write ($"tokens:  ");
            foreach (string token in tokens) {
                Console.Write (token + " ");
            }
        }*/
        #endregion
    }
}
