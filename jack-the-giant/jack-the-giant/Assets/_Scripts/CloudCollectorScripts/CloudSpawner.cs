using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] clouds;
    [SerializeField] private GameObject[] collectible;

    // Distance on the y axis between the clouds
    private float distanceBetweenClouds = 3f;

    // these variables make sure that the clouds do not get placed outside of the camera on the x axis
    private float minX, maxX;

    // holds the last clouds y axis position
    private float lastCloudPosY;

    // control the x position of the clouds to make the cloud position random
    private float controlX;

    // used to position the player above the first cloud
    private GameObject player;

	
	void Awake () {
        controlX = 0f;
        SetMinAndMaxX();
        CreateClouds();
        // create a reference to the player
        player = GameObject.FindGameObjectWithTag("Player");
	}

    void Start()
    {
        PositionThePlayer();
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

    void PositionThePlayer()
    {
        // Collecting the cloud and deadly cloud gameobjects in the scene
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");

        for(int i = 0; i < darkClouds.Length; i++)
        {
            // if a dark cloud is positioned first in the scene
            if(darkClouds[i].transform.position.y == 0)
            {
                Vector3 tempPos = darkClouds[i].transform.position;
                // repositioning the dark cloud to the first regular cloud position
                darkClouds[i].transform.position = new Vector3(cloudsInGame[0].transform.position.x, cloudsInGame[0].transform.position.y, cloudsInGame[0].transform.position.z);
                // sets the first cloud position to be where the dark cloud position was
                cloudsInGame[0].transform.position = tempPos;
            }

            Vector3 tempPos1 = cloudsInGame[0].transform.position;

            for(int cloudCount = 1; cloudCount < cloudsInGame.Length; cloudCount++)
            {
                // used to place player above the first cloud
                if(tempPos1.y < cloudsInGame[cloudCount].transform.position.y)
                {
                    tempPos1 = cloudsInGame[cloudCount].transform.position;
                }
            }

            tempPos1.y += 0.8f;
            player.transform.position = tempPos1;

        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        // checks to see if the tag of the collided object is a cloud or a deadly cloud
        if(target.tag == "Cloud" || target.tag == "Deadly")
        {
            if(target.transform.position.y == lastCloudPosY)
            {
                Shuffle(clouds);
                Shuffle(collectible);

                Vector3 temp = target.transform.position;

                // controls cloud re-spawning
                for(int i = 0; i < clouds.Length; i++)
                {
                    // checks to see if previous cloud gameobjects are still active in the scene
                    if (!clouds[i].activeInHierarchy)
                    {
                        // control the position of the cloud placement
                        // places clouds in a zig zag format
                        if (controlX == 0)
                        {
                            // randomize the x axis position
                            temp.x = Random.Range(0.0f, maxX);
                            controlX = 1f;
                        }
                        else if (controlX == 1)
                        {
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

                        temp.y -= distanceBetweenClouds;

                        // sets the new last cloud position
                        lastCloudPosY = temp.y;

                        // updates the position of the cloud
                        clouds[i].transform.position = temp;
                        // makes the cloud visible and active in the scene
                        clouds[i].SetActive(true);
                    }
                }
            }
        }
    }
}
