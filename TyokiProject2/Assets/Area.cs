using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    //一定範囲内にいるかどうかを判断するフラグ
    public static bool invincibly = false;

    //一定範囲内にいる間
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            invincibly = true;
        }
    }

    //一定範囲内からでたら
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            invincibly = false;
        }
    }
}
