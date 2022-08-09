using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
      [SerializeField] stageData stageData;
    [SerializeField][Range(500f,2000f)]float speed = 1000f;
    private Rigidbody rb;
    private float randomX;
    private float randomY;
    private float waittime=2;

    private bool goright=false;
    private bool goleft=false;
    void Start()
    { 
       

         rb=GetComponent<Rigidbody>();

        //                  randomX = UnityEngine.Random.Range(-1,1);
        // randomY = UnityEngine.Random.Range(-1,1);

        // Vector2 dir = new Vector2(randomX, randomY).normalized;

      //  rb.AddForce(dir * speed);
    }
    //   private void LateUpdate()
    // {
    //   transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
    //                                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y,stageData.LimitMax.y) );
    // }
    void Update()
    {
        if(goleft)
        {
        transform.position+=Vector3.left*2*Time.deltaTime;            
        }
        
        if(goleft)
        {
            transform.position+=Vector3.right*2*Time.deltaTime;
        }

    }
    IEnumerator randomGame()
    {
        int random=UnityEngine.Random.Range(1,6);
        switch(random)
        {
            case 1:
                StartCoroutine(pattern1());
                break;
            case 2:
                StartCoroutine(pattern2());
                break;
            case 3:
                StartCoroutine(pattern3());
                break;
            case 4:
                StartCoroutine(pattern4());
                break;
            case 5:
                StartCoroutine(pattern5());
                break;                                
        }
        yield return null;
    }
    IEnumerator pattern1()
    {//left
        goleft = true;
        yield return new WaitForSeconds(1.5f);
        goleft = false;
        yield return new WaitForSeconds(waittime);
        StartCoroutine(randomGame());
    }
        IEnumerator pattern2()
    {//right
        goright = true;
        yield return new WaitForSeconds(1.5f);
        goright = false;
        yield return new WaitForSeconds(waittime);
        StartCoroutine(randomGame());        
    }
        IEnumerator pattern3()
    {//랜덤이동
        float posX=UnityEngine.Random.Range(stageData.LimitMin.x,stageData.LimitMax.x);
        float posY=UnityEngine.Random.Range(stageData.LimitMin.y,stageData.LimitMax.y);
        transform.position = new Vector3(posX,posY,0);
        yield return new WaitForSeconds(waittime);
        StartCoroutine(randomGame());
    }
        IEnumerator pattern4()
    {//분신술
        
        yield return new WaitForSeconds(waittime);
        StartCoroutine(randomGame());
    }
        IEnumerator pattern5()
    {//미정
        yield return new WaitForSeconds(waittime);
        StartCoroutine(randomGame());        
    }
}
