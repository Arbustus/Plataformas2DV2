using UnityEngine;
using System.Collections;

public class Teletransporte : MonoBehaviour {
	//dice donde está el objeto donde se teletransportará el elemento
	public Transform destino;

	void OnTriggerEnter2D(Collider2D objeto){
		//si lo toca un jugador la posición de esta será igual a la del destino
		if (objeto.tag == "Player") {
			objeto.transform.position = destino.position;
		}
	}
	//Esta función sirve para visualizar en la escena los dos elementos que conectan, el de este script y el destino.
	//Si tienes seleccionado los elementos la linea será de amarillo, en este caso
	void OnDrawGizmosSelected() {
		if (destino != null)
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine (transform.position, destino.position);
		}
	//Si no tienes seleccionados los elementos la linea sera negra, en este caso
	void OnDrawGizmos() {
		if (destino != null) {
			Gizmos.color = Color.black;
			Gizmos.DrawLine (transform.position, destino.position);
		}
	}
}
