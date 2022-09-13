using AreaCalculator.Shapes;

namespace AreaCalculator;

public class ShapeCreator : IShapeCreator{
    public Triangle CreateTriangle(float sideA, float sideB, float sideC) {
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


    public Circle CreateCircle(float radius) {
        if (radius <= 0)
            throw new ArgumentException("Radius can not be negative or equal to zero");

        return new Circle(radius);
    }
}