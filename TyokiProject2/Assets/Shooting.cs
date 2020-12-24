using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //デフォルトで発射される弾丸
    [SerializeField] GameObject defaultBullet;

    //一定範囲内にいる間発射される弾丸
    [SerializeField] GameObject silverBullet;

    //弾丸発射点
    [SerializeField] Transform muzzle;

    //弾丸の速度
    const float SPEED = 10000;

    //球を撃つ間隔
    private const float SHOT_DELAY = 0.1f;
    //最後に発射した時間
    private float shotTime = SHOT_DELAY;

    void Update()
    {
        //バグ防止
        if (shotTime > SHOT_DELAY)
        {
            shotTime = SHOT_DELAY;    //発射間隔をリセット
        }
        shotTime += Time.deltaTime;
    }

    public void Shot()
    {
        if (shotTime < SHOT_DELAY)
        {
            return;
        }

        GameObject bullet;
        //弾丸の複製
        if (!Area.invincibly)
        {
            bullet = Instantiate(defaultBullet) as GameObject;
        }
        else
        {
            bullet = Instantiate(silverBullet) as GameObject;
        }
        Vector3 force;  //発射するベクトル

        force = gameObject.transform.forward * SPEED;

        //Rigidbodyに力を加えて発射
        bullet.GetComponent<Rigidbody>().AddForce(force);

        //弾丸の位置を調整
        bullet.transform.position = muzzle.position;

        //発射間隔のカウントをリセット
        shotTime = 0;
    }
}
