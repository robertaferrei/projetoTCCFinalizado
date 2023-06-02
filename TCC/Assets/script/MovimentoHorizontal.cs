using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MovimentoHorizontal : MonoBehaviour
{
    public float velocidade;
    public float JumpForce;
    public bool isJumping;
    private Rigidbody2D rig;

    public GameObject projetil;
    public Transform posicaoProjetil;

    private bool abaixar;
    public Animator anim;
    public float movimentoHorizntal;
    public float movimentoVertical;

    public SpriteRenderer spRender;

    public GameObject bullet;
    const float lifeTime = 2;
    public float speed;

    public const float runningSpeed = 9;
    public const float defaultSpeed = 6;
    public float Speed = defaultSpeed;

    public AudioSource somdePulo;
    public float alturaDoPulo;
    public Rigidbody2D Rigidbody2D;
    public bool estaNoChao;
    public Transform verrificadorDeChao;
    public LayerMask layerDoChao;
    public float raioDeVerificacao;



    public Image vida1;
    public Image vida2;
    public Image vida3;
    public Image vida4;
    public Image vida5;

    public int qntVidaAtual;
    public int qntVida;
    public int coins;

    public TextMeshProUGUI textoMoedas;

    private AudioSource sound;
    public AudioClip somMoeda;
    public AudioClip somPulo;
    public AudioClip atirar;

    public TextMeshProUGUI timetext;
    public float tempo;

    public GameObject Bandeira;
    public Button fechar;
    private bool ativarTempo;

    public GameObject posicaoTiro;

    public float forcaTiro;
    public GameObject painelInformacao;


    public float tempoPainel;

    public GameObject botaoFechar;


    public bool iniciarTempoPainel;

    public float velocidadeTiro;

    private bool isVerificarDirecao;


    // Start is called before the first frame update

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        spRender = GetComponentInChildren<SpriteRenderer>();

        qntVidaAtual = 5;
        qntVida = qntVidaAtual;
        sound = GetComponent<AudioSource>();

        fechar.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        movimento();
        slide();
        run();
        Shoot();
        tempoMoeda();



        if (ativarTempo == true)
        {
            tempo += Time.deltaTime;
        }
        if (tempo >= 10)
        {
            fechar.interactable = true;
;        }
        if(iniciarTempoPainel == true && tempoPainel <= 5)
        {
            tempoPainel += Time.deltaTime;

        }else if(tempoPainel >5 )
        {
            iniciarTempoPainel = false;
        }
        if (tempoPainel >= 5)
        {
            botaoFechar.SetActive(true);

        }
        else
        {
            botaoFechar.SetActive(false);
        }
    }

    //Minhas funções
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }

    void slide()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetTrigger("slide");
        }
        else
        {
            spRender.flipX = false;
        }
    }



   

    public void movimento()
    {
        movimentoHorizntal = Input.GetAxisRaw("Horizontal");
        movimentoVertical = Input.GetAxisRaw("Vertical");
        

        if(movimentoHorizntal > 0 && isVerificarDirecao ==true)
        {
            Flip();
        }else if(movimentoHorizntal<0 && isVerificarDirecao == false)
        {
            Flip();
        }


        transform.Translate(new Vector3(1 * movimentoHorizntal, 1 * movimentoVertical, 0) * velocidade * Time.deltaTime);
    }

    
  
    /*
    void OnCollisionEnter2D(Collision2D collisior)

    {
        if (collisior.gameObject.tag == "Chão")
        {
            isJumping = true;
        }

        if (collisior.gameObject.tag == "inimigo")
        {
            Destroy(gameObject);
        }
    }*/

    private void Flip()
    {

        isVerificarDirecao = !isVerificarDirecao;

        float x = transform.localScale.x * -1;

        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);

        velocidadeTiro *= -1;

    }


    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            GameObject temp = Instantiate(projetil);
            temp.transform.position = posicaoTiro.transform.position;
            temp.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeTiro, 0);

        }
    }
    void OnCollisionExit2D(Collision2D collisior)
    {
        if (collisior.gameObject.tag == "Chão")
        {
            isJumping = false;
        }
    }

    void run()
    {
        if (Input.GetKey(KeyCode.K))
        {
            Speed = runningSpeed;
        }
        else if (Speed != defaultSpeed)
        {

            Speed = defaultSpeed;
        }
    }

    public void pular()
    {
        estaNoChao = Physics2D.OverlapCircle(verrificadorDeChao.position, raioDeVerificacao, layerDoChao);

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao == true)
        {
            Rigidbody2D.velocity = Vector2.up * alturaDoPulo;
            somdePulo.Play();
        }
    }


    public void tempoMoeda()
    {
        tempo += Time.deltaTime;
        timetext.text = tempo.ToString("0");
        textoMoedas.text = coins.ToString();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "inimigo")
        {
            // anim.SetTrigger();

            /*
            anim.SetTrigger("morrer");

            movimentoHorizntal = 0;
            movimentoVertical = 0;

            velocidade = 0;

            Destroy(gameObject, 2);
            */

            qntVida -= 1;

            if (qntVida <= 4)
            {
                vida1.enabled = false;
                vida2.enabled = true;
                vida3.enabled = true;
                vida4.enabled = true;
                vida5.enabled = true;

            }
            if (qntVida <= 3)
            {
                vida1.enabled = false;
                vida2.enabled = false;
                vida3.enabled = true;
                vida4.enabled = true;
                vida5.enabled = true;

            }
            if (qntVida <= 2)
            {
                vida1.enabled = false;
                vida2.enabled = false;
                vida3.enabled = false;
                vida4.enabled = true;
                vida5.enabled = true;

            }
            if (qntVida <= 1)
            {
                vida1.enabled = false;
                vida2.enabled = false;
                vida3.enabled = false;
                vida4.enabled = false;
                vida5.enabled = true;

            }
            if (qntVida <= 0)
            {
                vida1.enabled = false;
                vida2.enabled = false;
                vida3.enabled = false;
                vida4.enabled = false;
                vida5.enabled = false;
                qntVida = 0;
                anim.SetTrigger("morrer");

                movimentoHorizntal = 0;
                movimentoVertical = 0;

                velocidade = 0;

                Destroy(gameObject, 2);
            }
        }

        if (col.gameObject.tag == "coins")
        {
            coins++;
            sound.PlayOneShot(somMoeda);
            Destroy(col.gameObject);
        }
        
        if (col.gameObject.tag == "informacoes")
        {
            Bandeira.SetActive(true);

            tempoPainel += Time.deltaTime;

            iniciarTempoPainel = true;

            velocidade = 0;

          

           

           
        }
    }

    public void fecharPainel()
    {
        Bandeira.SetActive(false);
        velocidade = 10;
        iniciarTempoPainel = false;
        tempoPainel = 0;
    }
}