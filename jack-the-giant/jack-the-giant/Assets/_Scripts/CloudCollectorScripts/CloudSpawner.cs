using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] clouds;

    // Distance on the y axis between the clouds
    private float distanceBetweenClouds = 3f;

    // these variables make sure that the clouds do not get placed outside of the camera on the x axis
    private float minX, maxX;

    // holds the last clouds y axis position
    private float lastCloudPosY;

    // control the x position of the clouds to make the cloud position random
    private float controlX;

    [SerializeField] private GameObject[] collectible;

    // used to position the player above the first cloud
    private GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
