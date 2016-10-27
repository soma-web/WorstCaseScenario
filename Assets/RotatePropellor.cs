using UnityEngine;
using System.Collections;

public class RotatePropellor : MonoBehaviour {

    public static bool doNotRotatePropellers = false;
	
	// Update is called once per frame
	void Update () {
        if(!doNotRotatePropellers)
        transform.RotateAround(transform.up, Mathf.Deg2Rad * 30f);
	}
}
