﻿using System;
using System.Collections.Generic;

namespace RoboArena
{
    public class TurnAction : RobotAction
    {
        private RotationDirection m_Direction;

        public TurnAction(Dictionary<string, int> arguments, RotationDirection direction) : base(arguments)
        {
            m_Direction = direction;
        }

        protected override void Act(Robot robot, World world, IEnumerable<Robot> others)
        {
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