namespace AreaCalculator.Shapes;

public class Square : IShape{
    private double _side;
    
    internal Square(double side) {
        _side = side;
    }
    
    public double CalculateArea() {
        return Math.Pow(_side, 2);
    }
}