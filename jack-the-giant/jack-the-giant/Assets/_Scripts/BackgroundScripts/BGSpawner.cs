using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour {

    private GameObject[] backgrounds;
    private float lastY;

	// Use this for initialization
	void Start () {
        GetBackgroundAndSetLastY();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GetBackgroundAndSetLastY()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        lastY = backgrounds[0].transform.position.y;
        
        for(int i = 1; i < backgrounds.Length; i++)
        {
            // checks to see if the lastY position is greater than the objects in the backgrounds array since the camera is moving down
            if(lastY > backgrounds[i].transform.position.y)
            {
                lastY = backgrounds[i].transform.position.y;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Background")
        {
           if(collision.transform.position.y == lastY)
            {
                Vector3 temp = collision.transform.position;
                float height = ((BoxCollider2D)collision).size.y;

                for(int i = 0; i < backgrounds.Length; i++)
                {
                    // checks if the background image is active
                    // if the background image is not active then proceed with the loop
                    if (!backgrounds[i].activeInHierarchy)
                    {
                        temp.y -= height;
                        lastY = temp.y;
                        backgrounds[i].transform.position = temp;
                        backgrounds[i].SetActive(true);
                    }
                }
            }
        }    
    }
}
