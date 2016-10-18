using UnityEngine;
using System.Collections;

public class MeleeState : IEnemyState 
{/// <summary>
/// The attack timer.
/// </summary>
	private float attackTimer;
	/// <summary>
	/// The attack cool down.
	/// </summary>
	private float attackCoolDown=3;
	/// <summary>
	/// The can attack.
	/// </summary>
	private bool canAttack=true; 

	private Enemy enemy;

	/// <summary>
	/// Enter the specified enemy.
	/// </summary>
	/// <param name="enemy">Enemy.</param>
	public void Enter(Enemy enemy)
	{
		this.enemy = enemy;
	}

	/// <summary>
	/// Execute this instance.
	/// </summary>
	public void Execute()
	{
		Attack ();
		if (enemy.InThrowRange && !enemy.InMeleeRange) {
			enemy.ChangeState (new RangedState ());
		} 
		else if (enemy.Target == null) {
			enemy.ChangeState (new IdleState ());
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
		
	}
	/// <summary>
	/// Attack this instance.
	/// </summary>
	private void Attack()
	{
		attackTimer += Time.deltaTime;
		if (attackTimer >= attackCoolDown) {
			canAttack = true;
			attackTimer = 0;
		}
		if (canAttack) {
			canAttack = false;
			enemy.MyAnimator.SetTrigger ("attack");
		}
	}
}
