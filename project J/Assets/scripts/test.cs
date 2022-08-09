using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
  [SerializeField] stageData stageData;
    public float moveSpeed=10;
   private Quaternion basePosition=new(0,0,0,0);
    void Start()
    {
       Input.gyro.enabled =true; 
    }
 
    // Update is called once per frame
    void Update()
    {
        Vector3 vec = Vector3.zero;
        vec.x=Input.acceleration.x*moveSpeed;
        if(vec.sqrMagnitude>1)
        vec.Normalize();

      vec*=Time.deltaTime; transform.Translate(vec*moveSpeed);

    }
    private void LateUpdate()
    {
      transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                                            Mathf.Clamp(transform.position.y, stageData.LimitMin.y,stageData.LimitMax.y) );
    }
}
