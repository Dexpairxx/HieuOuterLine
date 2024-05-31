using ShapeDrawer;
using SplashKitSDK;


public class Drawing
{
    private readonly List<Shape> _shapes;
    private Color _background;

    public Drawing(Color background)
    {
        _shapes = new List<Shape>();
        _background = background;
    }

    public Drawing() : this(Color.White)
    {
    }
    public int ShapeCount
    {
        get { return _shapes.Count; }
    }

    public void AddShape(Shape shape)
    {
        _shapes.Add(shape);
    }

    public void RemoveShape(Shape shape)
    {
        _shapes.Remove(shape);
    }
    public Color Background
    {
        get
        {
            return _background;
        }
        set
        {
            _background = value;
        }
    }
    public void Draw()
    {
        SplashKit.ClearScreen(_background);

        foreach (Shape shape in _shapes)
        {
            shape.Draw();
        }
    }
    public void SelectShapesAt(Point2D pt)
    {
        foreach (Shape s in _shapes)
        {
            if (s.IsAt(pt))
            {
                s.Selected = true;
            }
            else
            {
                s.Selected = false;
            }
        }
    }
    public List<Shape> SelectedShapes
    {
        get
        {
            List<Shape> _selectedShapes = new List<Shape>();
            foreach (Shape s in _shapes)
            {
                if (s.Selected)
                {
                    _selectedShapes.Add(s);
                }
            }
            return _selectedShapes;
        }
    }
}