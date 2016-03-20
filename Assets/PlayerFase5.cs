using UnityEngine;
using System.Collections;

public class PlayerFase5 : MonoBehaviour {

	public Transform playerAndHorse;

	public GameObject bala;
	public Transform bicoDaArma;

	private int posicaoMirando;
	private int posicaoAtual;
	public float[] possiveisPosicoes;
	public float[] tamanhosPorPosicao;

	// Use this for initialization
	void Start () {

		posicaoAtual = 1;
		posicaoMirando = 1;
		UpdatePositions ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (Controls.climbLadderUp) && posicaoAtual != 0) {

			posicaoAtual -= 1;
			UpdatePositions ();
		} else if (Input.GetKeyDown (Controls.climbLadderDown) && posicaoAtual != 2) {

			posicaoAtual += 1;
			UpdatePositions ();
		}

		if (Input.GetKeyDown (Controls.walkRight)) {

			posicaoMirando = 1;
			UpdatePositions ();

		} else if (Input.GetKeyDown (Controls.walkLeft)) {

			posicaoMirando = -1;
			UpdatePositions ();
		} else if (Input.GetKeyDown (KeyCode.Space)) {

			GameObject balaInstanciada = (GameObject) Instantiate (bala, bicoDaArma.position, Quaternion.identity);
			balaInstanciada.GetComponent<bullet> ().moveSpeed *= posicaoMirando;
		}
	}

	void UpdatePositions () {

		playerAndHorse.position = new Vector2 (playerAndHorse.position.x, possiveisPosicoes [posicaoAtual]);
		playerAndHorse.localScale = new Vector2 (tamanhosPorPosicao [posicaoAtual], tamanhosPorPosicao [posicaoAtual]);
		transform.localScale = new Vector2 (posicaoMirando * Mathf.Abs(transform.localScale.x), transform.localScale.y);
	}
}
