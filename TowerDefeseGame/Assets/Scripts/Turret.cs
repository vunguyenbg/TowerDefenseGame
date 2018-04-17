using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameObject target;
    public float radius = 15;
    public string enemyTag = "Enemy";
    public GameObject tr;
    public float turnSpeed = 5;
	void Start () 
    {
        InvokeRepeating("UpdateTarget", 0, 0.5f);
	}
	
	void Update () 
    {
        if (target  == null)
        {
            return;
        }
        else
        {
            Vector3 dir = target.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(tr.transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            tr.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
	}
    void UpdateTarget() 
    {
        GameObject[] enemies = null;
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEmeny = null;

        foreach (GameObject item in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, item.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEmeny = item;
            }
        }

        if (nearestEmeny != null && shortestDistance < radius)
        {
            target = nearestEmeny;
        }
        else
        {
            target = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
