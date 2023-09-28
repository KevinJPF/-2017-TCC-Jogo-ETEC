using UnityEngine;
using System.Collections;

public class JumpFlower : MonoBehaviour {

    public float jumpForce = 1000f;
    public Transform jumpFlower;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = jumpFlower.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (Player.falling)
        {
            colisor.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
            animator.SetBool("Jumping", true);
        }
        
    }
    void OnCollisionExit2D(Collision2D colisor)
    {
        animator.SetBool("Jumping", false);
    }
}
