using UnityEngine;

public class Character : MonoBehaviour {

	Animator animator;
	Vector3 moveDir;
	Rigidbody rigidbody;

	Vector3 walkAngle,runAngle;

	public float walkSpeed = 2f;
	public float runSpeed = 8f;

	bool isWalk { get { return (Mathf.Abs (Input.GetAxis ("Vertical")) > 0.3f) || (Mathf.Abs (Input.GetAxis ("Horizontal")) > 0.3f); }}
	bool isRun { get { return (Input.GetKey(KeyCode.LeftShift)); }}
	bool isLeft { get { return (Input.GetAxis ("Horizontal") < -0.3f); }}
	bool isRight { get { return (Input.GetAxis ("Horizontal") > 0.3f); }}
	bool isForward { get { return (Input.GetAxis ("Vertical") > 0.3f); }}
	bool isBackward { get { return (Input.GetAxis ("Vertical") < -0.3f); }}

	void Start () {
		animator = this.GetComponent<Animator> ();
		rigidbody = this.GetComponent<Rigidbody> ();
		walkAngle = new Vector3 (0, 35, 0); //角度調整
		runAngle = new Vector3 (0, 0, 0); //角度調整
	}

	void Update () {
		//AnimationControllerのパラメータ操作
		animator.SetBool ("isWalk", isWalk);
		animator.SetBool ("isRun", isRun);
		animator.SetBool ("isLeft", isLeft);
		animator.SetBool ("isRight", isRight);
		animator.SetBool ("isForward", isForward);
		animator.SetBool ("isBackward", isBackward);

		transform.eulerAngles = (isRun) ? runAngle : walkAngle;

		//キャラクタ移動
		moveDir = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")).normalized;
		rigidbody.velocity = moveDir * ((isRun) ? runSpeed : walkSpeed);
	}

}
