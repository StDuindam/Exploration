using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    //Visual jumptext
    [SerializeField]
    private Text jumpNumbers;
    private int jumpNum;

    //The data i want to print and read!
    
    
    //basic stuff
    public bool isGrounded = true;
    private bool isJumping = false;
    private Vector3 up = new Vector3(0,1,0);
    [SerializeField]
    private Animator animator;
    private Rigidbody rbody;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        jumpNum = 0;
	}
	
	//Input
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            Jump();
            isGrounded = false;
            }
	}

    //Jump up!
    public void Jump() {
        isJumping = true;
        rbody.AddForce(up * RandomJumpForce());
        animator.SetBool("Jump", true);
        animator.SetBool("Grounded", false);
        jumpNum += 1;
        jumpNumbers.text = ("Jumps: " + jumpNum);
        }

    //Back on the ground
    public void OnTriggerEnter(Collider col) {
        if (isJumping) {    
            animator.SetBool("Jump", false);
            animator.SetBool("Grounded", true);
            isGrounded = true;
            isJumping = false;
            }
        }
    private int RandomJumpForce() {
        return Random.Range(75, 200);
        }
}
