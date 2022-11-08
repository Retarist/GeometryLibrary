namespace GeometryOperationsLibrary.Shapes
{
    public class Triangle : Shape, ITriangleOperations
    {
        public float SideALength { get; }
        public float SideBLength { get; }
        public float SideCLength { get; }

        public Triangle(float sideALength, float sideBLength, float sideCLength)
        {
            SideALength = ValidateSideLength(sideALength, nameof(SideALength));
            SideBLength = ValidateSideLength(sideBLength, nameof(SideBLength));
            SideCLength = ValidateSideLength(sideCLength, nameof(SideCLength));
            ValidateTriangle();
        }

        public override float CalculateArea()
        {
            var halfPerimeter = (SideALength + SideBLength + SideCLength) / 2;

            float S = halfPerimeter * (halfPerimeter - SideALength) * (halfPerimeter - SideBLength) * (halfPerimeter - SideCLength);

            float result = (float)Math.Sqrt(S);

            return result;
        }

        private float ValidateSideLength(float sideLength, string paramName)
        {
            if (sideLength <= 0)
            {
                throw new ArgumentException("Side length should be more than 0", paramName);
            }
            return sideLength;
        }

        private void ValidateTriangle()
        {
            if (SideALength + SideBLength <= SideCLength)
            {
                throw new ArgumentException("Side length should be shorter than sum of two other sides", nameof(SideCLength));
            }

            if (SideBLength + SideCLength <= SideALength)
            {
                throw new ArgumentException("Side length should be shorter than sum of two other sides", nameof(SideALength));
            }

            if (SideALength + SideCLength <= SideBLength)
            {
                throw new ArgumentException("Side length should be shorter than sum of two other sides", nameof(SideBLength));
            }
        }

        public bool IsRightAngled()
        {
            return Math.Sqrt(SideALength) * Math.Sqrt(SideBLength) == Math.Sqrt(SideCLength) ||
            Math.Sqrt(SideBLength) * Math.Sqrt(SideCLength) == Math.Sqrt(SideALength) ||
            Math.Sqrt(SideALength) * Math.Sqrt(SideCLength) == Math.Sqrt(SideBLength);
        }
    }
}
