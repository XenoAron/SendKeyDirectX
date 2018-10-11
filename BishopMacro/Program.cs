using Interceptor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BishopMacro
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        static void Main(string[] args)
        {
            // 포커스 잡기
            IntPtr hWnd = FindWindow(null, "MapleStory");

            if (!hWnd.Equals(IntPtr.Zero))
                SetForegroundWindow(hWnd);
            
            Input input = new Input
            {
                KeyboardFilterMode = KeyboardFilterMode.All
            };

            input.Load();

            Thread.Sleep(3000);

            input.SendKey(Keys.D);
            input.Unload();

            Thread.Sleep(1000);
            Console.WriteLine("Ended");
        }
    }
}