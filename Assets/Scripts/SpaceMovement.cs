using UnityEngine;
using System.Collections;

public class SpaceMovement : MonoBehaviour {

	Rigidbody PlayerRb;
	public float AccelMultiplier = 10.0f;
	public float stoppingforce = 10.0f;
	public float maxForce = 1000.0f;
	private bool isCollided, Shipstopper, GoNow;
	private float aleronroll, terminalrollSpeed,ForceCounter,theForce;

	// Use this for initialization
	void Start () {
		PlayerRb = this.GetComponent<Rigidbody> ();
		aleronroll = 0.0f;
		terminalrollSpeed = 5.0f;
		PlayerRb.drag = 0.0f;
		stoppingforce = stoppingforce;
	}

	// Update is called once per frame
	void Update () {
		float HorizMov = Input.GetAxis ("Horizontal");
		float VertiMov = Input.GetAxis ("Vertical");

		AleronBarrelRoll ();

		PlayerRb.transform.Rotate (Vector3.right*VertiMov);
		PlayerRb.transform.Rotate (Vector3.forward*aleronroll*0.5f);
		PlayerRb.transform.Rotate (Vector3.up*HorizMov);

		//Debug.Log (AccelCounter);
		if (Input.GetKey ("space") || Input.GetKey (KeyCode.JoystickButton0)) {
			//GoNow = true;
			ForceCounter++;
		}
		if (ForceCounter >= maxForce) {
			ForceCounter = maxForce;
		}

		if (Input.GetKey (KeyCode.LeftShift)||Input.GetKey (KeyCode.RightShift)) {
			//Debug.Log ("hello?");
			PlayerRb.drag = stoppingforce;
			ForceCounter = 0.0f;
		} else {
			PlayerRb.drag = 0.0f;
		}
		theForce = ForceCounter * AccelMultiplier;
		Debug.Log (ForceCounter);
		PlayerRb.AddRelativeForce (Vector3.forward * theForce);
			

		//Debug.Log (isCollided);

		//}
		//ShipStopper ();

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
		if (Input.GetKey(KeyCode.Q)) {
			aleronroll++;
		}
		else if (Input.GetKey (KeyCode.E)) {
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
		PlayerRb.transform.Rotate (Vector3.up*HorizMov);

		//if (Input.GetKeyDown("space")) {
		//	PlayerRb.AddRelativeForce (Vector3.forward * forwardforce);
		//}
	}
	void ShipStopper(){
		if (Input.GetKeyDown(KeyCode.N)) {
			PlayerRb.AddRelativeForce (Vector3.forward * stoppingforce);
		}
	}
}
