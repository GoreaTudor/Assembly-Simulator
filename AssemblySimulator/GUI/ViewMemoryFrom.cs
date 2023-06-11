using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyASMCompiler;

namespace AssemblySimulator.GUI {
    public partial class ViewMemoryFrom : Form {

        private int[] memory;
        private int[] stack;

        public ViewMemoryFrom (int[] memory, Stack stack) {
            InitializeComponent ();

            if (memory != null && stack != null) {
                this.memory = memory;
                this.stack = stack.getStack ();

                displayValues (this.txt_memory, this.memory);
                displayValues (this.txt_stack, this.stack);

            } else {
                this.txt_memory.Text = "MEMORY  NULL";
                this.txt_stack.Text = "STACK  NULL";

                this.btn_MemorySearch.Enabled = false;
                this.btn_StackSearch.Enabled = false;
            }
            
        }


        #region Click Events
        private void btn_MemorySearch_Click (object sender, EventArgs e) {
            searchValue (
                this.txt_MemoryResult,
                this.memory,
                this.txt_MemorySearch.Text,
                this.radio_MemoryAscii.Checked,
                this.radio_MemoryHex.Checked,
                this.radio_MemoryDec.Checked,
                this.radio_MemoryBin.Checked
            );
        }

        private void btn_StackSearch_Click (object sender, EventArgs e) {
            searchValue (
                this.txt_StackResult,
                this.stack,
                this.txt_StackSearch.Text,
                this.radio_StackAscii.Checked,
                this.radio_StackHex.Checked,
                this.radio_StackDec.Checked,
                this.radio_StackBin.Checked
            );
        }
        #endregion


        private void displayValues (TextBox textBox, int[] values) {
            textBox.Text = "";

            for (int i = 0; i < values.Length; i++) {
                StringBuilder line = new StringBuilder ();

                // display line nr
                string lineNr = Convert.ToString (value: i, toBase: 16);
                line.Append (
                    (lineNr.Length == 1) ? $"000{lineNr}   " :
                    (lineNr.Length == 2) ? $"00{lineNr}   " :
                    (lineNr.Length == 3) ? $"0{lineNr}   " : 
                    $"{lineNr}   "
                );

                // display each byte
                string b0 = Convert.ToString (value: values[i] % 256, toBase: 16);
                string b1 = Convert.ToString (value: values[i] >> 8 % 256, toBase: 16);
                string b2 = Convert.ToString (value: values[i] >> 16 % 256, toBase: 16);
                string b3 = Convert.ToString (value: values[i] >> 24 % 256, toBase: 16);

                line.Append ((b3.Length == 2) ? $"{b3} " : $"0{b3} " );
                line.Append ((b2.Length == 2) ? $"{b2} " : $"0{b1} " );
                line.Append ((b1.Length == 2) ? $"{b1} " : $"0{b1} " );
                line.Append ((b0.Length == 2) ? $"{b0} " : $"0{b0} " );

                textBox.Text += line.ToString();
            }
        }

        private void searchValue (TextBox textBox, int[] values, string position, bool ascii, bool hex, bool dec, bool bin) {
            // validate position & get value
            int pos, val;
            try { 
                pos = Convert.ToInt32 (value: position, fromBase: 16);

                val = values[pos]; // can throw IndexOutOfRangeException

                // display value
                if (ascii) {
                    try { textBox.Text = ((char) val).ToString (); } catch (Exception e) { textBox.Text = "Invalid for ASCII"; }

                } else if (dec) {
                    textBox.Text = val.ToString ();

                } else if (bin) {
                    textBox.Text = Convert.ToString (value: val, toBase: 2);

                } else { // hex by default
                    textBox.Text = Convert.ToString (value: val, toBase: 16);
                }

            } catch (Exception e) { 
                textBox.Text = "Invalid Position"; return; 
            }
        }
    }
}
