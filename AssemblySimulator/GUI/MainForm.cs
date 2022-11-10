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
    public partial class MainForm : Form {

        private CompiledCode compiledCode = null;

        public MainForm () {
            InitializeComponent ();
            init ();

            log ("Project not built.");
        }

        private void init () {
            this.txt_CodeArea.Text = "";
            this.txt_eventsLog.Text = "";
            this.txt_input.Text = "";
            this.txt_output.Text = "";
            this.txt_memoryAddress.Text = "";
            this.txt_memoryValues.Text = "";
        }


        private void log (string text) {
            this.txt_eventsLog.Text += $"{DateTime.Now}: {text}\r\n";
        }

        private void drawLines (int nrOfLines) {
            this.txt_lines.Text = "";

            for (int i = 1; i <= nrOfLines; i++) {
                this.txt_lines.Text += $"{i}:\r\n";
            }
        }


        #region Click Events
        private void btn_build_Click (object sender, EventArgs e) {
            log ("building...");
            string[] lines = txt_CodeArea.Lines;
            this.drawLines (lines.Length);

            try {
                compiledCode = Compiler.compile (lines);
                log (compiledCode.ToString ());

            } catch (Exception ex) {
                log (ex.Message);
            }
        }

        private void btn_run_Click (object sender, EventArgs e) {
            log ("runnung...");
        }

        private void btn_debug_Click (object sender, EventArgs e) {
            log ("debugging...");
        }
        #endregion
    }
}
