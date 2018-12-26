using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	public GameObject gameObject; 

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
		Debug.Log("mati");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ToggleEndMenu(){
		Debug.Log("aktif");
		gameObject.SetActive(true);
		Debug.Log("Menu");
        SceneManager.LoadScene("LvlComplete");
	}
}
