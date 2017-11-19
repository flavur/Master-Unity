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

	
	void Awake () {
        controlX = 0f;
        SetMinAndMaxX();
        CreateClouds();
	}
	
	void SetMinAndMaxX()
    {

        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }

    // shuffles the clouds array
    void Shuffle(GameObject[] arrayToShuffle)
    {
        for(int shuffleNum = 0; shuffleNum < arrayToShuffle.Length; shuffleNum++)
        {
            // re-positioning the variables and setting arrayToShuffle array variable to the random number
            GameObject temp = arrayToShuffle[shuffleNum];
            int randomNum = Random.Range(shuffleNum, arrayToShuffle.Length);
            arrayToShuffle[shuffleNum] = arrayToShuffle[randomNum];
            arrayToShuffle[randomNum] = temp;
        }
    }

    // creates the clouds and places them in the game
    void CreateClouds()
    {
        Shuffle(clouds);

        float posY = 0f;

        for(int i = 0; i < clouds.Length; i++)
        {
            // grab position of the selected cloud object
            Vector3 temp = clouds[i].transform.position;

            temp.y = posY;

            // control the position of the cloud placement
            // places clouds in a zig zag format
            if(controlX == 0)
            {
                // randomize the x axis position
                temp.x = Random.Range(0.0f, maxX);
                controlX = 1f;
            }
            else if (controlX == 1){
                // randomize the x axis position
                temp.x = Random.Range(0.0f, minX);
                controlX = 2f;
            }
            else if (controlX == 2)
            {
                // randomize the x axis position
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3f;
            }
            else if (controlX == 3)
            {
                // randomize the x axis position
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0f;
            }

            // reset the last cloud log to 0
            lastCloudPosY = posY;

            clouds[i].transform.position = temp;

            // create distance in the y axis between the spawned clouds
            posY -= distanceBetweenClouds;
        }
    }
}
