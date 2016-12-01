using UnityEngine;
using System.Collections;

public class SpaceMovement : MonoBehaviour {

	Rigidbody PlayerRb;
	public float forwardforce = 10.0f;

	// Use this for initialization
	void Start () {
		PlayerRb = this.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		float HorizMov = Input.GetAxis ("Horizontal");
		float VertiMov = Input.GetAxis ("Vertical");

		//if (PlayerRb.rotation.eulerAngles.y > 45.0f) {
		//	HorizMov = 0.0f;
		//}

		PlayerRb.transform.Rotate (Vector3.right*VertiMov);
		PlayerRb.transform.Rotate (Vector3.up*HorizMov);

		if (Input.GetKeyDown("space")) {
			PlayerRb.AddRelativeForce (Vector3.forward * forwardforce);
		}
	}
}
