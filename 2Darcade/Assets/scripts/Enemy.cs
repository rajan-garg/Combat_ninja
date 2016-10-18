using UnityEngine;
using System.Collections;

public class Enemy : Character {
	
	[SerializeField]
	/// <summary>
	/// The start position.
	/// </summary>
	public Vector2 startPos;

	private IEnemyState currentState;
	/// <summary>
	/// Gets or sets the target.
	/// </summary>
	/// <value>The target.</value>
	public GameObject Target{ get; set; }

	[SerializeField]
	private float meleeRange;

	[SerializeField]
	private float throwRange;



	/// <summary>
	/// The E audio1.
	/// </summary>
	public AudioSource EAudio1; 
	/// <summary>
	/// The E audio2.
	/// </summary>
	public AudioSource EAudio2;

	/// <summary>
	/// Gets the in melee range.
	/// </summary>
	/// <value>The in melee range.</value>
	public bool InMeleeRange
	{
		get
		{ 
			if (Target!=null) 
			{
				return Vector2.Distance (transform.position, Target.transform.position) <= meleeRange;
			}
			return false;
		}
	}

	/// <summary>
	/// Gets the in throw range.
	/// </summary>
	/// <value>The in throw range.</value>
	public bool InThrowRange
	{
		get
		{ 
			if (Target!=null) 
			{
				return Vector2.Distance (transform.position, Target.transform.position) <= throwRange;
			}
			return false;
		}
	}

	/// <summary>
	/// Gets a value indicating whether this instance is dead.
	/// </summary>
	/// <value><c>true</c> if this instance is dead; otherwise, <c>false</c>.</value>
	public override bool IsDead
	{
		get
		{ 
			return health <= 0;
		}
	}

	/// <summary>
	/// Start this instance.
	/// </summary>
	public override void Start ()
	{
		//health=20;
		base.Start ();
		startPos = transform.position;
		Player.Instance.Dead += new DeadEventHandler (Removetarget);
		ChangeState (new IdleState ());
	}


	void Update () {
		if (!IsDead) 
		{
			if (!TakingDamage) {
				currentState.Execute ();
			}

			LookAtTarget ();
		}

	}

	/// <summary>
	/// Removetarget this instance.
	/// </summary>
	public void Removetarget()
	{
		Target = null;
		ChangeState (new PatrolState ());
	}

	private void LookAtTarget()
	{
		if (Target != null) 
		{
			float xDir = Target.transform.position.x - transform.position.x;
			if (xDir < 0 && faceRight || xDir > 0 && !faceRight) {
				changeDirection ();
			}
		}
	}

	/// <summary>
	/// Changes the state.
	/// </summary>
	/// <returns>The state.</returns>
	/// <param name="newState">New state.</param>
	public void ChangeState(IEnemyState newState)
	{
		if (currentState != null) {
			currentState.Exit ();
		}
		currentState = newState;
		currentState.Enter (this);
	}

	/// <summary>
	/// Move this instance.
	/// </summary>
	public void Move()
	{
		if (!Attack) {
			 
				MyAnimator.SetFloat ("speed", 1);
				transform.Translate (GetDirection () * (movementSpeed * Time.deltaTime));
			
		}

	}

	/// <summary>
	/// Gets the direction.
	/// </summary>
	/// <returns>The direction.</returns>
	public Vector2 GetDirection()
	{
		return faceRight ? Vector2.right : Vector2.left;
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	public override void OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D (other);
		currentState.OnTriggerEnter (other);
	}

	/// <summary>
	/// Takes the damage.
	/// </summary>
	/// <returns>The damage.</returns>
	public override IEnumerator TakeDamage()
	{
		health -= 10;
		if (!IsDead) {
			MyAnimator.SetTrigger ("damage");
			EAudio1.Play ();
		}
		else {
				MyAnimator.SetTrigger("die");
			EAudio2.Play ();
			yield return null;
		}
		//GetComponent<AudioSource> ().Play ();
	}

	/// <summary>
	/// Death this instance.
	/// </summary>
	public override void Death()
	{
		MyAnimator.ResetTrigger ("die");
	//	MyAnimator.SetTrigger ("idle");

	//	health = 20;
	//	transform.position = startPos;

		if (gameObject == null)
		{ 
			Destroy (gameObject);
		}
	}
}
