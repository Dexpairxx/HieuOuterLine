using SplashKitSDK;

namespace ShapeDrawer
{
    internal class MyCircle : Shape
    {
        private int _radius;

        public MyCircle(Color color) : base(color)
        {

        }

        public MyCircle() : this(Color.Blue)
        {
            _radius = 50;
        }
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public override void Draw() 
        {
            if (Selected) 
            {
                DrawOutline();
            }
            SplashKit.FillCircle(color, X, Y, Radius);
        }
        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, Radius + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, Radius));
        }
    }
}
