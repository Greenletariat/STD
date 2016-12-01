using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

	public void RestartGame(){
		Scene mainLevel = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (mainLevel.buildIndex);
	}
}
