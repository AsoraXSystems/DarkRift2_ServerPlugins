using RecastDetour.Detour;
using ServerPlugins.Game;
using Utilities;
using Utilities.Game;

namespace RecastDetour
{
    public class NavMeshAgent
    {
        public bool HasPath => CurrentPath != null;
        public SmoothPath CurrentPath { get; private set; }
        public Vector3 Destination { get; private set; }

        public Vector3 Position { get; set; }
        public NavMeshQuery NavMeshQuery { get; set; }
        public float Speed { get; set; }
        public float StoppingDistance { get; set; }

        private int _currentPathIndex;
        private Vector3 _currentDestination;


        public void SetDestination(Vector3 destination)
        {
            CurrentPath = Pathfinder.ComputeSmoothPath(NavMeshQuery, Position, destination);
            if (CurrentPath.Points.Count > 0)
            {
                _currentPathIndex = 0;
                _currentDestination = CurrentPath.Points[0];
                Destination = CurrentPath.Points[CurrentPath.PointsCount - 1];
            }
            else
            {
                CurrentPath = null;
            }
        }

        public void Integrate(float deltaTime)
        {
            var maxDistance = Speed * deltaTime;
            if (Vector3.Distance(Position, _currentDestination) <= StoppingDistance)
            {
                if (_currentPathIndex < CurrentPath.PointsCount - 1)
                {
                    _currentDestination = CurrentPath.Points[++_currentPathIndex];
                    Position = Vector3.MoveTowards(Position, _currentDestination, maxDistance);
                }
                else
                {
                    CurrentPath = null;
                }
            }
            else
            {
                Position = Vector3.MoveTowards(Position, _currentDestination, maxDistance);
            }
        }
    }
}