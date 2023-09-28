using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed, jumpSpeed;
	private float positionY=0, timeImmune, maxImmune, stuck;

	private bool isOnFloor;
	public static bool jumping, falling, immunity, checkActived;

	public Transform floorVerificator, spritePlayer;

	public static int maxLife = 3, coins, actLife, potions, speedPower1;
	public static int actLifeP, onSwitchs, iniDerrotados;
	public int lvlNow;

	public static Vector3 checkpoint;

    private Animator animator;

	public GameObject hpFull, hpOL, hpTL, hpEmpty, power1;

	public Text coinsAct, potionsAct;

	// Use this for initialization
	void Start () {
        animator = spritePlayer.GetComponent<Animator>();

		actLife = Database.vidaA;
		iniDerrotados = Database.inimigos;
		coins = Database.quantidade;

		PauseMenu.lvlact = lvlNow;

		if (checkActived)
		{
			spritePlayer.transform.position = checkpoint;
		}
    }
	
	// Update is called once per frame
	void Update () {
		//Moedas e poções
		coinsAct.text = coins.ToString();
		potionsAct.text = potions.ToString();

		stuck += Time.deltaTime;
		animator.SetFloat("stuck", stuck);

		if (Time.timeScale == 1) //Se o jogo não está pausado ele movimenta
		{
			animator.speed = 1;
			Movimentation ();
		} 
		else 
		{
			animator.speed = 0;
		}

        if (Input.GetButtonDown("Fire3")) //Volta ao menu principal
        {
            Application.LoadLevel("titleScreen");
        }

		if (immunity) //Torna o personagem imune por um periodo de tempo(maxImmune)
        {
            timeImmune += Time.deltaTime;

			gameObject.GetComponent<SpriteRenderer> ().enabled = !gameObject.GetComponent<SpriteRenderer> ().enabled;

            if (timeImmune >= maxImmune)
            {
				gameObject.GetComponent<SpriteRenderer> ().enabled = true;
                timeImmune = 0;
                immunity = false;
            }
        }

		ActLife ();

		if (Input.GetButtonDown("Fire1"))
		{
			PowerOne ();
		}

    }

    void Movimentation()
    {
        isOnFloor = Physics2D.Linecast(transform.position, floorVerificator.position, 1 << LayerMask.NameToLayer("Floor")); 

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
			stuck = 0;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
			stuck = 0;
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            Camera.add = 7.5f;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            Camera.add = -1.5f;
		}
        else
        {
            Camera.add = 4.5f;
		}

        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * jumpSpeed);
            jumping = true;
            positionY = transform.position.y;
        }


        if (jumping == true)
		{
			animator.SetBool("fall", true);
			stuck = 0;
            if (positionY > transform.position.y)
            {
                jumping = false;
				falling = true;
            }
            positionY = transform.position.y;
        }

        if (isOnFloor)
        {
			falling = false;
			animator.SetBool("fall", false);
            Camera.posY = gameObject.transform.position.y;
        }
        else
        {
			falling = true;
        }


		animator.SetFloat("movement", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
    }

    public void DamageLife(int dam)
    {
		if (!immunity) {
			actLife -= dam;
			if (actLife <= 0)
			{
				OnLoseLife();
			}
		}
        
    }

    public void RestoreLife(int res)
    {
        actLife += res;
    }

	public void ActLife()
	{
		actLifeP = actLife;
		if (actLife == 3) {
			hpFull.SetActive(true);
			hpOL.SetActive(false);
			hpTL.SetActive(false);
			hpEmpty.SetActive(false);
		}
		if (actLife == 2)
		{
			hpFull.SetActive(false);
			hpOL.SetActive(true);
			hpTL.SetActive(false);
			hpEmpty.SetActive(false);
		}
		if (actLife == 1)
		{
			hpFull.SetActive(false);
			hpOL.SetActive(false);
			hpTL.SetActive(true);
			hpEmpty.SetActive(false);
		}
		if (actLife <= 0)
		{
			hpFull.SetActive(false);
			hpOL.SetActive(false);
			hpTL.SetActive(false);
			hpEmpty.SetActive(true);
			actLifeP = actLife;
		}
	}

    public void Immune(float sec)
    {
        maxImmune = sec;
        immunity = true;
    }

    public void OnLoseLife()
    {
        /*if (checkActived)
        {
            spritePlayer.transform.position = checkpoint;
        }
        else
        {*/
		Application.LoadLevel("Game Over");
		
        //}
	}

	public void AddCoin(int coin)
	{
		coins += coin;
		coinsAct.text = coins.ToString();
	}

	public void AddPotion(int Potion)
	{
		potions += Potion;
	}

	void PowerOne() {
		float timePower1 = 0;
		/*do {
			power1.transform.Translate(Vector2.right * speedPower1 * Time.deltaTime);
			//timePower1 += Time.deltaTime;
		} while (timePower1 <= 3);*/
	}
}
