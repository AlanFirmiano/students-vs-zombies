using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag.Equals ("cop")) {
			Application.LoadLevel (1);
			//GameObject.FindGameObjectWithTag ("GameController").GetComponent<RespawnScript> ().passarFase3 ();
		}
	}
}
