using UnityEngine;
using System.Collections;

public class AutoDestruccionParticulas : MonoBehaviour {
	//ParticleSystem es un sistema de particulas que se va a utilizar y se activará el script
	ParticleSystem sp;

	// Use this for initialization
	void Start () {
		//Le dice a sp que tiene los mismos componentes que un sistema de particulas
		sp = GetComponent<ParticleSystem> ();
		//Se destruye el gameObject cuando acabe la duración que tiene dicho sistema de particulas
		Destroy (gameObject, sp.duration);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
