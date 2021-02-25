namespace RobloxFiles.DataTypes
{
    public class Ray
    {
        public readonly Vector3 Origin;
        public readonly Vector3 Direction;

        public override string ToString() => $"{{{Origin}}}, {{{Direction}}}";

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

        public Ray(Vector3 origin = null, Vector3 direction = null)
        {
            Origin = origin ?? new Vector3();
            Direction = direction ?? new Vector3();
        }

        public Vector3 ClosestPoint(Vector3 point)
        {
            Vector3 result = Origin;
            float dist = Direction.Dot(point - result);

            if (dist >= 0)
                result += (Direction * dist);

            return result;
        }

        public float Distance(Vector3 point)
        {
            Vector3 closestPoint = ClosestPoint(point);
            return (point - closestPoint).Magnitude;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ray other))
                return false;

            if (!Origin.Equals(other.Origin))
                return false;

            if (!Direction.Equals(other.Direction))
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            int hash = Origin.GetHashCode()
                     ^ Direction.GetHashCode();

            return hash;
        }
    }
}
