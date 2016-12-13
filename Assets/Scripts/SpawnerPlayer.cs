using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnerPlayer : MonoBehaviour {

	GameObject shipSelectorCanvas;
	Button b1;

	// Use this for initialization
	void Start () {
		shipSelectorCanvas = GameObject.Find("ShipSelectorCanvas");
		if (shipSelectorCanvas == null){
			Debug.Log("ShipSelectorCanvas not initialized!: " + this.ToString());
		}

		b1 = shipSelectorCanvas.transform.GetChild(0).GetComponent<Button>();
		if (b1 == null){
			Debug.Log("Button for ShipSelectorCanvas not initalized!: "+ this.ToString());
		}
		b1.onClick.AddListener(delegate() {ShipSelected();});


	}

	public void ShipSelected(){
		shipSelectorCanvas.SetActive(false);
	}

}
