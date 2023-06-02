using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverInimigo : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector2(Atirar.ValorTiro, 0) * speed * Time.deltaTime);
    }
}
