using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControleDoPlayer : MonoBehaviour {

	public float velocidade;
	public int forcaPulo;
	private AudioSource audioSource;

	private GameController gameController;
	private int moveLado;
	private Rigidbody2D rb;
	private Transform posicao;
	private BoxCollider2D colisor2d;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		colisor2d = GetComponent<BoxCollider2D> ();
		rb = GetComponent<Rigidbody2D> ();

		gameController = GameController.FindObjectOfType<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		EstaCaindo ();

		if (rb.velocity.y < -13.0f) {//QUEDA MAXIMA PRA MORRER
			Morreu ();
		}

		//move o personagem/
		float moveLado = Input.GetAxis ("Horizontal");
		if (transform.position.x >= -5.95f && transform.position.x <= 5.95f) {
			transform.Translate (moveLado * Time.deltaTime * 3, 0.0f, 0.0f);
		} else {
			if (transform.position.x < -5.95f) {
				moveLado = 1;
				transform.Translate (moveLado * Time.deltaTime * 3, 0.0f, 0.0f);
			} else {
				moveLado = -1;
				transform.Translate (moveLado * Time.deltaTime * 3, 0.0f, 0.0f);
			}
		}

	}

	void OnCollisionStay2D (Collision2D coll){
		if (EstaCaindo () == true && rb.velocity.y == 0.0f) {//SE ESTA CAINDO ENTAO PULA SE COLIDIR
			rb.AddForce(Vector2.up * forcaPulo);
			audioSource.Play ();
		}
	}

	bool EstaCaindo(){
		if (rb.velocity.y <= 0) {//SE ESTA CAINDO
			colisor2d.isTrigger = false;
			return true;
		} 
		else {//SE NAO ESTA CAINDO
			colisor2d.isTrigger = true;
			return false;
		}
	}

	public void Morreu (){
		gameObject.SetActive (false);
		gameController.mensagemTexto.text = "Perdeu!";
		gameController.mensagemRestart.text = "'R' Para reiniciar";
		gameController.SetRestart ();
	}
}
