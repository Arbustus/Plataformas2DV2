using UnityEngine;
using System.Collections;

public class rana : MonoBehaviour {
	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}
	// la rana salta continuamente
	void Update (){
			anim.SetTrigger ("jump");
	}
}
