using UnityEngine;
using System.Collections;

public class IdleState : IEnemyState {
	/// <summary>
	/// The enemy.
	/// </summary>
	private Enemy enemy;
	/// <summary>
	/// The idle timer.
	/// </summary>
	private float idleTimer;     //time we were in idle
	/// <summary>
	/// The duration of the idle.
	/// </summary>
	private float idleDuration;     //time it will stay in idle

	/// <summary>
	/// Enter the specified enemy.
	/// </summary>
	/// <param name="enemy">Enemy.</param>
	public void Enter(Enemy enemy)
	{
		idleDuration = UnityEngine.Random.Range (2, 8);
		this.enemy = enemy;
	}

	/// <summary>
	/// Execute this instance.
	/// </summary>
	public void Execute()
	{
		Idle ();
		Debug.Log ("idleing");
		if (enemy.Target != null) {
			enemy.ChangeState (new PatrolState ());
		}
	}

	/// <summary>
	/// Exit this instance.
	/// </summary>
	public void Exit()
	{

	}

	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="other">Other.</param>
	public void OnTriggerEnter(Collider2D other)
	{
		if (other.tag == "knife") {
			enemy.Target = Player.Instance.gameObject;		
		}
	}
	/// <summary>
	/// Idle this instance.
	/// </summary>
	private void Idle()
	{
		enemy.MyAnimator.SetFloat ("speed", 0);
		idleTimer += Time.deltaTime ;

		if (idleTimer >= idleDuration) 
		{
			enemy.ChangeState (new PatrolState ());
		}
	}

}
