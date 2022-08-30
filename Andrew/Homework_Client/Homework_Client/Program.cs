using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_Andrew
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Client());
            // Application.Run(new MultiFormContext(new Form_Client(), new Form_Server()));
        }
    }
}

/*
public class MultiFormContext : ApplicationContext
{
    private int openForms;
    public MultiFormContext(params Form[] forms)
    {
        openForms = forms.Length;

        foreach (var form in forms)
        {
            form.FormClosed += (s, args) =>
            {
                //When we have closed the last of the "starting" forms, 
                //end the program.
                if (Interlocked.Decrement(ref openForms) == 0)
                    ExitThread();
            };

            form.Show();
        }
    }
}

*/