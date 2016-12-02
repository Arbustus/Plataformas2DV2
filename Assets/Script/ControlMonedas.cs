using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlMonedas : MonoBehaviour {

	private int monedas = 0;
	Text texto;

	void Start(){
		texto = GetComponent<Text> ();
		resetear ();
	}

	public void suma_moneda(int cantidad){
		monedas = monedas + cantidad;	// monedas += cantidad; es igual a la línea anterior.
		if(monedas < 0){
			monedas = 0;
		}
		texto.text = monedas.ToString ();
	}

	public void resetear(){
		monedas = 0;
		texto.text = monedas.ToString ();
	}
}
