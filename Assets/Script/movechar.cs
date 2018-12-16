using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movechar : MonoBehaviour {
    private CharacterController controller;
    private Animator anim;
    public Transform CharacterGO;
    
    public bool onGround;
    public Rigidbody rb;
    public Text Score;
    
    public KeyCode moveL;
    public KeyCode moveR;
    public KeyCode Space;

    public float horizVel = 5;
    public float verVel = 0f;
    public float speed = 5;
    public int laneNum = 2;
    public string controlLocked = "n";
    public float horspd;
    public float gravity = 12;
    private Vector3 moveVector = Vector3.zero;


    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public static float forwardVel;
	// Use this for initialization
	void Start () {
        forwardVel = 4;
        onGround = true;
        rb = GetComponent<Rigidbody>();

        anim = CharacterGO.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        //rb.velocity = Vector3.forward * speed;
	}

	// Update is called once per frame
	void Update () {
        Debug.Log(controller.isGrounded);
        if(controller.isGrounded){
            // verVel = -0.5f;
        }   
        else{
            verVel -= gravity * Time.deltaTime;
        }

        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = speed;
        moveVector.y = verVel;
                
        // Physics.gravity = new Vector3(0, -1.0F, 0);
        controller.Move(moveVector * Time.deltaTime);
        Score.text = "Score: " + GM.coinTotal.ToString();

        
	}
    void IncreaseLevel(){
        GM.difficulty += 1;
    }

    void Fire()
    {

    
    // Create the Bullet from the Bullet Prefab
    var bullet = (GameObject)Instantiate (
        bulletPrefab,
        bulletSpawn.position,   
        bulletSpawn.rotation);

    // bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
    bullet.GetComponent<Rigidbody>().velocity = new Vector3 (horizVel , 0, 10 + GM.difficulty);

    Destroy(bullet, 2.0f);
    }

	void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "lethal"){
            Destroy(gameObject);
            Debug.Log("Dead");
            GM.zVelAdj = 0;
        }
        if(other.gameObject.name == "Capsule(Clone)"){
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "ground"){
            onGround = true;
            
        }
        
	}
     void OnCollisionExit(Collision other){
     if(other.gameObject.tag == "ground")
        {
         onGround = false;
        }
     }

    void OnTriggerEnter(Collider other){
        // if(other.gameObject.name == "Gate"){
        //     SceneManager.LoadScene("LvlComplete");
        // }
        if(other.gameObject.name == "Coin(Clone)"){
            Destroy(other.gameObject);
            GM.coinTotal += 1;
            if(GM.coinTotal % 5 == 0) IncreaseLevel();
        }
    }

	IEnumerator stopSlide(){
        yield return new WaitForSeconds(.5f);
        horizVel = 0;
        controlLocked = "n";
	}
}
