using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float playerSpeed = 8f;
    public float maxVelocity = 4f;

    private Rigidbody2D myBody;
    private Animator myAnim;

    public void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        PlayerMoveKeyboard();
	}

    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        //Player is moving to the right
        if(h > 0)
        {
            if(vel < maxVelocity)
            {
                forceX = playerSpeed;
            }
            myAnim.SetBool("isWalk",true);
            //face the player to the right
            Vector3 newScale = transform.localScale;
            newScale.x = 1.2f;
            transform.localScale = newScale;
        }
        //Player is moving to the left
        else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                forceX = -playerSpeed;
            }
            myAnim.SetBool("isWalk", true);
            //face the player to the left
            Vector3 newScale = transform.localScale;
            newScale.x = -1.2f;
            transform.localScale = newScale;
        }
        //Player is not moving
        else
        {
            myAnim.SetBool("isWalk", false);
        }

        myBody.AddForce(new Vector2(forceX, 0));
    }
}
