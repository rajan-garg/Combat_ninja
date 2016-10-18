using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState {
	private Enemy enemy;
	private float patrolTimer;
	private float patrolDuration;

	/// <summary>
	/// Enter the specified enemy.
	/// </summary>
	/// <param name="enemy">Enemy.</param>
	public void Enter(Enemy enemy)
	{
		patrolDuration = UnityEngine.Random.Range (4, 10);
		this.enemy = enemy;
		enemy.changeDirection ();
	}

	/// <summary>
	/// Execute this instance.
	/// </summary>
	public void Execute()
	{
		Patrol ();
		Debug.Log ("petrolling");
		enemy.Move ();
		if (enemy.Target != null&&enemy.InThrowRange) {
			enemy.ChangeState (new RangedState ());
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
		if (other.tag == "Edge") {
			enemy.changeDirection ();
		}

		if (other.tag == "knife") {
			enemy.Target = Player.Instance.gameObject;		
		}
	}
	/// <summary>
	/// Patrol this instance.
	/// </summary>
	private void Patrol()
	{
		enemy.MyAnimator.SetFloat ("speed", 0);
		patrolTimer += Time.deltaTime ;

		if (patrolTimer >= patrolDuration) 
		{
			enemy.ChangeState (new IdleState ());
		}
	}
}
