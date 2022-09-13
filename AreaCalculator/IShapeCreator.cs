using AreaCalculator.Shapes;

namespace AreaCalculator;

public interface IShapeCreator{
    Triangle CreateTriangle(float sideA, float sideB, float sideC);

    Circle CreateCircle(float radius);
}