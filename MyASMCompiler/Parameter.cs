using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASMCompiler {
    public class Parameter {
        public ParamType Type { get; set; }
        public int? Value { get; set; }

        public override string ToString () {
            return $"Type={Type}, Value={Value}";
        }
    }

    public enum ParamType {
        none, register, pointer, address, number
    } //         A        [A]     [100]    100
}
