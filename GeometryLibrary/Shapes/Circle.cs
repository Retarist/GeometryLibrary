namespace GeometryOperationsLibrary.Shapes
{
    public class Circle : Shape
    {
        public float Radius { get; }

        public Circle(float radius)
        {
            Radius = ValidateSideLength(radius, nameof(Radius));
        }

        public override float CalculateArea()
        {
            var result = (Radius * Radius) * Constants.PI;

            return result;
        }

        private float ValidateSideLength(float radius, string paramName)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius should be more than 0", paramName);
            }
            return radius;
        }
    }
}
