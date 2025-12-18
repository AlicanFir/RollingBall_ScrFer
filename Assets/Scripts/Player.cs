using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //TODAS LAS VARIABLES QUE APAREZCAN AQUI SON SOLO DE BOLAS
    //VARIABLES
    private Rigidbody rb;
    private Vector3 initialPosition;
    
    [SerializeField] private float altura;
    [SerializeField] private float force;
    private float initialForce;

    private float h; // si genero una variable global es usable desde todas las funciones
    private float v;

    private Vector3 interactionPoint;
    [SerializeField] private float interactionRadius;

    [SerializeField] private AudioClip jumpSound;

    private void Awake()
    {
        initialPosition = transform.position;
        initialForce = force;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // llamo al componente y lo almaceno en rb
    }

    void Update() // los inputs siempre se registran en el update
    {
        Movement();
        Interactions();
        
    }

    private void Interactions()
    {
        //cuando le das a la e lanzas como un radar para ver si hay algo delante

        if (Input.GetKeyDown(KeyCode.E))
        {
            interactionPoint = rb.transform.position - Vector3.forward * 0.5f; //punto en el que se origina la info
            //dibujamos la esfera para ver como de grande es como debug
            
            Collider [] results = Physics.OverlapSphere(interactionPoint, interactionRadius);

            if (results.Length > 0) //interfaces
            {
                // tenemos que flitrar, porque pilla el boton y el suelo ...
                //recorro todos los resultados y miro si alguno tiene el tag boton
                foreach (var result in results)
                {
                    if (result.gameObject.TryGetComponent(out Boton botonScript)) //a eso que he detectado mira a ver si tiene un componente y si lo tiene me lo das.
                    {
                        //hemos comprobado que result.gameobject es un boton y abrimos la puerta
                        botonScript.OpenDoor();
                    }
                }
            }
        }
    }

    private void Movement()
    {
        //si genero una variable en una funcion esta es local y solo se puede acceder desde su funcion
        v = Input.GetAxisRaw("Vertical"); 
        h = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Physics.Raycast(transform.position, Vector3.down, transform.localScale.y + 0.1f))
            {
                //lanza un raycast al suelo para ver la distancia y asi ver si salta o no
                AudioManager.instance.PlaySFX(jumpSound);
                RotateOnJump();
                rb.AddForce(Vector3.up* (altura * force), ForceMode.Impulse);
            }
        }
    }

    private void RotateOnJump()
    {
        if (v != 0) {transform.eulerAngles = new Vector3(90, 0, 0);}
        else if (h != 0) {transform.eulerAngles = new Vector3(0, 0, 90);}
    }

    void FixedUpdate() //cuando usamos comportamientos fisicos usamos fixed update -- se ejecuta cada 0.02 sec -- lo referido a fisicas -- comportamiento en el tiempo
    {
        rb.AddForce(new Vector3(-h, 0, -v).normalized * force, ForceMode.Force); //siempre que no trabajemos con el transform debemos usar getcomponent
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(interactionPoint, interactionRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out GoldenCube goldenCube))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Death"))
        {
            force = 0;
            this.gameObject.transform.position = initialPosition;
            force = initialForce;
        }
    }
}
