using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyASMCompiler.Errors;

namespace MyASMCompiler {
    public class Stack {
        private int[] stack;

        /// <summary>
        /// Stack Pointer - points to the last element, will be initialized with -1
        /// </summary>
        private int SP;

        public Stack (int maxSize) {
            this.stack = new int[maxSize];
            this.SP = -1;
        }

        public void push (int value) {
            try {
                stack[++SP] = value;
            } catch (IndexOutOfRangeException e) {
                throw new Errors.RuntimeErrors.StackOverflow ();
            }
        }

        public int pop () {
            try {
                return stack[SP--];
            } catch (IndexOutOfRangeException e) {
                throw new Errors.RuntimeErrors.StackUnderflow ();
            }
        }

        public int read (int offset) {
            int position = SP - offset;

            if (position < 0) { throw new Errors.RuntimeErrors.StackUnderflow (); }
            if (position >= stack.Length) { throw new Errors.RuntimeErrors.StackOverflow (); }

            return stack[SP - offset];
        }

        public void write (int value, int offset) {
            int position = SP - offset;

            if (position < 0) { throw new Errors.RuntimeErrors.StackUnderflow (); }
            if (position >= stack.Length) { throw new Errors.RuntimeErrors.StackOverflow (); }

            stack[SP - offset] = value;
        }

        public override string ToString () {
            string text = $"SP={SP}  stack=[";

            int i;
            for (i = 0; i <= stack.Length - 2; i ++) {
                if (i == SP) { text += "SP->"; }
                text += $"{stack[i]}, ";
            }

            if (i == SP) { text += "SP->"; }
            text += $"{stack[stack.Length - 1]}]";

            return text;
        }
    }
}
