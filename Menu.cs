using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	private bool wselect, sselect;
	public static bool backWSelect;

	public GameObject main, worlds, slots, lvl1;
	GameObject used;
    
    Player player = new Player();

    // Use this for initialization
    void Start () {

		Player.checkActived = false;

		if (backWSelect) {
			wselect = true;
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (wselect) {
			main.SetActive (false);
			slots.SetActive (false);
			worlds.SetActive (true);

			if (Database.progresso >= 2) {
				used = GameObject.Find ("lvl2");
				used.GetComponent<Button> ().interactable = true;
			} 
			if (Database.progresso >= 3) {
				used = GameObject.Find ("lvl3");
				used.GetComponent<Button> ().interactable = true;
			} 
			if (Database.progresso >= 4) {
				used = GameObject.Find ("lvl12");
				used.GetComponent<Button> ().interactable = true;
			}

		} else if (sselect) {
			main.SetActive (false);
			worlds.SetActive (false);
			slots.SetActive (true);
		}else
		{
			main.SetActive (true);
			worlds.SetActive (false);
			slots.SetActive (false);
		}
	}

	public void StartGame()
	{
		sselect = true;
	}

	public void NovoGames()
	{
		if (Database.newGame) {
			WSelectForest1 ();
		} else {
			sselect = false;
			wselect = true;
		}
	}

	public void LoadGame()
	{
		sselect = true;
		Database.newGame = false;
	}

	public void Options()
	{

	}

    public void ExitGame()
    {
		Application.Quit ();
	}

	public void WSelectForest1()
	{
		Application.LoadLevel("lvl1");
	}

	public void WSelectForest2()
	{
		Application.LoadLevel("lvl2");
	}

	public void WSelectForest3()
	{
		Application.LoadLevel("lvl3");
	}

	public void WSelectCave1()
	{
		Application.LoadLevel("lvl12");
	}

	public void WSelectCity1()
	{
		Application.LoadLevel("lvl13");
	}

	public void BackMainMenu()
	{
		wselect = false;
		sselect = false;
	}
}
