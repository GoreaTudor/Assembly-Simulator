
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
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_viewMemory = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_step = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_compile = new System.Windows.Forms.Button();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBuiltCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tooldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_CodeArea = new System.Windows.Forms.TextBox();
            this.panel_data = new System.Windows.Forms.Panel();
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
            this.txt_console = new System.Windows.Forms.TextBox();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.toolBar.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.panel_data.SuspendLayout();
            this.panel_IO.SuspendLayout();
            this.panel_mainRegisters.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolBar.Controls.Add(this.btn_reset);
            this.toolBar.Controls.Add(this.btn_viewMemory);
            this.toolBar.Controls.Add(this.btn_stop);
            this.toolBar.Controls.Add(this.btn_step);
            this.toolBar.Controls.Add(this.btn_start);
            this.toolBar.Controls.Add(this.btn_compile);
            this.toolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBar.Location = new System.Drawing.Point(0, 30);
            this.toolBar.Margin = new System.Windows.Forms.Padding(4);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(1290, 53);
            this.toolBar.TabIndex = 0;
            // 
            // btn_reset
            // 
            this.btn_reset.BackColor = System.Drawing.Color.Red;
            this.btn_reset.Location = new System.Drawing.Point(373, 4);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(80, 40);
            this.btn_reset.TabIndex = 5;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_viewMemory
            // 
            this.btn_viewMemory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_viewMemory.BackColor = System.Drawing.Color.Yellow;
            this.btn_viewMemory.Location = new System.Drawing.Point(743, 4);
            this.btn_viewMemory.Name = "btn_viewMemory";
            this.btn_viewMemory.Size = new System.Drawing.Size(120, 40);
            this.btn_viewMemory.TabIndex = 4;
            this.btn_viewMemory.Text = "View Memory";
            this.btn_viewMemory.UseVisualStyleBackColor = false;
            this.btn_viewMemory.Click += new System.EventHandler(this.btn_viewMemory_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_stop.Location = new System.Drawing.Point(287, 4);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(80, 40);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = false;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_step
            // 
            this.btn_step.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_step.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_step.Location = new System.Drawing.Point(200, 4);
            this.btn_step.Margin = new System.Windows.Forms.Padding(4);
            this.btn_step.Name = "btn_step";
            this.btn_step.Size = new System.Drawing.Size(80, 40);
            this.btn_step.TabIndex = 2;
            this.btn_step.Text = "Step";
            this.btn_step.UseVisualStyleBackColor = false;
            this.btn_step.Click += new System.EventHandler(this.btn_step_Click);
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.Lime;
            this.btn_start.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(112, 4);
            this.btn_start.Margin = new System.Windows.Forms.Padding(4);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(80, 40);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_compile
            // 
            this.btn_compile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_compile.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_compile.Location = new System.Drawing.Point(4, 4);
            this.btn_compile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_compile.Name = "btn_compile";
            this.btn_compile.Size = new System.Drawing.Size(100, 40);
            this.btn_compile.TabIndex = 0;
            this.btn_compile.Text = "Assemble";
            this.btn_compile.UseVisualStyleBackColor = false;
            this.btn_compile.Click += new System.EventHandler(this.btn_compile_Click);
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuBar.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.consoleToolStripMenuItem1,
            this.tooldToolStripMenuItem,
            this.helpToolStripMenuItem});
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
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildToolStripMenuItem,
            this.startToolStripMenuItem,
            this.stepToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.projectToolStripMenuItem.Text = "Build";
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.buildToolStripMenuItem.Text = "Assemble";
            this.buildToolStripMenuItem.Click += new System.EventHandler(this.buildToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stepToolStripMenuItem
            // 
            this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            this.stepToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.stepToolStripMenuItem.Text = "Stop";
            this.stepToolStripMenuItem.Click += new System.EventHandler(this.stepToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.stopToolStripMenuItem.Text = "Step into";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // consoleToolStripMenuItem1
            // 
            this.consoleToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearConsoleToolStripMenuItem,
            this.showBuiltCodeToolStripMenuItem});
            this.consoleToolStripMenuItem1.Name = "consoleToolStripMenuItem1";
            this.consoleToolStripMenuItem1.Size = new System.Drawing.Size(86, 24);
            this.consoleToolStripMenuItem1.Text = "Console";
            // 
            // clearConsoleToolStripMenuItem
            // 
            this.clearConsoleToolStripMenuItem.Name = "clearConsoleToolStripMenuItem";
            this.clearConsoleToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.clearConsoleToolStripMenuItem.Text = "Clear Console";
            this.clearConsoleToolStripMenuItem.Click += new System.EventHandler(this.clearConsoleToolStripMenuItem_Click);
            // 
            // showBuiltCodeToolStripMenuItem
            // 
            this.showBuiltCodeToolStripMenuItem.Name = "showBuiltCodeToolStripMenuItem";
            this.showBuiltCodeToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.showBuiltCodeToolStripMenuItem.Text = "Show Built Code";
            this.showBuiltCodeToolStripMenuItem.Click += new System.EventHandler(this.showBuiltCodeToolStripMenuItem_Click);
            // 
            // tooldToolStripMenuItem
            // 
            this.tooldToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.showMemoryToolStripMenuItem,
            this.resetOutputToolStripMenuItem});
            this.tooldToolStripMenuItem.Name = "tooldToolStripMenuItem";
            this.tooldToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.tooldToolStripMenuItem.Text = "Tools";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consoleToolStripMenuItem,
            this.outputToolStripMenuItem,
            this.inputToolStripMenuItem});
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.consoleToolStripMenuItem.Text = "Console";
            this.consoleToolStripMenuItem.Click += new System.EventHandler(this.consoleToolStripMenuItem_Click);
            // 
            // outputToolStripMenuItem
            // 
            this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
            this.outputToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.outputToolStripMenuItem.Text = "Output";
            this.outputToolStripMenuItem.Click += new System.EventHandler(this.outputToolStripMenuItem_Click);
            // 
            // inputToolStripMenuItem
            // 
            this.inputToolStripMenuItem.Name = "inputToolStripMenuItem";
            this.inputToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.inputToolStripMenuItem.Text = "Input";
            this.inputToolStripMenuItem.Click += new System.EventHandler(this.inputToolStripMenuItem_Click);
            // 
            // showMemoryToolStripMenuItem
            // 
            this.showMemoryToolStripMenuItem.Name = "showMemoryToolStripMenuItem";
            this.showMemoryToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.showMemoryToolStripMenuItem.Text = "Show Memory";
            this.showMemoryToolStripMenuItem.Click += new System.EventHandler(this.showMemoryToolStripMenuItem_Click);
            // 
            // resetOutputToolStripMenuItem
            // 
            this.resetOutputToolStripMenuItem.Name = "resetOutputToolStripMenuItem";
            this.resetOutputToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.resetOutputToolStripMenuItem.Text = "Reset Output";
            this.resetOutputToolStripMenuItem.Click += new System.EventHandler(this.resetOutputToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.documentationToolStripMenuItem.Text = "Documentation";
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.documentationToolStripMenuItem_Click);
            // 
            // txt_CodeArea
            // 
            this.txt_CodeArea.AcceptsTab = true;
            this.txt_CodeArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_CodeArea.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txt_CodeArea.ForeColor = System.Drawing.Color.Black;
            this.txt_CodeArea.Location = new System.Drawing.Point(4, 90);
            this.txt_CodeArea.Multiline = true;
            this.txt_CodeArea.Name = "txt_CodeArea";
            this.txt_CodeArea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_CodeArea.Size = new System.Drawing.Size(859, 434);
            this.txt_CodeArea.TabIndex = 0;
            this.txt_CodeArea.Text = "Code goes here";
            // 
            // panel_data
            // 
            this.panel_data.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel_data.Controls.Add(this.panel_IO);
            this.panel_data.Controls.Add(this.panel_mainRegisters);
            this.panel_data.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_data.Location = new System.Drawing.Point(869, 83);
            this.panel_data.Name = "panel_data";
            this.panel_data.Size = new System.Drawing.Size(421, 597);
            this.panel_data.TabIndex = 4;
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
            this.txt_output.ReadOnly = true;
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
            // txt_console
            // 
            this.txt_console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_console.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_console.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_console.Location = new System.Drawing.Point(0, 530);
            this.txt_console.Multiline = true;
            this.txt_console.Name = "txt_console";
            this.txt_console.ReadOnly = true;
            this.txt_console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_console.Size = new System.Drawing.Size(869, 150);
            this.txt_console.TabIndex = 3;
            this.txt_console.Text = "Console (Events Log)";
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1290, 680);
            this.Controls.Add(this.txt_console);
            this.Controls.Add(this.panel_data);
            this.Controls.Add(this.txt_CodeArea);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.menuBar);
            this.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuBar;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MyASM IDE";
            this.toolBar.ResumeLayout(false);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.panel_data.ResumeLayout(false);
            this.panel_IO.ResumeLayout(false);
            this.panel_IO.PerformLayout();
            this.panel_mainRegisters.ResumeLayout(false);
            this.panel_mainRegisters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel toolBar;
        private System.Windows.Forms.Button btn_compile;
        private System.Windows.Forms.Button btn_step;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
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
        private System.Windows.Forms.TextBox txt_console;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tooldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.ToolStripMenuItem showMemoryToolStripMenuItem;
        private System.Windows.Forms.Button btn_viewMemory;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showBuiltCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetOutputToolStripMenuItem;
    }
}