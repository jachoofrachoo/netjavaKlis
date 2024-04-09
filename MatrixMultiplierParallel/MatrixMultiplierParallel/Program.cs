using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixMultiplierParallel
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MatrixMultiplierForm());
        }
    }
}
