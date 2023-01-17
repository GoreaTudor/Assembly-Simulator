using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using MyASMCompiler;
using MyASMCompiler.Errors;

namespace MyASMCompiler.UnitTests {

    [TestClass]
    public class StackTests {

        [TestMethod]
        public void push_hasEnoughSpace_ok () {
            Stack stack = new Stack (10);
            Console.WriteLine ("Before: " + stack.ToString ());

            try {
                stack.push (12);
                Console.WriteLine ("After: " + stack.ToString());
                Assert.IsTrue (true);

            } catch (IndexOutOfRangeException e) {
                Assert.Fail ();
            }
        }

        [TestMethod]
        public void push_notEnoughSpace_StackOverflow () {
            int n = 10;
            Stack stack = new Stack (n);

            for (int i = 0; i < n; i++) {
                stack.push (i);
            }

            Console.WriteLine ("Full Stack: " + stack.ToString ());

            Assert.ThrowsException <RuntimeErrors.StackOverflow> (() => {
                stack.push (404);
            });
        }


        [TestMethod]
        public void pop_SPisGreaterThanZero_ok () {
            Stack stack = new Stack (10);
            stack.push (1);
            Console.WriteLine ("Before: " + stack.ToString ());

            try {
                int value = stack.pop ();
                Console.WriteLine ("After: " + stack.ToString ());
                Assert.AreEqual (1, value);

            } catch (IndexOutOfRangeException e) {
                Assert.Fail ();
            }
        }

        [TestMethod]
        public void pop_SPisEqualToZero_StackUnderflow () {
            Stack stack = new Stack (10);
            Console.WriteLine ("Empty stack: " + stack.ToString ());

            Assert.ThrowsException<RuntimeErrors.StackUnderflow> (() => {
                stack.pop ();
            });
        }


        [TestMethod]
        public void peek_validOffset_ok () {
            Stack stack = new Stack (10);
            stack.push (1);     // SP - 3
            stack.push (2);     // SP - 2
            stack.push (3);     // SP - 1
            stack.push (4);     // SP 
            Console.WriteLine ("Stack: " + stack.ToString ());

            try {
                int value = stack.read (3);
                Console.WriteLine ($"Value: {value}");
                Assert.AreEqual (1, value);

            } catch (RuntimeErrors.StackOverflow e) {
                Assert.Fail ();
            } catch (RuntimeErrors.StackUnderflow e) {
                Assert.Fail ();
            }
        }

        [TestMethod]
        public void peek_invalidOffset_StackOverflow () {
            Stack stack = new Stack (10);
            stack.push (1);     // SP - 3
            stack.push (2);     // SP - 2
            stack.push (3);     // SP - 1
            stack.push (4);     // SP 
            Console.WriteLine ("Stack: " + stack.ToString ());

            try {
                int value = stack.read (-10);
                Assert.Fail ();

            } catch (RuntimeErrors.StackOverflow e) {
                Assert.IsTrue (true);
            } catch (RuntimeErrors.StackUnderflow e) {
                Assert.Fail ();
            }
        }

        [TestMethod]
        public void peek_invalidOffset_StackUnderflow () {
            Stack stack = new Stack (10);
            stack.push (1);     // SP - 3
            stack.push (2);     // SP - 2
            stack.push (3);     // SP - 1
            stack.push (4);     // SP 
            Console.WriteLine ("Stack: " + stack.ToString ());

            try {
                int value = stack.read (10);
                Assert.Fail ();

            } catch (RuntimeErrors.StackOverflow e) {
                Assert.Fail ();
            } catch (RuntimeErrors.StackUnderflow e) {
                Assert.IsTrue (true);
            }
        }
    }
}
