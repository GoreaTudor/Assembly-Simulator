using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using MyASMCompiler.Errors;

namespace MyASMCompiler {
    class Runtime {
        public static SetupProperties setupProperties { get; set; }
        private static Process process = null;

        public static bool IsProcessRunning { get { return (process != null); } }

        public static void start (CompiledCode compiledCode, string input) {
            if (IsProcessRunning) { throw new Exception ("Another process already running"); }

            process = new Process (compiledCode, setupProperties, input);
        }

        public static void stop () {
            if (! IsProcessRunning) { throw new Exception ("There is no process running"); }

            process = null;
        }

        public static CurrentStatus step() {
            return process.next ();
        }
    }
}
