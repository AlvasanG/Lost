using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LogicaPersonaje : MonoBehaviour
{
    private AudioSource sonido;
    public AudioClip saltar;
    public AudioClip paso;

    public Animator anim;
    private float xAxis,yAxis;

    public Rigidbody rb;

    [Header("Movimiento")]
    
    public float velocidadMovimiento = 8f;
    public float velocidadRotacion = 200.0f;
    public float fuerzadeSalto = 8f;
    public bool puedoSaltar;
    public float velocidadInicial; // guarda la v de movimiento
    public float velocidadAgachado;
    private bool inverse;

    [Header("Granadas")]
    public int nGranadas;
    private bool lanzandoGranada;
    public float granadaCD = 2f;
    public GameObject granada;
    public float throwStrength;
    private float timeStamp;
    private Transform handCoord;
 
    public float angle = 0.3f; 
    
    
    [Header("Elementos HUD")]
    private GameObject playerHUD;
    private GameObject t_mainDialogue;
    private GameObject t_granadas;
    private GameObject p_buttons;
    private GameObject s_health;
    private Slider hpBar;

    [Header("Vida")]
    private float health;
    public float maxHealth;



    //public int nivel;

    // Start is called before the first frame update
    void Start()
    {
        if(transform.rotation.y == 1)
            inverse = true;
        else
            inverse = false;

        puedoSaltar = false;
        anim = GetComponent<Animator>();
        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.5f;
        sonido = GetComponent<AudioSource>();
        lanzandoGranada = false;
        health = maxHealth;

        playerHUD = GameObject.FindWithTag("HUD");
        if(playerHUD != null)
        {
            t_mainDialogue = GameObject.FindWithTag("text_MainDialogue");
            t_granadas = GameObject.FindWithTag("text_Granadas");
            p_buttons = GameObject.FindWithTag("panel_Buttons");
            s_health = GameObject.FindWithTag("slider_HP");
            if(s_health != null)
            {
                hpBar = s_health.GetComponent<Slider>();
                hpBar.value = CalculateHealth();
            }
        }
        

        handCoord = transform.Find("mixamorig:Hips");/*.transform.Find("mixamorig:Spine").transform.Find("mixamorig:Spine1")
        .transform.Find("mixamorig:Spine2").transform.Find("mixamorig:RightShoulder").transform.Find("mixamorig:RightArm")
        .transform.Find("mixamorig:RightForeArm").transform.Find("mixamorig:RightHand");*/
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGranadaText();
        UpdateHealth();

        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        anim.SetFloat("VelX", xAxis);
        anim.SetFloat("VelY", yAxis);

        var camera = Camera.main;

        var forward = camera.transform.forward;
        var right = camera.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        var desiredMoveDirection = (forward * yAxis + right * xAxis);

        desiredMoveDirection = inverse ? desiredMoveDirection * (-1) : desiredMoveDirection;

        transform.Translate(desiredMoveDirection * velocidadMovimiento * Time.deltaTime);

        //Sonidos del personaje al correr
        if(xAxis != 0f || yAxis != 0f)       
        {
            sonido.clip = paso;
            sonido.Play();
        }

        if(timeStamp <= Time.time){
            lanzandoGranada = false;
        }

        if( (Input.GetKey("e") || Input.GetButtonDown("Fire1")) && !lanzandoGranada){
            timeStamp = Time.time + granadaCD;
            LanzarGranada();
        }

        if(puedoSaltar == true) // Si puedo saltar
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) // si tecleas
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

            var camera = Camera.main;

            var forward = camera.transform.forward;
            forward.Normalize();

            //hand position
            Vector3 pos = new Vector3(handCoord.position.x,handCoord.position.y+1,handCoord.position.z);
            Vector3 force = throwStrength * forward;
            GameObject g = Instantiate(granada, pos, Quaternion.identity);
            g.GetComponent<Rigidbody>().AddForce(force,ForceMode.Impulse);
        } 
    }

    private void UpdateGranadaText()
    {
        t_granadas.GetComponent<Text>().text = "Granadas: " + nGranadas;
        if(nGranadas > 0)
            t_granadas.GetComponent<Text>().color = Color.black;
        else {
            t_granadas.GetComponent<Text>().color = Color.red;
        }
    }

    private float CalculateHealth()
    {
        return health/maxHealth;
    }

    private void UpdateHealth()
    {
        hpBar.value = CalculateHealth();

        if(health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if(health > maxHealth)
        {
            health = maxHealth;
        }

    }

    public void RecieveDamage(float damage)
    {
        health -= damage;
    }

    // Setter / Getter
    public GameObject GetTextMainDialogue()
    {
        return t_mainDialogue;
    }

    public GameObject GetButtonPanel()
    {
        return p_buttons;
    }

    public void EmptyText()
    {
        t_mainDialogue.GetComponent<Text>().text = "";
    }
}
