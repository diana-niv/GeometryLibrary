# GeometryLibrary

A C# geometry library and console application. The library defines 3D geometric shapes with surface area, volume, and centroid calculations, and supports combining, sorting, and searching for shapes.

## About The Project

This project consists of two parts:

- **GeometryLibrary:** a class library containing an abstract `Shape` base class and three concrete shapes: `Cylinder`, `Cuboid`, and `Tetrahedron`. It also includes a `CompositeShape` class for grouping shapes together and a `PointIn3d` struct for representing points in 3D space.
- **Computation:** a console application that demonstrates the library by creating shapes, combining them with the `+` operator, sorting by surface area, searching with `IsIn()`, and copying with copy constructors.

Built with:
- C# (.NET 10)

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- VS Code (or any C# compatible editor)

### Installation

1. Clone or download the repository.
2. Open the `Assignment2` folder in VS Code.
3. Make sure the .NET 10 SDK is installed by running:

```bash
dotnet --version
```

### Usage

Navigate to the `Computation` project folder and run:

```bash
cd Computation
dotnet run
```

The console will print information about each created shape including surface area, volume, and centroid where applicable.

## Roadmap

Implemented:
- Abstract `Shape` base class with `IComparable<Shape>` and `+` operator overload
- `PointIn3d` struct with 3D distance calculation
- `Cylinder` with surface area, volume, and centroid
- `Cuboid` with surface area, volume, and centroid
- `Tetrahedron` with surface area and centroid
- `CompositeShape` with indexer, `IsIn()`, `Sort()`, `SurfaceArea()`, and `Volume()`
- `Computation` console app demonstrating all features

## Contributing

This is a university assignment and is not open for external contributions.

## License

No license.

## Contact

Diana Ivanova,
cc241007@ustp-students.at

## Acknowledgments

- GeeksForGeeks: [Volume and Surface Area of Cuboid](https://www.geeksforgeeks.org/dsa/program-for-volume-and-surface-area-of-cuboid/)
- Math StackExchange: [How to calculate the area of a 3D triangle](https://math.stackexchange.com/questions/128991/how-to-calculate-the-area-of-a-3d-triangle)
- Course material and lecture slides: [https://yun-vis.net/ustp-bcc-csharp/](https://yun-vis.net/ustp-bcc-csharp/)
