using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI, HUD;

	public Text nCoin, nHP, nIni;

	public static int lvlact;

	public static bool timestop;

	private bool paused = false, gameOver = false;

	Player player = new Player();

	// Use this for initialization
	void Start () {

		PauseUI.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Pause")) {

			paused = !paused;
			timestop = !timestop;

		}

		if (timestop) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}

		if (paused) {

			PauseUI.SetActive(true);
			HUD.SetActive (false);

		}

		if (!paused) {

			PauseUI.SetActive(false);
			HUD.SetActive (true);

		}

		nCoin.text = Player.coins.ToString();
		nHP.text = Player.actLife.ToString();
		nIni.text = Player.iniDerrotados.ToString();


	}

	public void MainMenu()
	{
		Player.checkActived = false;
		Application.LoadLevel("titleScreen");
	}

	public void TryAgain()
	{
		switch (lvlact) {
		case 1:
			Player.checkActived = false;
			Database.vidaA = 3;
			Application.LoadLevel("lvl1");
			break;
		case 2:
			Player.checkActived = false;
			Database.vidaA = 3;
			Application.LoadLevel("lvl2");
			break;
		case 3:
			Player.checkActived = false;
			Database.vidaA = 3;
			Application.LoadLevel("lvl3");
			break;
		case 4:
			Player.checkActived = false;
			Database.vidaA = 3;
			Application.LoadLevel("lvl12");
			break;
		default:
			break;
		}
	}

	public void TryAgainMeOver()
	{
		switch (lvlact) {
		case 1:
			Database.vidaA = 3;
			Application.LoadLevel("lvl1");
			break;
		case 2:
			Database.vidaA = 3;
			Application.LoadLevel("lvl2");
			break;
		case 3:
			Database.vidaA = 3;
			Application.LoadLevel("lvl3");
			break;
		case 4:
			Database.vidaA = 3;
			Application.LoadLevel("lvl12");
			break;
		default:
			break;
		}
	}

	public void Continuar()
	{
		paused = false;
		timestop = false;
	}
}
