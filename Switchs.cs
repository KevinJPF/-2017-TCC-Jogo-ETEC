using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchs : MonoBehaviour {

	public GameObject crate, door;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D(Collider2D colisor) {
		if (colisor.gameObject == crate) { //Verifica se é a caixa quem esta em contato
			OpenDoor ();
		}
	}

	void OnTriggerExit2D(Collider2D colisor) {
		if (colisor.gameObject == crate) { //Verifica se é a caixa quem esta em contato
			CloseDoor ();
		}
	}

	void OpenDoor() {
		door.GetComponent<BoxCollider2D> ().enabled = false; //Desabilita a rigidez da porta
		door.GetComponent<Animator>().SetBool("Switch", true); //Muda a porta para aberta
	}

	void CloseDoor() {
		door.GetComponent<BoxCollider2D> ().enabled = true; //Habilita a rigidez da porta
		door.GetComponent<Animator>().SetBool("Switch", false); //Muda a porta para fechada
	}
}
