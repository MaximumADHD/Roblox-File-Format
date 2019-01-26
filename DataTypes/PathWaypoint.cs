using System;
using Roblox.Enums;

namespace Roblox.DataTypes
{
    public struct PathWaypoint
    {
        public readonly Vector3 Position;
        public readonly PathWaypointAction Action;

        public PathWaypoint(Vector3? position)
        {
            Position = position ?? Vector3.Zero;
            Action = PathWaypointAction.Walk;
        }

        public PathWaypoint(Vector3 position, PathWaypointAction action = PathWaypointAction.Walk)
        {
            Position = position;
            Action = action;
        }

        public override string ToString()
        {
            Type PathWaypointAction = typeof(PathWaypointAction);
            return '{' + Position + "} " + Enum.GetName(PathWaypointAction, Action);
        }
    }
}
