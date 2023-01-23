 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [Header("Positions")]

    public Vector3 pointA;
    public Vector3 pointB;
    public Vector3 target;
    
    [Header("Variables")]
    public float speed;

    void Start()
    {
        target = pointA;
    }

    // Update is called once per frame
    void Update()
    {   

        
        if(transform.position == pointA) //If we reached Point A
        {
            target = pointB;//lets go to Point B
        }
        if(transform.position == pointB)// If we reached Point B
        {
            target = pointA;//Lets go to Point A
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);//Move towards the targeted Point
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) //if player is on the platform
        {
            other.transform.parent = this.transform; //make the player be a part of the platform 
        }                                              //this will make the player move with the platform
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))//if the player leaves the platform
        {
            other.transform.parent = null;//make the player no longer be part of the platform
        }                                   //now the player moves freely no matter what the platform does
    }
}
