namespace GeometryLibrary;

// This represents a cuboid defined by two opposite corner points.
// BottomLeftBack is the corner with the smallest X, Y and Z values
// and TopRightFront is the corner with the largest. All dimensions can be calculated from just these two points.
public class Cuboid : Shape
{
    public PointIn3d BottomLeftBack;
    public PointIn3d TopRightFront;

    // This constructor creates a cuboid with a random position and random dimensions.
    // Adding 1 to each dimension ensures the cuboid is never flat.
    public Cuboid()
    {
        Random rng = new Random();
        BottomLeftBack = new PointIn3d(
            rng.NextDouble() * 10,
            rng.NextDouble() * 10,
            rng.NextDouble() * 10
        );
        TopRightFront = new PointIn3d(
            BottomLeftBack.X + rng.NextDouble() * 10 + 1,
            BottomLeftBack.Y + rng.NextDouble() * 10 + 1,
            BottomLeftBack.Z + rng.NextDouble() * 10 + 1
        );
    }

    // This constructor creates a cuboid by copying all values from another cuboid.
    public Cuboid(Cuboid other)
    {
        this.BottomLeftBack = other.BottomLeftBack;
        this.TopRightFront = other.TopRightFront;
    }

    // This constructor creates a cuboid with specific corner points.
    public Cuboid(PointIn3d bottomLeft, PointIn3d topFront)
    {
        BottomLeftBack = bottomLeft;
        TopRightFront = topFront;
    }

    // These calculate the dimensions from the difference between the two corner points.
    public double Height() => TopRightFront.Y - BottomLeftBack.Y;
    public double Width() => TopRightFront.X - BottomLeftBack.X;
    public double Length() => TopRightFront.Z - BottomLeftBack.Z;

    // Total surface area is the sum of all 6 faces which are 3 pairs of rectangles.
    public override double SurfaceArea() =>
        2 * (Width() * Height() + Width() * Length() + Height() * Length());

    // Volume is width multiplied by height multiplied by length.
    public double Volume() => Width() * Height() * Length();

    // The centroid is the center point of the cuboid calculated as the midpoint between the two opposite corners.
    public PointIn3d Centroid() => new PointIn3d(
        (BottomLeftBack.X + TopRightFront.X) / 2,
        (BottomLeftBack.Y + TopRightFront.Y) / 2,
        (BottomLeftBack.Z + TopRightFront.Z) / 2
    );

    // Two cuboids are equal if their two defining corner points are identical.
    // The null checks come first to avoid crashes.
    public static bool operator ==(Cuboid a, Cuboid b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;
        return a.BottomLeftBack.X == b.BottomLeftBack.X &&
               a.BottomLeftBack.Y == b.BottomLeftBack.Y &&
               a.BottomLeftBack.Z == b.BottomLeftBack.Z &&
               a.TopRightFront.X == b.TopRightFront.X &&
               a.TopRightFront.Y == b.TopRightFront.Y &&
               a.TopRightFront.Z == b.TopRightFront.Z;
    }

    // Not equal is just the opposite of equal.
    public static bool operator !=(Cuboid a, Cuboid b) => !(a == b);

    // This is used internally by C# in collections like List.
    // It checks if the other object is a Cuboid first and then uses == to compare.
    public override bool Equals(object? obj)
    {
        if (obj is Cuboid other) return this == other;
        return false;
    }

    // This returns a readable summary of the cuboid and is called automatically by Console.WriteLine.
    public override string ToString() =>
        $"Cuboid | Width: {Width():F2} | Height: {Height():F2} | Length: {Length():F2} | " +
        $"Surface Area: {SurfaceArea():F2} | Volume: {Volume():F2}";
}