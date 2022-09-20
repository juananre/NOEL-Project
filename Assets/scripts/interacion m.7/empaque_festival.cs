using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empaque_festival : MonoBehaviour
{
    [SerializeField] int necesario;
    [SerializeField] int recolectado;

    [SerializeField] Transform ubicacion_sultana;
    [SerializeField] Transform ubicacion_ducales;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "festival")
        {
            Destroy(gameObject);
            recolectado++;
            if (recolectado == necesario)
            {
                print("empacado festival");
            }
        }
        else if (collision.gameObject.tag == "sultana")
        {
            collision.gameObject.transform.position = ubicacion_sultana.position;
        } 

        else if (collision.gameObject.tag == "duacales")
        {
            collision.gameObject.transform.position = ubicacion_ducales.position;
        }
    }
}
