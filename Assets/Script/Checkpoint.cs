using UnityEngine;
using System.Collections;
//Actualiza el punto de reaparición de un personaje
public class Checkpoint : MonoBehaviour {

	//Necesitamos el GameControlScript de la escena que tiene el punto de posición del personaje y las funciones públicas
	private GameControlScript gcs;
	//Al tener como checkpoint una bandera aquí dices cual será su sprite
	public Sprite banderOn;
	//dices si está activada o no el checkpoint
	private bool activada = false;
	// Use this for initialization
	void Start () {
		//busca dentro de la escena un elemento(GameControl en este caso) y de este decimos que gcs tiene los mismo componente que el GameControlScript y te permite acceder a sus public void
		gcs = GameObject.Find ("GameControl").GetComponent<GameControlScript> ();
	}

	void OnTriggerEnter2D(Collider2D objeto) {
		//Si el trigger es el Player y no está activada la bandera funciona lo siguiente
		if (objeto.tag == "Player" && !activada) {
			//Cambia el sprite de la bandera al que tiene puesto el GameControlScript
			GetComponent<SpriteRenderer> ().sprite = banderOn;
			//actualizas la posición donde reaparece el personaje en la función checkpoint del GameControlScript
			gcs.checkpoint (transform.position);
			//Dices que el checkpoint está activado para no poder activarlo dos veces
			activada = true;
		}
	}
}
