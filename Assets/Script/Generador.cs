using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {

	public GameObject[] monedas;
	private GameObject moneda_nueva;
	private Transform pos_salida;
	private int numero_moneda = 0;
	private Animator anim;
	public int cajaGris = 0;

	void Start(){
		pos_salida = transform.Find("posicion_salida").transform;
		anim = GetComponent<Animator> ();
	}

	void OnCollisionEnter2D(Collision2D col){
		if (cajaGris == 3) {
			anim.SetTrigger ("Gris");

		}

		if(col.gameObject.tag == "Player" && cajaGris < 3){
			numero_moneda = Random.Range (0, monedas.Length);
			moneda_nueva = (GameObject)Instantiate (monedas[numero_moneda], pos_salida.position, transform.rotation);
			anim.SetTrigger("Golpe");
			cajaGris++;
		}
			
	}

	void OnTriggerEnter2D(Collider2D objeto){
		if(objeto.tag == "Player" && moneda_nueva == null){
			numero_moneda = Random.Range (0, monedas.Length);
			moneda_nueva = (GameObject)Instantiate (monedas[numero_moneda], pos_salida.position, transform.rotation);
		}
	}
}