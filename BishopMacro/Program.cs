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
            Process[] list = Process.GetProcesses();
            foreach (Process item in list)
            {
                // MapleStory : 24416
                Console.WriteLine(item.ProcessName + ": " + item.Id + Environment.NewLine);
                //SendKeys.Send("{LEFT}");
            }

            IntPtr hWnd = FindWindow(null, "League of Legends (TM) Client");

            if (!hWnd.Equals(IntPtr.Zero))
                SetForegroundWindow(hWnd);
            
            Input input = new Input
            {
                KeyboardFilterMode = KeyboardFilterMode.All
            };

            input.Load();
            Thread.Sleep(10000);
            input.SendKey(Keys.D);
            /*
            Thread.Sleep(10000);

            int speed = 300;
            input.SendKey(Keys.Q);
            Thread.Sleep(400);
            input.SendMouseEvent(MouseState.RightDown);
            input.SendMouseEvent(MouseState.RightUp);
            Thread.Sleep(speed);
            input.SendKey(Keys.E);
            Thread.Sleep(400);
            input.SendMouseEvent(MouseState.RightDown);
            input.SendMouseEvent(MouseState.RightUp);
            Thread.Sleep(speed);
            input.SendKey(Keys.R);
            Thread.Sleep(600);
            input.SendKey(Keys.Q);
            Thread.Sleep(speed);
            input.SendMouseEvent(MouseState.RightDown);
            input.SendMouseEvent(MouseState.RightUp);
            Thread.Sleep(speed);
            input.SendKey(Keys.E);
            */
            //input.SendKey(Keys.D);
            //input.SendKey(Keys.F);
            //input.SendText("Hello");
            input.Unload();

            Thread.Sleep(1000);
            Console.WriteLine("Ended");
        }
    }
}