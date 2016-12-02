using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {

	private Vector3 punto_inicio;
	public GameObject player;
	public bool esta_vivo = true;

	void Start(){
		punto_inicio = player.transform.position;
	}

	public void respaw(){
		player.transform.position = punto_inicio;
	}

	public void checkpoint(Vector3 nuevo_punto){
		punto_inicio = nuevo_punto;
		}
}
