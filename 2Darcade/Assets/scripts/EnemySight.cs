using UnityEngine;
using System.Collections;
/// <summary>
/// Enemy sight.
/// </summary>
public class EnemySight : MonoBehaviour {
	/// <summary>
	/// The enemy.
	/// </summary>
	[SerializeField]
	private Enemy enemy;
	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			enemy.Target = other.gameObject;
		}
	}
	/// <summary>
	/// Raises the trigger exit2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			enemy.Target = null;
		}
	}

}
