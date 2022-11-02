using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASMCompiler {
    public class Compiler {
        public static void test (string s) {
            Console.WriteLine ($"Hello, {s}");
        }

        public int sum (int a, int b) {
            return (a + b) * 2;
        }
    }
}
