using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectables : MonoBehaviour {

	// Use this for initialization
	public bool up, isCoin;
	public float speed, moveMax;
	private float timeMovin;

	Player player = new Player();

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update() {
		if (!isCoin) 
		{
			timeMovin += Time.deltaTime;

			if (timeMovin >= moveMax)
			{
				timeMovin = 0;
				up = !up;
			}
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

	void OnTriggerEnter2D(Collider2D colisor)
	{
		var player1 = colisor.gameObject.GetComponent<Player>();

		if (colisor.gameObject.tag == "Player")
		{
			if (isCoin) {
				Destroy (gameObject);
				player1.AddCoin (1);
			}
		}
	}
}
