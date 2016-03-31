using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
	//Moving states
	public enum MovingStates{Idle, FetchFlag, Left, Right, Jump, StealFlag};
	public MovingStates movingState;

	//Monster movement
	public float maxRunningVelocity = 5f;
	public float runningAcceleration = 40f;
	public float breakingAcceleration = 16f;
	public float jumpingForce = 8f;
}

