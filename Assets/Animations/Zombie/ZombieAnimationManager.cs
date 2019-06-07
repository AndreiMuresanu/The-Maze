using UnityEngine;
using System.Collections;

public class ZombieAnimationManager : MonoBehaviour {

	Animator anim;
	public Transform Switch;
	public Transform Switch1;
	public Transform RealBody;
	bool a = false;

	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update () {
		if(Switch1.position == RealBody.TransformPoint (1,0,0)){
			anim.SetInteger("ZombieCurrentAnimation", 2);
			//StartCoroutine("Wait");
		}
		if(Switch1.position == RealBody.TransformPoint (0,0,0)){
			anim.SetInteger("ZombieCurrentAnimation", 0);
		}
		if(RealBody.GetComponent<Rigidbody>().velocity != Vector3.zero && (Switch1.position != RealBody.TransformPoint (1,0,0)
		 && Switch.position != RealBody.TransformPoint (0,0,0)) || (Switch1.position != RealBody.TransformPoint (1,0,0)
		  && Switch.position != RealBody.TransformPoint (1,0,0))){
			anim.SetInteger("ZombieCurrentAnimation", 1);
		}
		if(Switch.position == RealBody.TransformPoint (4,0,0)){
			anim.SetInteger("ZombieCurrentAnimation", 4);
		}
	}

	IEnumerator Wait ()
	{
		yield return new WaitForSeconds (0.3f);
		if (Switch1.position == RealBody.TransformPoint (1, 0, 0)) {
			a = true;
		} 
		else {
			a = false;
		}
		yield return null;
	}
}