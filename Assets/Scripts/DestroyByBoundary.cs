using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	private ControleDoPlayer controleDoPlayer;

	void Start (){
		controleDoPlayer = ControleDoPlayer.FindObjectOfType<ControleDoPlayer> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Nave Mae")){
			controleDoPlayer.Morreu();
		}
		Destroy (other.gameObject);
	}
}
