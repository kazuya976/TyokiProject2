using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    const float LIFE_TIME = 2.0f;

    void Start()
    {
        Destroy(gameObject, LIFE_TIME);
    }
}
