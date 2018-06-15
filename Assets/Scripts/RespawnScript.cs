using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnScript : MonoBehaviour {
	float tempo;
	public GameObject inimigoPrefab;
	public Text PlacarUI;
	public Text VidaUI;
	int count = 0;
	int life = 100;
	// Use this for initialization
	void Start () {
		tempo = Time.time;
		PlacarUI.text = "Placar: " + count.ToString ();
		VidaUI.text = "Vida: " + life.ToString();
	}

	// Update is called once per frame
	void Update () {
		if (Time.time - tempo > 2) {
			Respawn();
			tempo = Time.time;	
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
		go.transform.position = new Vector3 (Random.Range(-5.0f,5.0f),0.5f,Random.Range(-5.0f,5.0f));
	}

	public void incrementarPlacar() {
		count++;
		PlacarUI.text = "Placar: " + (count*50).ToString ();
	}

	int placar() {
		return count;
	}
}