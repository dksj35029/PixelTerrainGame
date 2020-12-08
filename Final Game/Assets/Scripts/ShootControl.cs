using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{

	
	private Transform target;
	private PlayerControls playerControls;
	private Rigidbody2D rigidBody;
	private Collider2D collider;
	private SpriteRenderer spriteRenderer;
	public bool currentlyShooting = false;
	[SerializeField] public float shootingDistance,speed;
	[SerializeField] private float strength;
	public GameObject playerDetails; //retrieve player info
	public GameObject enemyDetails; //retrieve enemy info
	
	private void Awake(){
		playerControls = new PlayerControls();
		rigidBody = GetComponent<Rigidbody2D>();
		collider = GetComponent<Collider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	private void OnEnable(){
		playerControls.Enable();
	}
	
	private void OnDisable(){
		playerControls.Disable();
	}

    // Start is called before the first frame update
    void Start()
    {
		spriteRenderer.enabled = false;
		collider.enabled = false;
        resetPos();
    }
	
    // Update is called once per frame
    void Update()
    {
     	Move();	
    }
	
	public void resetPos(){
		currentlyShooting = false;
		collider.enabled = false;
		spriteRenderer.enabled = false;
		Vector3 currentPos = transform.position;
		float playerPosition = playerDetails.GetComponent<PlayerMove>().getPositionX();
		bool facingRight = playerDetails.GetComponent<PlayerMove>().facingRight();
		if(facingRight){
			currentPos.x = playerPosition + 1.08f - 0.4772741f + 1.2f;
		} else {
			currentPos.x = playerPosition - 0.8f + 0.4772741f - 1.2f;
		}
		transform.position = currentPos;
	}
	
	private void Move(){
		//read movement value
		float movementInput = playerControls.Camp.Move.ReadValue<float>();
		
		float attackInput = playerControls.Camp.Attack.ReadValue<float>();
		float attackDistance = 0.2f;
		//player direction
		float playerPosition = playerDetails.GetComponent<PlayerMove>().getPositionX();
	
		//move the bullet appropriately with the player
		Vector3 currentPos = transform.position;
		if(!currentlyShooting){
			if(movementInput == -1){
				spriteRenderer.flipX = true;
				currentPos.x = playerPosition - 0.8f + 0.4772741f - 1.2f;
				transform.position = currentPos;

			} else if (movementInput == 1){
				spriteRenderer.flipX = false;
				currentPos.x = playerPosition + 1.08f - 0.4772741f + 1.2f;
				transform.position = currentPos;
			}
		}
		
		
		//create a delay between each shot
		if(attackInput == 1 && !currentlyShooting){
			currentlyShooting = true;
			collider.enabled = true;
			spriteRenderer.enabled = true;
			if(spriteRenderer.flipX == true){
				shootingDistance = -50f;
			} else {
				shootingDistance = 100f;
			}
		}
		
		float direction = 1f;
		
		//determine direction of shooting
		if(currentlyShooting){
			if(spriteRenderer.flipX == true){
				if(currentPos.x > shootingDistance){
					currentPos.x -= direction * speed * Time.deltaTime;
					transform.position = currentPos;
				} else {
					currentlyShooting = false;
					resetPos();
				}
			} else {
				if(currentPos.x < shootingDistance){
					currentPos.x += direction * speed * Time.deltaTime;
					transform.position = currentPos;
				} else {
					currentlyShooting = false;
					resetPos();
				}
			}
		}
	
	}

}
