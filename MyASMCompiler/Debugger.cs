using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASMCompiler {

    /// <summary>
    /// Compiler class offers the main utilities that a IDE needs to debug your code. It offers:
    /// <list type="bullet">
    ///     <item> start() - starts the debugging process </item>
    ///     <item> next() - executes the next instruction and returns the status, if it's an output command it will return it's output too </item>
    ///     <item> stop() - stops the debugging process </item>
    /// </list>
    /// </summary>
    public class Debugger {

        /// <summary>
        /// Represents the status of a debug step
        /// </summary>
        public class DebugStatus {
            public string output { get; set; }
        }


        /// <summary>
        /// Starts the debugging process
        /// </summary>
        /// <param name="code"></param>
        public static void start (CompiledCode code) {
            ;
        }


        /// <summary>
        /// Executes the next instruction and returns the status, if it's an output command it will return it's output too
        /// </summary>
        /// <param name="instruction"></param>
        /// <returns> the status, if it's an output command it will return it's output too </returns>
        public static DebugStatus next (Instruction instruction) {
            return null;
        }


        /// <summary>
        /// Stops the debugging process
        /// </summary>
        /// <returns></returns>
        public static DebugStatus stop () {
            return null;
        }
    }
}
