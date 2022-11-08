using GeometryOperationsLibrary;
using GeometryOperationsLibrary.Shapes;

namespace GeometryOperationTests
{
    public class CircleTests
    {
        [Fact]
        public void CalculateArea_should_return_area()
        {
            float radius = 3;

            var circle = new Circle(radius);

            var expectedArea = (radius * radius) * Constants.PI;

            float actualArea = circle.CalculateArea();

            Assert.Equal(expectedArea, actualArea);
        }

        [Fact]
        public void Constructor_with_invalid_params_should_throw_ArgumentException()
        {
            float radius = -2;

            Assert.Throws<ArgumentException>("Radius", () => new Circle(radius));
        }
    }
}
