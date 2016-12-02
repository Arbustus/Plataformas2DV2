using UnityEngine;
using System.Collections;
[RequireComponent (typeof(BoxCollider2D))]
public class Enlazar_jugador : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.transform.parent = transform;
		}
	}
	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.transform.parent = null;
		}
	}
}
