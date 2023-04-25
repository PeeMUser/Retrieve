using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public float moveSpeed;
    public GameObject[] wayPoints;
    private Animator anim;
    int nextWaypoints = 1;
    float distToPoint;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
        

    }

     void Move()
    {
        
        distToPoint = Vector2.Distance(transform.position, wayPoints[nextWaypoints].transform.position);
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[nextWaypoints].transform.position, moveSpeed * Time.deltaTime);
        if(moveSpeed >= 0.1)
        {
            anim.SetBool("Walking", true);
        }
        if(distToPoint < 0.2f)
        {
            TakeTurn();
        }
    }
    void TakeTurn()
    {
        Vector3 currRot = transform.eulerAngles;
        currRot.z += wayPoints[nextWaypoints].transform.eulerAngles.z;
        transform.eulerAngles = currRot;
        ChooseNextWaypoint();
    }

    void ChooseNextWaypoint()
    {
        nextWaypoints++;
        if(nextWaypoints == wayPoints.Length)
        {
            nextWaypoints = 0;
        }
    }

}
