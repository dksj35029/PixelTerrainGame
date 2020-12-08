using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControl : MonoBehaviour
{

	
	private Transform target;
	private PlayerControls playerControls;
	private Rigidbody2D rigidBody;
	private Collider2D collider;
	private SpriteRenderer spriteRenderer;
	
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
        
    }
	
    // Update is called once per frame
    void Update()
    {
     	Move();	
    }
	
	private void Move(){
		//read movement value
		float movementInput = playerControls.Camp.Move.ReadValue<float>();
		
		float attackInput = playerControls.Camp.Attack.ReadValue<float>();
		float attackDistance = 0.2f;
		//player direction
		Vector3 parentPos = transform.parent.position;
	
		Vector3 currentPos = transform.position;
		
		//position the weapon in the right direction
		if(movementInput == -1){
			spriteRenderer.flipX = true;
			currentPos.x = parentPos.x - 0.8f + 0.4772741f;
			transform.position = currentPos;
			
		} else if (movementInput == 1){
			spriteRenderer.flipX = false;
			currentPos.x = parentPos.x + 1.08f - 0.4772741f;
			transform.position = currentPos;
		}
		
		//attack animation
		if(attackInput == 1){
			if(spriteRenderer.flipX == true){
				currentPos.x = parentPos.x - 0.8f + 0.4772741f - attackDistance;
				transform.position = currentPos;
			} else if(spriteRenderer.flipX == false){
				currentPos.x = parentPos.x + 1.08f - 0.4772741f + attackDistance;
				transform.position = currentPos;
			}
		} else {
			if(spriteRenderer.flipX == false){
				currentPos.x = parentPos.x + 1.08f - 0.4772741f;
				transform.position = currentPos;
			} else if(spriteRenderer.flipX == true){
				currentPos.x = parentPos.x - 0.8f + 0.4772741f;
				transform.position = currentPos;
			}
		}
		
	}
	
}
