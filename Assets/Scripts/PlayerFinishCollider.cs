using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerFinishCollider : MonoBehaviour {

	public GameObject player;
	GameObject winCanvas;

	void Start(){

		player = GameObject.Find ("Player");
		if (player == null) {
			Debug.Log ("Player not initialized!: " + this.ToString ());
		}

		winCanvas = GameObject.Find ("WinStateCanvas");
		if (winCanvas == null) {
			Debug.Log ("Win Canvas not initialized!: " + this.ToString ());
		}
		winCanvas.SetActive(false);

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "FinishLine"){
			winCanvas.SetActive(true);
		}
	}

	public void Restart(){
		Scene loadedLevel = SceneManager.GetActiveScene();
		SceneManager.LoadScene(loadedLevel.buildIndex);
	}
}
