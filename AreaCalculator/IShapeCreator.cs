using AreaCalculator.Shapes;

namespace AreaCalculator;

public interface IShapeCreator{
    Triangle CreateTriangle(double sideA, double sideB, double sideC);

    Circle CreateCircle(double radius);
    
    Square CreateSquare(double side);
}