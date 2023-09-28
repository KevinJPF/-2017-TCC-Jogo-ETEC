using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour {

	//public string dialogue, name;
	private DialogManager dMan;
	public GameObject box;

	public string[] dialogLines, names;


	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag == "Player") 
		{
			if (!dMan.dialogActive) 
			{
				dMan.dialogLines = dialogLines;
				dMan.names = names;
				dMan.currentLine = 0;
				dMan.ShowDialogue ();
				box.gameObject.SetActive (false);
			}
		}
	}
}
