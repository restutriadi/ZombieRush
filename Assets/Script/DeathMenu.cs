using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {

	public GameObject gameObject; 

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ToggleEndMenu(){
		gameObject.SetActive(true);
		Debug.Log("Menu");
        SceneManager.LoadScene("LvlComplete");

	}
}
