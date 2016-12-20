using UnityEngine;
using System.Collections;
[RequireComponent (typeof(BoxCollider2D))]//Es obligatorio que quien contenga este script tenga un BoxCollier2D si no se lo pondrá
public class Enlazar_jugador : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		//Si entra en colisión un Player el movimiento de este objeto será igual al del jugador
		if (col.gameObject.tag == "Player") {
			//la posición del padre es igual a la del hijo, el hijo sería el jugador
			col.gameObject.transform.parent = transform;
		}
	}
	void OnCollisionExit2D(Collision2D col){
		//Si sale del colisionador el Player el movimiento de este no se verá afectado por el de este objeto
		if (col.gameObject.tag == "Player") {
			col.gameObject.transform.parent = null;
		}
	}
}
