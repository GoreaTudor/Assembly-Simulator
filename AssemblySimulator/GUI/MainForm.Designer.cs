
namespace AssemblySimulator.GUI {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.toolBar = new System.Windows.Forms.Panel();
            this.btn_debug = new System.Windows.Forms.Button();
            this.btn_run = new System.Windows.Forms.Button();
            this.btn_build = new System.Windows.Forms.Button();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_CodeArea = new System.Windows.Forms.TextBox();
            this.panel_data = new System.Windows.Forms.Panel();
            this.panel_memory = new System.Windows.Forms.Panel();
            this.txt_memoryAddress = new System.Windows.Forms.TextBox();
            this.btn_searchAddress = new System.Windows.Forms.Button();
            this.label_address = new System.Windows.Forms.Label();
            this.txt_memoryValues = new System.Windows.Forms.TextBox();
            this.panel_IO = new System.Windows.Forms.Panel();
            this.txt_output = new System.Windows.Forms.TextBox();
            this.label_output = new System.Windows.Forms.Label();
            this.txt_input = new System.Windows.Forms.TextBox();
            this.label_input = new System.Windows.Forms.Label();
            this.panel_mainRegisters = new System.Windows.Forms.Panel();
            this.txt_A = new System.Windows.Forms.TextBox();
            this.label_D = new System.Windows.Forms.Label();
            this.txt_B = new System.Windows.Forms.TextBox();
            this.label_C = new System.Windows.Forms.Label();
            this.txt_C = new System.Windows.Forms.TextBox();
            this.label_B = new System.Windows.Forms.Label();
            this.txt_D = new System.Windows.Forms.TextBox();
            this.label_A = new System.Windows.Forms.Label();
            this.txt_eventsLog = new System.Windows.Forms.TextBox();
            this.txt_lines = new System.Windows.Forms.TextBox();
            this.toolBar.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.panel_data.SuspendLayout();
            this.panel_memory.SuspendLayout();
            this.panel_IO.SuspendLayout();
            this.panel_mainRegisters.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolBar.Controls.Add(this.btn_debug);
            this.toolBar.Controls.Add(this.btn_run);
            this.toolBar.Controls.Add(this.btn_build);
            this.toolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBar.Location = new System.Drawing.Point(0, 30);
            this.toolBar.Margin = new System.Windows.Forms.Padding(4);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(1290, 53);
            this.toolBar.TabIndex = 0;
            // 
            // btn_debug
            // 
            this.btn_debug.BackColor = System.Drawing.Color.Lime;
            this.btn_debug.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_debug.Location = new System.Drawing.Point(180, 4);
            this.btn_debug.Margin = new System.Windows.Forms.Padding(4);
            this.btn_debug.Name = "btn_debug";
            this.btn_debug.Size = new System.Drawing.Size(80, 40);
            this.btn_debug.TabIndex = 2;
            this.btn_debug.Text = "Debug";
            this.btn_debug.UseVisualStyleBackColor = false;
            this.btn_debug.Click += new System.EventHandler(this.btn_debug_Click);
            // 
            // btn_run
            // 
            this.btn_run.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_run.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_run.Location = new System.Drawing.Point(92, 4);
            this.btn_run.Margin = new System.Windows.Forms.Padding(4);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(80, 40);
            this.btn_run.TabIndex = 1;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = false;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_build
            // 
            this.btn_build.BackColor = System.Drawing.Color.Yellow;
            this.btn_build.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_build.Location = new System.Drawing.Point(4, 4);
            this.btn_build.Margin = new System.Windows.Forms.Padding(4);
            this.btn_build.Name = "btn_build";
            this.btn_build.Size = new System.Drawing.Size(80, 40);
            this.btn_build.TabIndex = 0;
            this.btn_build.Text = "Build";
            this.btn_build.UseVisualStyleBackColor = false;
            this.btn_build.Click += new System.EventHandler(this.btn_build_Click);
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuBar.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuBar.Size = new System.Drawing.Size(1290, 30);
            this.menuBar.TabIndex = 1;
            this.menuBar.Text = "Menu Bar";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // txt_CodeArea
            // 
            this.txt_CodeArea.AcceptsTab = true;
            this.txt_CodeArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_CodeArea.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txt_CodeArea.ForeColor = System.Drawing.Color.Black;
            this.txt_CodeArea.Location = new System.Drawing.Point(51, 90);
            this.txt_CodeArea.Multiline = true;
            this.txt_CodeArea.Name = "txt_CodeArea";
            this.txt_CodeArea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_CodeArea.Size = new System.Drawing.Size(812, 434);
            this.txt_CodeArea.TabIndex = 3;
            this.txt_CodeArea.Text = "Code goes here";
            // 
            // panel_data
            // 
            this.panel_data.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel_data.Controls.Add(this.panel_memory);
            this.panel_data.Controls.Add(this.panel_IO);
            this.panel_data.Controls.Add(this.panel_mainRegisters);
            this.panel_data.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_data.Location = new System.Drawing.Point(869, 83);
            this.panel_data.Name = "panel_data";
            this.panel_data.Size = new System.Drawing.Size(421, 597);
            this.panel_data.TabIndex = 4;
            // 
            // panel_memory
            // 
            this.panel_memory.Controls.Add(this.txt_memoryAddress);
            this.panel_memory.Controls.Add(this.btn_searchAddress);
            this.panel_memory.Controls.Add(this.label_address);
            this.panel_memory.Controls.Add(this.txt_memoryValues);
            this.panel_memory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_memory.Location = new System.Drawing.Point(0, 407);
            this.panel_memory.Name = "panel_memory";
            this.panel_memory.Size = new System.Drawing.Size(421, 190);
            this.panel_memory.TabIndex = 10;
            // 
            // txt_memoryAddress
            // 
            this.txt_memoryAddress.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_memoryAddress.Location = new System.Drawing.Point(99, 3);
            this.txt_memoryAddress.Name = "txt_memoryAddress";
            this.txt_memoryAddress.Size = new System.Drawing.Size(200, 27);
            this.txt_memoryAddress.TabIndex = 5;
            // 
            // btn_searchAddress
            // 
            this.btn_searchAddress.Location = new System.Drawing.Point(305, 1);
            this.btn_searchAddress.Name = "btn_searchAddress";
            this.btn_searchAddress.Size = new System.Drawing.Size(75, 30);
            this.btn_searchAddress.TabIndex = 2;
            this.btn_searchAddress.Text = "Search";
            this.btn_searchAddress.UseVisualStyleBackColor = true;
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(3, 6);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(90, 20);
            this.label_address.TabIndex = 5;
            this.label_address.Text = "Address: ";
            // 
            // txt_memoryValues
            // 
            this.txt_memoryValues.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_memoryValues.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_memoryValues.Location = new System.Drawing.Point(0, 40);
            this.txt_memoryValues.Multiline = true;
            this.txt_memoryValues.Name = "txt_memoryValues";
            this.txt_memoryValues.ReadOnly = true;
            this.txt_memoryValues.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_memoryValues.Size = new System.Drawing.Size(421, 150);
            this.txt_memoryValues.TabIndex = 4;
            // 
            // panel_IO
            // 
            this.panel_IO.Controls.Add(this.txt_output);
            this.panel_IO.Controls.Add(this.label_output);
            this.panel_IO.Controls.Add(this.txt_input);
            this.panel_IO.Controls.Add(this.label_input);
            this.panel_IO.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_IO.Location = new System.Drawing.Point(0, 0);
            this.panel_IO.Name = "panel_IO";
            this.panel_IO.Size = new System.Drawing.Size(421, 239);
            this.panel_IO.TabIndex = 9;
            // 
            // txt_output
            // 
            this.txt_output.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_output.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_output.Location = new System.Drawing.Point(8, 144);
            this.txt_output.Multiline = true;
            this.txt_output.Name = "txt_output";
            this.txt_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_output.Size = new System.Drawing.Size(404, 80);
            this.txt_output.TabIndex = 3;
            this.txt_output.Text = "Hello World!";
            // 
            // label_output
            // 
            this.label_output.AutoSize = true;
            this.label_output.Location = new System.Drawing.Point(4, 121);
            this.label_output.Name = "label_output";
            this.label_output.Size = new System.Drawing.Size(72, 20);
            this.label_output.TabIndex = 2;
            this.label_output.Text = "Output:";
            // 
            // txt_input
            // 
            this.txt_input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_input.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_input.Location = new System.Drawing.Point(8, 28);
            this.txt_input.Multiline = true;
            this.txt_input.Name = "txt_input";
            this.txt_input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_input.Size = new System.Drawing.Size(404, 80);
            this.txt_input.TabIndex = 1;
            this.txt_input.Text = "12 23 34";
            // 
            // label_input
            // 
            this.label_input.AutoSize = true;
            this.label_input.Location = new System.Drawing.Point(4, 4);
            this.label_input.Name = "label_input";
            this.label_input.Size = new System.Drawing.Size(63, 20);
            this.label_input.TabIndex = 0;
            this.label_input.Text = "Input:";
            // 
            // panel_mainRegisters
            // 
            this.panel_mainRegisters.Controls.Add(this.txt_A);
            this.panel_mainRegisters.Controls.Add(this.label_D);
            this.panel_mainRegisters.Controls.Add(this.txt_B);
            this.panel_mainRegisters.Controls.Add(this.label_C);
            this.panel_mainRegisters.Controls.Add(this.txt_C);
            this.panel_mainRegisters.Controls.Add(this.label_B);
            this.panel_mainRegisters.Controls.Add(this.txt_D);
            this.panel_mainRegisters.Controls.Add(this.label_A);
            this.panel_mainRegisters.Location = new System.Drawing.Point(256, 245);
            this.panel_mainRegisters.Name = "panel_mainRegisters";
            this.panel_mainRegisters.Size = new System.Drawing.Size(156, 136);
            this.panel_mainRegisters.TabIndex = 8;
            // 
            // txt_A
            // 
            this.txt_A.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_A.Location = new System.Drawing.Point(45, 3);
            this.txt_A.Name = "txt_A";
            this.txt_A.ReadOnly = true;
            this.txt_A.Size = new System.Drawing.Size(100, 27);
            this.txt_A.TabIndex = 0;
            // 
            // label_D
            // 
            this.label_D.AutoSize = true;
            this.label_D.Location = new System.Drawing.Point(3, 105);
            this.label_D.Name = "label_D";
            this.label_D.Size = new System.Drawing.Size(36, 20);
            this.label_D.TabIndex = 7;
            this.label_D.Text = "D: ";
            // 
            // txt_B
            // 
            this.txt_B.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_B.Location = new System.Drawing.Point(45, 36);
            this.txt_B.Name = "txt_B";
            this.txt_B.ReadOnly = true;
            this.txt_B.Size = new System.Drawing.Size(100, 27);
            this.txt_B.TabIndex = 1;
            // 
            // label_C
            // 
            this.label_C.AutoSize = true;
            this.label_C.Location = new System.Drawing.Point(3, 72);
            this.label_C.Name = "label_C";
            this.label_C.Size = new System.Drawing.Size(36, 20);
            this.label_C.TabIndex = 6;
            this.label_C.Text = "C: ";
            // 
            // txt_C
            // 
            this.txt_C.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_C.Location = new System.Drawing.Point(45, 69);
            this.txt_C.Name = "txt_C";
            this.txt_C.ReadOnly = true;
            this.txt_C.Size = new System.Drawing.Size(100, 27);
            this.txt_C.TabIndex = 2;
            // 
            // label_B
            // 
            this.label_B.AutoSize = true;
            this.label_B.Location = new System.Drawing.Point(3, 39);
            this.label_B.Name = "label_B";
            this.label_B.Size = new System.Drawing.Size(36, 20);
            this.label_B.TabIndex = 5;
            this.label_B.Text = "B: ";
            // 
            // txt_D
            // 
            this.txt_D.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_D.Location = new System.Drawing.Point(45, 102);
            this.txt_D.Name = "txt_D";
            this.txt_D.ReadOnly = true;
            this.txt_D.Size = new System.Drawing.Size(100, 27);
            this.txt_D.TabIndex = 3;
            // 
            // label_A
            // 
            this.label_A.AutoSize = true;
            this.label_A.Location = new System.Drawing.Point(3, 6);
            this.label_A.Name = "label_A";
            this.label_A.Size = new System.Drawing.Size(36, 20);
            this.label_A.TabIndex = 4;
            this.label_A.Text = "A: ";
            // 
            // txt_eventsLog
            // 
            this.txt_eventsLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_eventsLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_eventsLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_eventsLog.Location = new System.Drawing.Point(0, 530);
            this.txt_eventsLog.Multiline = true;
            this.txt_eventsLog.Name = "txt_eventsLog";
            this.txt_eventsLog.ReadOnly = true;
            this.txt_eventsLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_eventsLog.Size = new System.Drawing.Size(869, 150);
            this.txt_eventsLog.TabIndex = 0;
            this.txt_eventsLog.Text = "Events Log (Console)";
            // 
            // txt_lines
            // 
            this.txt_lines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_lines.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txt_lines.Enabled = false;
            this.txt_lines.Location = new System.Drawing.Point(4, 90);
            this.txt_lines.Multiline = true;
            this.txt_lines.Name = "txt_lines";
            this.txt_lines.Size = new System.Drawing.Size(50, 434);
            this.txt_lines.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1290, 680);
            this.Controls.Add(this.txt_lines);
            this.Controls.Add(this.txt_eventsLog);
            this.Controls.Add(this.panel_data);
            this.Controls.Add(this.txt_CodeArea);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.menuBar);
            this.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuBar;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.toolBar.ResumeLayout(false);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.panel_data.ResumeLayout(false);
            this.panel_memory.ResumeLayout(false);
            this.panel_memory.PerformLayout();
            this.panel_IO.ResumeLayout(false);
            this.panel_IO.PerformLayout();
            this.panel_mainRegisters.ResumeLayout(false);
            this.panel_mainRegisters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel toolBar;
        private System.Windows.Forms.Button btn_build;
        private System.Windows.Forms.Button btn_debug;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_CodeArea;
        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.TextBox txt_A;
        private System.Windows.Forms.TextBox txt_D;
        private System.Windows.Forms.TextBox txt_C;
        private System.Windows.Forms.TextBox txt_B;
        private System.Windows.Forms.Label label_D;
        private System.Windows.Forms.Label label_C;
        private System.Windows.Forms.Label label_B;
        private System.Windows.Forms.Label label_A;
        private System.Windows.Forms.Panel panel_mainRegisters;
        private System.Windows.Forms.Panel panel_IO;
        private System.Windows.Forms.Label label_input;
        private System.Windows.Forms.TextBox txt_input;
        private System.Windows.Forms.Label label_output;
        private System.Windows.Forms.TextBox txt_output;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_eventsLog;
        private System.Windows.Forms.Panel panel_memory;
        private System.Windows.Forms.Button btn_searchAddress;
        private System.Windows.Forms.TextBox txt_memoryValues;
        private System.Windows.Forms.TextBox txt_memoryAddress;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.TextBox txt_lines;
    }
}