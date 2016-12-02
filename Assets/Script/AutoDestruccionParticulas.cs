using UnityEngine;
using System.Collections;

public class AutoDestruccionParticulas : MonoBehaviour {
	ParticleSystem sp;

	// Use this for initialization
	void Start () {
		sp = GetComponent<ParticleSystem> ();
		Destroy (gameObject, sp.duration);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
