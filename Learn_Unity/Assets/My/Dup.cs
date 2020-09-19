using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dup : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    
    private GameObject objk;

    

    // Update is called once per frame
    void Update()
    {
        

        float k = Random.Range(0, 1.0f);
        if (k > 0.5f)
        {
            objk = obj1;
        }
        else if(k<=0.5f)
        {
            objk = obj2;
        }



        if (Input.GetMouseButtonDown(0))
            Instantiate(objk, new Vector3(0, 0, 0), Quaternion.identity);
            Destroy(objk, 1.5f);
            Debug.Log("Pressed primary button.");

    }
}
