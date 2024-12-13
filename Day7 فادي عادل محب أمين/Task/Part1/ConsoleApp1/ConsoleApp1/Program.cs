//Question 1 Start:

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }

    // the default constructor:
    public Car() { }

    // the constructor with one parameter (Id):
    public Car(int id)
    {
        Id = id;
    }

    // the constructor with two parameters (Id, Brand):
    public Car(int id, string brand)
    {
        Id = id;
        Brand = brand;
    }

    // the constructor with all three parameters (Id, Brand, Price):
    public Car(int id, string brand, decimal price)
    {
        Id = id;
        Brand = brand;
        Price = price;
    }
}



public class Program
{
    public static void Main()
    {
        Car car1 = new Car(); // the default constructor
        Car car2 = new Car(1); // the constructor with one parameter (Id)
        Car car3 = new Car(2, "Ford"); // the constructor with two parameters (Id, Brand)
        Car car4 = new Car(3, "Chevrolet", 30000m); // constructor with all three parameters (Id, Brand, Price)

        Console.WriteLine($"Car1: Id={car1.Id}, Brand={car1.Brand}, Price={car1.Price}");
        Console.WriteLine($"Car2: Id={car2.Id}, Brand={car2.Brand}, Price={car2.Price}");
        Console.WriteLine($"Car3: Id={car3.Id}, Brand={car3.Brand}, Price={car3.Price}");
        Console.WriteLine($"Car4: Id={car4.Id}, Brand={car4.Brand}, Price={car4.Price}");
    }
}


/*Why does defining a custom constructor suppress the default constructor in C#?
because the compiler only provides a default constructor if no other constructors are defined.
Once you define a custom constructor, the compiler assumes you have taken control of the object
initialization process and does not generate the default constructor automatically
*/

//Question 1 End:







//Question 2 Start:
public class Calculator
{
    public int Sum(int a, int b)
    {
        return a + b;
    }

    public int Sum(int a, int b, int c)
    {
        return a + b + c;
    }

    public double Sum(double a, double b)
    {
        return a + b;
    }
}

public class Program
{
    public static void Main()
    {
        Calculator calculator = new Calculator();

        int result1 = calculator.Sum(1, 2);
        Console.WriteLine($"Sum of 1 and 2 is: {result1}");

        int result2 = calculator.Sum(1, 2, 3);
        Console.WriteLine($"Sum of 1, 2, and 3 is: {result2}");

        double result3 = calculator.Sum(1.5, 2.5);
        Console.WriteLine($"Sum of 1.5 and 2.5 is: {result3}");
    }
}


/* How does method overloading improve code readability and reusability?
by allowing you to use the same method name for
different operations based on the parameters.
This makes the code easier to understand and maintain,
as you don't need to remember multiple method names for similar operations.
*/


//Question 2 End:












//Question 3 Start:
public class Parent
{
    public int X { get; set; }
    public int Y { get; set; }
    public Parent(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Child : Parent
{
    public int Z { get; set; }
    public Child(int x, int y, int z) : base(x, y)
    {
        Z = z;
    }
}

public class Program
{
    public static void Main()
    {
        Child child = new Child(1, 2, 3);

        Console.WriteLine($"X={child.X}, Y={child.Y}, Z={child.Z}");
    }
}

/*What is the purpose of constructor chaining in inheritance?
it allows you to ensure that the base class is properly initialized
before the derived class adds its own initialization.
This helps maintain a clear and consistent initialization process,
ensuring that all necessary properties are set up correctly.
*/

//Question 3 End:








//Question 4 Start:
namespace example
{
    public class Parent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Parent(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual int Product()
        {
            return X * Y;
        }
    }

    public class Child : Parent
    {
        public int Z { get; set; }

        public Child(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }

        public override int Product()
        {
            return X * Y * Z;
        }
    }
}


namespace example
{
    public class Program
    {
        public static void Main()
        {
            Child child = new Child(2, 3, 4);
            Parent parentRef = child;
            Console.WriteLine($"Parent reference: Product() = {parentRef.Product()}");
            Console.WriteLine($"Child reference: Product() = {child.Product()}");
        }
    }
}

/*How does new differ from override in method overriding?
new keyword: Hides the base class method. If you call
the method using a base class reference, the base class method is called.

override keyword: Replaces the base class method. If you call
the method using a base class reference, the derived class method is called.
*/

//Question 4 End:







//Question 5 Start:
namespace example
{
    public class Parent
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Parent(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    public class Child : Parent
    {
        public int Z { get; set; }

        public Child(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}

namespace example
{
    public class Program
    {
        public static void Main()
        {
            Parent parent = new Parent(1, 2);
            Child child = new Child(3, 4, 5);
            Console.WriteLine(parent.ToString()); // Output: (1, 2)
            Console.WriteLine(child.ToString());  // Output: (3, 4, 5)
        }
    }
}

/*Why is ToString() often overridden in custom classes?
ToString() is often overridden to provide a meaningful string
representation of an object. This is useful for debugging, logging,
and displaying object information in a readable format. By default,
ToString() returns the class name, which is not very informative. Overriding
it allows you to customize the output to include relevant property values.
*/

//Question 5 End:








//Question 6 Start:
namespace Shapes
{
    public interface IShape
    {
        double Area { get; }
        void Draw();
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Area => Width * Height;

        public void Draw()
        {
            Console.WriteLine($"Drawing a rectangle with width {Width} and height {Height}");
        }
    }
}


namespace Shapes
{
    public class Program
    {
        public static void Main()
        {
            IShape rectangle = new Rectangle(5, 10);
            Console.WriteLine($"Area: {rectangle.Area}");
            rectangle.Draw();
        }
    }
}
/*Why can't you create an instance of an interface directly?

You can't create an instance of an interface directly because
an interface only defines
a contract (methods and properties) without providing any implementation.
To use an interface, you need to create a class that implements
the interface and provides the actual implementation for its members.
*/


//Question 6 End:









//Question 7 Start:
namespace Shapes
{
    public interface IShape
    {
        double Area { get; }
        void Draw();
        void PrintDetails()
        {
            Console.WriteLine($"Area: {Area}");
        }
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Area => Math.PI * Radius * Radius;

        public void Draw()
        {
            Console.WriteLine($"Drawing a circle with radius {Radius}");
        }
    }
}


namespace Shapes
{
    public class Program
    {
        public static void Main()
        {
            IShape circle = new Circle(5);
            circle.PrintDetails();
            circle.Draw();
        }
    }
}


/*the benefits of default implementations in interfaces (C# 8.0):
Backward Compatibility: Allows adding new methods to interfaces
without breaking existing implementations.

Code Reusability: Provides common functionality that can be shared
across multiple implementations.
*/

//Question 7 End:






//Question 8 Start:
namespace Vehicles
{
    public interface IMovable
    {
        void Move();
    }

    public class Car : IMovable
    {
        public void Move()
        {
            Console.WriteLine("The car is moving.");
        }
    }
}

namespace Vehicles
{
    public class Program
    {
        public static void Main()
        {
            IMovable movableCar = new Car();
            movableCar.Move();
        }
    }
}

/*Why is it useful to use an interface reference to access implementing class methods?
Using an interface reference allows for flexibility
and decoupling in your code. It enables you to write code
that works with any class implementing the interface,
making it easier to extend and maintain.
This approach promotes the use of polymorphism, allowing you to
switch out implementations without changing the code that uses the interface.
*/

//Question 8 End:





//Question 9 Start:
namespace FileOperations
{
    public interface IReadable
    {
        void Read();
    }

    public interface IWritable
    {
        void Write();
    }

    public class File : IReadable, IWritable
    {
        public void Read()
        {
            Console.WriteLine("Reading from the file.");
        }

        public void Write()
        {
            Console.WriteLine("Writing to the file.");
        }
    }
}

namespace FileOperations
{
    public class Program
    {
        public static void Main()
        {
            File file = new File();
            file.Read();
            file.Write();
        }
    }
}

/*How does C# overcome the limitation of single inheritance with interfaces?
C# allows a class to implement multiple interfaces,
which provides a way to achieve multiple inheritance. This means a class
can inherit behavior from multiple sources, overcoming the limitation of
single inheritance. This approach promotes flexibility and code reuse.
*/

//Question 9 End:







//Question 10 Start:
namespace Shapes
{
    public abstract class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("Drawing Shape");
        }

        public abstract double CalculateArea();
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing Rectangle");
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }
}

namespace Shapes
{
    public class Program
    {
        public static void Main()
        {
            Shape rectangle = new Rectangle(5, 10);
            rectangle.Draw();
            Console.WriteLine($"Area: {rectangle.CalculateArea()}");
        }
    }
}

/*Difference between a virtual method and an abstract method in C#:

Virtual Method: Provides a default implementation that can be overridden
by derived classes. If not overridden, the base class implementation is used.

Abstract Method: Does not provide any implementation
and must be overridden in derived classes.
It forces derived classes to provide their own implementation.
*/

//Question 10 End: