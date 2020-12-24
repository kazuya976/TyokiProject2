using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //x軸の角度を制限するための変数
    const float ANGLE_UP = 60f;
    const float ANGLE_DOWN = -60f;

    Camera MainCamera;
    GameObject player; // 操作キャラ

    // カメラの回転速度
    [SerializeField] float rotate_speed = 3f;
    // Axsiの位置を指定する変数
    [SerializeField] Vector3 axisPos;

    // マウススクロールの値を入れる
    [SerializeField] float scroll;
    // マウスホイールの値を保存
    [SerializeField] float scrollLog;

    void Start()
    {
        //Playerをタグから取得
        player = GameObject.FindGameObjectWithTag("Player");
        //Main Cameraを取得
        MainCamera = Camera.main;

        MainCamera.transform.parent = transform;

        //CameraのAxisに相対的な位置をlocalPositionで指定
        MainCamera.transform.localPosition = new Vector3(0, 0, -3);
        //CameraとAxisの向きを最初だけそろえる
        MainCamera.transform.localRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        //Axisの位置をplayerの位置＋axisPosで決める
        transform.position = player.transform.position + axisPos;
        //三人称の時のCameraの位置にマウススクロールの値を足して位置を調整
        //thirdPosAdd = thiirdPos + new Vector3(0, 0, scrollLog);

        //マウススクロールの値を入れる
        scroll = Input.GetAxis("Mouse ScrollWheel");
        //scrollAdd += Input.GetAxis("Mouse ScorllWheel");
        //マウススクロールの値は動かさないと0になるのでここで保存する
        scrollLog += Input.GetAxis("Mouse ScrollWheel");

        //Cameraの位置、ｚ軸にスクロール分を加える
        MainCamera.transform.localPosition
                    = new Vector3(MainCamera.transform.localPosition.x,
                    MainCamera.transform.localPosition.y,
                    MainCamera.transform.localPosition.z + scroll);

        if (Input.GetMouseButton(1))
        {
            //Cameraの角度にマウスからとった値を入れる
            transform.eulerAngles += new Vector3(
                Input.GetAxis("Mouse Y") * rotate_speed * -1,
                Input.GetAxis("Mouse X") * rotate_speed
                , 0);

            //x軸の角度
            float angleX = transform.eulerAngles.x;
            //x軸の値を180度超えたら360引くことで制限しやすくなる
            if (angleX >= 180)
            {
                angleX = angleX - 360;
            }
            //Mathf.Clamp（値、最小値、最大値）でx軸の値を制限する
            transform.eulerAngles = new Vector3(
                Mathf.Clamp(angleX, ANGLE_DOWN, ANGLE_UP),
                transform.eulerAngles.y,
                transform.eulerAngles.z
                );
        }
    }
}
