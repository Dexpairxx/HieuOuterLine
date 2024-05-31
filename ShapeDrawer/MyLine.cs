using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    internal class MyLine : Shape
    {
        private int _length;

        public MyLine(Color color) : base(color)
        {

        }

        public MyLine() : this(Color.Red) 
        {
            _length = 100;
        }
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.DrawLine(color, X, Y, X + Length, Y);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, 4);
            SplashKit.DrawCircle(Color.Black, X + Length, Y, 4);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, X + Length, Y));
        }
    }
}
