using UnityEngine;
using System.Collections;

/// <summary>
/// Initializes a new instance of the <see cref="DeadEventHandler"/> delegate.
/// </summary>
/// <param name="object">Object.</param>
/// <param name="method">Method.</param>
/// <summary>
/// Ends the invoke.
/// </summary>
/// <returns>The invoke.</returns>
/// <param name="result">Result.</param>
/// <summary>
/// Begins the invoke.
/// </summary>
/// <returns>The invoke.</returns>
/// <param name="callback">Callback.</param>
/// <param name="object">Object.</param>
/// <summary>
/// Invoke this instance.
/// </summary>
public delegate void DeadEventHandler();

public class Player : Character {

	private Vector2 startPos;

	private static Player instance;

	/// <summary>
	/// Occurs when dead.
	/// </summary>
	public event DeadEventHandler Dead;

	[SerializeField]
	private stat healthStat;

	/// <summary>
	/// The shot delay.
	/// </summary>
	public float shotDelay;
	private float shotDelayCounter;

	/// <summary>
	/// The audio1.
	/// </summary>
	public AudioSource Audio1; 
	/// <summary>
	/// The audio2.
	/// </summary>
	public AudioSource Audio2;
	/// <summary>
	/// The audio3.
	/// </summary>
	public AudioSource Audio3;
	/// <summary>
	/// The audio4.
	/// </summary>
	public AudioSource Audio4;
	/// <summary>
	/// The audio5.
	/// </summary>
	public AudioSource Audio5;
	/// <summary>
	/// The audio6.
	/// </summary>
	public AudioSource Audio6;
		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static Player Instance
	{
		get
		{
			if (instance == null) {
				instance = GameObject.FindObjectOfType<Player>();
			}
			return instance;
		}

	}
	/// <summary>
	/// The ground points.
	/// </summary>
	[SerializeField]
	private Transform[] groundPoints; 
	/// <summary>
	/// The radius.
	/// </summary>
	[SerializeField]
	private float radius;
	/// <summary>
	/// The what is ground.
	/// </summary>
	[SerializeField]
	private LayerMask whatIsGround;
	/// <summary>
	/// The air control.
	/// </summary>
	[SerializeField]
	private bool airControl;
	/// <summary>
	/// The jump force.
	/// </summary>
	[SerializeField]
	private float jumpForce;
	/// <summary>
	/// The sprite renderer.
	/// </summary>
	private SpriteRenderer spriteRenderer;

	private bool immortal=false;
	[SerializeField]
	private float immortalTime;



	float lastTimet;
	float lastTimea;

	/// <summary>
	/// Gets or sets my rigidbody.
	/// </summary>
	/// <value>My rigidbody.</value>
	public Rigidbody2D MyRigidbody { get; set;}

	/// <summary>
	/// Gets or sets the jump.
	/// </summary>
	/// <value>The jump.</value>
	public bool Jump { get; set;}

	/// <summary>
	/// Gets or sets the on ground.
	/// </summary>
	/// <value>The on ground.</value>
	public bool OnGround { get; set;}

//	public static void PlayerHealth( int MaxPlayerHealth)
//	{
//		MaxPlayerHealth=health;
//		MaxPlayerHealth=50;
//	}

	/// <summary>
	/// Gets a value indicating whether this instance is dead.
	/// </summary>
	/// <value><c>true</c> if this instance is dead; otherwise, <c>false</c>.</value>
	public override bool IsDead
	{
		get
		{ 
			if (healthStat.CurrentVal <= 0) {
								OnDead ();
			}

			return healthStat.CurrentVal<= 0;
		}
	}


	/// <summary>
	/// Start this instance.
	/// </summary>
	public override void Start () {
//		PlayerHealth (50);
		//int playerHealth=health;
		//PlayerHealth
		lastTimet = Time.fixedTime;
		lastTimet = Time.fixedTime;

		//health=50;

		base.Start ();

		startPos = transform.position;
		spriteRenderer = GetComponent<SpriteRenderer> ();
		MyRigidbody = GetComponent<Rigidbody2D> ();
		//LifeManager.lifeCounter = startingLives;
		healthStat.Initialize();
	}

	void Update(){   

		if (Input.GetKeyDown (KeyCode.X) && (Time.fixedTime - lastTimet) > 1.0f) 
		{
			MyAnimator.SetTrigger ("throw");
			Audio6.Play ();
			lastTimet = Time.fixedTime;
			shotDelayCounter = shotDelay;

		}
		if (Input.GetKey (KeyCode.X)) 
		{
			shotDelayCounter -= Time.deltaTime;

			if (shotDelayCounter <= 0) 
			{
				shotDelayCounter = shotDelay;
				MyAnimator.SetTrigger ("throw");
				lastTimet = Time.fixedTime;
				Audio6.Play ();
			}
				
		}

		if( Input.GetKeyDown(KeyCode.Z) && (Time.fixedTime - lastTimea) > 1.0f)
		{
			MyAnimator.SetTrigger ("attack");
			Audio5.Play ();	
			lastTimea = Time.fixedTime;
		}

		if (!TakingDamage&&!IsDead) {
			if (transform.position.y <= -10f) {
				//LifeManager.lifeCounter = LifeManager.lifeCounter - 1;
				LifeManager.decreaseLife ();
								Death();
			
			}

			HInput();
		}


	}                                     //update calls depends on the frame speed of the system so called very often
	void FixedUpdate () {
		if (!TakingDamage&&!IsDead) {
			float horizontal = Input.GetAxis ("Horizontal");

			OnGround = IsGrounded ();
			Movement (horizontal);
			Flip (horizontal);
			Layers ();
		}


	}                                      //fixed update calls depends on the time and called after some interval, used for all physics function.

	/// <summary>
	/// Raises the dead event.
	/// </summary>
	public void OnDead()
	{
		if (Dead != null) {
			
						Dead ();
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "movingPlatform") {
			transform.parent = other.transform;
		}
	}
		
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.tag == "movingPlatform") {
			transform.parent = null;
		}
	}

	private void Flip(float horizontal){
		if(horizontal>0&&!faceRight||horizontal<0&&faceRight){
			changeDirection ();
		}
	}                                     //flip function flips our character when we press the arrow keys.




	private void HInput(){
		
		if( Input.GetKeyDown(KeyCode.Space) )
		{
						MyAnimator.SetTrigger ("jump");
						if(OnGround)
			              Audio3.Play ();
			
		}

	}                                                  //controls the input to the player through keys by changing the bool value



	private void  Movement(float horizontal)
	{
		if (MyRigidbody.velocity.y < 0) {
			MyAnimator.SetBool ("land", true);
		}
		if (!Attack && (OnGround || airControl)) {
			MyRigidbody.velocity = new Vector2 (horizontal * movementSpeed, MyRigidbody.velocity.y);
		}
		if (Jump && MyRigidbody.velocity.y == 0) {
			MyRigidbody.AddForce (new Vector2 (0, jumpForce));
		}
		MyAnimator.SetFloat ("speed", Mathf.Abs (horizontal));
	}


	private bool IsGrounded(){
		if(MyRigidbody.velocity.y<=0){
			foreach (Transform point in groundPoints) {
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, radius, whatIsGround);

				for( int i=0 ;i<colliders.Length; i++){
					if(colliders[i].gameObject!=gameObject)
					{

						return true;
					}
				}
			}
		}
		return false;
	}                                                   //function to check whether player is on the ground or not

	private void Layers(){

		if (!OnGround) {
			MyAnimator.SetLayerWeight (1, 1);
		}
		else {
			MyAnimator.SetLayerWeight (1, 0);
		}          

	}                                                      //changing the layers

	/// <summary>
	/// Throws the kinfe.
	/// </summary>
	/// <returns>The kinfe.</returns>
	/// <param name="value">Value.</param>
	public override void ThrowKinfe(int value)
	{
		if (!OnGround && value == 1 || OnGround && value == 0) 
		{
			base.ThrowKinfe (value);
		}

	}

	private IEnumerator IndicateImmortal()
	{
		while (immortal) {
			spriteRenderer.enabled = false;
			yield return new WaitForSeconds (.1f);
			spriteRenderer.enabled = true ;
			yield return new WaitForSeconds (.1f);
		}
	}

	/// <summary>
	/// Takes the damage.
	/// </summary>
	/// <returns>The damage.</returns>
	public override IEnumerator TakeDamage()
	{
		if (!immortal &&health>0) {
			healthStat.CurrentVal -= 10;
			if (!IsDead) {
				MyAnimator.SetTrigger ("damage");
				Audio4.Play ();
				immortal = true;
				StartCoroutine (IndicateImmortal());
				yield return new WaitForSeconds (immortalTime);
				immortal = false;
			}
			else {

				LifeManager.decreaseLife ();
				MyAnimator.SetLayerWeight (1, 0);

				MyAnimator.SetTrigger ("die");
				Audio2.Play ();
			}
		}
	
	}

	/// <summary>
	/// Death this instance.
	/// </summary>
	public override void Death()
	{
		
		Audio1.Play();
	//	LifeManager.lifeCounter = LifeManager.lifeCounter - 1;
		MyRigidbody.velocity = Vector2.zero;
		MyAnimator.SetTrigger ("idle");
		healthStat.CurrentVal = healthStat.MaxVal;
		transform.position = startPos;
	}
    
}
