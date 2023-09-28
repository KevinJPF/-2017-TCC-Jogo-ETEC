using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FalledDown : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D (Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            var p = colisor.gameObject.GetComponent<Player>();
            p.DamageLife(3);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
			Destroy(colisor);
        }
        
    }
}
