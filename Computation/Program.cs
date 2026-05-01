using GeometryLibrary;

namespace Computation;

class Program
{
    static void Main(string[] args)
    {
        // Create shapes 
        Cylinder cyl1 = new Cylinder();
        Cylinder cyl2 = new Cylinder();
        Console.WriteLine(cyl1);
        Console.WriteLine(cyl2);

        Cuboid cub1 = new Cuboid();
        Cuboid cub2 = new Cuboid();
        Console.WriteLine(cub1);
        Console.WriteLine(cub2);

        Tetrahedron tetr1 = new Tetrahedron();
        Tetrahedron tetr2 = new Tetrahedron();
        Console.WriteLine(tetr1);
        Console.WriteLine(tetr2);

        // Print centroids
        PointIn3d cubCentroid = cub1.Centroid();
        Console.WriteLine($"Cuboid1 Centroid: ({cubCentroid.X:F2}, {cubCentroid.Y:F2}, {cubCentroid.Z:F2})");

        PointIn3d tetrCentroid = tetr1.Centroid();
        Console.WriteLine($"Tetrahedron1 Centroid: ({tetrCentroid.X:F2}, {tetrCentroid.Y:F2}, {tetrCentroid.Z:F2})");

        // Combine with the + operator
        CompositeShape composite = cyl1 + cub1;
        composite.Add(cyl2);
        composite.Add(cub2);
        composite.Add(tetr1);
        composite.Add(tetr2);

        Console.WriteLine($"\nComposite Surface Area: {composite.SurfaceArea():F2}");
        Console.WriteLine($"Composite Volume: {composite.Volume():F2}");

        // Sort by surface area
        composite.Sort();

        Console.WriteLine("\nShapes sorted by surface area:");
        for (int i = 0; i < 6; i++)
            Console.WriteLine($"[{i}] {composite[i]}");

        // IsIn, [] access, and copy constructor
        int index = composite.IsIn(cub1);
        Console.WriteLine($"\ncub1 is at index: {index}");

        Shape found = composite[index];
        Console.WriteLine($"Accessed shape: {found}");

        Cuboid copiedCuboid = new Cuboid(cub1);
        Console.WriteLine($"Copy of cub1: {copiedCuboid}");
    }
}