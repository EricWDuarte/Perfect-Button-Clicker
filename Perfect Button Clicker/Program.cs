using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace Perfect_Button_Clicker
{
    class Program : Form
    {
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static bool activate = true;

        static Color colorR = Color.FromArgb(200, 100, 0);
        static Color colorB = Color.FromArgb(0, 100, 200);
        static Color colorBackground = Color.FromArgb(50, 50, 50);
        static Color colorBackgroundFish = Color.FromArgb(3, 82, 100);
        static Color colorFish = Color.FromArgb(255, 127, 0);

        static Color colorBackgroundGreg = Color.FromArgb(38, 16, 3);
        static Color colorGreg = Color.FromArgb(255, 233, 222);

        static int offsetButtonX = 340;
        static int offsetButtonY = 180;

        static int offsetCurrencyX = 450;
        static int offsetCurrencyY = 345;

        static int offsetFishX = 650;
        static int offsetFishY = 456;

        static int offsetGregX = 351;
        static int offsetGregY = 163;


        static bool button = true;
        static bool fishing = false;
        static bool whack = false;

        static int speed = 140;

        static int counter = 0;


        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HotkeyWin.Form1());
        }

        CancellationTokenSource cancelTokenSource;


        public void Start(int n)
        {
            speed = n;
            cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;



            if (button == true)
            {
                Task task1 = new Task(async () => await BehaviourButtonMasher(token));
                task1.Start();
            }
            else if (fishing == true)
            {
                Task task2 = new Task(async () => await BehaviourFishing(token));
                task2.Start();
            } else if (whack == true)
            {
                Task task3 = new Task(async () => await BehaviourWhack(token));
                task3.Start();

            }

        }

        public void Stop()
        {
            cancelTokenSource.Cancel();
        }

        static async Task BehaviourButtonMasher(CancellationToken token)
        {
            while (true)
            {
                await Task.Delay(speed);
                if(token.IsCancellationRequested)
                {
                    return;
                }

                counter++;

                Bitmap buttonImg = new Bitmap(540, 150);
                Bitmap purpleButtonCurrencyImg = new Bitmap(15, 20);

                Graphics graphicsButton = Graphics.FromImage(buttonImg as Image);
                Graphics graphicsCurrency = Graphics.FromImage(purpleButtonCurrencyImg as Image);

                graphicsButton.CopyFromScreen(offsetButtonX, offsetButtonY, 0, 0, buttonImg.Size);
                graphicsCurrency.CopyFromScreen(offsetCurrencyX, offsetCurrencyY, 0, 0, purpleButtonCurrencyImg.Size);

                Point buttonCenter;

                if(getButtonCenter(buttonImg, out buttonCenter)) {
                    if (counter % 15 == 0)
                    {
                        counter = 0;
                        Click(buttonCenter.X + 4, buttonCenter.Y + 4);
                    }
                    else
                    {
                        Click(buttonCenter);
                    }
                } 
                else
                {
                    Click(420, 470);
                }

                if(buttonImg.GetPixel(buttonCenter.X - offsetButtonX, buttonCenter.Y - offsetButtonY) == colorR && canBuyBuff(purpleButtonCurrencyImg))
                {
                    BuyBuff();
                }
            }
        }

        public static bool getButtonCenter(Bitmap buttonImg, out Point center)
        {
            int X = 0;
            int Y = 0;

            int XStart = 0;
            int XEnd = 0;
            int YStart = 0;
            int YEnd = 0;

            bool found = false;
            for (int i = 0; i < buttonImg.Height; i++)
            {
                for (int j = 0; j < buttonImg.Width; j++)
                {
                    Color pixel = buttonImg.GetPixel(j, i);

                    if (pixel == colorR || pixel == colorB)
                    {
                        YStart = i;

                        found = true;
                        break;
                    }
                }
                if (found)
                    break;
            }

            found = false;
            for (int i = buttonImg.Height - 1; i >= 0; i--)
            {
                for (int j = buttonImg.Width - 1; j >= 0; j--)
                {
                    Color pixel = buttonImg.GetPixel(j, i);

                    if (pixel == colorR || pixel == colorB)
                    {
                        YEnd = i;
                        found = true;
                        break;
                    }
                }
                if (found)
                    break;
            }

            Y = (YStart + YEnd) / 2;

            for (int j = 0; j < buttonImg.Width; j++)
            {
                Color pixel = buttonImg.GetPixel(j, Y + 20);

                if (pixel == colorR || pixel == colorB)
                {
                    XStart = j;
                    break;
                }
            }

            for (int j = buttonImg.Width - 1; j >= 0; j--)
            {
                Color pixel = buttonImg.GetPixel(j, Y + 20);

                if (pixel == colorR || pixel == colorB)
                {
                    XEnd = j;
                    break;
                }
            }

            X = (XStart + XEnd) / 2;

            center = new Point(X + offsetButtonX + 1, Y + offsetButtonY + 1);
            return found;
        }

        public static bool canBuyBuff(Bitmap purpleButtonCurrencyImg)
        {
            for (int i = 0; i < purpleButtonCurrencyImg.Height; i++)
            {
                for (int j = 0; j < purpleButtonCurrencyImg.Width; j++)
                {
                    Color pixel = purpleButtonCurrencyImg.GetPixel(j, i);

                    if (pixel != colorBackground)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // <-- Sistema de pesca automatica - Não implementado -->

        static async Task BehaviourWhack(CancellationToken token)
        {
            int counter = 14;

            while (true)
            {
                await Task.Delay(speed);
                if (token.IsCancellationRequested)
                {
                    return;
                }

                Bitmap gregImg = new Bitmap(521, 261);
                Graphics gregGraphics = Graphics.FromImage(gregImg as Image);
                gregGraphics.CopyFromScreen(offsetGregX, offsetGregY, 0, 0, gregImg.Size);
                //gregImg.Save(@"c:\img.tiff", ImageFormat.Tiff);

                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        //await Task.Delay(100);
                        Color c = gregImg.GetPixel((i * Convert.ToInt32(Math.Round(43.333))) + 17, (j * Convert.ToInt32(Math.Round(43.333))) + 27);

                        if (!IsSimilarColorTo(c, colorBackgroundGreg, 120))
                        {
                            if (!IsSimilarColorTo(c, colorGreg, 20))
                            {
                                if (counter == 0)
                                {
                                    counter = 14;
                                }

                                counter--;

                                if (counter == 0)
                                    await Task.Delay(500);

                                Click((i * Convert.ToInt32(Math.Round(43.333))) + 17 + offsetGregX, (j * Convert.ToInt32(Math.Round(43.333))) + 27 + offsetGregY);
                            }
                        }
                    }
                }
            }
        }

        static async Task BehaviourFishing(CancellationToken token)
        {
            while (true)
            {
                await Task.Delay(speed);
                if (token.IsCancellationRequested)
                {
                    return;
                }

                int start = 0, end = 0, center = 0;
                int fishStart = 0, fishEnd = 0, fishCenter = 0;

                Bitmap fishImg = new Bitmap(210, 22);
                Graphics fishGraphics = Graphics.FromImage(fishImg as Image);
                fishGraphics.CopyFromScreen(offsetFishX, offsetFishY, 0, 0, fishImg.Size);
                //fishImg.Save(@"c:\img.tiff", ImageFormat.Tiff);

                for (int i = 0; i < fishImg.Width; i++)
                {
                    Color c = fishImg.GetPixel(i, 7);
                    if (!IsSimilarColorTo(c, colorBackgroundFish, 30))
                    {
                        start = i;
                    }
                }

                for (int i = fishImg.Width - 1; i >= 0; i--)
                {
                    Color c = fishImg.GetPixel(i, 7);
                    if (!IsSimilarColorTo(c, colorBackgroundFish, 30))
                    {
                        end = i;
                    }
                }

                center = (start + end) / 2;

                for (int i = 0; i < fishImg.Width; i++)
                {
                    Color c = fishImg.GetPixel(i, fishImg.Height - 1);
                    if (IsSimilarColorTo(c, colorFish, 5))
                    {
                        fishStart = i;
                    }
                }

                for (int i = fishImg.Width - 1; i >= 0; i--)
                {
                    Color c = fishImg.GetPixel(i, fishImg.Height - 1);
                    if (IsSimilarColorTo(c, colorFish, 5))
                    {
                        fishEnd = i;
                    }
                }

                fishCenter = (fishStart + fishEnd) / 2;

                if (center == fishCenter)
                {
                    Console.WriteLine("Presses ENTER");
                    SendKeys.SendWait("{ENTER}");
                }
            }
        }


        public static async void BuyBuff()
        {
            Point shop = new Point(750, 475);
            Point buff = new Point(800, 225);

            Click(shop);
            await Task.Delay(120);
            Click(buff);
            Click(shop);
        }

        public static void focusButton()
        {
            button = true;
            fishing = false;
            whack = false;
        }

        public static void focusFishing()
        {
            button = false;
            fishing = true;
            whack = false;
        }

        public static void focusWhack()
        {
            button = false;
            fishing = false;
            whack = true;
        }

        public static bool IsSimilarColorTo(Color a, Color b)
        {
            if(Math.Abs(a.R - b.R) < 10)
            {
                if (Math.Abs(a.G - b.G) < 10)
                {
                    if (Math.Abs(a.B - b.B) < 10)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsSimilarColorTo(Color a, Color b, int similarity)
        {
            if (Math.Abs(a.R - b.R) < similarity)
            {
                if (Math.Abs(a.G - b.G) < similarity)
                {
                    if (Math.Abs(a.B - b.B) < similarity)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static void Click(Point p)
        {
            SetCursorPos(p.X, p.Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, p.X, p.Y, 0, 0);
        }

        public static void Click(int X, int Y)
        {
            SetCursorPos(X, Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

    }
}
