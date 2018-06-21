using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoCOPScript : MonoBehaviour {
	public int life;
	public Animator animator; 
	// Use this for initialization
	void Start () {
		life = 100;
		animator.SetBool ("atirando",false);
		animator.SetBool ("morrendo",false);
		animator.SetBool ("correndo",false);
		animator.SetBool ("voltando",false);
	}

	IEnumerator Example()
	{
		yield return new WaitForSeconds(10);
	}
	// Update is called once per frame
	void Update () {
		//print(this.gameObject.transform.position);
		//MOVIMENTACAO
		if(Input.GetKey(KeyCode.UpArrow)) {
			this.gameObject.transform.Translate (Vector3.forward * 0.1f);

		} else if(Input.GetKey(KeyCode.DownArrow)) {
			this.gameObject.transform.Translate (Vector3.forward * -0.1f);
		}

		if(Input.GetKey(KeyCode.RightArrow)) {
			this.gameObject.transform.RotateAround (this.gameObject.transform.position, Vector3.up, 2);
		}
		if(Input.GetKey(KeyCode.LeftArrow)) {
			this.gameObject.transform.RotateAround (this.gameObject.transform.position, Vector3.up, -2);
		}
		//ANIMACAO
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			animator.SetBool ("correndo",true);
		}
		if(Input.GetKeyUp(KeyCode.UpArrow)) {
			animator.SetBool ("correndo",false);
		}
		if(Input.GetKey(KeyCode.DownArrow)) {
			animator.SetBool ("voltando",true);
		}
		if(Input.GetKeyUp(KeyCode.DownArrow)) {
			animator.SetBool ("voltando",false);
		}
		if(Input.GetKey(KeyCode.RightArrow)) {
			this.gameObject.transform.RotateAround (this.gameObject.transform.position, Vector3.up, 2);
		}
		if(Input.GetKey(KeyCode.LeftArrow)) {
			this.gameObject.transform.RotateAround (this.gameObject.transform.position, Vector3.up, -2);
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			animator.SetBool ("atirando", true);

		}
		if(Input.GetKeyUp(KeyCode.Space)){
			animator.SetBool ("atirando", false);
		}

		if(Input.GetKeyDown(KeyCode.X)){
			animator.SetBool ("morrendo", true);
		}
		if(Input.GetKeyUp(KeyCode.X)){
			animator.SetBool ("morrendo", false);
		}
	}
	void OnCollisionExit(Collision col){
		if(col.gameObject.tag.Equals("chao")){
			this.gameObject.transform.position = new Vector3 (0,0.5f,0);
			this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
		}
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag.Equals ("inimigo")) {
			print ("k");
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<RespawnScript> ().mostrarVida (10);

		}

	}
}