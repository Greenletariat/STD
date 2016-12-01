using UnityEngine;
using System.Collections;

public class GameFieldHelper : MonoBehaviour {
	private Vector3 gameFieldRadius;
	private Vector3 gameFieldMargins;
	private Vector3 gameFieldOffset;

	// Use this for initialization
	void Start () {
		//Since it's a plane, the plane scale * 10 is the normal scale, radius is half
		gameFieldRadius = this.transform.lossyScale * 5;
		gameFieldMargins = new Vector3(1.0f, 0.0f, 1.0f) * (gameFieldRadius.magnitude / 20.0f);
		gameFieldOffset = this.transform.position;
		gameFieldOffset.Scale(new Vector3(1.0f, 0.0f, 1.0f));
	}

	public Vector3 getGameFieldRadius(){
		return gameFieldRadius;
	}

	public Vector3 getGameFieldMargins(){
		return gameFieldMargins;
	}

	public Vector3 getGameFieldOffset(){
		return gameFieldOffset;
	}
}
