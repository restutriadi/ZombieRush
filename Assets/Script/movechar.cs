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
    public KeyCode Space;

    public float horizVel = 0;
    public int laneNum = 2;
    public string controlLocked = "n";
    public float horspd;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

	// Use this for initialization
	void Start () {
        onGround = true;
        rb = GetComponent<Rigidbody>();
        //rb.velocity = Vector3.forward * speed;
	}

	// Update is called once per frame
	void Update () {
        Physics.gravity = new Vector3(0, -1.0F, 0);
        Score.text = "Score: " + GM.coinTotal.ToString();
        horizVel = Input.GetAxis("Horizontal") * horspd;
        // Debug.log(horizVel);
		rb.velocity = new Vector3 (horizVel,0,4);

		if (!onGround){
           rb.velocity = new Vector3(horizVel,4,0);
            //onGround = false;
		}
        if(Input.GetKeyDown(Space)){
            Fire();

        }

	}


    void Fire()
{

    
    // Create the Bullet from the Bullet Prefab
    var bullet = (GameObject)Instantiate (
        bulletPrefab,
        bulletSpawn.position,
        bulletSpawn.rotation);

    // bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
    bullet.GetComponent<Rigidbody>().velocity = new Vector3 (horizVel,0,10);

    Destroy(bullet, 2.0f);
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
        // if(other.gameObject.name == "Gate"){
        //     SceneManager.LoadScene("LvlComplete");
        // }
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
