using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayEvents
{
    class Program
    {
        //! Start with Handle and raise evenets!
        /* Todo:
         * Add screen event listener;
         * Add closing event remove listener; Use FormClosing event https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.formclosing?redirectedfrom=MSDN&view=net-5.0
         * Might need delegates https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
         * Event for screen on/off/standby event https://stackoverflow.com/questions/2208595/c-sharp-how-to-get-the-events-when-the-screen-display-goes-to-power-off-or-on
         * Add system tray icon and add config terminal for task start manager, which files for which monitor hash etc
         * 
         * Different Events https://www.daveoncsharp.com/2009/10/how-to-capture-system-events-using-csharp/
         * 
         * 
         * Read 'Handle and raise events' (2017): https://docs.microsoft.com/en-us/dotnet/standard/events/
         * 
         * 
         */
        static void Main(string[] args)
        {
            //FormClosingEventHandler.Combine(
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += new EventHandler(printEvent);
            Console.ReadKey();
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged -= new EventHandler(printEvent);
        }

        static void printEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Object sender: {0}", sender);
            Console.WriteLine("EventArgs e: {0}", e);
        }
        static void closingArgs()
        {

        }
    }
}
