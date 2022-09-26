using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empaque_sultanas : MonoBehaviour
{
    [SerializeField] int necesario_sulana;
    [SerializeField] int recolectado_sultana;

    [SerializeField] Transform ubicacion_ducales;
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
        if (collision.gameObject.tag == "sultana")
        {
            Destroy(collision.gameObject);
            recolectado_sultana++;
            if (recolectado_sultana == necesario_sulana)
            {
                print("empacado sultanas");
            }
        }
        else if (collision.gameObject.tag == "duacales")
        {
            collision.gameObject.transform.position = ubicacion_ducales.position;
        }

        else if (collision.gameObject.tag == "festival")
        {
            collision.gameObject.transform.position = ubicacion_festival.position;
        }
    }
}
