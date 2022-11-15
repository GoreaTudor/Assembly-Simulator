using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASMCompiler {
    public class Instruction {
        public OpCodes Opcode { get; set; }
        public int? Param1 { get; set; }
        public int? Param2 { get; set; }
        public string Label { get; set; }

        public override string ToString () {
            string param1 = (Param1.HasValue) ? Param1.Value.ToString() : "-";
            string param2 = (Param2.HasValue) ? Param2.Value.ToString() : "-";
            string label = (Label != null) ? Label : "-";

            return $"Opcode={this.Opcode}  Param1={param1}  Param2={param2}  Label={label}";
        }
    }


    /// <summary>
    /// Types of parameters:
    /// <list type="bullet">
    ///     <item> Registers: A, B, C, D </item>
    ///     <item> Pointers: [A], [B], [C], [D] </item>
    ///     <item> Address: [123], [0x2f], [b1100101], ... </item>
    ///     <item> Number: 123, 0x2f, b1100101, ... </item>
    /// </list>
    /// 
    /// <para> Instruction set: </para>
    /// <list type="number">
    ///     <item>
    ///         Memory:
    ///         <list type="bullet">
    ///             <item> MOV dest, src => dest = src </item>
    ///         </list>
    ///     </item>
    /// 
    ///     <item>
    ///         Arithmetic:
    ///         <list type="bullet">
    ///             <item> ADD dest, src => dest += src </item>
    ///             <item> SUB dest, src => dest -= src </item>
    ///             <item> MULT dest, src => dest *= src </item>
    ///             <item> DIV dest, src => dest /= src </item>
    ///             <item> MOD dest, src => dest %= src </item>
    ///             <item> INC dest => dest ++ </item>
    ///             <item> DEC dest => dest -- </item>
    ///             <item> NEG dest => dest = -dest </item>
    ///         </list>
    ///     </item>
    ///     
    ///     <item>
    ///         Logic:
    ///         <list type="bullet">
    ///             <item> AND dest, src  => dest &= src </item>
    ///             <item> OR dest, src => dest |= src </item>
    ///             <item> XOR dest, src => dest ^= src </item>
    ///             <item> NOT dest => dest = !dest </item>
    ///         </list>
    ///     </item>
    ///     
    ///     <item>
    ///         Shifts:
    ///         <list type="bullet">
    ///             <item> SHL dest => shifts contents one time to the left </item>
    ///             <item> SHR dest => shifts contents one time to the right </item>
    ///             <item> ROL dest => rotates contents one time to the left </item>
    ///             <item> ROR dest => rotates contents one time to the right </item>
    ///         </list>
    ///     </item>
    ///     
    ///     <item>
    ///         Jumps and branches:
    ///         <list type="bullet">
    ///             <item> JMP label => jumps to label address </item>
    ///             <item> JZ src, label => if src == 0 jumps to label address  (Synonim: BZ) </item>
    ///             <item> JNZ src, label => if src != 0 jumps to label addressv  (Synonim: BNZ) </item>
    ///             <item> JLZ src, label => if src < 0 jumps to label address  (Synonim: BLZ) </item>
    ///             <item> JLEZ src, label => if src <= 0 jumps to label address  (Synonim: BLEZ) </item>
    ///             <item> JGZ src, label => if src > 0 jumps to label address  (Synonim: BGZ) </item>
    ///             <item> JGEZ src, label => if src >= 0 jumps to label address  (Synonim: BGEZ) </item>
    ///         </list>
    ///     </item>
    ///     
    ///     <item>
    ///         Sets:
    ///         <list type="bullet">
    ///             <item> SZ src, dest => if src == 0 sets dest value to 1, else to 0 </item>
    ///             <item> SNZ src, dest => if src != 0 sets dest value to 1, else to 0 </item>
    ///             <item> SLZ src, dest => if src < 0 sets dest value to 1, else to 0 </item>
    ///             <item> SLEZ src, dest => if src <= 0 sets dest value to 1, else to 0 </item>
    ///             <item> SGZ src, dest => if src > 0 sets dest value to 1, else to 0 </item>
    ///             <item> SGEZ src, dest => if src >= 0 sets dest value to 1, else to 0 </item>
    ///         </list>
    ///     </item>
    ///     
    ///     <item>
    ///         Functions and stack:
    ///         <list type="bullet">
    ///             <item> PUSH src => stack.push(src) </item>
    ///             <item> POP dest => dest = stack.pop() </item>
    ///             <item> PEEK dest, nr => dest = stack[SP - nr] </item>
    ///             <item> CALL label => pushes to the stach the next instruction address, then jumps to label address </item>
    ///             <item> RET => pops the stack, and returns execution to the instruction </item>
    ///         </list>
    ///     </item>
    ///     
    ///     <item>
    ///         IO:
    ///         <list type="bullet">
    ///             <item> INPI dest => reads the next item, as an integer, and saves the value into dest </item>
    ///             <item> INPC dest => reads the next item, as an character, and saves the value into dest </item>
    ///             <item> OUTI src => displays the char value of the src contents </item>
    ///             <item> OUTC src => displays the char value of the src contents </item>
    ///         </list>
    ///     </item>
    ///     
    ///     <item>
    ///         Other:
    ///         <list type="bullet">
    ///             <item> HLT => stops the code execution </item>
    ///         </list>
    ///     </item>
    ///     
    /// </list>
    /// </summary>
    /// <param name="code"> the code of the instruction </param>
    /// <returns> an instruction based on the string </returns>
    public enum OpCodes {
        DEF = -1,     // will not be included in the instructions
        HLT = 0,


        ///// Memory /////
        MOV_REG_NUMBER,
        MOV_REG_REG,
        MOV_REG_POINTER,
        MOV_REG_ADDRESS,
        MOV_POINTER_NUMBER,
        MOV_POINTER_REG,
        MOV_ADDRESS_NUMBER,
        MOV_ADDRESS_REG,


        ///// Arithmetic /////
        ADD_REG_NUMBER,
        ADD_REG_REG,
        ADD_REG_POINTER,
        ADD_REG_ADDRESS,

        SUB_REG_NUMBER,
        SUB_REG_REG,
        SUB_REG_POINTER,
        SUB_REG_ADDRESS,

        MULT_REG_NUMBER,
        MULT_REG_REG,
        MULT_REG_POINTER,
        MULT_REG_ADDRESS,

        DIV_REG_NUMBER,
        DIV_REG_REG,
        DIV_REG_POINTER,
        DIV_REG_ADDRESS,

        MOD_REG_NUMBER,
        MOD_REG_REG,
        MOD_REG_POINTER,
        MOD_REG_ADDRESS,

        INC_REG,
        DEC_REG,

        NEG_REG,


        ///// Logic /////
        AND_REG_NUMBER,
        AND_REG_REG,
        AND_REG_POINTER,
        AND_REG_ADDRESS,

        OR_REG_NUMBER,
        OR_REG_REG,
        OR_REG_POINTER,
        OR_REG_ADDRESS,

        XOR_REG_NUMBER,
        XOR_REG_REG,
        XOR_REG_POINTER,
        XOR_REG_ADDRESS,

        NOT_REG,


        ///// Jumps and Branches /////
        JMP_LABEL,

        JZ_REG_LABEL,
        JNZ_REG_LABEL,

        JLZ_REG_LABEL,
        JLEZ_REG_LABEL,

        JGZ_REG_LABEL,
        JGEZ_REG_LABEL,


        ///// Sets /////
        SZ_REG_REG,
        SNZ_REG_REG,

        SLZ_REG_REG,
        SLEZ_REG_REG,

        SGZ_REG_REG,
        SGEZ_REG_REG,


        ///// Shifts /////
        SHL_REG,
        SHR_REG,


        ///// Stack and Functions /////
        PUSH_NUMBER,
        PUSH_REG,
        PUSH_POINTER,
        PUSH_ADDRESS,

        POP_REG,

        PEEK_REG_NUMBER,

        CALL_LABEL,

        RET,


        ///// IO /////
        INPI_REG,
        INPC_REG,

        OUTI_REG,
        OUTC_REG,
    }
}
