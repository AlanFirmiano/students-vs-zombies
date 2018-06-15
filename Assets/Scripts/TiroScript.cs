using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroScript : MonoBehaviour {

	public GameObject projetilPrefab;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject go = Instantiate (projetilPrefab) as GameObject;
			go.transform.position = this.gameObject.transform.position;
			go.transform.rotation = this.gameObject.transform.rotation;
			go.transform.Translate (Vector3.forward * 0.5f);
			go.GetComponent<Rigidbody> ().AddForce (go.transform.forward * 2500.0f);
		}
	}
}
