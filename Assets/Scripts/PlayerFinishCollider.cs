using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerFinishCollider : MonoBehaviour {

	public GameObject player;
	GameObject winCanvas;
	Button b1;

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

		b1 = GameObject.Find("WinStateButton").GetComponent<Button>();
		if (b1 == null){
			Debug.Log("Reset Button not initialized!: " + this.ToString());
		}
		b1.onClick.AddListener(delegate() {Restart();});

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
