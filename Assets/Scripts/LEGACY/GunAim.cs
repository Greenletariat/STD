using UnityEngine;
using System.Collections;

public class GunAim : MonoBehaviour {
	public float RotationSped = 10.0f;
	private float mouseposX;
	private float mouseposZ;
	private Vector3 temp;
	private Vector3 rayHitWorldPosition;
	// Use this for initialization
	void Start () {
		//GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
	}

	// Update is called once per frame
	void Update () {
		//Ray rayHit = Camera.main.ScreenPointToRay(Input.mousePosition);
		//if (Physics.Raycast (rayHit)) {
			//rayHitWorldPosition = rayHit.point;
		//	mouseposX = rayHit.point.x;
		//	mouseposX = rayHit.point.z;
		//}
		//Vector3 temp = new Vector3 (0.0f, mouseposX, mouseposZ);
		/*float h = Input.GetAxis("Mouse X");
		float v = Input.GetAxis("Mouse Y");
		Vector3 temp = new Vector3( 0.0f, h, v);
		Debug.Log ("coordinates: "+v+","+h);
		if (Input.GetMouseButtonDown (0)) {
			var cube = (GameObject)Instantiate (GameObject.CreatePrimitive(PrimitiveType.Cube),temp);
		}*/

		/*this.GetComponent<Rigidbody> ().transform.rotation = Quaternion.Slerp (
			this.GetComponent<Rigidbody> ().transform.rotation,
			Quaternion.LookRotation (temp - this.GetComponent<Rigidbody> ().transform.position),
			RotationSped * Time.deltaTime);*/
			//this.GetComponent<Rigidbody> ().transform.Rotate (temp);

	}
}
