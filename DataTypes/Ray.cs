namespace RobloxFiles.DataTypes
{
    public struct Ray
    {
        public readonly Vector3 Origin;
        public readonly Vector3 Direction;

        public Ray Unit
        {
            get
            {
                Ray unit;

                if (Direction.Magnitude == 1.0f)
                    unit = this;
                else
                    unit = new Ray(Origin, Direction.Unit);

                return unit;
            }
        }

        public Ray(Vector3 origin, Vector3 direction)
        {
            Origin = origin;
            Direction = direction;
        }

        public override string ToString()
        {
            return '{' + Origin.ToString() + "}, {" + Direction.ToString() + '}';
        }

        public Vector3 ClosestPoint(Vector3 point)
        {
            Vector3 offset = point - Origin;
            float diff = offset.Dot(Direction) / Direction.Dot(Direction);
            return Origin + (diff * Direction);
        }

        public float Distance(Vector3 point)
        {
            Vector3 projected = ClosestPoint(point);
            return (point - projected).Magnitude;
        }
    }
}
