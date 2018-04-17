using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour {

    public static Transform[] point;
	void Awake () 
    {
        point = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            point[i] = transform.GetChild(i).transform;
        }
	}
}
