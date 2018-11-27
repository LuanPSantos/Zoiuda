using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControleInimigo : MonoBehaviour {

	public float moveInimigoX;
	public float limiteX;
	public GUIText pontosTexto;

	private ControleDoPlayer controleDoPlayer;
	private Rigidbody2D rb;
	private bool andandoParaDireita;

	void Start () {
		controleDoPlayer = ControleDoPlayer.FindObjectOfType<ControleDoPlayer> ();
		rb = GetComponent<Rigidbody2D> ();
		andandoParaDireita = true;
		pontosTexto = FindObjectOfType<GUIText> ();

	}

	void Update () {

		if (andandoParaDireita == true) {
			transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
			if (transform.position.x <= limiteX) {
				transform.Translate (moveInimigoX * Time.deltaTime, 0.0f, 0.0f);
			} else {
				andandoParaDireita = false;
			}

		} else {
			transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			if (transform.position.x >= -limiteX) {
				transform.Translate (-moveInimigoX * Time.deltaTime, 0.0f, 0.0f);
			} else {
				andandoParaDireita = true;
			}

		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if(other.CompareTag("Player")){
			controleDoPlayer.Morreu ();
		}
	}
}
