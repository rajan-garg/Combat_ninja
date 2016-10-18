﻿using UnityEngine;
using System.Collections;

public class AttackBehaviour : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	/// <summary>
	/// Raises the state enter event.
	/// </summary>
	/// <param name="animator">Animator.</param>
	/// <param name="stateInfo">State info.</param>
	/// <param name="layerIndex">Layer index.</param>
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.GetComponent<Character> ().Attack = true;
		animator.SetFloat ("speed", 0);
		if (animator.tag == "Player") {
			if (Player.Instance.OnGround) {
				Player.Instance.MyRigidbody.velocity = Vector2.zero;
			} 
		}

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	/// <summary>
	/// Raises the state exit event.
	/// </summary>
	/// <param name="animator">Animator.</param>
	/// <param name="stateInfo">State info.</param>
	/// <param name="layerIndex">Layer index.</param>
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.GetComponent<Character> ().Attack = false;
		animator.GetComponent<Character> ().SwordCollider.enabled = false;
		animator.ResetTrigger ("attack");
		animator.ResetTrigger ("throw");
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
