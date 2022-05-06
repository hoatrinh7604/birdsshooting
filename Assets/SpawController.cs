using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawController : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] Transform spawPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] float delayTime = 2f;
    [SerializeField] float delayMinTime = 2f;
    [SerializeField] float delayMaxTime = 2f;
    [SerializeField] float speedObj = 5f;
    private float time;

    [SerializeField] bool isRight;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > delayTime)
        {
            SpawObject();
            time = 0;
            delayTime = Random.Range(delayMinTime, delayMaxTime);
        }
    }

    void SpawObject()
    {
        int index = Random.Range(0, objects.Length);
        GameObject obj = Instantiate(objects[index]);
        if(isRight)
        {
            obj.GetComponent<SpriteRenderer>().flipX = true;
        }    
        obj.GetComponent<MovingController>().Settarget(endPoint);
        obj.GetComponent<MovingController>().UpdateSpeed(speedObj);
        obj.transform.position = spawPoint.position;
    }

    public void UpdateSpeed()
    {
        speedObj += 1;
    }
}
