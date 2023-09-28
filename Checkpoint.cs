using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {


	Database db = new Database ();
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
			Database.quantidade = Player.coins;
			Database.inimigos = Player.iniDerrotados;

            Player.checkpoint = transform.position;
            Player.checkActived = true;
        }
    }
}
