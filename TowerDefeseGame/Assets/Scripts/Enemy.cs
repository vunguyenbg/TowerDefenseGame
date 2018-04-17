using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Transform target;
    private int index = 0;
    private float speed = 5.0f;
	void Start () 
    {
        target = WayPoints.point[index];
	}
	
	void Update () 
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position , target.position) <= 0.2f)
        {
            NextWayPoint();
        }
	}
    void NextWayPoint()
    {
        if (index >= WayPoints.point.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        index++;
        target = WayPoints.point[index];
    }
}
