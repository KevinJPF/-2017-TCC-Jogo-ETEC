using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText, dName;

	public bool dialogActive;

	public string[] dialogLines, names;
	public int currentLine;

	Player player = new Player();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (dialogActive) {

			PauseMenu.timestop = true;
			dText.text = dialogLines[currentLine].Replace ("\\n", "\n");
			dName.text = names[currentLine];
		}

		if (dialogActive && Input.GetButtonDown("Submit"))
		{

			//dBox.SetActive(false);
			//dialogActive = false;

			currentLine++;

		}

		if (currentLine >= dialogLines.Length) 
		{

			PauseMenu.timestop = false;
			dBox.SetActive(false);
			dialogActive = false;
			currentLine = 0;
		}

	}

	public void ShowDialogue()
	{

		dialogActive = true;
		dBox.SetActive (true);

	}
}
