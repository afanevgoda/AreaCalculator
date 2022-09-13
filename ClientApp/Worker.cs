using AreaCalculator;
using AreaCalculator.Shapes;

namespace ClientApp;

public class Worker : BackgroundService{
    private readonly ILogger<Worker> _logger;
    private readonly IShapeCreator _shapeCreator;
    private readonly IAreaCalculator _areaCalculator;
    private readonly Triangle _defaultTriangle;

    public Worker(ILogger<Worker> logger, IShapeCreator shapeCreator, IAreaCalculator areaCalculator) {
        _logger = logger;
        _shapeCreator = shapeCreator;
        _areaCalculator = areaCalculator;

        _defaultTriangle = _shapeCreator.CreateTriangle(3, 5, 7);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        while (!stoppingToken.IsCancellationRequested) {
            CalculateAreaOfRandomShapes();
            await Task.Delay(20 * 1000, stoppingToken);
        }
    }

    private void CalculateAreaOfRandomShapes() {
        Enumerable.Repeat(0, 100).Select(_ => CreateCircleOrTriangle()).ToList()
            .ForEach(shape => {
                var area = _areaCalculator.CalculateArea(shape);
                if (shape is Triangle triangle)
                    _logger.Log(LogLevel.Information,
                        $"Type is Triangle. Area is {area.ToString()}. Is this triangle right? " +
                        $"{triangle.IsItRightTriangle()}");
                else
                    _logger.Log(LogLevel.Information, $"Type is {shape.GetType().Name}. Area is {area.ToString()}");
            });
    }

    private IShape CreateCircleOrTriangle() {
        var rnd = new Random();
        // -1 inclusive, 1 exclusive => we will get -1 or 0
        var randomValue = rnd.Next(-1, 1);
        if (randomValue == -1)
            return _shapeCreator.CreateCircle(rnd.Next(1, 10));

        try {
            return _shapeCreator.CreateTriangle(
                rnd.Next(3, 10),
                rnd.Next(3, 10),
                rnd.Next(3, 10));
        }
        catch {
            // Console was used for shorter outputs but we should use the logger here for sure
            Console.WriteLine("Tried to create impossible triangle. Nothing to worry about, it will be replaced with " +
                              "the default one");
        }

        return _defaultTriangle;
    }
}