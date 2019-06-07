using UnityEngine;
using System.Collections;

public class Unit1M : MonoBehaviour {


	public Transform target;
	public static float speed = 5f;
	Vector3[] path;
	int targetIndex;
	bool a = true;
	int i = 5;
	//public static Vector3 AttackerPos;
	//public static Quaternion AttackerRo;
	public bool InRange = false;
	//bool b = true;


	void Start() {
		//transform.rotation.x = 0;
		//transform.rotation.y = 0;
		Update ();
	}

	void MyClass(){
		PathRequestManager.RequestPath(transform.position,target.position, OnPathFound);
	}

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if (pathSuccessful) {
			path = newPath;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator FollowPath() {
		Vector3 currentWaypoint = path[0];

		while (true) {
			if (transform.position == currentWaypoint) {
				targetIndex ++;
				if (targetIndex >= path.Length) {
					targetIndex = 0;
					path = new Vector3[0];
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}
			a = true;
			if(a == true){
				transform.position = Vector3.MoveTowards(transform.position,currentWaypoint,speed * Time.deltaTime);
			}
			yield return null;

		}
	}

	public void OnDrawGizmos() {
		if (path != null) {
			for (int i = targetIndex; i < path.Length; i ++) {
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);

				if (i == targetIndex) {
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else {
					Gizmos.DrawLine(path[i-1],path[i]);
				}
			}
		}
	}

	void Update(){
		float y = transform.rotation.y;
		//transform.eulerAngles = new Vector3(0,y,0);
		//transform.rotation = new Quaternion(0,y,0,0);
		if(targetIndex == 0){
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		//AttackerPos = transform.position;
		//AttackerRo = transform.rotation;
		//if(target == true){	
		if (InRange == true && target.position.y > -1) {
			transform.LookAt (target.position);
			if (Target.Ismoving == true) {
				//if (Input.GetButtonDown ("Jump") || Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")){
				//StopCoroutine("FollowPath");
				if (i == 5) {
					//Debug.Log ("Request");
					a = false;
					targetIndex = 0;
					path = new Vector3[0];
					i = 0;
					MyClass ();
				}
				i++;
			}
		}
		if(InRange == false && targetIndex == 0){
			targetIndex = 0;
			path = new Vector3[0];
			i = 5;
		}
		//}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.name == "FollowRange") {
			if(a == true){
				Debug.Log ("Touched FollowRange");
				//target = other.gameObject.GetComponentInParent<Transform>();
				target = other.gameObject.transform;
				a = false;
			}
			InRange = true;
		} 
	}

	void OnTriggerExit (Collider other){
		if (other.gameObject.name == "FollowRange") {
			InRange = false;
		} 
	}
}