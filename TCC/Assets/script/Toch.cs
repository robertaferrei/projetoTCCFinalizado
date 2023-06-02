using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toch : MonoBehaviour
{
    private int auxDirecao;
    private float speed;
    private bool isVerificarDirecao;
    public GameObject projetil;
    public float velocidadeTiro;
    public GameObject posicaoTiro;


    void Start()
    {
        speed = 8f; 
    }


    void Update()
    {
        if(auxDirecao != 0)
        {
            transform.Translate(speed * Time.deltaTime * auxDirecao, 0, 0);
        }
        if (auxDirecao < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if(auxDirecao > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (auxDirecao > 0 && isVerificarDirecao == true)
        {
            Flip();
        }
        else if (auxDirecao < 0 && isVerificarDirecao == false)
        {
            Flip();
        }

    }
    public void TochHorizontal(int direcao)
    {
        auxDirecao = direcao;
    }

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
}
