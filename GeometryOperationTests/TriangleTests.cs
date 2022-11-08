using GeometryOperationsLibrary.Shapes;

namespace GeometryOperationTests
{
    public class TriangleTests
    {
        [Fact]
        public void CalculateArea_should_return_area()
        {
            float sideALength = 3;
            float sideBLength = 3;
            float sideCLength = 3;

            var triangle = new Triangle(sideALength, sideBLength, sideCLength);

            var halfPerimeter = (sideALength + sideBLength + sideCLength) / 2;
            float S = halfPerimeter * (halfPerimeter - sideALength) * (halfPerimeter - sideBLength) * (halfPerimeter - sideCLength);
            float expectedArea = (float)Math.Sqrt(S);

            float actualArea = triangle.CalculateArea();

            Assert.Equal(expectedArea, actualArea);
        }

        [Fact]
        public void Constructor_with_invalid_params_should_throw_ArgumentException()
        {
            float sideALength = -2;
            float sideBLength = 2;
            float sideCLength = 3;

            Assert.Throws<ArgumentException>("SideALength", () => new Triangle(sideALength, sideBLength, sideCLength));
        }

        [Fact]
        public void IsRightAngled_should_return_isRigthAngled()
        {
            float sideALength = 3;
            float sideBLength = 3;
            float sideCLength = 3;

            var triangle = new Triangle(sideALength, sideBLength, sideCLength);

            var excpectedResult = Math.Sqrt(sideALength) * Math.Sqrt(sideBLength) == Math.Sqrt(sideCLength) ||
            Math.Sqrt(sideBLength) * Math.Sqrt(sideCLength) == Math.Sqrt(sideALength) ||
            Math.Sqrt(sideALength) * Math.Sqrt(sideCLength) == Math.Sqrt(sideBLength);

            bool actualResult = triangle.IsRightAngled();

            Assert.Equal(excpectedResult, actualResult);
        }
    }
}