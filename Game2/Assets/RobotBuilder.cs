using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBuilder : MonoBehaviour {

    public GameObject enemy;

    public void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemy);
        }
    }

}
