using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour {          //abstarct class will prevent character script to b added to gameobject
	                                                //accesible within class and classes derived from that class
	[SerializeField]
	protected Transform KnifePos;                             
	[SerializeField]
	protected float movementSpeed;
	/// <summary>
	/// The face right.
	/// </summary>
	protected bool faceRight;
	/// <summary>
	/// The knife prefab.
	/// </summary>
	[SerializeField]
	private GameObject knifePrefab;
	/// <summary>
	/// The health.
	/// </summary>
	[SerializeField]
	protected int health;

	//public static int enemyHealth ;
	//public static int playerHealth ;
	/// <summary>
	/// The sword collider.
	/// </summary>
	[SerializeField]
	private EdgeCollider2D swordCollider;
	/// <summary>
	/// The damage sources.
	/// </summary>
	[SerializeField]
	private List<string> damageSources;

	/// <summary>
	/// Gets a value indicating whether this instance is dead.
	/// </summary>
	/// <value><c>true</c> if this instance is dead; otherwise, <c>false</c>.</value>
	public abstract bool IsDead { get; }      //charcter is not gonna return after death so only get

	/// <summary>
	/// Gets or sets the attack.
	/// </summary>
	/// <value>The attack.</value>
	public bool Attack { get; set;}
	/// <summary>
	/// Gets or sets the taking damage.
	/// </summary>
	/// <value>The taking damage.</value>
	public bool TakingDamage{ get; set; }
	/// <summary>
	/// Gets my animator.
	/// </summary>
	/// <value>My animator.</value>
	public Animator MyAnimator{ get ; private set;}

	/// <summary>
	/// Gets the sword collider.
	/// </summary>
	/// <value>The sword collider.</value>
	public EdgeCollider2D SwordCollider {
		get {
			return swordCollider;
		}
	}

	/// <summary>
	/// Start this instance.
	/// </summary>
	public virtual void Start () {
		faceRight = true;
		MyAnimator = GetComponent<Animator> ();
	}
	

	void Update () {
	
	}

	/// <summary>
	/// Takes the damage.
	/// </summary>
	/// <returns>The damage.</returns>
	public abstract IEnumerator TakeDamage ();     //abstract-every class inherited has to use this fuction

	/// <summary>
	/// Death this instance.
	/// </summary>
	public abstract void Death ();

	/// <summary>
	/// Changes the direction.
	/// </summary>
	/// <returns>The direction.</returns>
	public void changeDirection()
	{
		faceRight = !faceRight;
		transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, 1);
	}

	/// <summary>
	/// Throws the kinfe.
	/// </summary>
	/// <returns>The kinfe.</returns>
	/// <param name="value">Value.</param>
	public virtual void ThrowKinfe(int value){
		if (faceRight) 
		{
			GameObject temp=(GameObject)Instantiate (knifePrefab, KnifePos.position, Quaternion.Euler(new Vector3(0,0,-90)));
			temp.GetComponent<Knife> ().Initialize (Vector2.right);
		} 
		else 
		{
			GameObject temp=(GameObject)Instantiate (knifePrefab, KnifePos.position, Quaternion.Euler(new Vector3(0,0,90)));
			temp.GetComponent<Knife> ().Initialize (Vector2.left);
		}
	}

	/// <summary>
	/// Melees the attack.
	/// </summary>
	/// <returns>The attack.</returns>
	public void MeleeAttack()
	{
		SwordCollider.enabled = true;
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	public virtual void OnTriggerEnter2D(Collider2D other)
	{
		if (damageSources.Contains(other.tag)) {
			StartCoroutine (TakeDamage ());
		}
	}
}
