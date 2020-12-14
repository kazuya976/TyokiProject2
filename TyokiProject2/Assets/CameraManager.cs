using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    const float MOVE_SPEED = 0.2f;
    private GameObject MainCamera;
    private GameObject targetObject; // 注視したいオブジェクト

    // カメラの回転速度を格納する変数
    public Vector3 rotationSpeed;
    // マウス移動方向とカメラ回転方向を反転する判定フラグ
    public bool reverse;
    // マウス座標を格納する変数
    private Vector2 lastMousePosition;
    // カメラの角度を格納する変数（初期値に0,0を代入）
    private Vector3 newAngle = new Vector3(0, 0, 0);

    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
        targetObject = GameObject.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            MainCamera.transform.Translate(0, 0, MOVE_SPEED);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MainCamera.transform.Translate(MOVE_SPEED * -1, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            MainCamera.transform.Translate(0, 0, MOVE_SPEED * -1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            MainCamera.transform.Translate(MOVE_SPEED, 0, 0);
        }

        // 右クリックした時
        if (Input.GetMouseButtonDown(1))
        {
            // カメラの角度を変数"newAngle"に格納
            newAngle = new Vector3(0, 0, 0);
            // マウス座標を変数"lastMousePosition"に格納
            lastMousePosition = Input.mousePosition;
        }

        // 左ドラッグしている間
        else if (Input.GetMouseButton(1))
        {
            Debug.Log("押してる");
            //カメラ回転方向の判定フラグが"true"の場合
            if (!reverse)
            {
                // Y軸の回転：マウスドラッグ方向に視点回転
                //（クリック時の座標とマウス座標の現在値の差分値）
                newAngle.y -= (lastMousePosition.x - Input.mousePosition.x);

                // X軸の回転：マウスドラッグ方向に視点回転
                //（クリック時の座標とマウス座標の現在値の差分値）
                newAngle.x -= (Input.mousePosition.y - lastMousePosition.y);
          

                // マウス座標を変数"lastMousePosition"に格納
                lastMousePosition = Input.mousePosition;
            }

            // カメラ回転方向の判定フラグが"reverse"の場合
            else if (reverse)
            {
                // Y軸の回転：マウスドラッグと逆方向に視点回転
                newAngle.y -= (Input.mousePosition.x - lastMousePosition.x) ;
                // X軸の回転：マウスドラッグと逆方向に視点回転
                newAngle.x -= (lastMousePosition.y - Input.mousePosition.y);

                // マウス座標を変数"lastMousePosition"に格納
                lastMousePosition = Input.mousePosition;
            }

            transform.RotateAround(targetObject.transform.position, newAngle, 1f);
        }

        //Qボタンでカメラ反転
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DirectionChange();
        }
    }

    // マウスドラッグ方向と視点回転方向を反転する処理
    public void DirectionChange()
    {
        // 判定フラグ変数"reverse"が"false"であれば
        if (!reverse)
        {
            // 判定フラグ変数"reverse"に"true"を代入
            reverse = true;
        }
        // でなければ（判定フラグ変数"reverse"が"true"であれば）
        else
        {
            // 判定フラグ変数"reverse"に"false"を代入
            reverse = false;
        }
    }
}
