using Assets;
using Assets.Parts;
using Assets.Robots;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    private RobotBuilder m_RobotBuilder;

    public void Start()
    {
        m_RobotBuilder = GetComponentInChildren<RobotBuilder>();

        var robot = GetRobot();
        m_RobotBuilder.BuildRobot(robot);
    }

    public Robot GetRobot()
    {
        IEnumerable<Part> parts = PartsManager.GetInstance().GetParts();
        return BuildRobot(parts);
    }

    private Robot BuildRobot(IEnumerable<Part> parts)
    {
        var robot = new Robot();

        robot.Parts = new Dictionary<SlotEnum, Part>();
        foreach (var part in parts)
        {
            robot.Parts.Add(part.Slot, part);
        }

        return robot;
    }
}
