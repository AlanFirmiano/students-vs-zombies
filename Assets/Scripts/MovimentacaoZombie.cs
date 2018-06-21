using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoZombie : MonoBehaviour {
	public float speed;
	public float life;
	float tempo;
	public Animator animator; 
	void Start(){
		tempo = 0;
		//life = 100;
		animator.SetBool ("morrendo",false);
		animator.SetBool ("atacando",false);
		speed = 1.5f;
	}
	// Update is called once per frame
	void Update () {
		GameObject cop = GameObject.FindGameObjectWithTag("cop");
		float step = speed * Time.deltaTime;
		if (animator.GetBool ("morrendo") == false) {
			this.transform.LookAt (cop.transform.position);
			transform.position = Vector3.MoveTowards (transform.position, cop.transform.position, step);
		} else {
			if (tempo>0 && Time.time - tempo > 2) {
				GameObject.FindGameObjectWithTag ("GameController").GetComponent<RespawnScript> ().incrementarPlacar ();
				Destroy (this.gameObject);
			}
		}
	}
		
	public void tiraVida(float perde){
		this.life -= perde;
		if (this.life <= 0) {
			tempo = Time.time;
			animator.SetBool ("morrendo", true);
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag.Equals ("cop")) {
			animator.SetBool ("atacando", true);
		}
	}

	void OnCollisionExit(Collision col){
		if (col.gameObject.tag.Equals ("cop")) {
			animator.SetBool ("atacando", false);
		}
	}
}
