using UnityEngine;
using System.Collections;

public class enemyOnHorseAI : MonoBehaviour {

	private GameManager gameManager;

	private Transform target;
	public Transform enemy;
	public GameObject bala;
	public Transform bicoDaArma;
	public AudioClip somTiro;

	public float tempoEntreTiros;
	public float[] possiveisPosicoes;
	public float[] tamanhosPorPosicao;

	public float velocidadeMin;
	public float velocidadeMax;
	public float posicaoInicial;

	public float minDistanceToGameOver;

	private float ContagemRegressivaParaAtirar;
	private float ladoQueNasce;
	private float posicaoVerticalQueNasce;
	private float velocidade;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();

		target = GameObject.Find("PlayerAndHorse").transform;
		ContagemRegressivaParaAtirar = tempoEntreTiros;

		ladoQueNasce = Random.value;
		if (ladoQueNasce > 0.5f)
			ladoQueNasce = 1f;
		else
			ladoQueNasce = -1f;
		

		posicaoVerticalQueNasce = Random.value;
		if (posicaoVerticalQueNasce > 0.66f)
			posicaoVerticalQueNasce = 0f;
		else if (posicaoVerticalQueNasce > 0.33f)
			posicaoVerticalQueNasce = 1f;
		else
			posicaoVerticalQueNasce = 2f;

		velocidade = Random.Range (velocidadeMin, velocidadeMax);
		enemy.localScale = new Vector3(-ladoQueNasce*enemy.localScale.x, enemy.localScale.y);
		transform.localScale = new Vector2 (tamanhosPorPosicao [(int)posicaoVerticalQueNasce], tamanhosPorPosicao [(int)posicaoVerticalQueNasce]);

		transform.position = new Vector2 (posicaoInicial * ladoQueNasce, possiveisPosicoes [(int) posicaoVerticalQueNasce]);
	}
	
	// Update is called once per frame
	void Update () {
		ContagemRegressivaParaAtirar -= Time.deltaTime;

		transform.Translate (Vector2.right * velocidade * -ladoQueNasce * Time.deltaTime);
		if ((transform.position.y == target.position.y) && ContagemRegressivaParaAtirar <= 0) {

			GameObject balaInstanciada = (GameObject) Instantiate (bala, bicoDaArma.position, Quaternion.identity);
			balaInstanciada.GetComponent<bullet> ().moveSpeed *= (int) -ladoQueNasce;
			ContagemRegressivaParaAtirar = tempoEntreTiros;
			AudioSource.PlayClipAtPoint (somTiro, Vector2.zero);
		}

		if (Mathf.Abs (transform.position.x - target.position.x) <= minDistanceToGameOver) {
			gameManager.GameOver ();
			Destroy (gameObject);
		}
	}
}
