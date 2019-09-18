using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Xna.Framework.Input;
using Terraria;
using WebmilioCommons.Inputs;
using ThreadState = System.Threading.ThreadState;

namespace MatterOverdrive.Android
{
    public class AndroidConsole
    {
        public static void Open()
        {
            Process?.Kill();

            Process = new Process()
            {
                EnableRaisingEvents = true,
                StartInfo = new ProcessStartInfo("cmd")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardInput = false,
                    RedirectStandardError = true,
                    
                    UseShellExecute = false,
                    CreateNoWindow = false
                }
            };

            Process.OutputDataReceived += ConsoleOnOutputDataReceived;
            Process.Exited += ConsoleOnExited;

            //KeyboardManager.KeyPressed += KeyboardManagerOnKeyPressed;

            Process.Start();

            Main.NewText("Opened existing Android Console.");

            Thread thread = new Thread(WatchExit);
            thread.Start();
        }

        private static void KeyboardManagerOnKeyPressed(Keys key)
        {
            Process.StandardInput.Write((char) key);
            Process.StandardInput.Flush();
        }


        private static void GetInput()
        {
            while ((Process?.HasExited ?? false) && Process.StandardOutput.BaseStream.CanRead)
                System.Diagnostics.Debug.WriteLine(Process.StandardOutput.Read());
        }


        private static void WatchExit()
        {
            while (!Process.HasExited)
                Thread.Sleep(1000);

            Process = null;
        }


        private static void ConsoleOnExited(object sender, EventArgs e)
        {
            Main.NewText("Closed existing Android Console.");

            //KeyboardManager.KeyPressed -= KeyboardManagerOnKeyPressed;

            Process.Exited -= ConsoleOnExited;
            Process.OutputDataReceived -= ConsoleOnOutputDataReceived;
        }

        private static void ConsoleOnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!((Process)sender).HasExited)
                Main.NewText(e.Data);
        }


        public static Process Process { get; private set; }


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        /*private const int
            SW_HIDE = 0,
            SW_SHOW = 5;


        public static void Open()
        {
            ShowConsoleWindow();

            Thread thread = new Thread(() =>
            {
                IntPtr pointer = GetConsoleWindow();

                while (pointer != IntPtr.Zero)
                {
                    pointer = GetConsoleWindow();
                    Main.NewText(Console.ReadLine());
                }
            });
        }


        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        public static void ShowConsoleWindow()
        {
            IntPtr pointer = GetConsoleWindow();

            if (pointer == IntPtr.Zero)
                AllocConsole();
            else
                ShowWindow(pointer, SW_SHOW);
        }

        public static void HideConsole()
        {
            IntPtr pointer = GetConsoleWindow();
            ShowWindow(pointer, SW_HIDE);
        }*/
    }
}