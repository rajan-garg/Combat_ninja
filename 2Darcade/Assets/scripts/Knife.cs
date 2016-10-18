using UnityEngine;
using System.Collections;
/// <summary>
/// Knife.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
/// <summary>
/// Knife.
/// </summary>
public class Knife : MonoBehaviour {
	/// <summary>
	/// The speed.
	/// </summary>
	[SerializeField]
	private float speed;
	/// <summary>
	/// My rigidbody.
	/// </summary>
	private Rigidbody2D myRigidbody;
	/// <summary>
	/// The direction.
	/// </summary>
	private Vector2 direction;
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();

	}
	/// <summary>
	/// Fixeds the update.
	/// </summary>
	/// <returns>The update.</returns>
	void FixedUpdate()
	{
		myRigidbody.velocity = direction * speed;
	}
		
	/// <summary>
	/// Initialize the specified direction.
	/// </summary>
	/// <param name="direction">Direction.</param>
	public void Initialize(Vector2 direction){
		this.direction = direction;
	}
	/// <summary>
	/// Raises the became invisible event.
	/// </summary>
	void OnBecameInvisible(){
		Destroy (gameObject);
	}
}
