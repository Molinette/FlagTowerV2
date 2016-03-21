using UnityEngine;
using System.Collections;

/**
 * Interface des projectiles
 * Les différents projectiles devront retourner leur dommage
 */

public interface IProjectile : MonoBehaviour{
	
	public float projectileDamage();
}
