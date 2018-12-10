using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movechar : MonoBehaviour {

    public bool onGround;
    public Rigidbody rb;
    public Text Score;

    public KeyCode moveL;
    public KeyCode moveR;

    public float horizVel = 0;
    public int laneNum = 2;
    public string controlLocked = "n";

	// Use this for initialization
	void Start () {
        onGround = true;
        //rb = GetComponent<Rigidbody>();
        //rb.velocity = Vector3.forward * speed;
	}

	// Update is called once per frame
	void Update () {

        Score.text = "Score: " + GM.coinTotal.ToString();

		GetComponent<Rigidbody>().velocity = new Vector3 (horizVel,0,4);

		if ((Input.GetKeyDown(moveL)) && (laneNum>1) && (controlLocked == "n")){
            horizVel = -2;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controlLocked = "y";
		}

		if ((Input.GetKeyDown(moveR)) && (laneNum<3) && (controlLocked == "n")){
            horizVel = 2;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = "y";
		}

		//if (Input.GetKeyDown(moveU) && onGround){
        //    rb.velocity (horizVel,4,0);
        //    onGround = false;
		//}
	}

	void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "lethal"){
            Destroy(gameObject);
            GM.zVelAdj = 0;
        }
        if(other.gameObject.name == "Capsule(Clone)"){
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "ground"){
            onGround = true;
        }
	}

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Gate"){
            SceneManager.LoadScene("LvlComplete");
        }
        if(other.gameObject.name == "Coin(Clone)"){
            Destroy(other.gameObject);
            GM.coinTotal += 1;
        }
    }

	IEnumerator stopSlide(){
        yield return new WaitForSeconds(.5f);
        horizVel = 0;
        controlLocked = "n";
	}
}
