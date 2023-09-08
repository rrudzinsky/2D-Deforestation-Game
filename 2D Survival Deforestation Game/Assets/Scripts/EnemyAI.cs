using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        float distance = 100000000;
        float new_distance = 0;
        foreach (Transform g in GameObject.Find("Trees").transform.GetComponentsInChildren<Transform>())
        {
            new_distance = Vector2.Distance(g.transform.position, this.transform.position);
            if(distance > new_distance)
            {
                distance = new_distance;
                target = g.gameObject;
            }
        }


    }
    //move towards a target at a set speed.
    private void MoveTowardsTarget() {
        //the speed, in units per second, we want to move towards the target
        float speed = 0.5f;
        //move towards the center of the world (or where ever you like)
        Vector3 targetPosition = new Vector3(target.transform.position.x,
                                             target.transform.position.y,
                                             target.transform.position.z);

        Vector3 currentPosition = this.transform.position;
        //first, check to see if we're close enough to the target
        if(Vector3.Distance(currentPosition, targetPosition) > .1f) { 
            Vector3 directionOfTravel = targetPosition - currentPosition;
            //now normalize the direction, since we only want the direction information
            directionOfTravel.Normalize();  
            //scale the movement on each axis by the directionOfTravel vector components

            this.transform.Translate(
                (directionOfTravel.x * speed * Time.deltaTime),
                (directionOfTravel.y * speed * Time.deltaTime),
                (directionOfTravel.z * speed * Time.deltaTime),
                Space.World);
    }
}
    void Update()
    {
        MoveTowardsTarget();
    }
}
