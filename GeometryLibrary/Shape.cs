namespace GeometryLibrary;

// This is the base class for all shapes. Every shape inherits from here and must implement its own SurfaceArea method.
// It also implements IComparable so shapes can be sorted by surface area.
public abstract class Shape : IComparable<Shape>
{
    // Every shape must provide its own surface area calculation.
    // It is abstract because the child class is the one that implements it.
    public abstract double SurfaceArea();

    // This defines how two shapes are compared to each other.
    // It is used by Sort() and compares shapes by surface area.
    public int CompareTo(Shape? other)
    {
        if (other == null) return 0;
        return this.SurfaceArea().CompareTo(other.SurfaceArea());
    }

    // This overloads the + operator so you can write shape1 + shape2.
    // It creates a new CompositeShape and adds both shapes to it.
    public static CompositeShape operator +(Shape s1, Shape s2)
    {
        CompositeShape cs = new CompositeShape();
        cs.Add(s1);
        cs.Add(s2);
        return cs;
    }
}