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


        #region Click Events
        private void btn_build_Click (object sender, EventArgs e) {
            log ("building...");
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
