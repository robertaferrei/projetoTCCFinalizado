using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{

    public GameObject bala;
    public GameObject cano;
    public float speed;


    void Start()
    {
        transform.Translate(new Vector2(1, 0) * Time.deltaTime * speed);

    }











    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0)) {
            print("CLiCOU");
            GetComponent<AudioSource>().Play();
            GameObject  b = Instantiate(bala, cano.transform.position, cano.transform.rotation);
            bala.GetComponent<Rigidbody2D>().AddForce(Camera.main.transform.forward * 1000);





        }





    }

    












   




}

