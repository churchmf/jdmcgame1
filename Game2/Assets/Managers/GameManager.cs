using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject HeadPrefab;
    public GameObject TorsoPrefab;

    // Use this for initialization
    public void Start () {
        Robot robot = RobotManager.GetInstance().GetRobot();

        foreach(Part part in robot.Parts.Values)
        {
            switch(part.Slot)
            {
                case SlotEnum.Head:
                    CreateHead(part);
                    break;
                case SlotEnum.Torso:
                    CreateTorso(part);
                    break;
            }
        }
    }

    private void CreateTorso(Part part)
    {
        var gameObject = Instantiate(TorsoPrefab);
        var renderer = gameObject.GetComponent<Renderer>();
        renderer.material.color = part.Color;
    }

    private void CreateHead(Part part)
    {
        var gameObject = Instantiate(HeadPrefab);
        var renderer = gameObject.GetComponent<Renderer>();
        renderer.material.color = part.Color;
    }
}
