using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnScript : MonoBehaviour {
	float tempo;
	public GameObject inimigoPrefab;
	public GameObject policialPrefab;
	public Animator animator; 
	public Text PlacarUI;
	public Text VidaUI;
	int count = 0;
	int life = 100;
	int maxInimigos = 1; // Máximo de inimigos na fase
	int countInimigos = 0;
	int fase = 1;
	int morreram = 0;
	// Use this for initialization
	void Start () {
		tempo = Time.time;
		PlacarUI.text = "Placar: " + count.ToString ();
		VidaUI.text = "Vida: " + life.ToString();
	}

	// Update is called once per frame
	void Update () {
		if (Time.time - tempo > 2 && countInimigos < maxInimigos) {
			Respawn();
			tempo = Time.time;
			this.countInimigos += 1;
		}

		if(morreram == maxInimigos) {
			if(fase == 1)
				policialPrefab.transform.position = new Vector3 (12.0f, 1, 0.0f);
			fase++;
			morreram = 0;
			countInimigos=0;
			if(fase == 2)
				maxInimigos = 2;
			if(fase == 3)
				maxInimigos = 3;
		}
	}
	public void mostrarVida(int vida){
		life -= vida;
		if (life <= 0) {
			Destroy (GameObject.FindGameObjectWithTag ("cop"));
		}
		VidaUI.text = "Vida: " + life.ToString();
	}

	void Respawn(){
		GameObject go = Instantiate (inimigoPrefab) as GameObject;
		if(fase == 1)
			go.transform.position = new Vector3 (Random.Range(20.0f,35.0f), 0.5f,Random.Range(45.0f,-45.0f));
		else if(fase == 2)
			go.transform.position = new Vector3 (Random.Range(-40.0f,0.0f), 0.5f,Random.Range(45.0f,-45.0f));
	}

	public void incrementarPlacar() {
		morreram++;
		count++;
		PlacarUI.text = "Placar: " + (count*50).ToString ();
	}

	int placar() {
		return count;
	}

	public void passarFase3() {
		print(morreram + ":" + maxInimigos + " -- " + fase);
		if(fase == 3) {
			Application.LoadLevel (1);
		}
	}
}