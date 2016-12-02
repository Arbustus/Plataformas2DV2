using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]
public class Menu_Script : MonoBehaviour {
	Animator anim;
	private bool menu_pausa = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (menu_pausa) {
				continuar ();
			} else {
				pausa ();
			}
		}
	}

	public void pausa (){
		menu_pausa = true;
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

	public void continuar(){
		menu_pausa = false;
		Time.timeScale = 1;
		anim.SetBool ("opciones", false);
		anim.SetBool ("pausa", false);
	}
}
