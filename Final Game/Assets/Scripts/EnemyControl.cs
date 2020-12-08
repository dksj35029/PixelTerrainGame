using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{


	[SerializeField] private float speed, jumpSpeed, targetDestination;
	[SerializeField] public float activity;
	[SerializeField] private float strength;
	[SerializeField] public float enemyHealth;
	[SerializeField] private LayerMask ground;
	[SerializeField] public bool death = false;
	public bool diedAlready = false;
	[SerializeField] private float offset1 = 2.93408f;
	[SerializeField] private float offset2 = 0.5685456f;
	
	private Rigidbody2D rigidBody;
	private Collider2D collider;
	private Animator animator;
	private SpriteRenderer spriteRenderer;
	
	
	//Retrieve player info to detect collisions
	public GameObject player;
	public GameObject bullet;
	
	//Used to display tombstones for each deceased alien at the players campsite
	public GameObject grave1;
	public GameObject grave2;
	public GameObject grave3;
	public GameObject grave4;
	
	private void Awake(){
		rigidBody = GetComponent<Rigidbody2D>();
		collider = GetComponent<Collider2D>();
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	public float GetRandomNumber(float min, float max)
	{ 
		return Random.Range(min,max);
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//Allow body to be walked on if dead
		if(!death){
			collider.enabled = true;
     		Move();	
		} else {
			collider.enabled = false;
		}
    }
	
	public void changeActivity(float newActivity){
		//Switch animation accordingly
		activity = newActivity;
		Move();
	}
	
	//Increment the aliens stats for the next day
	public void PostDeath(float currentDay){
		death = false;
		speed+=0.4f;
		strength+=1f;
		enemyHealth = currentDay + 4;
		activity = 3;
		Vector3 currentPos = transform.position;
		spriteRenderer.flipX = false;
		currentPos.x = 65;
		transform.position = currentPos;	
	}
	
	//Reincarnation feature for deceased enemy
	public void Recover(){
		diedAlready = true;
		death = false;
		activity = 1;
		enemyHealth = 5;
	}
	
	//Cannot reincarnate more than once
	public bool DiedAlready(){
		if(diedAlready == true){
			return true;
		} else {
			return false;
		}
	}
	
	
	//Check if the enemy is dead
	public bool deathStatus(){
		if(death == true){
			return true;
		} else {
			return false;
		}
	}
	
	public void resetActivity(){
		activity = 1;
		animator.SetInteger("AnimState",0);
		//Reset animation
	}
	
	public float getPositionX(){
		Vector3 enemyPos = transform.position;
		return enemyPos.x;
	}
	
	
	//Retrieve the player posiiton and animate/direct accordingly
	public void notifyPlayerPosition(float playerPos,float currentDay){
		if(!death){
			Vector3 currentPos = transform.position;
			if(playerPos > 40){
				targetDestination = 0;
				if(playerPos > currentPos.x - offset1 && playerPos < currentPos.x + offset2){
					activity = 3;
				} else {		
					animator.SetInteger("AnimState",2); //Walk state
					activity = 2;
					followPlayer(playerPos);
				}
			} else {
				resetActivity();
				if(currentDay < 3){
					activity = 2;
					targetDestination = 75;
				}
			}
			if(currentPos.x > 74f && currentPos.x < 76f && targetDestination == 75){
				activity = 1;
			}
			Move();
		}
	}
	
	public void lowerHealth(float strength){
		enemyHealth-=1;
		activity = 4;
		if(enemyHealth < 1){
			activity = 5;
		}
		//Decrement health
	}
	
	private void Move(){
		//move enemy accordingly
		float theCurrentDay = player.GetComponent<PlayerMove>().getCurrentDay();
		//Display graves at the players campsite, for each deceased alien
		switch(theCurrentDay){
			case 2:
				SpriteRenderer tempGrave = grave1.GetComponent<SpriteRenderer>();
				tempGrave.enabled = true;
				break;
			case 3:
				SpriteRenderer tempGrave2 = grave2.GetComponent<SpriteRenderer>();
				tempGrave2.enabled = true;
				break;
			case 4:
				SpriteRenderer tempGrave3 = grave3.GetComponent<SpriteRenderer>();
				tempGrave3.enabled = true;
				break;
			case 5:
				SpriteRenderer tempGrave4 = grave4.GetComponent<SpriteRenderer>();
				tempGrave4.enabled = true;
				break;
		}	
		
		if(targetDestination != 0){
			Vector3 currentPos = transform.position;
			if(currentPos.x > targetDestination){
				spriteRenderer.flipX = false;
				currentPos.x += -1f * speed * Time.deltaTime;
			} else if (currentPos.x < targetDestination) {
				spriteRenderer.flipX = true;
				currentPos.x += 1f * speed * Time.deltaTime;
			} else {
				targetDestination = 0;
				spriteRenderer.flipX = true;
			}
			transform.position = currentPos;
		}
		
		//animation
		rigidBody.bodyType = RigidbodyType2D.Dynamic;
		switch(activity){
			case 1: //idle
				animator.SetInteger("AnimState",0);
				break;
			case 2: //running casually
				animator.SetInteger("AnimState",2);
				break;
			case 3: //attack
				animator.SetTrigger("Attack");
				break;
			case 4: //attack
				animator.SetTrigger("Hurt");
				break;
			case 5: //death
				animator.SetTrigger("Death");
				death = true;
				break;
			default: //switch to idle state
				animator.SetInteger("AnimState",0);
				break;
		}
	}
	
	//Follow the player when he is in their territory
	public void followPlayer(float playerPos){
		float direction = 1f;
		Vector3 currentPos = transform.position;
		spriteRenderer.flipX = true;
		if(playerPos < currentPos.x){
			direction = -1f;
			spriteRenderer.flipX = false;
		}
		currentPos.x += direction * speed * Time.deltaTime;
		transform.position = currentPos;
	}
	
	//Detect collision with either player or weapons, to determine an attack or loss of health
	
	private void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			other.gameObject.GetComponent<PlayerMove>().lowerHealth(strength);
		}  
		
		if (other.gameObject.tag == "Weapons"){
			float playerPosition = player.GetComponent<PlayerMove>().getPositionX();
			if(playerPosition > 40){
				lowerHealth(1f);
				bullet.GetComponent<ShootControl>().resetPos();
			}
		}
	}
	
}
