using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotkeys;

namespace HotkeyWin
{
    public partial class Form1 : Form
    {
        Perfect_Button_Clicker.Program p = new Perfect_Button_Clicker.Program();

        private Hotkeys.GlobalHotkey ghk;

        public Form1()
        {
            InitializeComponent();
            ghk = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F7, this);
        }

        private void HandleHotkey()
        {
            if(Perfect_Button_Clicker.Program.activate)
            {
                p.Start(int.Parse(textBox2.Text));
                Perfect_Button_Clicker.Program.activate = false;
            } else
            {
                p.Stop();
                Perfect_Button_Clicker.Program.activate = true;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkeys.Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WriteLine("Trying to register F7");
            if (ghk.Register())
                WriteLine("Hotkey registered.");
            else
                WriteLine("Hotkey failed to register");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ghk.Unregiser())
                MessageBox.Show("Hotkey failed to unregister!");
        }

        private void WriteLine(string text)
        {
            textBox1.Text += text + Environment.NewLine;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Perfect_Button_Clicker.Program.focusButton();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Perfect_Button_Clicker.Program.focusFishing();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Perfect_Button_Clicker.Program.focusWhack();
        }
    }
}
