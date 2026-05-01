namespace GeometryLibrary;

// This represents a cylinder defined by a radius and two center points,
// one for the bottom circle and one for the top circle.
public class Cylinder : Shape
{
    public double Radius;
    public PointIn3d TopCenter;    // Center point of the top circle
    public PointIn3d BottomCenter; // Center point of the bottom circle

    // This constructor creates a cylinder with a random radius and height.
    // The bottom is fixed at the origin and the top is placed above it on the Y axis.
    public Cylinder()
    {
        Random rng = new Random();
        Radius = rng.NextDouble() * 9.5 + 0.5; // Random radius between 0.5 and 10
        BottomCenter = new PointIn3d(0, 0, 0);
        TopCenter = new PointIn3d(0, rng.NextDouble() * 19 + 1, 0); // Random height between 1 and 20
    }

    // This constructor creates a cylinder by copying all values from another cylinder.
    public Cylinder(Cylinder other)
    {
        this.Radius = other.Radius;
        this.TopCenter = other.TopCenter;
        this.BottomCenter = other.BottomCenter;
    }

    // This constructor creates a cylinder with specific values.
    public Cylinder(double radius, PointIn3d bottom, PointIn3d top)
    {
        Radius = radius;
        BottomCenter = bottom;
        TopCenter = top;
    }

    // The height is the distance between the bottom and top center points.
    public double Height() => PointIn3d.Distance(BottomCenter, TopCenter);

    // This is the area of one circular face.
    public double BottomArea() => Math.PI * Radius * Radius;

    // Total surface area is 2 circles (top and bottom) plus the curved side.
    public override double SurfaceArea() => 2 * BottomArea() + 2 * Math.PI * Radius * Height();

    // Volume is the area of the base circle multiplied by the height.
    public double Volume() => BottomArea() * Height();

    // Two cylinders are equal if they have the same radius and the same top and bottom center positions.
    // The null checks come first to avoid crashes.
    public static bool operator ==(Cylinder a, Cylinder b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;
        return a.Radius == b.Radius &&
               a.TopCenter.X == b.TopCenter.X &&
               a.TopCenter.Y == b.TopCenter.Y &&
               a.TopCenter.Z == b.TopCenter.Z &&
               a.BottomCenter.X == b.BottomCenter.X &&
               a.BottomCenter.Y == b.BottomCenter.Y &&
               a.BottomCenter.Z == b.BottomCenter.Z;
    }

    // Not equal is just the opposite of equal.
    public static bool operator !=(Cylinder a, Cylinder b) => !(a == b);

    // This is used internally by C# in collections like List.
    // It checks if the other object is a Cylinder first and then uses == to compare.
    public override bool Equals(object? obj)
    {
        if (obj is Cylinder other) return this == other;
        return false;
    }

    // This returns a readable summary of the cylinder and is called automatically by Console.WriteLine.
    public override string ToString() =>
        $"Cylinder | Radius: {Radius:F2} | Height: {Height():F2} | " +
        $"Surface Area: {SurfaceArea():F2} | Volume: {Volume():F2}";
}