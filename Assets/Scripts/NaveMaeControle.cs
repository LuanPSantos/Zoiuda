using UnityEngine;
using System.Collections;

public class NaveMaeControle : MonoBehaviour {

	private GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = GameController.FindObjectOfType<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if(other.CompareTag("Player")){
			gameController.GanhaJogo ();
		}else{
			Destroy (other.gameObject);
		}
	}

}
