using AreaCalculator.Shapes;

namespace AreaCalculator;

public class ShapeCreator : IShapeCreator{
    public Triangle CreateTriangle(double sideA, double sideB, double sideC) {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            throw new ArgumentException("Sides can not have negative or zero length");
        if (!CheckIsSuchTrianglePossible(sideA, sideB, sideC))
            throw new ArgumentException("Such triangle can not exist");

        return new Triangle(sideA, sideB, sideC);
    }

    private bool CheckIsSuchTrianglePossible(double sideA, double sideB, double sideC) {
        var sideACheck = sideB + sideC > sideA;
        var sideBCheck = sideA + sideC > sideB;
        var sideCCheck = sideA + sideB > sideC;
        return sideACheck && sideBCheck && sideCCheck;
    }


    public Circle CreateCircle(double radius) {
        if (radius <= 0)
            throw new ArgumentException("Radius can not be negative or equal to zero");

        return new Circle(radius);
    }

    public Square CreateSquare(double side) {
        if (side <= 0)
            throw new ArgumentException("Side can not be negative or equal to zero");
        
        return new Square(side);
    }
}