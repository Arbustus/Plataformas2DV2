using UnityEngine;
using System.Collections;
//Se utiliza para guardar un punto en el espacio y utilizarlo para hacer aparecer al personaje
public class GameControlScript : MonoBehaviour {
	//Es un vector3 al necesitar tres vectores para localizar al personaje en el espacio, es el punto donde aparece al principio
	private Vector3 punto_inicio;
	//Colocas público un GameObject que será el personaje
	public GameObject player;
	//Un buleano para decir si está o no vivo el personaje, en este script no se usa
	public bool esta_vivo = true;

	void Start(){
		//Al iniciar la escena decimos que el punto del inicio es igual a la posición donde aparece el personaje
		punto_inicio = player.transform.position;
	}

	//Decimos que el personaje aparecerá en el punto de inicio, al ser público se puede acceder a este mediante otro script
	public void respaw(){
		player.transform.position = punto_inicio;
	}
	//Dice cuales son las nuevas coordenadas del nuevo punto, al ser público se puede acceder a este mediante otro script
	public void checkpoint(Vector3 nuevo_punto){
		punto_inicio = nuevo_punto;
		}
}