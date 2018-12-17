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
    private GameObject newProjectile;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public static float forwardVel;
    public static bool DeathStatus;
    public DeathMenu deathmenu;
	// Use this for initialization
	void Start () {
        DeathStatus = false;
        forwardVel = 4;
        onGround = true;
        rb = GetComponent<Rigidbody>();
        anim = CharacterGO.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        //rb.velocity = Vector3.forward * speed;
	}

	// Update is called once per frame
	void Update () {
        if(DeathStatus == true) {
            deathmenu.ToggleEndMenu();
            // SceneManager.LoadScene("LvlComplete");
            // Debug.Log("bisa");
            return;
        };
        // Debug.Log(controller.isGrounded);
        if(controller.isGrounded){
            // verVel = -0.5f;
        }   
        else{
            verVel -= gravity * Time.deltaTime;
        }

        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = speed + GM.difficulty;
        moveVector.y = verVel;
                
        // Physics.gravity = new Vector3(0, -1.0F, 0);
        controller.Move(moveVector * Time.deltaTime);
        Score.text = "Score: " + GM.coinTotal.ToString();
        if(Input.GetKeyDown(KeyCode.Space)){
            // temp.x = transform.position.x;
            // temp.y = transform.position.y;
            // temp.z = transform.position.z + 4;
            // transform.position = temp;
            // newProjectile = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
            // newProjectile.GetComponent<Rigidbody>().velocity = ;
            Fire();
        };

        // Debug.Log(transform.position.x);
        
	}
    void IncreaseLevel(){
        GM.difficulty += 1;
    }

    void Fire()
    {

    Vector3 temp = new Vector3();

    // Create the Bullet from the Bullet Prefab
            temp.x = transform.position.x;
            temp.y = transform.position.y + 1;
            temp.z = transform.position.z + 4;

    // var bullet = 
    //     (GameObject)Instantiate (
    //     bulletPrefab,
    //     temp,   
    //     bulletSpawn.rotation);
        newProjectile = Instantiate(bulletPrefab, temp, transform.rotation) as GameObject;
        // bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
        // bullet.GetComponent<Rigidbody>().velocity = new Vector3(speed * Time.deltaTime * 100, 0, 0);
        newProjectile.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 7);

        Destroy(newProjectile, 2.0f);
    }


     void OnCollisionExit(Collision other){


     }

    void OnTriggerEnter(Collider other){
        
        if(other.gameObject.tag == "lethal"){
            // Destroy(gameObject);
            // Debug.Log("Dead");
            GM.zVelAdj = 0;
            Death();
        }
        
        if(other.gameObject.name == "Capsule(Clone)"){
            Destroy(other.gameObject);

        }        


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

    void Death(){
        DeathStatus = true;
    }
}
