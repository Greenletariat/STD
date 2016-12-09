using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceMovement : MonoBehaviour {

	Rigidbody PlayerRb;
	public float AccelMultiplier = 10.0f;
	public float stoppingforce = 10.0f;
	public float maxForce = 1000.0f;
	private bool isCollided, Shipstopper, GoNow;
	private float aleronroll, terminalrollSpeed,ForceCounter,theForce;
	public int maxHealth = 100;
	private int currentHealth;
	public Text health;
	public Text timer;
	public Text speed;
	public Image healthbar;
	private decimal time = 0.0m;
	private decimal velocity = 0.0m;
	public GameObject loseCanvas;

	// Use this for initialization
	void Start () {
		PlayerRb = this.GetComponent<Rigidbody> ();
		aleronroll = 0.0f;
		terminalrollSpeed = 5.0f;
		PlayerRb.drag = 0.0f;
		stoppingforce = stoppingforce;
		timer.text = 0.0 + " s";
		speed.text = 0.0 + " m/s";
		currentHealth = maxHealth;
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
			theForce = ForceCounter * AccelMultiplier;
			PlayerRb.AddRelativeForce (Vector3.forward * theForce);
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

		//Debug.Log (ForceCounter);

		time += (decimal)Time.deltaTime;
		int d = 3; 
		decimal temptime = decimal.Round (time, d);
		timer.text = temptime + " s";
		velocity = (decimal)(PlayerRb.velocity.magnitude);
		decimal tempvelocity = decimal.Round (velocity, d);
		speed.text = tempvelocity + " m/s";	

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
	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag("Asteroid") && currentHealth > 10) {
			currentHealth -= 10;
			healthbar.rectTransform.sizeDelta = new Vector2 (currentHealth, healthbar.rectTransform.sizeDelta.y);
		}
		if(other.gameObject.CompareTag("Asteroid") && currentHealth <= 10){
			currentHealth = 0;
			healthbar.rectTransform.sizeDelta = new Vector2 (currentHealth, healthbar.rectTransform.sizeDelta.y);
			loseCanvas.SetActive (true);
		}
	}
}
