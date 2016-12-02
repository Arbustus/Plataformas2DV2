using UnityEngine;
using System.Collections;

public class Moneda : MonoBehaviour {

	private Rigidbody2D rb;
	GameObject txt_moneda;
	ControlMonedas cm;
	public int suma;

	void Start (){
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2 (Random.Range (-200,200), Random.Range (50,200)));
		txt_moneda = GameObject.Find ("Texto_moneda");
		cm = txt_moneda.GetComponent<ControlMonedas> ();
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			cm.suma_moneda (suma);
			Destroy(gameObject);
		}
	}

	//void OnDestroy(){
	//	GameObject.Find ("texto_monedas").GetComponent<ControlMonedas> ().suma_moneda (5);
	//}

}
