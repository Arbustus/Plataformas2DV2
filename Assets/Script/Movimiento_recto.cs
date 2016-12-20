using UnityEngine;
using System.Collections;

public class Movimiento_recto : MonoBehaviour {
	//tiene que tener una plataforma, y dos elementos que sea el inicio y el fin
	public GameObject plataforma;
	public Transform inicio;
	public Transform fin;
	//marca la dirección de la plataforma
	private Vector3 destino;
	//marca la velocidad de la plataforma
	public float velocidad = 10f;

	// Use this for initialization
	void Start () {
		//al iniciar la escena la plataforma se moverá hasta la posición del fin
		destino = fin.position;
	}
	
	// Update is called once per frame
	void Update () {
		//la posicion de la plataforma sera un vector que se moverá desde la plataforma hasta el destino a una velocidad constante
		plataforma.transform.position = Vector3.MoveTowards (plataforma.transform.position, destino, velocidad * Time.deltaTime);
		//si la posicion de la plataforma y del fin es la misma el destino cambiará a inicio
		if (plataforma.transform.position == fin.position) {
			destino = inicio.position;
		}

		if (plataforma.transform.position == inicio.position) {
			destino = fin.position;
		}
	}
}
