using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saci : MonoBehaviour {

	private float tempoAtq, h, tonto, cooldown;
	public static bool atacou;

	public int velocidade, hpAct;
	private int hpMax = 3;

	public GameObject stars, player, end;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = gameObject.transform.GetComponent<Animator>();
		hpAct = 1;
	}
	
	// Update is called once per frame
	void Update () {

		var distancia = (player.transform.position.x);

		if (hpAct <= 0) {
			cooldown += Time.deltaTime;
			if (cooldown >= -3) {
				Destroy (gameObject);
				end.SetActive (true);
			}
		}

		if (distancia > transform.position.x) {
			h += Time.deltaTime;
			if (h >= 2) {
				transform.eulerAngles = new Vector2 (0, 0);
				h = 0;
			}

		} else {
			h += Time.deltaTime;
			if (h >= 2) {
				transform.eulerAngles = new Vector2 (0, 180);
				h = 0;
			}
		}
		if (cooldown >= 3) {
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			if (tonto >= 10) {
				atacou = false;
				animator.SetBool ("walking", false);
				animator.SetBool ("movement", false);
				animator.SetBool ("stunned", true);
				stars.SetActive (true);
				tonto += Time.deltaTime;
				if (tonto >= 15) {
					tonto = 0;
					animator.SetBool ("stunned", false);
					stars.SetActive (false);
				}
			} else {
				Atacando ();
			}
		} else {
			gameObject.GetComponent<SpriteRenderer> ().enabled = !gameObject.GetComponent<SpriteRenderer> ().enabled;
			cooldown += Time.deltaTime;
		}

	}

	void OnCollisionEnter2D(Collision2D colisor)
	{
		if (colisor.gameObject.tag == "Player") {
			var player = colisor.gameObject.GetComponent<Player>();
			if (tonto >= 10 && Player.falling) {
				colisor.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 700f);
				DamageSaci (1);
				SaciImune();
				if (hpAct <= 0) {
					cooldown = -6;
				} else {
					tonto = 0;
				}
			}
			if (atacou) {
				tonto = 10;
				player.DamageLife (1);
				player.Immune (3);
			}
		}


	}

	void SaciImune()
	{
		animator.SetBool ("stunned", false);
		stars.SetActive (false);
		tonto = 0;
		cooldown = 0;
	}

	void DamageSaci(int dano)
	{
		hpAct = hpAct - dano;
	}

	void Atacando()
	{
		if (!atacou) {
			animator.SetBool ("movement", true);
			tempoAtq += Time.deltaTime;
			if (tempoAtq >= 0.2) {
				//Instantiate (ataque, transform.position, transform.rotation);
				tempoAtq = 0;
				animator.SetBool ("walking", true);
				//animator.SetBool ("movement", false);
				atacou = true;
			}
		}

		if (atacou) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
			tonto += Time.deltaTime;
		}
	}
}
