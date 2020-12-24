using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CapsuleClliderとRigidbodyを追加
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    Shooting shooting;

    //移動スピード
    const float SPEED = 3f;

    //Animatorを入れる
    private Animator animator;

    //Main Cameraを入れる
    Transform cam;


    void Start()
    {
        shooting = transform.Find("Shooting").GetComponent<Shooting>();

        //Animatorコンポーネントを取得
        animator = GetComponent<Animator>();

        //メインカメラのTransformを取得
        cam = Camera.main.transform;
    }

    void Update()
    {
        //A・Dキー、←→キーで横移動
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * SPEED;

        //W・Sキー、↑↓キーで前後移動
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * SPEED;

        //AnimationControllerのParametersに数値を送って
        //アニメーションを出す
        animator.SetFloat("X", x * 50);
        animator.SetFloat("Y", z * 50);

        //前移動の時だけ方向転換させる
        if (z > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x,
                cam.eulerAngles.y, transform.rotation.z));
        }
        else
        {
            //zが0より小さい（後退）するとスピードが落ちる
        }
        if (z < 0)
        {
            z *= 0.67f;
        }

        //xとzの数値に基づいて移動
        transform.position += transform.forward * z + transform.right * x;

        //弾丸を発射する
        if (Input.GetKey(KeyCode.Space))
        {
            shooting.Shot();
        }
    }
}
