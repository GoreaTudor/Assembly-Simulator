
namespace AssemblySimulator.GUI {
    partial class ViewMemoryFrom {
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
            this.lbl_memory = new System.Windows.Forms.Label();
            this.txt_memory = new System.Windows.Forms.TextBox();
            this.radio_MemoryHex = new System.Windows.Forms.RadioButton();
            this.radio_MemoryDec = new System.Windows.Forms.RadioButton();
            this.radio_MemoryBin = new System.Windows.Forms.RadioButton();
            this.btn_MemorySearch = new System.Windows.Forms.Button();
            this.txt_MemoryResult = new System.Windows.Forms.TextBox();
            this.txt_stack = new System.Windows.Forms.TextBox();
            this.lbl_stack = new System.Windows.Forms.Label();
            this.txt_StackResult = new System.Windows.Forms.TextBox();
            this.btn_StackSearch = new System.Windows.Forms.Button();
            this.radio_StackHex = new System.Windows.Forms.RadioButton();
            this.radio_StackDec = new System.Windows.Forms.RadioButton();
            this.radio_StackBin = new System.Windows.Forms.RadioButton();
            this.panel_memory = new System.Windows.Forms.Panel();
            this.txt_MemorySearch = new System.Windows.Forms.TextBox();
            this.radio_MemoryAscii = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_StackSearch = new System.Windows.Forms.TextBox();
            this.radio_StackAscii = new System.Windows.Forms.RadioButton();
            this.lbl_memory0x = new System.Windows.Forms.Label();
            this.lbl_stack0x = new System.Windows.Forms.Label();
            this.panel_memory.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_memory
            // 
            this.lbl_memory.AutoSize = true;
            this.lbl_memory.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_memory.Location = new System.Drawing.Point(3, 0);
            this.lbl_memory.Name = "lbl_memory";
            this.lbl_memory.Size = new System.Drawing.Size(72, 20);
            this.lbl_memory.TabIndex = 0;
            this.lbl_memory.Text = "Memory:";
            // 
            // txt_memory
            // 
            this.txt_memory.Location = new System.Drawing.Point(3, 21);
            this.txt_memory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_memory.Multiline = true;
            this.txt_memory.Name = "txt_memory";
            this.txt_memory.ReadOnly = true;
            this.txt_memory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_memory.Size = new System.Drawing.Size(200, 400);
            this.txt_memory.TabIndex = 1;
            this.txt_memory.Text = "0000   00 00 00 00\r\n0001   00 1F 94 03\r\n0002   00 00 A4 57\r\n";
            // 
            // radio_MemoryHex
            // 
            this.radio_MemoryHex.AutoSize = true;
            this.radio_MemoryHex.Checked = true;
            this.radio_MemoryHex.Location = new System.Drawing.Point(3, 494);
            this.radio_MemoryHex.Name = "radio_MemoryHex";
            this.radio_MemoryHex.Size = new System.Drawing.Size(57, 24);
            this.radio_MemoryHex.TabIndex = 3;
            this.radio_MemoryHex.TabStop = true;
            this.radio_MemoryHex.Text = "Hex";
            this.radio_MemoryHex.UseVisualStyleBackColor = true;
            // 
            // radio_MemoryDec
            // 
            this.radio_MemoryDec.AutoSize = true;
            this.radio_MemoryDec.Location = new System.Drawing.Point(84, 494);
            this.radio_MemoryDec.Name = "radio_MemoryDec";
            this.radio_MemoryDec.Size = new System.Drawing.Size(57, 24);
            this.radio_MemoryDec.TabIndex = 4;
            this.radio_MemoryDec.Text = "Dec";
            this.radio_MemoryDec.UseVisualStyleBackColor = true;
            // 
            // radio_MemoryBin
            // 
            this.radio_MemoryBin.AutoSize = true;
            this.radio_MemoryBin.Location = new System.Drawing.Point(84, 524);
            this.radio_MemoryBin.Name = "radio_MemoryBin";
            this.radio_MemoryBin.Size = new System.Drawing.Size(57, 24);
            this.radio_MemoryBin.TabIndex = 5;
            this.radio_MemoryBin.Text = "Bin";
            this.radio_MemoryBin.UseVisualStyleBackColor = true;
            // 
            // btn_MemorySearch
            // 
            this.btn_MemorySearch.Location = new System.Drawing.Point(128, 462);
            this.btn_MemorySearch.Name = "btn_MemorySearch";
            this.btn_MemorySearch.Size = new System.Drawing.Size(75, 27);
            this.btn_MemorySearch.TabIndex = 7;
            this.btn_MemorySearch.Text = "Search";
            this.btn_MemorySearch.UseVisualStyleBackColor = true;
            this.btn_MemorySearch.Click += new System.EventHandler(this.btn_MemorySearch_Click);
            // 
            // txt_MemoryResult
            // 
            this.txt_MemoryResult.Location = new System.Drawing.Point(7, 428);
            this.txt_MemoryResult.Name = "txt_MemoryResult";
            this.txt_MemoryResult.ReadOnly = true;
            this.txt_MemoryResult.Size = new System.Drawing.Size(196, 27);
            this.txt_MemoryResult.TabIndex = 8;
            // 
            // txt_stack
            // 
            this.txt_stack.Location = new System.Drawing.Point(3, 24);
            this.txt_stack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_stack.Multiline = true;
            this.txt_stack.Name = "txt_stack";
            this.txt_stack.ReadOnly = true;
            this.txt_stack.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_stack.Size = new System.Drawing.Size(200, 400);
            this.txt_stack.TabIndex = 9;
            this.txt_stack.Text = "0000   00 00 00 00\r\n0001   00 1F 94 03\r\n0002   00 00 A4 57\r\n";
            // 
            // lbl_stack
            // 
            this.lbl_stack.AutoSize = true;
            this.lbl_stack.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stack.Location = new System.Drawing.Point(3, 0);
            this.lbl_stack.Name = "lbl_stack";
            this.lbl_stack.Size = new System.Drawing.Size(63, 20);
            this.lbl_stack.TabIndex = 10;
            this.lbl_stack.Text = "Stack:";
            // 
            // txt_StackResult
            // 
            this.txt_StackResult.Location = new System.Drawing.Point(7, 431);
            this.txt_StackResult.Name = "txt_StackResult";
            this.txt_StackResult.ReadOnly = true;
            this.txt_StackResult.Size = new System.Drawing.Size(196, 27);
            this.txt_StackResult.TabIndex = 11;
            // 
            // btn_StackSearch
            // 
            this.btn_StackSearch.Location = new System.Drawing.Point(128, 464);
            this.btn_StackSearch.Name = "btn_StackSearch";
            this.btn_StackSearch.Size = new System.Drawing.Size(75, 27);
            this.btn_StackSearch.TabIndex = 13;
            this.btn_StackSearch.Text = "Search";
            this.btn_StackSearch.UseVisualStyleBackColor = true;
            this.btn_StackSearch.Click += new System.EventHandler(this.btn_StackSearch_Click);
            // 
            // radio_StackHex
            // 
            this.radio_StackHex.AutoSize = true;
            this.radio_StackHex.Checked = true;
            this.radio_StackHex.Location = new System.Drawing.Point(3, 497);
            this.radio_StackHex.Name = "radio_StackHex";
            this.radio_StackHex.Size = new System.Drawing.Size(57, 24);
            this.radio_StackHex.TabIndex = 14;
            this.radio_StackHex.TabStop = true;
            this.radio_StackHex.Text = "Hex";
            this.radio_StackHex.UseVisualStyleBackColor = true;
            // 
            // radio_StackDec
            // 
            this.radio_StackDec.AutoSize = true;
            this.radio_StackDec.Location = new System.Drawing.Point(84, 494);
            this.radio_StackDec.Name = "radio_StackDec";
            this.radio_StackDec.Size = new System.Drawing.Size(57, 24);
            this.radio_StackDec.TabIndex = 15;
            this.radio_StackDec.Text = "Dec";
            this.radio_StackDec.UseVisualStyleBackColor = true;
            // 
            // radio_StackBin
            // 
            this.radio_StackBin.AutoSize = true;
            this.radio_StackBin.Location = new System.Drawing.Point(84, 524);
            this.radio_StackBin.Name = "radio_StackBin";
            this.radio_StackBin.Size = new System.Drawing.Size(57, 24);
            this.radio_StackBin.TabIndex = 16;
            this.radio_StackBin.Text = "Bin";
            this.radio_StackBin.UseVisualStyleBackColor = true;
            // 
            // panel_memory
            // 
            this.panel_memory.Controls.Add(this.lbl_memory0x);
            this.panel_memory.Controls.Add(this.txt_MemorySearch);
            this.panel_memory.Controls.Add(this.radio_MemoryAscii);
            this.panel_memory.Controls.Add(this.lbl_memory);
            this.panel_memory.Controls.Add(this.txt_memory);
            this.panel_memory.Controls.Add(this.txt_MemoryResult);
            this.panel_memory.Controls.Add(this.btn_MemorySearch);
            this.panel_memory.Controls.Add(this.radio_MemoryHex);
            this.panel_memory.Controls.Add(this.radio_MemoryDec);
            this.panel_memory.Controls.Add(this.radio_MemoryBin);
            this.panel_memory.Location = new System.Drawing.Point(12, 12);
            this.panel_memory.Name = "panel_memory";
            this.panel_memory.Size = new System.Drawing.Size(213, 555);
            this.panel_memory.TabIndex = 17;
            // 
            // txt_MemorySearch
            // 
            this.txt_MemorySearch.Location = new System.Drawing.Point(36, 462);
            this.txt_MemorySearch.Name = "txt_MemorySearch";
            this.txt_MemorySearch.Size = new System.Drawing.Size(86, 27);
            this.txt_MemorySearch.TabIndex = 10;
            // 
            // radio_MemoryAscii
            // 
            this.radio_MemoryAscii.AutoSize = true;
            this.radio_MemoryAscii.Location = new System.Drawing.Point(3, 524);
            this.radio_MemoryAscii.Name = "radio_MemoryAscii";
            this.radio_MemoryAscii.Size = new System.Drawing.Size(75, 24);
            this.radio_MemoryAscii.TabIndex = 9;
            this.radio_MemoryAscii.TabStop = true;
            this.radio_MemoryAscii.Text = "ASCII";
            this.radio_MemoryAscii.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_stack0x);
            this.panel1.Controls.Add(this.txt_StackSearch);
            this.panel1.Controls.Add(this.radio_StackAscii);
            this.panel1.Controls.Add(this.lbl_stack);
            this.panel1.Controls.Add(this.txt_stack);
            this.panel1.Controls.Add(this.radio_StackBin);
            this.panel1.Controls.Add(this.txt_StackResult);
            this.panel1.Controls.Add(this.radio_StackDec);
            this.panel1.Controls.Add(this.radio_StackHex);
            this.panel1.Controls.Add(this.btn_StackSearch);
            this.panel1.Location = new System.Drawing.Point(300, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 555);
            this.panel1.TabIndex = 18;
            // 
            // txt_StackSearch
            // 
            this.txt_StackSearch.Location = new System.Drawing.Point(36, 464);
            this.txt_StackSearch.Name = "txt_StackSearch";
            this.txt_StackSearch.Size = new System.Drawing.Size(86, 27);
            this.txt_StackSearch.TabIndex = 11;
            // 
            // radio_StackAscii
            // 
            this.radio_StackAscii.AutoSize = true;
            this.radio_StackAscii.Location = new System.Drawing.Point(3, 524);
            this.radio_StackAscii.Name = "radio_StackAscii";
            this.radio_StackAscii.Size = new System.Drawing.Size(75, 24);
            this.radio_StackAscii.TabIndex = 10;
            this.radio_StackAscii.TabStop = true;
            this.radio_StackAscii.Text = "ASCII";
            this.radio_StackAscii.UseVisualStyleBackColor = true;
            // 
            // lbl_memory0x
            // 
            this.lbl_memory0x.AutoSize = true;
            this.lbl_memory0x.Location = new System.Drawing.Point(3, 467);
            this.lbl_memory0x.Name = "lbl_memory0x";
            this.lbl_memory0x.Size = new System.Drawing.Size(27, 20);
            this.lbl_memory0x.TabIndex = 11;
            this.lbl_memory0x.Text = "0x";
            // 
            // lbl_stack0x
            // 
            this.lbl_stack0x.AutoSize = true;
            this.lbl_stack0x.Location = new System.Drawing.Point(3, 467);
            this.lbl_stack0x.Name = "lbl_stack0x";
            this.lbl_stack0x.Size = new System.Drawing.Size(27, 20);
            this.lbl_stack0x.TabIndex = 12;
            this.lbl_stack0x.Text = "0x";
            // 
            // ViewMemoryFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 583);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_memory);
            this.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ViewMemoryFrom";
            this.Text = "View Memory";
            this.panel_memory.ResumeLayout(false);
            this.panel_memory.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_memory;
        private System.Windows.Forms.TextBox txt_memory;
        private System.Windows.Forms.RadioButton radio_MemoryHex;
        private System.Windows.Forms.RadioButton radio_MemoryDec;
        private System.Windows.Forms.RadioButton radio_MemoryBin;
        private System.Windows.Forms.Button btn_MemorySearch;
        private System.Windows.Forms.TextBox txt_MemoryResult;
        private System.Windows.Forms.TextBox txt_stack;
        private System.Windows.Forms.Label lbl_stack;
        private System.Windows.Forms.TextBox txt_StackResult;
        private System.Windows.Forms.Button btn_StackSearch;
        private System.Windows.Forms.RadioButton radio_StackHex;
        private System.Windows.Forms.RadioButton radio_StackDec;
        private System.Windows.Forms.RadioButton radio_StackBin;
        private System.Windows.Forms.Panel panel_memory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radio_MemoryAscii;
        private System.Windows.Forms.RadioButton radio_StackAscii;
        private System.Windows.Forms.TextBox txt_MemorySearch;
        private System.Windows.Forms.TextBox txt_StackSearch;
        private System.Windows.Forms.Label lbl_memory0x;
        private System.Windows.Forms.Label lbl_stack0x;
    }
}