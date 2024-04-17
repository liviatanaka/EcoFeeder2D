using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{

    private Transform targetObj;
    // Start is called before the first frame update
    void Start()
    {
        targetObj = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, targetObj.position, 1*Time.deltaTime);
    }
}
