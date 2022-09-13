namespace AreaCalculator.Shapes;

public class Circle : IShape{
    private float _radius;

    internal Circle(float radius) {
        _radius = radius;
    }

    public double CalculateArea() {
        return (float)(Math.PI * Math.Pow(_radius, 2));
    }
}