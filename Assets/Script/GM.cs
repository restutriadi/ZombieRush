using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    public static int coinTotal = 0;

    public static float zVelAdj = 1;

    public Transform area;
    public float zScenePos = 12;

    public Transform coinObj;
    public Transform capsuleObj;
    public Transform obstacleObj;

    public int randNum;

	// Use this for initialization
	void Start () {
        
	}

	// Update is called once per frame
	void Update () {
        if(zScenePos < 100){

            Instantiate(area, new Vector3(0, 0, zScenePos), area.rotation);
            zScenePos += 4;

            randNum = Random.Range(0, 12);

            if(randNum<=2){
                Instantiate(coinObj, new Vector3(-1, 1, zScenePos), coinObj.rotation);
            }

            if(randNum>2 && randNum<=5){
                Instantiate(coinObj, new Vector3(0, 1, zScenePos), coinObj.rotation);
            }

            if(randNum>5 && randNum<=8){
                Instantiate(coinObj, new Vector3(1, 1, zScenePos), coinObj.rotation);
            }

            if(randNum==9){
                Instantiate(obstacleObj, new Vector3(-1, 1, zScenePos), obstacleObj.rotation);
            }

            if(randNum==10){
                Instantiate(obstacleObj, new Vector3(0, 1, zScenePos), obstacleObj.rotation);
            }

            if(randNum==11){
                Instantiate(obstacleObj, new Vector3(1, 1, zScenePos), obstacleObj.rotation);
            }

            if(randNum==12){
                Instantiate(capsuleObj, new Vector3(0, 1, zScenePos), capsuleObj.rotation);
            }
        }
	}
}
