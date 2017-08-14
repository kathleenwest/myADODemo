using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myADODemo
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Form1 form = null;          // This form needs to be accessible to all code blocks
            bool formProblem = false;       

            try
            {
                //=====================================================
                // Most problems occur when a form is initialized,
                // loaded, and databased connections are made when
                // the object is instatiated. The Form1 class has
                // code to throw an exception and exit gracefully
                // without the form object disposal reference problems
                //======================================================
                form = new Form1();

                //======================================================
                // If you get here, your form loaded and connections OK.
                // Hint: System.Environment.Exit(0); to exit the form
                // and application under normal circumstances or
                // throw a new exception (or re-throw) to exit with a
                // user message explaning why the form is closing
                //======================================================
                Application.Run(form);
            }

            catch (Exception ex)
            {
                //=======================================================
                // General Exception Handling of Any Problems
                // Say What Went Wrong To User
                // Have Child Forms Throw New Exception With Explanation
                // All Exceptions Will End Up Here Last
                // Make your inner exceptions throw specific messages (ex)
                //=======================================================
                formProblem = true;
                string message = "The Form Had an Error: " + ex.Message;
                string caption = "Something Went Wrong";
                              
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);
            }

            finally
            {
                //======================================================
                // How the Application Closes Gracefully
                // The form can properly close itself from the Main 
                // caller only because there are no longer any orphaned
                // object references (when the form closes itself there
                // is an orphan reference from the main caller and
                // event handlers that were subscribed when the form
                // loaded itself).
                //======================================================
                
                if (formProblem)
                {
                    if (!(form == null))
                    {
                        form.Close();
                    }
                    Application.Exit();
                }              
            }
        } // end Main
    }
}
