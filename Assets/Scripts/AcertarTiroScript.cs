using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcertarTiroScript : MonoBehaviour {

	float tempo;
	// Use this for initialization
	void Start () {
		tempo = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time - tempo > 5) {
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag.Equals("inimigo")){
			
			col.gameObject.GetComponent <MovimentacaoZombie> ().tiraVida (50);
			Destroy (this.gameObject);
		}
	}
}
