using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using MyASMCompiler;

namespace AssemblySimulator.GUI {
    public partial class MainForm : Form {

        private string filepath = null;
        private readonly string fileFilter = "All files (*.*)|*.myasm";

        private CompiledCode compiledCode = null;
        public bool IsBuilt { get { return (compiledCode != null); } }
        public bool IsPaused { get; set; }

        private int[] memory = null;
        private Stack stack = null;


        public MainForm () {
            InitializeComponent ();
            init ();

            Compiler.setup (memorySize: 256, stackSize: 128);
            IsPaused = true;

            log ("Project not built.");
        }

        private void init () {
            this.txt_CodeArea.Text = "";
            this.txt_console.Text = "";
            this.txt_input.Text = "";
            this.txt_output.Text = "";
            this.txt_A.Text = "0";
            this.txt_B.Text = "0";
            this.txt_C.Text = "0";
            this.txt_D.Text = "0";
        }


        private void log (string text) {
            this.txt_console.AppendText ($"> {DateTime.Now}: {text}\r\n");
        }

        private void displayStatus(CurrentStatus status) {
            this.memory = status.memory;
            this.stack = status.stack;

            this.txt_A.Text = status.registers[0].ToString ();
            this.txt_B.Text = status.registers[1].ToString ();
            this.txt_C.Text = status.registers[2].ToString ();
            this.txt_D.Text = status.registers[3].ToString ();

            log ("Next instr: " + ((status.instruction != null) ? status.instruction.ToString() : "-"));

            if (status.hasOutput) {
                this.txt_output.Text += status.output;
            }
        }


        #region Click Events
        private void btn_compile_Click (object sender, EventArgs e) => compile ();
        private void btn_start_Click (object sender, EventArgs e) => start ();
        private void btn_step_Click (object sender, EventArgs e) => step ();
        private void btn_stop_Click (object sender, EventArgs e) => stop ();
        private void btn_reset_Click (object sender, EventArgs e) => resetMemoryAndRegisters ();
        private void btn_viewMemory_Click (object sender, EventArgs e) => showMemory ();

        private void newToolStripMenuItem_Click (object sender, EventArgs e) => newFile ();
        private void openToolStripMenuItem_Click (object sender, EventArgs e) => openFile ();
        private void saveToolStripMenuItem_Click (object sender, EventArgs e) => saveFile ();
        private void saveAsToolStripMenuItem_Click (object sender, EventArgs e) => saveFileAs ();
        private void exitToolStripMenuItem_Click (object sender, EventArgs e) => exit ();

        private void buildToolStripMenuItem_Click (object sender, EventArgs e) => compile ();
        private void startToolStripMenuItem_Click (object sender, EventArgs e) => start ();
        private void stepToolStripMenuItem_Click (object sender, EventArgs e) => step ();
        private void stopToolStripMenuItem_Click (object sender, EventArgs e) => stop ();
        private void resetToolStripMenuItem_Click (object sender, EventArgs e) => resetMemoryAndRegisters ();

        private void clearConsoleToolStripMenuItem_Click (object sender, EventArgs e) => clearConsole ();
        private void showBuiltCodeToolStripMenuItem_Click (object sender, EventArgs e) => showBuiltCode ();

        private void consoleToolStripMenuItem_Click (object sender, EventArgs e) => clearConsole ();
        private void outputToolStripMenuItem_Click (object sender, EventArgs e) => clearOutput ();
        private void inputToolStripMenuItem_Click (object sender, EventArgs e) => clearInput ();
        private void showMemoryToolStripMenuItem_Click (object sender, EventArgs e) => showMemory ();
        private void resetOutputToolStripMenuItem_Click (object sender, EventArgs e) => resetMemoryAndRegisters ();

        private void documentationToolStripMenuItem_Click (object sender, EventArgs e) => documentation ();
        #endregion


        ///// Menu Bar & Tool Bar - Actions /////

        #region File
        private void newFile () {
            log ("New file");
            this.compiledCode = null;
            this.txt_CodeArea.Text = "";
            this.filepath = null;
            resetMemoryAndRegisters ();
        }

        private void openFile () {
            log ("Opening...");
            OpenFileDialog fileDialog = new OpenFileDialog {
                Filter = fileFilter  // force extension
            };

            if (fileDialog.ShowDialog () == DialogResult.OK) {
                this.filepath = fileDialog.FileName;
                log ("Filepath: " + this.filepath);

                string fileContent;

                using (StreamReader reader = new StreamReader (this.filepath)) {
                    fileContent = reader.ReadToEnd ();
                    this.txt_CodeArea.Text = fileContent;

                    this.compiledCode = null;
                    resetMemoryAndRegisters ();

                    log ("Opened");
                } 
            }
        }

        private void saveFile () {
            log ("Saving...");
            if (filepath == null) { saveFileAs (); }

            string fileContent = this.txt_CodeArea.Text;

            using (StreamWriter writer = new StreamWriter(this.filepath)) {
                writer.Write (fileContent);
                log ("Saved");
            }
        }

        private void saveFileAs () {
            log ("Saving as...");
            SaveFileDialog fileDialog = new SaveFileDialog {
                Filter = fileFilter  // force extension
            };

            if (fileDialog.ShowDialog() == DialogResult.OK) {
                this.filepath = fileDialog.FileName;
                log ("Filepath: " + this.filepath);

                string fileContent = this.txt_CodeArea.Text;

                using (StreamWriter writer = new StreamWriter(this.filepath)) {
                    writer.Write (fileContent);
                    log ("Saved As");
                }
            }
        }

        private void exit () {
            this.Close ();
        }
        #endregion


        #region Build

        #region BackgroundWorker
        private void worker_DoWork (object sender, DoWorkEventArgs e) {
            var worker = sender as BackgroundWorker;
            e.Result = "";

            bool wantsToStop = false;

            do {
                if (worker.CancellationPending) {
                    e.Cancel = true;
                    break;
                }

                try {
                    Thread.Sleep (50);
                    CurrentStatus status = Runtime.step ();
                    wantsToStop = status.stop;

                    worker.ReportProgress (0, status);

                } catch (Exception ex) {
                    e.Result = ex.Message;
                    wantsToStop = true;
                }
            } while (! wantsToStop);
        }

        private void worker_ProgressChanged (object sender, ProgressChangedEventArgs e) {
            CurrentStatus status = e.UserState as CurrentStatus;
            displayStatus (status);
        }

        private void worker_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e) {
            IsPaused = true;
            if (e.Cancelled) {
                log ("Paused");

            } else {
                if ((string)e.Result == "") { // all fine
                    log ("HALTING...");
                    Runtime.stop ();

                } else { // there was an error
                    log ("Error: " + e.Result);
                    log ("Force stopping...");
                    Runtime.stop ();
                }
            } 
        }
        #endregion

        private void compile () {
            log ("building...");
            string[] lines = txt_CodeArea.Lines;

            try {
                compiledCode = Compiler.compile (lines);
                log ("Project built.");
                //log (compiledCode.ToString ());

            } catch (Exception ex) {
                log (ex.Message);
            }
        }

        private void start () {
            log ("Starting...");
            if (! IsBuilt) { log ("Project not built"); return; }
            if (! IsPaused) { log ("Process not paused"); return; }

            if (!Runtime.IsProcessRunning) {
                string input = this.txt_input.Text;
                Runtime.start (compiledCode, input);
                resetMemoryAndRegisters ();
            }

            IsPaused = false;
            worker.RunWorkerAsync ();
        }

        private void step () {
            log ("Stepping...");
            if (! IsBuilt) { log ("Project not built"); return; }
            if (! IsPaused) { log ("Process not paused"); return; }

            if (! Runtime.IsProcessRunning) {
                string input = this.txt_input.Text;
                Runtime.start (compiledCode, input);
                resetMemoryAndRegisters ();
            }

            try {
                CurrentStatus status = Runtime.step ();
                displayStatus (status);

                if (status.stop) {
                    log ("HALTING");
                    Runtime.stop ();
                }
            } catch (Exception e) {
                log ("Error: " + e.Message);
                log ("Force stopping...");
                Runtime.stop ();
            }  
        }

        private void stop () {
            log ("Stopping...");
            if (! IsBuilt) { log ("Project not built"); return; }
            if (IsPaused) { log ("Process is paused"); return; }

            if (! Runtime.IsProcessRunning) { log ("No process running"); return; }

            worker.CancelAsync ();
        }

        private void resetMemoryAndRegisters () {
            this.txt_output.Text = "";
            this.txt_A.Text = "0";
            this.txt_B.Text = "0";
            this.txt_C.Text = "0";
            this.txt_D.Text = "0";

            this.memory = null;
            this.stack = null;

            log ("Memory RESET");
        }
        #endregion


        #region Console
        private void clearConsole () => this.txt_console.Text = $"> {DateTime.Now}: Console cleared.\r\n";
        private void showBuiltCode () => log (this.compiledCode.ToString());
        #endregion


        #region Tools
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
