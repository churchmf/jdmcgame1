using System.Collections.Generic;

public enum SlotEnum
{
    Head,
    LeftArm,
    RightArm,
    Torso,
    Wheels
}

public class Robot
{
    public IDictionary<SlotEnum, Part> Parts;
}

public class RobotManager {

    #region Singleton
    private static RobotManager m_instance;
    public static RobotManager GetInstance()
    {
        if (m_instance == null)
        {
            m_instance = new RobotManager();
        }
        return m_instance;
    }
    #endregion 

    private RobotManager() { }

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
