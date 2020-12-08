using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

	
	//variables for player stats
	[SerializeField] private float speed, jumpSpeed, health, currentDay, crystals;
	[SerializeField] private LayerMask ground;
	
	//components used on the element
	private PlayerControls playerControls;
	private Rigidbody2D rigidBody;
	private Collider2D collider;
	private Animator animator;
	private SpriteRenderer spriteRenderer;

	//game objects
	public GameObject enemy; //allows for retrieving enemy info
	public GameObject displayStats; //used for the stat display
	public GameObject crystalsCollect; //retrieiving in-game crystals
	
	//audio to make game interactive
	public AudioSource deathSound;
	public AudioSource crystalSound;
	public AudioSource crystalInsufficient;
	
	public GameObject traps;
	public GameObject traps2;
	public GameObject upgradeMenu; //Upgrade menu
	
	public GameObject instructionCanvas;
	
	//initiailise 
	private void Awake(){
		playerControls = new PlayerControls();
		rigidBody = GetComponent<Rigidbody2D>();
		collider = GetComponent<Collider2D>();
		animator = GetComponent<Animator>();
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
        playerControls.Camp.Jump.performed += _ => Jump();
		//update relevant stats
		displayStats.GetComponent<DisplayStats>().updateHealth(health);
		displayStats.GetComponent<DisplayStats>().updateCrystals(crystals);
    }
	
	private void Jump(){
		if(onGround()){
			rigidBody.AddForce(new Vector2(0,jumpSpeed),ForceMode2D.Impulse);
			animator.SetTrigger("Jump"); //trigger jump animation
		}
	}
	
	public float getCurrentDay(){
		//retrieve day, and send to other scripts that call for it
		return currentDay;
	}
	
	private void endGame(){
		//game over
		deathSound.Play();
		SceneManager.LoadScene(0);
	}

	private bool onGround(){
		//determine if the user is on the ground to prevent double jumps
		Vector2 topLeft = transform.position;
		topLeft.x -= collider.bounds.extents.x;
		topLeft.y += collider.bounds.extents.y;
		
		Vector2 bottomRight = transform.position;
		bottomRight.x += collider.bounds.extents.x;
		bottomRight.y -= collider.bounds.extents.y;
		
		return Physics2D.OverlapArea(topLeft,bottomRight,ground);
	}
	
	public float getPositionX(){
		//return x position
		Vector3 enemyPos = transform.position;
		return enemyPos.x;
	}
	
	public bool facingRight(){
		bool theDirection = spriteRenderer.flipX;
		return theDirection;
	}

    // Update is called once per frame
    void Update()
    {
		Traps();
     	Move();
    }
	
	public void lowerHealth(float strength){
		//lower the player health
		health-=strength;
		displayStats.GetComponent<DisplayStats>().updateHealth(health);
		if(health < 1){
			endGame();
		}
	}
	
	private void Traps(){
		//determine how many traps to set
		switch(currentDay){
			case 2:
				Collider2D colliderTempTraps = traps.GetComponent<Collider2D>();
				SpriteRenderer displayTempTraps = traps.GetComponent<SpriteRenderer>();
				colliderTempTraps.enabled = true;
				displayTempTraps.enabled = true;
				break;
			case 3:
				Collider2D colliderTempTraps2 = traps2.GetComponent<Collider2D>();
				SpriteRenderer displayTempTraps2 = traps2.GetComponent<SpriteRenderer>();
				colliderTempTraps2.enabled = true;
				displayTempTraps2.enabled = true;
				break;
		}
	}
	
	private void Move(){
		//Used for movement related functionalities
		if(currentDay > 1){
			instructionCanvas.GetComponent<Canvas>().enabled = false;
			//instructions no longer needed after day 1
		}
		//read user input values
		float movementInput = playerControls.Camp.Move.ReadValue<float>();
		float inspectInput = playerControls.Camp.Inspect.ReadValue<float>();
		float numberInput1 = playerControls.Camp.Number1.ReadValue<float>();
		float numberInput2 = playerControls.Camp.Number2.ReadValue<float>();
		
		//move player accordingly
		Vector3 currentPos = transform.position;
		currentPos.x += movementInput * speed * Time.deltaTime;
		transform.position = currentPos;
		
		//user can interact with Upgrade box within coordinates
		if(currentPos.x > 2.6 && currentPos.x < 5.6){
			if(inspectInput == 1){
				upgradeMenu.GetComponent<Canvas>().enabled = true;
			}
		} else {
			upgradeMenu.GetComponent<Canvas> ().enabled = false;
		}
		
		//ensure that players can't spend more than they own
		if(upgradeMenu.GetComponent<Canvas>().enabled == true){
			if(numberInput1 == 1){
				if(crystals > 2){
					jumpSpeed+=2;
					speed+=0.5f;
					crystals-=3;
					displayStats.GetComponent<DisplayStats>().updateCrystals(crystals);
					crystalSound.Play();
					upgradeMenu.GetComponent<Canvas>().enabled = false;
				}
				numberInput1 = 0;
			} else if (numberInput2 == 1){
				if(crystals > 0){
					health+=2;
					crystals-=1;
					displayStats.GetComponent<DisplayStats>().updateCrystals(crystals);
					crystalSound.Play();
					upgradeMenu.GetComponent<Canvas>().enabled = false;
				}
				numberInput2 = 0;
			}
			displayStats.GetComponent<DisplayStats>().updateHealth(health);
		}
		
		//animation
		
		if(movementInput != 0){
			animator.SetBool("Walk",true);
		} else {
			animator.SetBool("Walk",false);
		}
		
		//player direction
		if(movementInput == -1){
			spriteRenderer.flipX = true;
		} else if (movementInput == 1){
			spriteRenderer.flipX = false;
		}
		
		
		/*
		float enemyPositionX = enemy.GetComponent<EnemyControl>().getPositionX();
		if(currentPos.x > enemyPositionX - 2.93408 && currentPos.x < enemyPositionX + 0.5685456){
			enemy.GetComponent<EnemyControl>().activity = 3;
		} else {
			enemy.GetComponent<EnemyControl>().resetActivity();
		}
		*/
		
		//make sure the enemy is aware of players location
		enemy.GetComponent<EnemyControl>().notifyPlayerPosition(currentPos.x,currentDay);
		
		//determine if the enemy is dead
		bool getDeathStatus = enemy.GetComponent<EnemyControl>().deathStatus(); 
		if(getDeathStatus && currentPos.x < 1){
			currentDay+=1; //increment the day, player has defeated enemy
			displayStats.GetComponent<DisplayStats>().updateDay(currentDay);
			enemy.GetComponent<EnemyControl>().PostDeath(currentDay);
			Collider2D colliderTemp = crystalsCollect.GetComponent<Collider2D>();
			colliderTemp.enabled = true;
		}
		
	}
	
	//detect collision
	private void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Crystals"){
			bool getDeathStatus = enemy.GetComponent<EnemyControl>().deathStatus();
			if(getDeathStatus){
				Collider2D colliderTemp = crystalsCollect.GetComponent<Collider2D>();
				colliderTemp.enabled = false;
				crystals+=2;
				displayStats.GetComponent<DisplayStats>().updateCrystals(crystals);
				crystalSound.Play();
				//retrieve crystals after defeating enemy
			}
		}
		if(other.gameObject.tag == "Traps"){
			//lower player health
			health-=1;
			crystalInsufficient.Play();
			displayStats.GetComponent<DisplayStats>().updateHealth(health);
		}
	}
	
}
