namespace GeometryLibrary;

// This represents a tetrahedron which is a 3D shape with 4 triangular faces and 4 corner points.
public class Tetrahedron : Shape
{
    public PointIn3d A;
    public PointIn3d B;
    public PointIn3d C;
    public PointIn3d D;

    // This constructor creates a tetrahedron with 4 random points in a 10x10x10 space.
    public Tetrahedron()
    {
        Random rng = new Random();
        A = new PointIn3d(rng.NextDouble() * 10, rng.NextDouble() * 10, rng.NextDouble() * 10);
        B = new PointIn3d(rng.NextDouble() * 10, rng.NextDouble() * 10, rng.NextDouble() * 10);
        C = new PointIn3d(rng.NextDouble() * 10, rng.NextDouble() * 10, rng.NextDouble() * 10);
        D = new PointIn3d(rng.NextDouble() * 10, rng.NextDouble() * 10, rng.NextDouble() * 10);
    }

    // This constructor creates a tetrahedron by copying all points from another tetrahedron.
    public Tetrahedron(Tetrahedron other)
    {
        this.A = other.A;
        this.B = other.B;
        this.C = other.C;
        this.D = other.D;
    }

    // This constructor creates a tetrahedron with specific corner points.
    public Tetrahedron(PointIn3d a, PointIn3d b, PointIn3d c, PointIn3d d)
    {
        A = a; B = b; C = c; D = d;
    }

    // This calculates the area of a triangle defined by 3 points in 3D space.
    // First it calculates two edge vectors from p1(point1) to p2(point2) and from p1(point1) to p3(point3).
    // Then it finds the angle between them using the dot product.
    // The area is then calculated with the formula: 0.5 * length of edge1 * length of edge2 * sin(angle).
    private double TriangleArea(PointIn3d p1, PointIn3d p2, PointIn3d p3)
    {
        // Edge vectors from p1 to p2 and from p1 to p3
        double edge1X = p2.X - p1.X;
        double edge1Y = p2.Y - p1.Y;
        double edge1Z = p2.Z - p1.Z;

        double edge2X = p3.X - p1.X;
        double edge2Y = p3.Y - p1.Y;
        double edge2Z = p3.Z - p1.Z;

        // Lengths of the two edges
        double lengthAB = Math.Sqrt(edge1X * edge1X + edge1Y * edge1Y + edge1Z * edge1Z);
        double lengthAC = Math.Sqrt(edge2X * edge2X + edge2Y * edge2Y + edge2Z * edge2Z);

        // Dot product used to find the angle between the two edges
        double dot = edge1X * edge2X + edge1Y * edge2Y + edge1Z * edge2Z;

        // Angle between the two edges in radians
        // The Math.Acos(Double) method returns the angle whose cosine is the specified number
        double angle = Math.Acos(dot / (lengthAB * lengthAC));

        // Triangle area formula = 0.5 * |AB| * |AC| * sin(angle)
        return 0.5 * lengthAB * lengthAC * Math.Sin(angle);
    }

    // Total surface area is the sum of the areas of all 4 triangular faces.
    public override double SurfaceArea()
    {
        return TriangleArea(A, B, C) + TriangleArea(A, B, D)
             + TriangleArea(A, C, D) + TriangleArea(B, C, D);
    }

    // The centroid is the center point of the tetrahedron calculated as the average of all 4 corner points.
    public PointIn3d Centroid() => new PointIn3d(
        (A.X + B.X + C.X + D.X) / 4,
        (A.Y + B.Y + C.Y + D.Y) / 4,
        (A.Z + B.Z + C.Z + D.Z) / 4
    );

    // Two tetrahedrons are equal if all four corner points are identical.
    // The null checks come first to avoid crashes when accessing properties on a null object.
    public static bool operator ==(Tetrahedron a, Tetrahedron b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;
        return a.A.X == b.A.X && a.A.Y == b.A.Y && a.A.Z == b.A.Z &&
               a.B.X == b.B.X && a.B.Y == b.B.Y && a.B.Z == b.B.Z &&
               a.C.X == b.C.X && a.C.Y == b.C.Y && a.C.Z == b.C.Z &&
               a.D.X == b.D.X && a.D.Y == b.D.Y && a.D.Z == b.D.Z;
    }

    // Not equal is just the opposite of equal.
    public static bool operator !=(Tetrahedron a, Tetrahedron b) => !(a == b);

    // This is used internally by C# in collections like List.
    // It checks if the other object is a Tetrahedron first and then uses == to compare.
    public override bool Equals(object? obj)
    {
        if (obj is Tetrahedron other) return this == other;
        return false;
    }

    // This returns a readable summary of the tetrahedron and is called automatically by Console.WriteLine.
    public override string ToString() =>
        $"Tetrahedron | Surface Area: {SurfaceArea():F2} | Centroid: ({Centroid().X:F2}, {Centroid().Y:F2}, {Centroid().Z:F2})";
}