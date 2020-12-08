using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{

	public Text dayCounter;
	public Text healthCounter;
	public Text crystalCounter;
	public Text crystalCounter2;
	public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
       
    }
	
	public void updateDay(float newDay){
		dayCounter.text = "DAY "+newDay;
		audioSource.Play();
	}
	
	public void updateHealth(float numberHere){
		healthCounter.text = "HEALTH: "+numberHere;
	}
	
	public void updateCrystals(float numberHere){
		crystalCounter.text = "CRYSTALS: "+numberHere;
		crystalCounter2.text = "CRYSTALS: "+numberHere;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
