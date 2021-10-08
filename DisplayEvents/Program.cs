using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

// ↓↓ Added as a refrences ↓↓
using System.Management;
using System.Windows.Forms;

// Added system.drawing refrence (don't need using)
namespace DisplayEvents
{
    class Program
    {
        //! add using System refrences
        //! Start with Handle and raise evenets!
        /* Todo:
         * Add screen event listener;
         * Add closing event remove listener; Use FormClosing event https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.formclosing?redirectedfrom=MSDN&view=net-5.0
         * Might need delegates https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
         * EventHandler Delegat: https://docs.microsoft.com/en-us/dotnet/api/system.eventhandler?view=net-5.0
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
        static void getMonitors(string[] args)
        {
            // GET ALL MONITORS
            List<string> monitors = new List<string>();
            foreach(var screen in Screen.AllScreens)
            {
                monitors.Add("Device Name: " + screen.DeviceName);
                monitors.Add("Bounds: " +
                    screen.ToString());
                monitors.Add("Type: " +
                    screen.GetType().ToString());

                monitors.Add("Primary Screen: " +
                    screen.Primary.ToString());
                monitors.Add("hash: " + screen.GetHashCode().ToString());
                //!! Hash can be used as ID! As long as settings doesn't change, ie: Bounds, working area, location etc.
                monitors.Add("B: " + screen.Bounds.ToString());
                monitors.Add("W: " + screen.WorkingArea.ToString());
                monitors.Add("");

                monitors.Add("");

                /* TODo
                 * System Tray Icon with Config Terminal. choose which files to start
                 * Screen connect event
                 * Screen power on/off/standby-events https://stackoverflow.com/questions/2208595/c-sharp-how-to-get-the-events-when-the-screen-display-goes-to-power-off-or-on
                 * 
                 * 
                 */

            }
            foreach(string monitor in monitors)
            {
                Console.WriteLine(monitor);
            }
            Console.WriteLine("\n\r\n\r\n\r");

            // GET PRIMARY MONITOR AND ID
            RegistryKey Display = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\DISPLAY");
            Console.WriteLine(Display);
            Console.WriteLine("\n\r\n\r\n\r");

            SelectQuery Sq = new SelectQuery("Win32_DesktopMonitor");
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
            StringBuilder sb = new StringBuilder();

            foreach(ManagementObject mo in osDetailsCollection)
            {
                Console.WriteLine(string.Format("PNPDeviceID: {0}", (string)mo["PNPDeviceID"]));
            }



            Console.ReadKey();
        }
    }

    //(alt +281 = ↓) 
}
