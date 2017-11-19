using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;

        // width of the sprite
        float width = sr.sprite.bounds.size.x;

        // will calculate the world height which is represented by the camera
        float worldHeight = Camera.main.orthographicSize *2f;
        // calculates the width of the game screen
        float worldWidth = worldHeight/Screen.height * Screen.width;

        // calculates how the background will scale to fill the camera view
        tempScale.x = worldWidth / width;
        // updates the background scale
        transform.localScale = tempScale;
	}
	
	
}
