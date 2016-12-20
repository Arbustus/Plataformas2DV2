using UnityEngine;
using System.Collections;
//hace falta un AudioSource (solo uno en la escena) un RigidBody2D y un GameObject
[RequireComponent (typeof(AudioSource))]
[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(GameObject))]
public class Player1_Controles : MonoBehaviour {
	//velocidad de ljugador
	public float velocidad = 100f;
	//audios que genera
	public AudioClip sonido_salto;
	public AudioClip sonido_herir;
	public AudioClip sonido_moneda;
	//particulas que apareceran cuando se muera
	public GameObject particulas_muerte;
	//public float velocidad_maxima = 5f; LO COMENTADO ES PARA USAR ACELERACIÓN HASTA UNA VELOCIDAD MAXIMA Y NO UNA VELOCIDAD CONSTANTE DESDE INICIO

	//para saber si esta el suelo o no cerca
	private bool suelo_cerca = false;
	//para modificar el animator
	private Animator anim;
	//para poder darle un movimiento
	private Rigidbody2D rb;
	//Para acceder a la posición y poder teletransportarlo
	private GameControlScript gcs;
	//acceder a los audios
	private AudioSource audio;




	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		gcs = GameObject.Find ("GameControl").GetComponent<GameControlScript> ();
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Mathf.Abs es equivalente al valor absoluto
		//velocidad = Mathf.Abs(rb.velocity.x);
		//if (velocidad > velocidad_maxima) {
			// transform.localScale.x multiplica esa velocidad maxima por la direccion a donde está mirando el personaje. Esto permite que sea negativa o positiva la velocidad se mueva sin problema y con un límite.
			//rb.velocity = new Vector2(velocidad_maxima * transform.localScale.x, rb.velocity.y);
		//}
		anim.SetFloat("velocity", Mathf.Abs(rb.velocity.x)); // igualamos la velocidad al valor de velocity para que al moverse el personaje a X velocidad cambie la animación

		if (Input.GetKey (KeyCode.RightArrow)) {
			MovimientoDerecha ();
		}

		//if (Input.GetKeyUp (KeyCode.RightArrow)) {
			//anim.SetFloat ("velocity", 0f);
		//}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			MovimientoIzquierda ();
		}

		//if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			//anim.SetFloat ("velocity", 0f);
		//}
		//
		if (Input.GetKeyDown (KeyCode.UpArrow) && suelo_cerca) {
			Salto ();
		}
				
	}

	void MovimientoDerecha(){
		//GetComponent<Rigidbody2D> ().AddForce (Vector2.right*fuerza);
		rb.velocity = new Vector2(velocidad, rb.velocity.y);//Se le añade fuerza constante al rb en x y se mantiene la fuerza en y
		this.transform.localScale = new Vector3(1, 1, 1);//cambia la escala, se usa para que mire hacia otro lado
		//anim.SetFloat ("velocity", 1f);
	}

	void MovimientoIzquierda() {
		//GetComponent<Rigidbody2D> ().AddForce (Vector2.left*fuerza);
		rb.velocity = new Vector2(-velocidad, rb.velocity.y);
		this.transform.localScale = new Vector3(-1, 1, 1);
		//anim.SetFloat ("velocity", 1f);
	}

	void Salto() {
		rb.AddForce (Vector2.up*300);//se le añade una fuerza en y al salto
		anim.SetBool ("jump", true);
		audio.PlayOneShot (sonido_salto, 0.5f);//el audio se escucha una vez
	}

	void OnTriggerStay2D(Collider2D objeto){
		//si el jugador está en contacto con Apoyo suelo_cerca será true.
		if (objeto.tag == "Apoyo") {
			suelo_cerca = true;
			anim.SetBool ("jump", false);
		} else {
			suelo_cerca = false;
		}
	}

					//void OnTriggerExit2D(Collider2D objeto){
						//if(objeto.tag == "Apoyo") {
						//	suelo_cerca = false;
						//}
					//}

	void OnCollisionEnter2D(Collision2D col){
		//al entrar en contacto con muerte
		if (col.gameObject.tag == "muerte") {
			//gcs.respaw ();
			audio.PlayOneShot (sonido_herir, 0.5f);
			//creas las particulas_muerte en la posicion y con la rotación del jugador
			Instantiate(particulas_muerte, transform.position, transform.rotation);
			//invoke funciona para que se active una función después de x tiempo, en este caso se activa la muerte al pasar un segundo
			Invoke ("muerte", 1);
		}
		if (col.gameObject.tag == "Moneda") {
			audio.PlayOneShot (sonido_moneda, 0.5f);
		}
	}
	//al morir, repareces en el último punto guardado en el gcs.
	void muerte(){
		gcs.respaw ();
	}
}