using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hammerkey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private long StartTick, Hammers;
        public long Tick()
        {
            return System.DateTime.Now.Ticks / 10000;
        }

        private void Hammer_Click(object sender, EventArgs e)
        {
            if (Hammers == 0) StartTick = Tick();
            Hammers++;
            double TimePassed = (double)(Tick() - StartTick) / (double)1000;
            double HammerRate = (double)Hammers / TimePassed;
            Hammer.Text = "Hammers: " + Hammers + "\r\n" +
                          "Time: " + (Tick() - StartTick) + "\r\n" +
                          "Each secod: " + Math.Round(HammerRate, 2);
        }
    }
}