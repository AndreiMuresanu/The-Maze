using UnityEngine;
using System.Collections;

public class Controller1 : MonoBehaviour {

	public static Quaternion playerro;
	public float moveSpeed = 10f;
	public static bool rolling = false;
	public VirtualJoystick moveJoystick;
	Quaternion oldRotation;
	public Transform JoystickBack;
	public Transform Joystick;


	Rigidbody myRigidbody;
	Camera viewCamera;
	Vector3 velocity;

	//public bool a = true;

	public void DashPress(){
		if (PlayerHealth.CanRoll == true && Pause.paused == false && PlayerHealth.dead == false) {
			rolling = true;
			PlayerAnimationManager.CurrentAnimation = 8;
			//Debug.Log("Dashing");
			//gameObject.GetComponent<Renderer> ().material.color = Color.green;
			StopCoroutine ("Wait");
			StartCoroutine ("Wait");
		}
	}

	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();
		viewCamera = Camera.main;
	}

	void Update ()
	{
		if (!Input.GetButton ("Horizontal") && !Input.GetButton ("Vertical") && moveJoystick.InputDirection == Vector3.zero && rolling == false || PlayerHealth.dead == true) {
			//a = false;
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			//PlayerAnimationManager.CurrentAnimation = 0;
		}
		if (Input.GetKeyDown ("f") && PlayerHealth.CanRoll == true && Pause.paused == false && PlayerHealth.dead == false) {
			rolling = true;
			PlayerAnimationManager.CurrentAnimation = 8;
			//Debug.Log("Dashing");
			//gameObject.GetComponent<Renderer> ().material.color = Color.green;
			StopCoroutine ("Wait");
			StartCoroutine ("Wait");
		}
		//transform.rotation.x = 0;
		//transform.rotation.z = 0;
		Vector3 mousePos = viewCamera.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
		//uncomment once everything is done (complete) [below is for pc only]
		if (Pause.paused == false && PlayerHealth.dead == false && moveJoystick.InputDirection == Vector3.zero) {
			transform.LookAt (mousePos + Vector3.up * transform.position.y);
		}
		//for touch version
		//if (moveJoystick.InputDirection == Vector3.zero) {
		//	transform.rotation = oldRotation;
		//}
		if (moveJoystick.InputDirection != Vector3.zero) {
			transform.LookAt (transform.position + moveJoystick.InputDirection);
			oldRotation = transform.rotation;
		}
		if (rolling == false && PlayerHealth.dead == false) {
			if(moveJoystick.InputDirection != Vector3.zero){
				velocity = moveJoystick.InputDirection.normalized * moveSpeed;
			}
			/*if(moveJoystick.InputDirection.x > 0 && moveJoystick.InputDirection.z > 0){
				if(moveJoystick.InputDirection != Vector3.zero){
					velocity = new Vector3(moveJoystick.InputDirection.x * moveJoystick.InputDirection.x, 0, 
					moveJoystick.InputDirection.z * moveJoystick.InputDirection.z) * moveSpeed;
				}
			}
			if(moveJoystick.InputDirection.x < 0 && moveJoystick.InputDirection.z < 0){
				if(moveJoystick.InputDirection != Vector3.zero){
					velocity = new Vector3( -1f * (moveJoystick.InputDirection.x * moveJoystick.InputDirection.x), 0, 
					moveJoystick.InputDirection.z * moveJoystick.InputDirection.z) * moveSpeed;
				}
			}
			if(moveJoystick.InputDirection.x < 0 && moveJoystick.InputDirection.z < 0){
				if(moveJoystick.InputDirection != Vector3.zero){
					velocity = new Vector3(-1f * (moveJoystick.InputDirection.x * moveJoystick.InputDirection.x), 0, 
					-1f * (moveJoystick.InputDirection.z * moveJoystick.InputDirection.z)) * moveSpeed;
				}
			}
			if(moveJoystick.InputDirection.x > 0 && moveJoystick.InputDirection.z < 0){
				if(moveJoystick.InputDirection != Vector3.zero){
					velocity = new Vector3(moveJoystick.InputDirection.x * moveJoystick.InputDirection.x, 0, 
					-1f * (moveJoystick.InputDirection.z * moveJoystick.InputDirection.z)) * moveSpeed;
				}
			}*/
			if(moveJoystick.InputDirection == Vector3.zero){
				velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized * moveSpeed;
			}
		} 
	}

	void FixedUpdate (){
		if ((Input.GetButton ("Horizontal") || Input.GetButton ("Vertical") || moveJoystick.InputDirection != Vector3.zero) && rolling == false && SwordSwing.FireingBow == false) {
			if (SwordSwing.FireingBow == false && PlayerHealth.sheild == false && SwordSwing.CastingSpell == false) {
				PlayerAnimationManager.CurrentAnimation = 1;
			}
		} 
		else {
			if(SwordSwing.FireingBow == false && PlayerHealth.sheild == false && SwordSwing.CastingSpell == false && rolling == false){
				PlayerAnimationManager.CurrentAnimation = 0;
			}
		}
		if (rolling == false) {
			playerro = transform.rotation;
			myRigidbody.MovePosition (myRigidbody.position + velocity * Time.fixedDeltaTime);
			//PlayerAnimationManager.CurrentAnimation = 1;
		}
		//else {
		//	PlayerAnimationManager.CurrentAnimation = 0;
		//}
		if (rolling == true) {
			PlayerAnimationManager.CurrentAnimation = 8;
			transform.Translate (Vector3.forward * Time.fixedDeltaTime * moveSpeed*2);
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (0.225f);
		rolling = false;
		//gameObject.GetComponent<Renderer>().material.color = Color.white;
		yield return null;
	}
}