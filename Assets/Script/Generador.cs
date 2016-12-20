using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {
	//son las monedas u elementos que generará, los corchetes añaden una lista
	public GameObject[] monedas;
	private GameObject moneda_nueva;
	//dice de donde saldrá el elmento
	private Transform pos_salida;
	//cantidad de monedas que tendra la lista de las cuales generará una
	private int numero_moneda = 0;
	private Animator anim;
	//numero de golpes que recibe la caja antes de dejar de funcionar
	public int cajaGris = 0;

	void Start(){
		//encuentra un elemento (debe de ser hijo) desde donde saldrán las monedas
		pos_salida = transform.Find("posicion_salida").transform;
		//obten los componentes del animator, sirve para cuando se cambian las animaciones dentro de un elemento desde script
		anim = GetComponent<Animator> ();
	}
	//al entrar en contacto este elemento
	void OnCollisionEnter2D(Collision2D col){
		//si has dado ya tres golpes vuelvete gris mediante la animación
		if (cajaGris == 3) {
			anim.SetTrigger ("Gris");

		}
		//si al colisiones tienes menos de tres golpes y te golpea el Player
		if(col.gameObject.tag == "Player" && cajaGris < 3){
			//cantidad de monedas que hay en la lista
			numero_moneda = Random.Range (0, monedas.Length);
			//genera una moneda aleatoria(de la lista) desde pos_salida
			moneda_nueva = (GameObject)Instantiate (monedas[numero_moneda], pos_salida.position, transform.rotation);
			//activa el trigger Goloe
			anim.SetTrigger("Golpe");
			//añade 1 al valor de cajaGris
			cajaGris++;
		}
			
	}
	//Al entrar en el trigger(funciona o este o el superior dependiendo de si tienes un trigger o un collider)
	void OnTriggerEnter2D(Collider2D objeto){
		//Si es un Player y no hay en la escena el objeto moneda_nueva
		if(objeto.tag == "Player" && moneda_nueva == null){
			numero_moneda = Random.Range (0, monedas.Length);
			moneda_nueva = (GameObject)Instantiate (monedas[numero_moneda], pos_salida.position, transform.rotation);
		}
	}
}