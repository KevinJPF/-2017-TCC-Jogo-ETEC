using UnityEngine;
using System.Collections;

public class HpItem : MonoBehaviour {

    public bool up;
    public float speed, moveMax;
    private float timeMovin;

    Player player = new Player();

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {

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

    void OnTriggerEnter2D(Collider2D colisor)
    {
        var player1 = colisor.gameObject.GetComponent<Player>();
		if (Player.actLifeP <= 2) {
			player1.RestoreLife(1);
			Destroy(gameObject);
		}
        
    }

}

