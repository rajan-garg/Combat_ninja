using UnityEngine;
using System.Collections;
/// <summary>
/// Collision trigger.
/// </summary>
public class CollisionTrigger : MonoBehaviour {
	/// <summary>
	/// The platform collider.
	/// </summary>
	[SerializeField]
	private BoxCollider2D platformCollider;
	/// <summary>
	/// The platform trigger.
	/// </summary>
	[SerializeField] 
	private BoxCollider2D platformTrigger;
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
	

		Physics2D.IgnoreCollision (platformCollider, platformTrigger, true);
	}
	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other){
	
		if(other.gameObject.tag=="Player"||other.gameObject.tag=="Enemy"){
			Physics2D.IgnoreCollision (platformCollider,other, true);
		}
	}
	/// <summary>
	/// Raises the trigger exit2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerExit2D(Collider2D other){

		if(other.gameObject.tag=="Player"||other.gameObject.tag=="Enemy"){
			Physics2D.IgnoreCollision (platformCollider, other, false);
		}
	}

}
