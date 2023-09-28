using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    private Transform player;
    public static float posY, add;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
		
        if (player.transform.rotation.y == 0)
        {
            if (player.transform.position.y > posY + 6)
            {
                Vector3 newPosition = new Vector3(player.position.x + 5, player.position.y+2, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 9);
            }
            else if (player.transform.position.y < posY - 6)
            {
                Vector3 newPosition = new Vector3(player.position.x + 5, player.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 6);
            }
            else
            {
				Vector3 newPosition = new Vector3(player.position.x + 5, posY + add, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 9);
            }
        }
        else
        {
            if (player.transform.position.y > posY + 6)
            {
                Vector3 newPosition = new Vector3(player.position.x - 5, player.position.y+2, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 9);
            }
            else if (player.transform.position.y < posY - 6)
            {
                Vector3 newPosition = new Vector3(player.position.x - 5, player.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 6);
            }
            else
            {
                Vector3 newPosition = new Vector3(player.position.x - 5, posY + add, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 9);
            }
        }
    }
}
