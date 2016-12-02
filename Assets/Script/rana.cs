using UnityEngine;
using System.Collections;

public class rana : MonoBehaviour {
	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Update (){
			anim.SetTrigger ("jump");
	}
}
