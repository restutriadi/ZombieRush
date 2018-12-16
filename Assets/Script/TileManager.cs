using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public GameObject[] tilePrefabs;
	public Transform playerTransform;
	public float tilelength = 2.0f; 
	public float spawnZ = 0f;
	public float zScenePos = 12;
	
	public int amnTilesOnScreen = 14; 
	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		SpawnTile();
		SpawnTile();
		SpawnTile();
		SpawnTile();
		for (int i = 0; i < amnTilesOnScreen; i ++){
			SpawnTile();

		}

	}
	
	// Update is called once per frame
	void Update () {
		if(playerTransform.position.z > (spawnZ - amnTilesOnScreen * tilelength)){
			SpawnTile();
		}
	}

	void SpawnTile(int prefabIndex = -1){
		GameObject go;
		go = Instantiate(tilePrefabs[0]) as GameObject;
		go.transform.SetParent(transform);
		// go.transform.position = Vector3.forward * spawnZ;
		// spawnZ += tilelength;
		Instantiate(tilePrefabs[0], new Vector3(0, 0, zScenePos), transform.rotation);
         zScenePos += 4;
    
	}
}
