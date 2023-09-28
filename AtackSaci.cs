using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackSaci : MonoBehaviour {

	public int velocidade;

	Player player = new Player();

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * velocidade * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag == "Player") {
			player.Immune (3);
			player.DamageLife (1);
		}
		//Destroy (gameObject);
	}
}
