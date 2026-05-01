namespace GeometryLibrary;

// This represents a collection of shapes grouped together.
// It can calculate the combined surface area and volume of all shapes inside it.
public class CompositeShape
{
    // This is the internal list that holds all the shapes.
    // It uses Shape as the type so it can hold any shape like Cylinder, Cuboid or Tetrahedron.
    private List<Shape> shapes = new List<Shape>();

    // This empty constructor is needed so the + operator in Shape.cs can
    // create an empty CompositeShape and then add shapes to it.
    public CompositeShape() { }

    // This constructor creates a CompositeShape with n randomly generated shapes.
    // It randomly picks between Cylinder, Cuboid and Tetrahedron for each slot.
    public CompositeShape(int n)
    {
        Random rng = new Random();
        for (int i = 0; i < n; i++)
        {
            int pick = rng.Next(3); // Picks 0, 1 or 2 randomly
            if (pick == 0) shapes.Add(new Cylinder());
            else if (pick == 1) shapes.Add(new Cuboid());
            else shapes.Add(new Tetrahedron());
        }
    }

    // This adds a shape to the collection.
    public void Add(Shape s) => shapes.Add(s);

    // This is an indexer that allows accessing shapes by position using square brackets.
    // For example composite[0] returns the first shape.
    public Shape this[int index] => shapes[index];

    // This sorts all shapes by surface area using the CompareTo method defined in Shape.cs.
    public void Sort() => shapes.Sort();

    // This searches for a shape in the collection using Equals.
    // It returns the index if found or -1 if not found.
    // Returning -1 is a common convention in programming for not found.
    public int IsIn(Shape s)
    {
        for (int i = 0; i < shapes.Count; i++)
            if (shapes[i].Equals(s)) return i;
        return -1;
    }

    // This returns the combined surface area of all shapes in the collection.
    // Every shape has SurfaceArea so this works regardless of the shape type.
    public double SurfaceArea()
    {
        double total = 0;
        foreach (Shape s in shapes) total += s.SurfaceArea();
        return total;
    }

    // This returns the combined volume of all shapes that have a Volume method.
    // Tetrahedron is skipped because it does not have a Volume method.
    // The is keyword checks the type before calling Volume to avoid errors.
    public double Volume()
    {
        double total = 0;
        foreach (Shape s in shapes)
        {
            if (s is Cylinder c) total += c.Volume();
            else if (s is Cuboid cb) total += cb.Volume();
        }
        return total;
    }
}