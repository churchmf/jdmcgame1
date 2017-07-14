using System;
using System.Collections.Generic;

namespace RoboArena
{
    public class DataManager
    {
        public static RobotData GetRobotData(string id)
        {
            // TODO query for data instead
            var random = new Random();
            return new RobotData
            {
                Id = id,
                MaxHealth = random.Next(9, 11),
                MaxEnergy = random.Next(9, 11),
                MaxSpeed = random.Next(3, 5),
                Actions = new List<RobotAction>
                {
                    new MoveAction(CardinalDirection.North),
                    new MoveAction(CardinalDirection.East),
                    new MoveAction(CardinalDirection.South),
                    new MoveAction(CardinalDirection.West),
                }
            };
        }
    }

    public class RobotData
    {
        public string Id { get; set; }
        public int MaxHealth { get; set; }
        public int MaxEnergy { get; set; }
        public int MaxSpeed { get; set; }
        public IList<RobotAction> Actions { get; set; }

        public void Initialize(Robot robot)
        {
            robot.Health = MaxHealth;
            robot.Energy = MaxEnergy;
            robot.Speed = MaxSpeed;
        }
    }
}
