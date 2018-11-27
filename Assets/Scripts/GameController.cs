using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject plataformas;
	public GameObject inimigos;
	public GameObject naveMae;
	public Vector3 spawnPlataformas;
	public Vector3 spawnInimigos;
	public GameObject camera;
	public GameObject player;
	public GUIText pontosTexto;
	public GUIText mensagemTexto;
	public GUIText mensagemRestart;

	private Quaternion spawnRotacao = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
	private float spawnEmY; 
	private Transform transformCamera;
	private float correnteY;
	private float anteriorY;
	private float correntePontos;
	private float anteriorPontos;
	private bool restart;

	void Start () {
		restart = false;

		transformCamera = camera.GetComponent<Transform> ();

		spawnEmY = transformCamera.position.y + 5.5f;

		anteriorY = transformCamera.position.y - 1;

		SpawnPlataformas ();

		correntePontos = 0;
		anteriorPontos = 0;
	}

	void Update (){
		spawnEmY = transformCamera.position.y + 5.5f;

		correnteY = transformCamera.position.y;

		if (correnteY > anteriorY + Random.Range(1.6f , 2.6f)){ //spawn plataformas
			anteriorY = correnteY;
			SpawnPlataformas ();
		}

		if (correnteY > anteriorY + Random.Range (0.2f, 1.4f) && Mathf.Floor(Random.Range(0.0f , 100.0f))%100 == 0) {
			SpawnInimigos ();
		}

		correntePontos = Mathf.Floor (player.transform.position.y); //conta os pontos e mostra na tela
		if (correntePontos > anteriorPontos) {
			anteriorPontos = correntePontos;
			if (correntePontos == 1500) {
				SpawnNaveMae ();
			} else {
				pontosTexto.text = correntePontos.ToString ();
			}

		}

		if (restart == true) {
			if(Input.GetKey(KeyCode.R)){
				Application.LoadLevel("ZoionaGamePlay");
			}
		}
	}

	void SpawnPlataformas (){
		Vector3 spawnPosicao = new Vector3 (Random.Range (-spawnPlataformas.x, spawnPlataformas.x), spawnEmY, spawnPlataformas.z);
		Instantiate (plataformas, spawnPosicao, spawnRotacao);
	}

	void SpawnInimigos (){
		Vector3 spawnPosicao = new Vector3 (Random.Range (-spawnInimigos.x, spawnInimigos.x), spawnEmY, spawnInimigos.z);
		Instantiate (inimigos, spawnPosicao, spawnRotacao);
	}

	void SpawnNaveMae (){
		Vector3 spawnPosicao = new Vector3 (0.0f, spawnEmY, 0.0f);
		Instantiate (naveMae, spawnPosicao, spawnRotacao);
	}

	public void GanhaJogo (){
		mensagemTexto.text = "Você Ganhou!";
		mensagemRestart.text = "'R' Para reiniciar";
		player.SetActive (false);
		SetRestart ();
	}

	public void SetRestart (){
		restart = true;
	}
}
