using UnityEngine;
using System.Collections;
using System;

public class FallingPlatform : MonoBehaviour {

	private bool touched = false, falling = false;
	private float respawn = 2, timeFall, timeToFall;
	RigidbodyConstraints2D x, z;
	Vector3 oldPosition = new Vector3();
	public GameObject plat, prefab;

	// Use this for initialization
	void Start () {
		oldPosition = plat.transform.position;
		GameObject tempPlatf = Instantiate (prefab) as GameObject;
	}

	// Update is called once per frame
	void Update () {

		if (touched) {
			timeToFall += Time.deltaTime;
		}

		if (timeToFall >= 2)
		{
			plat.AddComponent<Rigidbody2D> ();

			timeFall += Time.deltaTime;

			if (timeFall >= respawn) {
				plat.GetComponent<Rigidbody2D> ().gravityScale = 0;
				plat.transform.position = oldPosition;
				timeToFall = 0;
				timeFall = 0;
				touched = false;
				Destroy (plat);
				Spawn ();
			}

		}
	}

	void OnCollisionEnter2D(Collision2D colisor)
	{
		touched = true;
	}

	void OnCollisionStay2D(Collision2D colisor)
	{
		if (colisor.gameObject.tag == "Player") {
			colisor.gameObject.transform.parent = transform;
		} else {
			plat.GetComponent<BoxCollider2D> ().enabled = false;
		}

	}

	void OnCollisionExit2D(Collision2D colisor)
	{
		/*if (colisor.gameObject.name == "Player")
        {
            colisor.gameObject.transform.parent = null;
        }*/
		colisor.gameObject.transform.parent = null;
	}

	void Spawn()
	{
		GameObject tempPlatf = Instantiate (prefab) as GameObject;
	}
}
