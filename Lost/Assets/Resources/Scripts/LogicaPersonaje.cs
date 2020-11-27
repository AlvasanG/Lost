using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;

    private AudioSource sonido;
    public AudioClip saltar;
    public AudioClip paso;

    public Animator anim;
    private float x,y;

    public Rigidbody rb;
    public float fuerzadeSalto = 8f;
    public bool puedoSaltar;

    public float velocidadInicial; // guarda la v de movimiento
    public float velocidadAgachado;

    public int nGranadas;
    private bool lanzandoGranada;
    public float granadaCD = 2f;
    public GameObject granada;
    public float throwStrength;

    private float timeStamp;
    private Transform handCoord;


    public float angle = 0.3f;

    //public int nivel;

    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();
        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.5f;
        sonido = GetComponent<AudioSource>();
        lanzandoGranada = false;

        
        handCoord = transform.Find("mixamorig:Hips").transform.Find("mixamorig:Spine").transform.Find("mixamorig:Spine1")
        .transform.Find("mixamorig:Spine2").transform.Find("mixamorig:RightShoulder").transform.Find("mixamorig:RightArm")
        .transform.Find("mixamorig:RightForeArm").transform.Find("mixamorig:RightHand");
    }

    // Estandar de reproduccion
    void FixedUpdate() 
    {

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
        
    }
    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        //Sonidos del personaje al correr
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow)
         || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow) ||
         Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow)
         || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow))       
        {
            sonido.clip = paso;
            sonido.Play();
        }

        if(timeStamp <= Time.time){
            lanzandoGranada = false;
        }

        if(Input.GetKey("e") && !lanzandoGranada){
            timeStamp = Time.time + granadaCD;
            LanzarGranada();
        }

        if(puedoSaltar == true) // Si puedo saltar
        {
            if(Input.GetKeyDown(KeyCode.Space)) // si tecleas
            {
                anim.SetBool("salto", true);
                rb.AddForce(new Vector3(0, fuerzadeSalto, 0), ForceMode.Impulse);
                // Sonido al saltar
                sonido.clip = saltar;
                sonido.Play();

            }
            if (Input.GetKey(KeyCode.LeftShift)) // mientras lo dejemos apretado
            {
                anim.SetBool("agachado", true);
                velocidadMovimiento = velocidadAgachado;

            }
            else
            {
                anim.SetBool("agachado", false);
                velocidadMovimiento = velocidadInicial;
            }
            anim.SetBool("tocoSuelo", true);

        }
        else // Si no puedo saltar
        {
            EstoyCayendo();
        }
    }

    public void EstoyCayendo(){
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("salto", false);
    }

    private void LanzarGranada(){
        lanzandoGranada = true;
        if(nGranadas > 0){
            nGranadas--;

            //hand position
            Vector3 pos = new Vector3(handCoord.position.x,handCoord.position.y,handCoord.position.z);
            Vector3 v = new Vector3(this.transform.forward.x, angle, this.transform.forward.z);
            Vector3 force = throwStrength * v;
            GameObject g = Instantiate(granada, pos, Quaternion.identity);
            g.GetComponent<Rigidbody>().AddForce(force,ForceMode.Impulse);
        } else {
            //Debug.Log("No tenemos granadas");
        }
    }
}