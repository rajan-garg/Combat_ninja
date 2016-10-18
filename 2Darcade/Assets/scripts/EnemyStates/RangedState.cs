using UnityEngine;
using System.Collections;

public class RangedState : IEnemyState {
	private Enemy enemy;

	private float throwTimer;
	private float throwCoolDown=3;
	private bool canThrow=true; 

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
		ThrowKinfe ();
		if (enemy.InMeleeRange) {
			enemy.ChangeState(new MeleeState ());
		}
		else if (enemy.Target != null) {
			enemy.Move ();
		} 
		else {
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
	/// Throws the kinfe.
	/// </summary>
	/// <returns>The kinfe.</returns>
	private void ThrowKinfe()
	{
		throwTimer += Time.deltaTime;
		if (throwTimer >= throwCoolDown) {
			canThrow = true;
			throwTimer = 0;
		}
		if (canThrow) {
			canThrow = false;
			enemy.MyAnimator.SetTrigger ("throw");
		}
	}
}
