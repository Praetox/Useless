using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace sn0w
{
    class Snowflake
    {
        private int iSize;
        private double dSpeed;
        private double dAngle;
        private int iFrame;
        private int iFrameT;
        private double dX;
        private double dY;
        private Point szPic;
        private int iMaxHMov;
        public Snowflake(Point ptLoc, Point szPic, int iFrame, int iFrameCnt, int iSize, int iAngle, double dSpeed)
        {
            this.szPic = szPic;
            this.iSize = iSize;
            this.iFrame = iFrame;
            this.iFrameT = iFrameCnt;
            this.dX = (double)ptLoc.X;
            this.dY = (double)ptLoc.Y;
            this.dSpeed = (int)Math.Round(dSpeed * (1 + (((double)iSize) / 16))); ;
            this.dAngle = ((double)iAngle)*(Math.PI/((double)180));
            double dVSteps = (double)szPic.Y / (dSpeed * Math.Sin(dAngle));
            this.iMaxHMov = (int)Math.Round(dVSteps / dSpeed * Math.Cos(dAngle));
        }
        public Flakedata Next()
        {
            Flakedata ret = new Flakedata();
            
            dX += dSpeed * Math.Cos(dAngle);
            dY += dSpeed * Math.Sin(dAngle);
            if (dX > szPic.X || dY > szPic.Y)
            {
                Random r = new Random();
                dX = r.Next(-iMaxHMov, szPic.X) - iSize;
                dY = -iSize; while (dX < -iSize)
                {
                    dX += dSpeed * Math.Cos(dAngle);
                    dY += dSpeed * Math.Sin(dAngle);
                }
            }

            iFrame++;
            if (iFrame >= iFrameT)
                iFrame = 0;

            ret.pt = new Point(
                (int)Math.Round(dX),
                (int)Math.Round(dY));
            ret.sz = iSize;
            ret.fr = iFrame;
            return ret;
        }
    }
    class Flakedata
    {
        public Point pt;
        public int sz;
        public int fr;
    }
}
