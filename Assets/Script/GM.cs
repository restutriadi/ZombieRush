using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    public static int coinTotal = 0;

    public static float zVelAdj = 1;

    public Transform area;
    public float zScenePos = 40;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        if(zScenePos < 100){
            Instantiate(area, new Vector3(0, 0, zScenePos), area.rotation);
            zScenePos += 4;
        }
	}
}
