using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}

     void OnCollisionExit(Collision other){


     }


    void OnTriggerEnter(Collider other){
        
        if(other.gameObject.tag == "lethal"){
        	Destroy(other.gameObject);
        	Debug.Log("kena");
			GM.poinTotal += 1;
        }
        
        // if(other.gameObject.name == "Capsule(Clone)"){

        // }        

        // if(other.gameObject.name == "Coin(Clone)"){
            // GM.coinTotal += 1;
            // if(GM.coinTotal % 5 == 0) IncreaseLevel();
        // }

    }
}
