using UnityEngine;
using System.Collections;
using UnityEngine.UI;//Necesario cuando modifica la UI
//Modifica el valor que aparecerá en pantalla sobre las monedas que tenemos
public class ControlMonedas : MonoBehaviour {
	//cantidad de monedas que tenemos
	private int monedas = 0;
	Text texto;

	void Start(){
		texto = GetComponent<Text> ();
		resetear ();
	}
	//aumenta la cantidad de monedas que tienes entre parentesis decimos que esta función tiene un numero entero y el nombre de este numero que es cantidad
	public void suma_moneda(int cantidad){
		//sumanos el valor de la moneda una cantidad que podemos modificar fuera
		monedas = monedas + cantidad;	// monedas += cantidad; es igual a la línea anterior.
		//impide que el valor de las monedas sea negativo
		if(monedas < 0){
			monedas = 0;
		}
		//To.String sirve para convertir algo en texto
		texto.text = monedas.ToString ();
	}

	//esta función devuelve el valor de las monedas a 0
	public void resetear(){
		monedas = 0;
		texto.text = monedas.ToString ();
	}
}
