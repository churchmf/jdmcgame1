using System;
using System.Collections.Generic;

namespace RoboArena
{
    public class TurnAction : RobotAction
    {
        private RotationDirection m_Direction;

        public TurnAction(RotationDirection direction) : base(1)
        {
            m_Direction = direction;
        }

        protected override void Act(Robot robot, World world, IEnumerable<Robot> others)
        {
            // TODO use bitwise operations on enums to do this instead of nested switch
            CardinalDirection newFacing = robot.Facing;
            switch(robot.Facing)
            {
                case CardinalDirection.North:
                    switch(m_Direction)
                    {
                        case RotationDirection.Left:
                            newFacing = CardinalDirection.West;
                            break;
                        case RotationDirection.Right:
                            newFacing = CardinalDirection.East;
                            break;
                        default:
                            throw new ArgumentException(String.Format("Unhandled RotationDirection {0}", m_Direction));
                    }
                    break;
                case CardinalDirection.East:
                    switch (m_Direction)
                    {
                        case RotationDirection.Left:
                            newFacing = CardinalDirection.North;
                            break;
                        case RotationDirection.Right:
                            newFacing = CardinalDirection.South;
                            break;
                        default:
                            throw new ArgumentException(String.Format("Unhandled RotationDirection {0}", m_Direction));
                    }
                    break;
                case CardinalDirection.South:
                    switch (m_Direction)
                    {
                        case RotationDirection.Left:
                            newFacing = CardinalDirection.East;
                            break;
                        case RotationDirection.Right:
                            newFacing = CardinalDirection.West;
                            break;
                        default:
                            throw new ArgumentException(String.Format("Unhandled RotationDirection {0}", m_Direction));
                    }
                    break;
                case CardinalDirection.West:
                    switch (m_Direction)
                    {
                        case RotationDirection.Left:
                            newFacing = CardinalDirection.South;
                            break;
                        case RotationDirection.Right:
                            newFacing = CardinalDirection.North;
                            break;
                        default:
                            throw new ArgumentException(String.Format("Unhandled RotationDirection {0}", m_Direction));
                    }
                    break;
            }
            robot.Facing = newFacing;
        }
    }
}