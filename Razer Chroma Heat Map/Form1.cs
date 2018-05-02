using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using ColoreColor = Corale.Colore.Core.Color;
using KeyboardCustom = Corale.Colore.Razer.Keyboard.Effects.Custom;
using KeypadCustom = Corale.Colore.Razer.Keypad.Effects.Custom;
using MouseCustom = Corale.Colore.Razer.Mouse.Effects.CustomGrid;
using MousePadCustom = Corale.Colore.Razer.Mousepad.Effects.Custom;


namespace Razer_Chroma_Heat_Map
{
    public partial class Form1 : Form
    {
        public static KeyboardCustom keyboardGrid = KeyboardCustom.Create();
        public static KeypadCustom keypadGrid = KeypadCustom.Create();
        public static MouseCustom mouseGrid = MouseCustom.Create();
        public static MousePadCustom mousepadGrid = MousePadCustom.Create();

        private static System.Timers.Timer aTimer;
        private static System.Timers.Timer bTimer;
        private static System.Timers.Timer cTimer;

        private static ConcurrentDictionary<string, int> keyPressesCon = new ConcurrentDictionary<string, int>(16, 255);

        int buildRate = 10; int decayRate = 1; int maxValue = 10000; int NUM_COLORS = 2; int idx1 = 0; int idx2 = 0;

        double[,] curColor = new double[2, 3] { { 0, 0, 0 }, { 1, 1, 1 } };

        bool ledOFFCold = true; bool scaleBrightness = true;

        int nyanCatColCount = 0;

        GlobalKeyboardHook gHook;

        public Form1()
        {
            InitializeComponent();

            Chroma.Instance.Keyboard.Clear();
            Chroma.Instance.Keypad.Clear();

            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
            gHook.hook();

            foreach (Key key in Enum.GetValues(typeof(Key)))
                if (key.ToString() != Key.Invalid.ToString())
                    keyPressesCon.TryAdd(key.ToString(), 0);

            colorChoiceListBox.SelectedIndex = 0;
            timerTypeListBox.SelectedIndex = 0;

            double timerResolution1 = 100;
            aTimer = new System.Timers.Timer(timerResolution1);
            aTimer.Elapsed += heatMapTimer;
            aTimer.AutoReset = true;
            aTimer.Enabled = false;

            double timerResolution2 = 200;
            bTimer = new System.Timers.Timer(timerResolution2);
            bTimer.Elapsed += rainbowStarlightTimer;
            bTimer.AutoReset = true;
            bTimer.Enabled = false;

            double timerResolution3 = 300;
            cTimer = new System.Timers.Timer(timerResolution3);
            cTimer.Elapsed += nyanCatTimer;
            cTimer.AutoReset = true;
            cTimer.Enabled = false;

        }

        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            string keyCode = "";


            if (Enum.IsDefined(typeof(Key), e.KeyCode.ToString()))
                keyCode = e.KeyCode.ToString();
            else if (e.KeyCode.ToString() == "Oem1")
                keyCode = "OemSemicolon";
            else if (e.KeyCode.ToString() == "Oemtilde")
                keyCode = "OemTilde";
            else if (e.KeyCode.ToString() == "Oemplus")
                keyCode = "OemEquals";
            else if (e.KeyCode.ToString() == "Back")
                keyCode = "Backspace";
            else if (e.KeyCode.ToString() == "OemOpenBrackets")
                keyCode = "OemLeftBracket";
            else if (e.KeyCode.ToString() == "Oem5")
                keyCode = "OemBackslash";
            else if (e.KeyCode.ToString() == "Oem6")
                keyCode = "OemRightBracket";
            else if (e.KeyCode.ToString() == "Oemcomma")
                keyCode = "OemComma";
            else if (e.KeyCode.ToString() == "OemQuestion")
                keyCode = "OemSlash";
            else if (e.KeyCode.ToString() == "Oem7")
                keyCode = "OemApostrophe";
            else if (e.KeyCode.ToString() == "Capital")
                keyCode = "CapsLock";
            else if (e.KeyCode.ToString() == "LWin")
                keyCode = "LeftWindows";
            else if (e.KeyCode.ToString() == "Return")
                keyCode = "Enter";
            else if (e.KeyCode.ToString() == "Apps")
                keyCode = "RightMenu";
            else if (e.KeyCode.ToString() == "Next")
                keyCode = "PageDown";
            else if (e.KeyCode.ToString() == "Decimal")
                keyCode = "NumDecimal";
            else if (e.KeyCode.ToString() == "NumPad0")
                keyCode = "Num0";
            else if (e.KeyCode.ToString() == "NumPad1")
                keyCode = "Num1";
            else if (e.KeyCode.ToString() == "NumPad2")
                keyCode = "Num2";
            else if (e.KeyCode.ToString() == "NumPad3")
                keyCode = "Num3";
            else if (e.KeyCode.ToString() == "NumPad4")
                keyCode = "Num4";
            else if (e.KeyCode.ToString() == "NumPad5")
                keyCode = "Num5";
            else if (e.KeyCode.ToString() == "NumPad6")
                keyCode = "Num6";
            else if (e.KeyCode.ToString() == "NumPad7")
                keyCode = "Num7";
            else if (e.KeyCode.ToString() == "NumPad8")
                keyCode = "Num8";
            else if (e.KeyCode.ToString() == "NumPad9")
                keyCode = "Num9";
            else if (e.KeyCode.ToString() == "Add")
                keyCode = "NumAdd";
            else if (e.KeyCode.ToString() == "Divide")
                keyCode = "NumDivide";
            else if (e.KeyCode.ToString() == "Multiply")
                keyCode = "NumMultiply";
            else if (e.KeyCode.ToString() == "Subtract")
                keyCode = "NumSubtract";
            else if (e.KeyCode.ToString() == "LShiftKey")
                keyCode = "LeftShift";
            else if (e.KeyCode.ToString() == "LControlKey")
                keyCode = "LeftControl";
            else if (e.KeyCode.ToString() == "LMenu")
                keyCode = "LeftAlt";
            else if (e.KeyCode.ToString() == "RShiftKey")
                keyCode = "RightShift";
            else if (e.KeyCode.ToString() == "RControlKey")
                keyCode = "RightControl";
            else if (e.KeyCode.ToString() == "RMenu")
                keyCode = "RightAlt";
            else
                keyCode = "Undefined";

            if (keyCode != "Undefined")
            {
                if (keyPressesCon.ContainsKey(keyCode))
                {
                    if ((keyPressesCon[keyCode] + buildRate) > maxValue)
                        keyPressesCon[keyCode] = maxValue;
                    else
                        keyPressesCon[keyCode] = (keyPressesCon[keyCode] + buildRate);
                }
                else
                    keyPressesCon.TryAdd(keyCode, buildRate);
            }

            // Debug.WriteLine(e.KeyValue.ToString());
            // Debug.WriteLine(Key.Escape.ToString());

        }

        public void heatMapTimer(Object source, EventArgs e)
        {
            int i = 0;
            foreach (int s in keyPressesCon.Values.ToList())
            {
                if (Enum.IsDefined(typeof(Key), keyPressesCon.Keys.ElementAt(i).ToString()) != true)
                {
                    i++;
                    continue;
                }

                Key newKey = (Key)Enum.Parse(typeof(Key), keyPressesCon.Keys.ElementAt(i), true);

                if (s > 0)
                    keyPressesCon[keyPressesCon.Keys.ElementAt(i).ToString()] = s - decayRate;
                else if ((s - decayRate) > (maxValue))
                    keyPressesCon[keyPressesCon.Keys.ElementAt(i).ToString()] = (int)(maxValue);
                else
                {
                    keyPressesCon[keyPressesCon.Keys.ElementAt(i).ToString()] = 0;
                    if (ledOFFCold)
                        keyPressesCon[keyPressesCon.Keys.ElementAt(i).ToString()] = 1;
                    else
                    {
                        keyPressesCon[keyPressesCon.Keys.ElementAt(i).ToString()] = 0;
                        keyboardGrid[newKey] = new ColoreColor(0, 0, 0);
                        
                        i++;
                        continue;
                    }
                }

                float fractBetween = 0;
                float adjValue = ((float)(s) / (float)(maxValue));

                if (adjValue <= 0)              // accounts for an input <=0
                    idx1 = idx2 = 0;
                else if (adjValue >= 1)         // accounts for an input >=1
                    idx1 = idx2 = NUM_COLORS - 1;
                else
                {
                    adjValue = adjValue * (NUM_COLORS - 1);     // Will multiply value by 3.
                    idx1 = (int)(Math.Floor(adjValue));         // Our desired color will be after this index.
                    idx2 = idx1 + 1;                            // ... and before this index (inclusive).
                    fractBetween = adjValue - (float)(idx1);    // Distance between the two indexes (0-1).
                }

                byte curRColor = (byte)(((curColor[idx2, 0] - curColor[idx1, 0]) * fractBetween + curColor[idx1, 0]) * (255));
                byte curGColor = (byte)(((curColor[idx2, 1] - curColor[idx1, 1]) * fractBetween + curColor[idx1, 1]) * (255));
                byte curBColor = (byte)(((curColor[idx2, 2] - curColor[idx1, 2]) * fractBetween + curColor[idx1, 2]) * (255));

                keyboardGrid[newKey] = new ColoreColor((byte)(curRColor), (byte)(curGColor), (byte)(curBColor));

                i++;
            }
            Chroma.Instance.Keyboard.SetCustom(keyboardGrid);
        }

        public void rainbowStarlightTimer(Object source, EventArgs e)
        {
            if (keyPressesCon.Count > 0)
            {
                Random rnd = new Random();

                // int maxValue = 500;
                int decayRate = (maxValue / 50);

                keyPressesCon[keyPressesCon.Keys.ElementAt(rnd.Next(keyPressesCon.Count)).ToString()] = (int)(maxValue);

                int i = 0;
                foreach (int s in keyPressesCon.Values.ToList())
                {
                    if (Enum.IsDefined(typeof(Key), keyPressesCon.Keys.ElementAt(i)))
                    {
                        Key newKey = (Key)Enum.Parse(typeof(Key), keyPressesCon.Keys.ElementAt(i), true);

                        if (s > 0)
                            keyPressesCon[keyPressesCon.Keys.ElementAt(i).ToString()] = s - decayRate;
                        else if ((s - decayRate) > (maxValue))
                            keyPressesCon[keyPressesCon.Keys.ElementAt(i).ToString()] = (int)(maxValue);
                        else
                        {
                            keyPressesCon[keyPressesCon.Keys.ElementAt(i).ToString()] = 0;
                            if (ledOFFCold)
                                keyPressesCon[keyPressesCon.Keys.ElementAt(i).ToString()] = 1;
                            else
                            {
                                keyPressesCon[keyPressesCon.Keys.ElementAt(i).ToString()] = 0;
                                keyboardGrid[newKey] = new ColoreColor(0, 0, 0);
                                i++;
                                continue;
                            }
                        }

                        float fractBetween = 0;
                        float adjValue = ((float)(s) / (float)(maxValue));

                        if (adjValue <= 0)              // accounts for an input <=0
                            idx1 = idx2 = 0;
                        else if (adjValue >= 1)         // accounts for an input >=1
                            idx1 = idx2 = NUM_COLORS - 1;
                        else
                        {
                            adjValue = adjValue * (NUM_COLORS - 1);     // Will multiply value by 3.
                            idx1 = (int)(Math.Floor(adjValue));         // Our desired color will be after this index.
                            idx2 = idx1 + 1;                            // ... and before this index (inclusive).
                            fractBetween = adjValue - (float)(idx1);    // Distance between the two indexes (0-1).
                        }

                        byte curRColor = (byte)(((curColor[idx2, 0] - curColor[idx1, 0]) * fractBetween + curColor[idx1, 0]) * (255));
                        byte curGColor = (byte)(((curColor[idx2, 1] - curColor[idx1, 1]) * fractBetween + curColor[idx1, 1]) * (255));
                        byte curBColor = (byte)(((curColor[idx2, 2] - curColor[idx1, 2]) * fractBetween + curColor[idx1, 2]) * (255));

                        keyboardGrid[newKey] = new ColoreColor((byte)(curRColor), (byte)(curGColor), (byte)(curBColor));
                        i++;
                    }
                }
                Chroma.Instance.Keyboard.SetCustom(keyboardGrid);
            }
        }

        public void nyanCatTimer(Object source, EventArgs e)
        {
            //"Blue-Green-Red-Yellow-White" 6x22
            //XXXXXXXXXXXXXXXXXXXXXXXX
            //X    BBGGRRYYWW        X
            //X    BBGGRRYYWW Cat    X
            //X    BBGGRRYYWW Cat    X
            //X    BBGGRRYYWW Cat    X
            //X    BBGGRRYYWW        X
            //X    BBGGRRYYWW        X    
            //XXXXXXXXXXXXXXXXXXXXXXXX

            // Chroma.Instance.Keyboard.SetAll(ColoreColor.Black);

            for (int r = 0; r < Constants.MaxRows; r++)
                for (int c = 0; c < Constants.MaxColumns; c++)
                    keyboardGrid[r, c] = ColoreColor.Black;

            if (nyanCatColCount == (Constants.MaxColumns + 11))
                nyanCatColCount = 0;

            // Layer 1 - Rainbow runner across keyboard
            for (int k = 0; k < (Constants.MaxRows); k++)
            {
                // Cat
                if (nyanCatColCount >= 0 && nyanCatColCount < Constants.MaxColumns)
                {
                    if (k > 1 && k < 5)
                        keyboardGrid[k, nyanCatColCount] = ColoreColor.White;
                }

                if (nyanCatColCount >= 1 && nyanCatColCount < (Constants.MaxColumns - 1))
                {
                    if (k > 1 && k < 5)
                        keyboardGrid[k, nyanCatColCount - 1] = ColoreColor.White;
                }

                // Rainbow
                if (nyanCatColCount >= 2 && nyanCatColCount < (Constants.MaxColumns - 2))
                    keyboardGrid[k, nyanCatColCount-2] = ColoreColor.Black;
                if (nyanCatColCount >= 3 && nyanCatColCount < (Constants.MaxColumns - 3))
                    keyboardGrid[k, nyanCatColCount-3] = ColoreColor.Black;
                if (nyanCatColCount >= 4 && nyanCatColCount < (Constants.MaxColumns - 4))
                    keyboardGrid[k, nyanCatColCount-4] = ColoreColor.Yellow;
                if (nyanCatColCount >= 5 && nyanCatColCount < (Constants.MaxColumns - 5))
                    keyboardGrid[k, nyanCatColCount-5] = ColoreColor.Yellow;
                if (nyanCatColCount >= 6 && nyanCatColCount < (Constants.MaxColumns - 6))
                    keyboardGrid[k, nyanCatColCount-6] = ColoreColor.Red;
                if (nyanCatColCount >= 7 && nyanCatColCount < (Constants.MaxColumns - 7))
                    keyboardGrid[k, nyanCatColCount-7] = ColoreColor.Red;
                if (nyanCatColCount >= 8 && nyanCatColCount < (Constants.MaxColumns - 8))
                    keyboardGrid[k, nyanCatColCount-8] = ColoreColor.Green;
                if (nyanCatColCount >= 9 && nyanCatColCount < (Constants.MaxColumns - 9))
                    keyboardGrid[k, nyanCatColCount-9] = ColoreColor.Green;
                if (nyanCatColCount >= 10 && nyanCatColCount < (Constants.MaxColumns - 10))
                    keyboardGrid[k, nyanCatColCount-10] = ColoreColor.Blue;
                if (nyanCatColCount >= 11 && nyanCatColCount < (Constants.MaxColumns - 11))
                    keyboardGrid[k, nyanCatColCount-11] = ColoreColor.Blue;
            }

            /*
            int catRow = 2;
            if (nyanCatColCount % 2 == 0)
                catRow = 2;
            else
                catRow = 3;
            */


            /*
            // Cat
            if (nyanCatColCount >= Constants.MaxColumns - 3)
            {
                keyboardGrid[catRow, nyanCatColCount + 2] = ColoreColor.White;
                keyboardGrid[catRow + 1, nyanCatColCount + 2] = ColoreColor.White;
                keyboardGrid[catRow + 2, nyanCatColCount + 2] = ColoreColor.White;

                keyboardGrid[catRow, nyanCatColCount + 3] = ColoreColor.White;
                keyboardGrid[catRow + 1, nyanCatColCount + 3] = ColoreColor.White;
                keyboardGrid[catRow + 2, nyanCatColCount + 3] = ColoreColor.White;
            }
            else
            {
                keyboardGrid[catRow, nyanCatColCount - Constants.MaxColumns + 2] = ColoreColor.White;
                keyboardGrid[catRow + 1, nyanCatColCount - Constants.MaxColumns + 2] = ColoreColor.White;
                keyboardGrid[catRow + 2, nyanCatColCount - Constants.MaxColumns + 2] = ColoreColor.White;

                keyboardGrid[catRow, nyanCatColCount - Constants.MaxColumns + 3] = ColoreColor.White;
                keyboardGrid[catRow + 1, nyanCatColCount - Constants.MaxColumns + 3] = ColoreColor.White;
                keyboardGrid[catRow + 2, nyanCatColCount - Constants.MaxColumns + 3] = ColoreColor.White;
            }
            */


            // Increment ColCount, Clear the keyboard and apply new grid
            nyanCatColCount++;
            
            Chroma.Instance.Keyboard.SetCustom(keyboardGrid);
            //Debug.WriteLine("NyanCatDone");
        }

        public void randoKeyTimer(Object source, EventArgs e)
        {
            Random rnd = new Random();

            for (int r = 0; r < Constants.MaxRows; r++)
            {
                for (int c = 0; c < Constants.MaxColumns; c++)
                {
                    if (rnd.Next(0, 1) == 0)
                        keyboardGrid[r, c] = ColoreColor.Black;
                    else
                    {
                        byte curRColor = (byte)(rnd.Next(255));
                        byte curGColor = (byte)(rnd.Next(255));
                        byte curBColor = (byte)(rnd.Next(255));

                        keyboardGrid[r, c] = new ColoreColor((byte)(curRColor), (byte)(curGColor), (byte)(curBColor));
                    }
                }
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            string colorType = colorChoiceListBox.SelectedItem.ToString();
            string timerType = timerTypeListBox.SelectedItem.ToString();
            buildRate = int.Parse(buildRateTextBox.Text.ToString());
            decayRate = int.Parse(decayRateTextBox.Text.ToString());
            maxValue = int.Parse(maxHeatValueTextBox.Text.ToString());
            ledOFFCold = bool.Parse(coldOFFCheckBox.Checked.ToString());
            scaleBrightness = bool.Parse(scaleBrightnessCheckbox.Checked.ToString());

            foreach (string s in keyPressesCon.Keys.ToList())
                keyPressesCon[s] = 0;

            Chroma.Instance.Keyboard.Clear();

            aTimer.Enabled = false;
            bTimer.Enabled = false;
            cTimer.Enabled = false;

            gHook.unhook();

            if (colorType.ToString() == "White")
            {
                NUM_COLORS = 2;
                curColor = new double[2, 3] { { 0, 0, 0 }, { 1, 1, 1 } };
            }
            else if (colorType == "Red")
            {
                NUM_COLORS = 2;
                curColor = new double[2, 3] { { 0, 0, 0 }, { 1, 0, 0 } };
            }
            else if (colorType == "Green")
            {
                NUM_COLORS = 2;
                curColor = new double[2, 3] { { 0, 0, 0 }, { 0, 1, 0 } };
            }
            else if (colorType == "Blue")
            {
                NUM_COLORS = 2;
                curColor = new double[2, 3] { { 0, 0, 0 }, { 0, 0, 1 } };
            }
            else if (colorType == "Teal")
            {
                NUM_COLORS = 2;
                curColor = new double[2, 3] { { 0, 0, 0 }, { 0, 1, 1 } };
            }
            else if (colorType == "Purple")
            {
                NUM_COLORS = 2;
                curColor = new double[2, 3] { { 0, 0, 0 }, { 1, 0, 1 } };
            }
            else if (colorType == "Yellow")
            {
                NUM_COLORS = 2;
                curColor = new double[2, 3] { { 0, 0, 0 }, { 1, 1, 0 } };
            }
            else if (colorType == "Test Color") // Color type for testing new palettes
            {
                NUM_COLORS = 5;
                //                                Blue     -     Green     -     Red      -     Yellow    -     White
                curColor = new double[5, 3] { { 0, 0, .25 }, { 0, .125, 0 }, { .5, 0, 0 }, { .75, .75, 0 }, { 1, 1, 1 } };
            }
            else if (colorType == "Blue-Green-Red")
            {
                // Multi color RGB Spectrum
                NUM_COLORS = 3;
                if (scaleBrightness)
                    curColor = new double[3, 3] { { 0, 0, .25 }, { 0, .25, 0 }, { 1, 0, 0 } }; 
                else
                    curColor = new double[3, 3] { { 0, 0, 1 }, { 0, 1, 0 }, { 1, 0, 0 } };
            }
            else if (colorType == "Blue-Green-Red-Yellow")
            {
                // Multi color RGB Spectrum
                NUM_COLORS = 4;
                if (scaleBrightness)
                    curColor = new double[4, 3] { { 0, 0, .25 }, { 0, .25, 0 }, { .5, 0, 0 }, { 1, 1, 0 } };
                else
                    curColor = new double[4, 3] { { 0, 0, 1 }, { 0, 1, 0 }, { 1, 0, 0 }, { 1, 1, 0 } };
            }
            else if (colorType == "Blue-Green-Red-Yellow-White")
            {
                // Multi color RGB Spectrum
                NUM_COLORS = 5;
                if (scaleBrightness)
                    curColor = new double[5, 3] { { 0, 0, .25 }, { 0, .25, 0 }, { .5, 0, 0 }, { .75, .75, 0 }, { 1, 1, 1 } };
                else
                    curColor = new double[5, 3] { { 0, 0, 1 }, { 0, 1, 0 }, { 1, 0, 0 }, { 1, 1, 0 }, { 1, 1, 1 } };
            }

            aTimer.Enabled = false;
            bTimer.Enabled = false;
            cTimer.Enabled = false;

            if (timerType == "Heat Map")
            {
                Debug.WriteLine("Heat Map");
                gHook.hook();
                aTimer.Enabled = true;
            }
            else if (timerType == "Starlight")
            {
                Debug.WriteLine("Starlight");
                bTimer.Enabled = true;
            }
            else if (timerType == "NyanCat")
            {
                Debug.WriteLine("NyanCat");
                NUM_COLORS = 5;
                curColor = new double[5, 3] { { 0, 0, .25 }, { 0, .25, 0 }, { .5, 0, 0 }, { .75, .75, 0 }, { 1, 1, 1 } };
                nyanCatColCount = 0;
                cTimer.Enabled = true;
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            gHook.unhook();
            this.Close();
        }

    }
}
