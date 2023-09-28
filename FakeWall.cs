using UnityEngine;
using System.Collections;

public class FakeWall : MonoBehaviour {

	public GameObject wall, wallE;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

    }

    void OnTriggerStay2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            wall.GetComponent<MeshRenderer>().enabled = false;
            wallE.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            wall.GetComponent<MeshRenderer>().enabled = true;
            wallE.GetComponent<MeshRenderer>().enabled = true;
        }
        
    }
}
