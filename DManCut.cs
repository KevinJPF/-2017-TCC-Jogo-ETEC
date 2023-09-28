using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DManCut : MonoBehaviour {

	public GameObject dBox, image1, image2, image3, image4, image5, image6, image7, image8, image9, image10, cut;
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

		switch (currentLine) {
		case 0:
			image1.SetActive (true);
			break;
		case 1:
			image1.SetActive (false);
			image2.SetActive (true);
			break;
		case 2:
			image2.SetActive (false);
			image3.SetActive (true);
			break;
		case 3:
			image3.SetActive (false);
			image2.SetActive (true);
			break;
		case 6:
			image2.SetActive (false);
			image4.SetActive (true);
			break;
		case 7:
			image5.SetActive (false);
			image6.SetActive (true);
			break;
		case 8:
			image6.SetActive (false);
			image7.SetActive (true);
			break;
		case 9:
			image7.SetActive (false);
			image8.SetActive (true);
			break;
		case 10:
			image8.SetActive (false);
			image9.SetActive (true);
			break;
		case 11:
			image10.transform.localScale = new Vector2 (120, 120);
			image10.transform.position = new Vector2 (0, 0);
			break;
		case 12:
			image10.transform.localScale = new Vector3 (0, 0, 0);
			break;
		case 13:
			cut.SetActive (false);
			break;
		default:
			break;
		}

		if (dialogActive) {

			PauseMenu.timestop = true;
			dText.text = dialogLines[currentLine].Replace ("\\n", "\n");
			dName.text = names[currentLine];
		}

		if (dialogActive && Input.GetButtonDown("Submit"))
		{

			currentLine++;

		}

		if (currentLine >= dialogLines.Length) 
		{

			PauseMenu.timestop = false;
			dBox.SetActive(false);
			dialogActive = false;
			currentLine = 0;
			cut.SetActive (false);
		}
	}

	public void ShowDialog()
	{

		dialogActive = true;
		dBox.SetActive (true);
		cut.SetActive (true);

	}
}
