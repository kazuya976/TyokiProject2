using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    const float MOVE_SPEED = 0.2f;
    GameObject cube;

    void Start()
    {
        cube = GameObject.Find("Cube");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            cube.transform.Translate(0, 0, MOVE_SPEED);
        }

        if (Input.GetKey(KeyCode.A))
        {
            cube.transform.Translate(MOVE_SPEED * -1, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            cube.transform.Translate(0, 0, MOVE_SPEED * -1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            cube.transform.Translate(MOVE_SPEED, 0, 0);
        }
    }
}
