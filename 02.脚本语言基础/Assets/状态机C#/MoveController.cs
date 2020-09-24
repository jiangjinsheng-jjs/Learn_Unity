using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 挂在需要移动的物体上
/// </summary>
public class MoveController : MonoBehaviour
{
    private Transform mTransform;
    // 移动方向
    private Vector3 translation = Vector3.zero;

    // 按键状态
    private bool downA, downS, downD, downW;
    // 移动方向
    private Direction direction = Direction.None;

    void Awake()
    {
        mTransform = this.transform;
    }

    void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.W))
            downW = true;
        else if (Input.GetKeyDown(KeyCode.S))
            downS = true;
        else if (Input.GetKeyDown(KeyCode.A))
            downA = true;
        else if (Input.GetKeyDown(KeyCode.D))
            downD = true;

        if (Input.GetKeyUp(KeyCode.W))
            downW = false;
        else if (Input.GetKeyUp(KeyCode.S))
            downS = false;
        else if (Input.GetKeyUp(KeyCode.A))
            downA = false;
        else if (Input.GetKeyUp(KeyCode.D))
            downD = false;

        if (downW)
            direction = Direction.Forward;
        else if (downS)
            direction = Direction.Back;
        else if (downA)
            direction = Direction.Left;
        else if (downD)
            direction = Direction.Right;
        else
            direction = Direction.None;
    }

    void Update()
    {
        switch (direction)
        {
            case Direction.Forward:
                translation.z = 0.02f; //向前移动
                break;
            case Direction.Back:
                translation.z = -0.02f; //向后移动
                break;
            case Direction.Left:
                translation.x = -0.02f; //向左移动
                break;
            case Direction.Right:
                translation.x = 0.02f; //向右移动
                break;
            case Direction.None:
                translation.x = 0;
                translation.z = 0;
                break;
        }

        mTransform.Translate(translation, Space.World);
    }
}

// 物体行进方向
public enum Direction
{
    None,
    Forward,
    Back,
    Left,
    Right
}
