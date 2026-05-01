namespace GeometryLibrary;

// This represents a point in 3D space with X, Y and Z coordinates.
// It is a struct instead of a class because it is just simple data with no inheritance needed.
public struct PointIn3d
{
    public double X;
    public double Y;
    public double Z;

    // This constructor creates a point at the given coordinates.
    public PointIn3d(double x, double y, double z)
    {
        X = x; Y = y; Z = z;
    }

    // This calculates the straight line distance between two points in 3D space.
    // It uses the 3D version of the Pythagorean theorem.
    public static double Distance(PointIn3d a, PointIn3d b)
    {
        return Math.Sqrt(
            Math.Pow(b.X - a.X, 2) +
            Math.Pow(b.Y - a.Y, 2) +
            Math.Pow(b.Z - a.Z, 2)
        );
    }
}