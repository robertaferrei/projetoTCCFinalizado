using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public float velocidade;
    public float fatorAndar;
    private SpriteRenderer imagemInimigo;
    public bool isSensor;
    

    // Start is called before the first frame update
    void Start()
    {
        fatorAndar = 1;
        imagemInimigo = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(fatorAndar, 0) * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sensor")
        {
            isSensor = !isSensor;
            print("Cheguei ao limite");
            fatorAndar = fatorAndar * -1;
            imagemInimigo.flipX = isSensor;


        }
        if (collision.gameObject.tag == "tiroPlayer")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }

   


    void OnCollisionEnter2D(Collision2D collisior)
    {

        if (collisior.gameObject.tag == "inimigo")
        {
            Destroy(gameObject);
        }




    }




}



