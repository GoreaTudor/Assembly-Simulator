using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASMCompiler {

    /// <summary>
    /// 
    /// </summary>
    public class CompiledCode {


        /// <summary>
        /// 
        /// </summary>
        public List <Instruction> instructions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary <string, int> labelsTable { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public CompiledCode () {
            this.instructions = new List <Instruction> ();
            this.labelsTable = new Dictionary <string, int> ();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString () {

            string text = "Code:";
            int i = 0;
            foreach (var instr in instructions) {
                text += $"\ninstr {++i}: {instr.Name}  {instr.param1}  {instr.param2}  {instr.label}";
            }

            text += "\nLabels table:";
            foreach (var pair in labelsTable) {
                text += $"\n{pair.Key} - {pair.Value}";
            }

            return text;
        }
    }
}
