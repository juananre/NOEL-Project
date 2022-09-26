using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empaque_ducales : MonoBehaviour
{
    [SerializeField] int necesario_ducales;
    [SerializeField] int recolectado_ducales;

    [SerializeField] Transform ubicacion_sultana;
    [SerializeField] Transform ubicacion_festival;
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
        if (collision.gameObject.tag == "duacales")
        {
            Destroy(collision.gameObject);
            recolectado_ducales++;
            if (recolectado_ducales == necesario_ducales)
            {
                print("empacado ducales");
            }
        }
        else if (collision.gameObject.tag == "sultana")
        {
            collision.gameObject.transform.position = ubicacion_sultana.position;
        }

        else if (collision.gameObject.tag == "festival")
        {
            collision.gameObject.transform.position = ubicacion_festival.position;
        }
    }
}
