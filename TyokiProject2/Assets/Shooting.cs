using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //デフォルトで発射される弾丸
    public GameObject bullet;

    //一定範囲内にいる間発射される弾丸
    public GameObject Silver_bullet;

    //弾丸発射点
    public Transform muzzle;

    //弾丸の速度
    const float SPEED = 1000;

    GameObject bullets;

    void Update()
    {
        //スペースキーが押されたとき
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //弾丸の複製
            if (!Area.invincibly)
            {
                bullets = Instantiate(bullet) as GameObject;
            }
            else
            {
                bullets = Instantiate(Silver_bullet) as GameObject;
            }
           

            Vector3 force;

            force = this.gameObject.transform.forward * SPEED;

            //Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);

            //弾丸の位置を調整
            bullets.transform.position = muzzle.position;
        }
    }
}
