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

            Compiler.test ("Tudor");

            Compiler c = new Compiler ();
            Console.WriteLine ($"sum = {c.sum(2, 3)}");
        }
    }
}
