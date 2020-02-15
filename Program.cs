using System;
using System.Collections.Generic;
/*7)	Реалізувати задачу створення різних геометричних фігур.
* Повинно бути реалізовано створення декількох фігур з різними характеристиками*/
namespace LAB_1
{
    abstract class ShapeBuilder
    {
        public Shape Shape { get; private set; }
        public void CreateShape()
            => Shape = new Shape();

        public abstract void SetNumOfParts();
    }
    class Professor
    {
        public Shape SetShape(ShapeBuilder shapeBuilder)
        {
            shapeBuilder.CreateShape();
            shapeBuilder.SetNumOfParts();
            return shapeBuilder.Shape;
        }
    }
    class Shape
    {
        public List<Side> Sides = new List<Side>();
        public void PrintShapeInfo()
        {
            foreach(Side a in Sides)
                a.PrintSideInfo();
        }
    }
    sealed class Side
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Side() { }

        public Side(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }

        public void PrintSideInfo()
            => Console.WriteLine($"Coords: ({A.X},{A.Y},{A.Z}); ({B.X},{B.Y},{B.Z}); ({C.X},{C.Y},{C.Z})");
    }
    sealed class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public Point() : this(0, 0, 0) { }
        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
    sealed class Square : ShapeBuilder
    {
        public override void SetNumOfParts()
        {
            Console.WriteLine("Drawing a Square =>");
            for(int i = 0; i < 4; i++)
            {
                Random rand = new Random();

                Point a = new Point(rand.Next(0, 5), rand.Next(0, 10), rand.Next(3, 5));
                Point b = new Point(rand.Next(0, 6), rand.Next(2, 5), rand.Next(0, 5));
                Point c = new Point(rand.Next(0, 4), rand.Next(0, 7), rand.Next(2, 4));

                Side side = new Side(a, b, c);

                Shape.Sides.Add(side);
            }
        }
    }

    class Program
    {
        public static Shape ShapeCreator(int NumOfSides)
        {
            Shape Shape = new Shape();
            Console.WriteLine("Drawing a Triangle =>");
            for(int i = 0; i < NumOfSides; i++)
            {
                Random rand = new Random();

                Point a = new Point(rand.Next(0, 5), rand.Next(0, 5), rand.Next(0, 5));
                Point b = new Point(rand.Next(0, 5), rand.Next(0, 5), rand.Next(0, 5));
                Point c = new Point(rand.Next(0, 5), rand.Next(0, 5), rand.Next(0, 5));

                Side side = new Side(a, b, c);

                Shape.Sides.Add(side);
            }

            return Shape;
        }
        static void Main(string[] args)
        {
            Professor professor = new Professor();
            ShapeBuilder builder = new Square();
            Shape square = professor.SetShape(builder);

            square.PrintShapeInfo();

            Shape triangle = ShapeCreator(3);
            Console.WriteLine(new string('-', 33));
            triangle.PrintShapeInfo();
            Console.ReadLine();
        }
    }
}


