using UnityEngine;
using System.Collections;

public class SpaceMovement : MonoBehaviour {

	Rigidbody PlayerRb;
	public float forwardforce = 10.0f;
	private bool isCollided;
	private float aleronroll, terminalrollSpeed;

	// Use this for initialization
	void Start () {
		PlayerRb = this.GetComponent<Rigidbody> ();
		aleronroll = 0.0f;
		terminalrollSpeed = 5.0f;
	}

	// Update is called once per frame
	void Update () {
		float HorizMov = Input.GetAxis ("Horizontal");
		float VertiMov = Input.GetAxis ("Vertical");

		AleronBarrelRoll ();

		PlayerRb.transform.Rotate (Vector3.right*VertiMov);
		PlayerRb.transform.Rotate (Vector3.forward*aleronroll*0.5f);
		PlayerRb.transform.Rotate (Vector3.up*HorizMov);

		if (Input.GetKey("space")||Input.GetKey(KeyCode.JoystickButton0)) {
			PlayerRb.AddRelativeForce (Vector3.forward * forwardforce);
		}
		Debug.Log (isCollided);
	}
	void OnTriggerEnter(Collider other){
		if (other) {
			isCollided = true;
		}
	}
	void OnTriggerExit(Collider other){
		if (other) {
			isCollided = true;
		}
	}
	void AleronBarrelRoll(){
		if (Input.GetKey(KeyCode.I)) {
			aleronroll++;
		}
		else if (Input.GetKey (KeyCode.O)) {
			aleronroll--;
		} else {
			aleronroll = 0.0f;
		}
		if (aleronroll >= terminalrollSpeed) {
			aleronroll = terminalrollSpeed;
		} else if (aleronroll <= -terminalrollSpeed) {
			aleronroll = -terminalrollSpeed;
		}


		//if (PlayerRb.rotation.eulerAngles.y > 45.0f) {
		//	HorizMov = 0.0f;
		//}

		float HorizMov = Input.GetAxis ("Horizontal");
		float VertiMov = Input.GetAxis ("Vertical");

		PlayerRb.transform.Rotate (Vector3.right*VertiMov);
		PlayerRb.transform.Rotate (Vector3.forward*aleronroll*0.5f);
		PlayerRb.transform.Rotate (Vector3.up*HorizMov);

		if (Input.GetKey("space")||Input.GetKey(KeyCode.JoystickButton0)) {
			PlayerRb.AddRelativeForce (Vector3.forward * forwardforce);
		}
		Debug.Log (isCollided);
	}
}
