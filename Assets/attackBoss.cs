using UnityEngine;
using System.Collections;

public class attackBoss : StateMachineBehaviour {

	float counter = 0f;
	public float chargePower;
	BoxCollider2D spearCollider;
	void Awake () {

		spearCollider = GameObject.Find ("Boss").transform.FindChild ("Lance").gameObject.GetComponent<BoxCollider2D> ();
	}
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//	
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
		counter += Time.deltaTime;
		if (counter >= 0.3f) {
			animator.gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			animator.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * animator.transform.localScale.x * chargePower, ForceMode2D.Impulse);
			animator.SetInteger ("status", 2);
			spearCollider.enabled = true;
			counter = 0;
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
