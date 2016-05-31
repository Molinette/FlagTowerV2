using UnityEngine;
using System.Collections;

public class TowerDownScript : MonoBehaviour {
	//Step prefab
	public GameObject step;

    //Total number of steps
    public int totalSteps = 3;
    //Height in game units of each step
    public float stepHeight = 3f;
    //Health of every steps
    public float stepHealth = 200f;
    //Max health of the tower
    private float maxhealth;
    //Tower's health
    private float health;
    //How many step right now
    private float currentStep;
    //Starting Y value
    private float startingPosY;

	private GameObject stepInstance;

    void Start(){
        currentStep = totalSteps;
        startingPosY = transform.position.y;
        //Sets the total health
        health = totalSteps*stepHealth;
        maxhealth = health;

		//Spawn steps
		for(int i = 0; i < totalSteps; i++){
			Vector3 stepPosition = transform.position;
			stepPosition.y += stepHeight*i;
			stepPosition.z = 10;
			stepInstance = (GameObject)GameObject.Instantiate(step, stepPosition, step.transform.rotation);
			stepInstance.transform.parent = transform;
		}
    }

		
    //Increment or decrement health depending on the health passed by parameter
    public void changeHealth(float healthAmount){
        float tempCurrentStep;
        float currentHeight;

        //Increment or decrement health by health amount with min and max
        health = Mathf.Clamp(health += healthAmount, 0, maxhealth);

        tempCurrentStep = Mathf.Ceil(health / stepHealth);
        if(currentStep != tempCurrentStep){
            currentStep = tempCurrentStep;
            currentHeight = stepToHeight(currentStep) - stepToHeight(totalSteps);
            transform.position = new Vector3(transform.position.x, currentHeight + startingPosY,transform.position.z);
        }
    }

    //Get height from step based on steps height
    private float stepToHeight(float step){
        return step * stepHeight;
    }

    //currentStep getter
    public float getCurrentStep() {

        return currentStep;
    }

    //currentStep setter
    public void setCurrentStep(float currentStep){

        this.currentStep = currentStep;

    }

}
