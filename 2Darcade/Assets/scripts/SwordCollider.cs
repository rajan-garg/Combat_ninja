using UnityEngine;
using System.Collections;
/// <summary>
/// Sword collider.
/// </summary>
public class SwordCollider : MonoBehaviour {

	[SerializeField]
	private string targetTag;
	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == targetTag) {
			GetComponent<Collider2D> ().enabled = false; 
		}
	}
}
