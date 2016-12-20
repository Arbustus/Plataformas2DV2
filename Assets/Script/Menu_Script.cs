using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]//requiere que el elemento tenga un Animator
//controla los menus
public class Menu_Script : MonoBehaviour {
	Animator anim;
	//para saber si el menú está o no en pausa
	private bool menu_pausa = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//al pulsar una tecla se activa el menu pausa o el continuar
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//si estas en el menu pasa activas continuar
			if (menu_pausa) {
				continuar ();
				//so mp activa pausa
			} else {
				pausa ();
			}
		}
	}
	//menu pausa donde el buleano está activado, paras el tiempo y modificas los valores de anim. para hacer la animación.
	public void pausa (){
		menu_pausa = true;
		//controla el tiempo de la escena, los valores válidos son entre 0 y 1.
		Time.timeScale = 0;
		anim.SetBool ("opciones", false);
		anim.SetBool ("pausa", true);
	}

	public void salir(){
		Application.Quit ();
		Debug.Log ("Saliendo!");
	}

	public void opciones(){
		anim.SetBool ("opciones", true);
		anim.SetBool ("pausa", true);
	}
	// menu_pausa es falso y vuelve a correr el tiempo.
	public void continuar(){
		menu_pausa = false;
		Time.timeScale = 1;
		anim.SetBool ("opciones", false);
		anim.SetBool ("pausa", false);
	}
}
