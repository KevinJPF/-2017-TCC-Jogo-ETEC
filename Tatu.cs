using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Tatu : MonoBehaviour {

    Player player = new Player();

    private float speed = 6f, distanceActual;
    public bool side;
    public float distanceTotal;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        Movement();
    }

    void Movement()
    {

        if (!side)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        distanceActual += Time.deltaTime;

        if (distanceActual >= distanceTotal)
        {
            distanceActual = 0;
            side = !side;
        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        var player1 = colisor.gameObject.GetComponent<Player>();
        if (colisor.gameObject.tag == "Player")
        {
            if (Player.falling == true)
            {
				Player.iniDerrotados ++;
                colisor.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 700f);
                Destroy(gameObject);
            }
            else
            {
                if (!Player.immunity)
				{
					colisor.gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.right * 1000f);
					colisor.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 1200f);
                    player1.DamageLife(1);
                    player1.Immune(3);
                }
            }
            
        }

    }
}
