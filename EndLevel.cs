using UnityEngine;
using System.Collections;
public class EndLevel : MonoBehaviour {



    public bool select;
    public int lvl;

    Player player = new Player();
	Database db = new Database();
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
			Player.checkActived = false;
			if (select)
			{
				player.lvlNow = lvl;
			}
			if (Database.progresso == player.lvlNow) {
				Database.progresso++;
			}
			if (player.lvlNow == 1)
			{
				db.SalvarJogo ();
				Application.LoadLevel("lvl2");
			}else if (player.lvlNow == 2)
			{
				db.SalvarJogo ();
				Application.LoadLevel("lvl3");
			}else if (player.lvlNow == 3)
			{
				db.SalvarJogo ();
				Application.LoadLevel("lvl12");
			}
            else
			{
				db.SalvarJogo ();
                Application.LoadLevel("titleScreen");
            }
        }
    }
}
