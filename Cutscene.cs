using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour {
	
	//public string dialogue, name;
	private DManCut dMano;
	public GameObject box;

	public string[] dialogLines, names;


	// Use this for initialization
	void Start () {
		dMano = FindObjectOfType<DManCut>();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag == "Player") 
		{
			if (!dMano.dialogActive) 
			{
				dMano.dialogLines = dialogLines;
				dMano.names = names;
				dMano.currentLine = 0;
				dMano.ShowDialog();
				box.gameObject.SetActive (false);
			}
		}
	}

}
