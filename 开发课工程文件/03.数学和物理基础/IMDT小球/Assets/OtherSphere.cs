using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherSphere : MonoBehaviour
{
    public float friction;
    public float mass;
    public float radius;
    public float W = 20 - 0.5f;
    public float H = 10 - 0.5f;
    Vector3 pos;
    [NonSerialized]
    public Vector3 currentV;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        //判断是否与边界碰撞
        if (pos.z > H - 1.0f)
        {
            Vector3 N = new Vector3(0, 0, -1);
            currentV = currentV - 2 * N * Vector3.Dot(N, currentV);
        }
        if (pos.z < -H + 1.0f)
        {
            Vector3 N = new Vector3(0, 0, 1);
            currentV = currentV - 2 * N * Vector3.Dot(N, currentV);
        }
        if (pos.x < -W + 1.0f)
        {
            Vector3 N = new Vector3(1, 0, 0);
            currentV = currentV - 2 * N * Vector3.Dot(N, currentV);
        }
        if (pos.x > W - 1.0f)
        {
            Vector3 N = new Vector3(-1, 0, 0);
            currentV = currentV - 2 * N * Vector3.Dot(N, currentV);
        }
        //摩擦力
        Vector3 frictionDeltaV = -Time.deltaTime * friction * currentV.normalized;
        //防止摩擦力反向运动
        Vector3 finalV = currentV + frictionDeltaV;
        if (finalV.x * currentV.x <= 0)
            frictionDeltaV.x = -currentV.x;
        if (finalV.y * currentV.y <= 0)
            frictionDeltaV.y = -currentV.y;
        if (finalV.z * currentV.z <= 0)
            frictionDeltaV.z = -currentV.z;

        //应用加速度
        Vector3 curV = currentV + frictionDeltaV;
        transform.Translate((curV + currentV) * Time.deltaTime / 2);
        currentV = curV;
        pos = transform.position;
        
        
    }
}
