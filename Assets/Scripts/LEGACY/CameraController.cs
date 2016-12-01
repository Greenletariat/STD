//DEPRICATED, INTEGRATED INTO PLAYERMANAGER

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject Player;
	public Camera cam;
	private Rigidbody rbP;
	private Vector3 offset;

	void Start()
	{
		rbP = Player.GetComponent<Rigidbody>();
		offset = cam.transform.position;
	}
	void Update()
	{
		cam.transform.position = rbP.transform.position + offset;
	}



}