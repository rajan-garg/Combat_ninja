using UnityEngine;
using System.Collections;
/// <summary>
/// Ignore collision.
/// </summary>
public class IgnoreCollision : MonoBehaviour {
	/// <summary>
	/// The other.
	/// </summary>
	[SerializeField]
	private Collider2D other;
	/// <summary>
	/// Awake this instance.
	/// </summary>
	private void Awake()
	{
		Physics2D.IgnoreCollision(GetComponent<Collider2D>(),other,true);
	}
}
