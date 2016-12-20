using UnityEngine;
using System.Collections;

public class Moneda : MonoBehaviour {

	private Rigidbody2D rb;
	GameObject txt_moneda;
	//script en la escena
	ControlMonedas cm;
	//el valor de la moneda
	public int suma;

	void Start (){
		//rb tiene los componenetes del Rigidbody2D
		rb = GetComponent<Rigidbody2D> ();
		//A rb se le añade una fuerza aleatoria entre dos valores que queremos en x e y.
		rb.AddForce (new Vector2 (Random.Range (-200,200), Random.Range (50,200)));
		//Encuentra en la escena Texto_moneda
		txt_moneda = GameObject.Find ("Texto_moneda");
		//cm accede a los componente de ControlMonedas que esa dentro de Texto_moneda se podría hacer como cm = GameObject.Find ("Texto_moneda").GetComponent<>(ControlMonedas);
		cm = txt_moneda.GetComponent<ControlMonedas> ();
	}

	void OnCollisionEnter2D(Collision2D col){
		//Al colisionar con un objeto cuyo tag sea Player...
		if (col.gameObject.tag == "Player") {
			//la cantidad que tenemos de monedas aumenta, y la moneda se destruye
			cm.suma_moneda (suma);
			Destroy(gameObject);
		}
	}

	//void OnDestroy(){
	//	GameObject.Find ("texto_monedas").GetComponent<ControlMonedas> ().suma_moneda (5);
	//}

}
