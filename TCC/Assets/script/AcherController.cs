using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AcherController : MonoBehaviour
{

    public Transform posicaoPlayer;
    public float velocidadeMovimento;
    public float distancia;
    public GameObject projetil;
    public bool tempoTiro;
    public GameObject tiroInimigo;
    // Start is called before the first frame update
    void Start()
    {
        tempoTiro = false;
    }

    // Update is called once per frame
    void Update()
    {

        distancia = Vector3.Distance(transform.position, posicaoPlayer.transform.position);

       

        if (distancia < 8 && tempoTiro == false)
        {
            Instantiate(projetil, transform.position, Quaternion.identity);

            projetil.transform.Translate(new Vector2(-1, 0) * 2 * Time.deltaTime);

            tempoTiro = true;

            StartCoroutine(tiroNovo());

        }

       

     //   transform.position = Vector3.MoveTowards(transform.position, posicaoPlayer.position, velocidadeMovimento * Time.deltaTime);

        

    }

    IEnumerator tiroNovo()
    {
        
        yield return new WaitForSeconds(2f);
        tempoTiro = false;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "tiroPlayer")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }









}
