using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilInimigoLixo : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0, 0)) ;
    }
}
