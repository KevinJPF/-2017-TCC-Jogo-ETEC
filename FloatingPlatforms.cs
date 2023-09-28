using UnityEngine;
using System.Collections;
using System;

public class FloatingPlatforms : MonoBehaviour {

    public bool move, up, side, right;
    public float speed, moveMax;
    private float actualDist, timeFall = 3, timeToFall = 1, timeMovin;
    private bool fallingg;
    Vector3 oldPosition = new Vector3();

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (move)
        {
            timeMovin += Time.deltaTime;

            if (timeMovin >= moveMax)
            {
                timeMovin = 0;
                right = !right;
                up = !up;
            }

            if (side)
            {
                if (right)
                {
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                }
                else if (!right)
                {
                    transform.Translate(-Vector2.right * speed * Time.deltaTime);
                }
            }
            else
            {
                if (up)
                {
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                }
                else if (!up)
                {
                    transform.Translate(-Vector2.up * speed * Time.deltaTime);
                }
            }
            
        }
	}

    void OnCollisionEnter2D(Collision2D colisor)
    {
        
    }

    void OnCollisionStay2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            colisor.gameObject.transform.parent = transform;
        }
        //colisor.gameObject.transform.parent = transform;
    }

    void OnCollisionExit2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            colisor.gameObject.transform.parent = null;
        }
        //colisor.gameObject.transform.parent = null;
    }
}
