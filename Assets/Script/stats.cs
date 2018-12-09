using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour {

    // Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        GetComponent<TextMesh>().text = "Score : " + GM.coinTotal;
	}
}
