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

            Compiler.setup (memorySize: 256, stackSize: 128);

            log ("Project not built.");
        }

        private void init () {
            this.txt_CodeArea.Text = "";
            this.txt_console.Text = "";
            this.txt_input.Text = "";
            this.txt_output.Text = "";
        }


        private void log (string text) {
            this.txt_console.AppendText ($"> {DateTime.Now}: {text}\r\n");
        }

        private void drawLines (int nrOfLines) {
            this.txt_lines.Text = "";

            for (int i = 1; i <= nrOfLines; i++) {
                this.txt_lines.Text += $"{i}:\r\n";
            }
        }


        #region Click Events
        private void btn_compile_Click (object sender, EventArgs e) => compile ();
        private void btn_start_Click (object sender, EventArgs e) => start ();
        private void btn_step_Click (object sender, EventArgs e) => step ();
        private void btn_stop_Click (object sender, EventArgs e) => stop ();

        private void newToolStripMenuItem_Click (object sender, EventArgs e) => newFile ();
        private void openToolStripMenuItem_Click (object sender, EventArgs e) => openFile ();
        private void saveToolStripMenuItem_Click (object sender, EventArgs e) => saveFile ();
        private void saveAsToolStripMenuItem_Click (object sender, EventArgs e) => saveFileAs ();
        private void closeToolStripMenuItem_Click (object sender, EventArgs e) => closeFile ();
        private void exitToolStripMenuItem_Click (object sender, EventArgs e) => exit ();

        private void consoleToolStripMenuItem_Click (object sender, EventArgs e) => clearConsole ();
        private void outputToolStripMenuItem_Click (object sender, EventArgs e) => clearOutput ();
        private void inputToolStripMenuItem_Click (object sender, EventArgs e) => clearInput ();
        private void showMemoryToolStripMenuItem_Click (object sender, EventArgs e) => showMemory ();

        private void documentationToolStripMenuItem_Click (object sender, EventArgs e) => documentation ();
        #endregion


        ///// Menu Bar & Tool Bar - Actions /////

        #region File
        private void newFile () {
            ;
        }

        private void openFile () {
            ;
        }

        private void saveFile () {
            ;
        }

        private void saveFileAs () {
            ;
        }

        private void closeFile () {
            ;
        }

        private void exit () {
            ;
        }
        #endregion

        #region Edit
        #endregion

        #region Build

        #region BackgroundWorker
        private void worker_DoWork (object sender, DoWorkEventArgs e) {
            ;
        }

        private void worker_ProgressChanged (object sender, ProgressChangedEventArgs e) {
            ;
        }

        private void worker_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e) {
            ;
        }
        #endregion

        private void compile () {
            log ("building...");
            string[] lines = txt_CodeArea.Lines;
            this.drawLines (lines.Length);

            try {
                compiledCode = Compiler.compile (lines);
                log ("Project built.");
                log (compiledCode.ToString ());

            } catch (Exception ex) {
                log (ex.Message);
            }
        }

        private void start () {
            log ("Start");
        }

        private void step () {
            log ("Step");
        }

        private void stop () {
            log ("Stop");
        }
        #endregion

        #region Tools
        private void clearConsole () => this.txt_console.Text = $"> {DateTime.Now}: Console cleared.\r\n";
        private void clearOutput () => this.txt_output.Text = "";
        private void clearInput () => this.txt_input.Text = "";

        private void showMemory () {
            Form form = new ViewMemoryFrom ();
            form.ShowDialog ();
        }
        #endregion

        #region Help
        private void documentation () {
            ;
        }
        #endregion  
    }
}
