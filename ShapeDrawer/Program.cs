using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    switch (kindToAdd)
                    {
                        case ShapeKind.Line:
                        newShape = new MyLine();
                        newShape.X = SplashKit.MouseX();
                        newShape.Y = SplashKit.MouseY();
                        break;

                        case ShapeKind.Circle:
                        newShape = new MyCircle();
                        newShape.X = SplashKit.MouseX();
                        newShape.Y = SplashKit.MouseY();
                        break;

                        default:
                        newShape = new MyRectangle();
                        newShape.X = SplashKit.MouseX();
                        newShape.Y = SplashKit.MouseY();
                        break;
                    }
                    myDrawing.AddShape(newShape);

                }
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    Point2D mousePosition = SplashKit.MousePosition();
                    myDrawing.SelectShapesAt(mousePosition);
                }

                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) || SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    foreach (Shape shape in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(shape);
                    }
                }

                myDrawing.Draw();

                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}
