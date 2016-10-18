using UnityEngine;
using System.Collections;
/// <summary>
/// I enemy state.
/// </summary>
public interface IEnemyState
{/// <summary>
/// Execute this instance.
/// </summary>
	void Execute ();                                //these are public by default
	/// <summary>
	/// Enter the specified enemy.
	/// </summary>
	/// <param name="enemy">Enemy.</param>
	void Enter(Enemy enemy);
	/// <summary>
	/// Exit this instance.
	/// </summary>
	void Exit ();
	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter(Collider2D other);
}
