using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class empaque_control : MonoBehaviour
{
    [SerializeField] int necesario_sulana;
    [SerializeField] int recolectado_sultana;

    [SerializeField] int necesario_festival;
    [SerializeField] int recolectado_festival;

    [SerializeField] int necesario_ducales;
    [SerializeField] int recolectado_ducales;

    [SerializeField] Transform ubicacion_ducales;
    [SerializeField] Transform ubicacion_festival;
    [SerializeField] Transform ubicacion_sultana;
    [SerializeField] Transform salida_ducales;
    [SerializeField] Transform salida_festival;
    [SerializeField] Transform salida_sultana;
    [SerializeField] Transform llegada_paquetes;

    [SerializeField] GameObject paquetes_cerrado;

    int paquetes_hechos = 0;
    int hechos = 3;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "sultana"&& gameObject.tag == "sultana_paquete")
        {
            Destroy(collision.gameObject);
            recolectado_sultana++;
            if (recolectado_sultana == necesario_sulana)
            {
                Sequence sequence = DOTween.Sequence();
                sequence.Append(transform.DOMove(salida_sultana.position, 1f));
                sequence.OnComplete(() => gameObject.SetActive(false));
                print("empacado sultanas");
            }
        }

        else if (collision.gameObject.tag == "festival"&& gameObject.tag == "festival_paquete")
        {
            Destroy(collision.gameObject);
            recolectado_festival++;
            if (recolectado_festival == necesario_festival)
            {
                Sequence sequence = DOTween.Sequence();
                sequence.Append(transform.DOMove(salida_festival.position, 1f));
                sequence.OnComplete(() => gameObject.SetActive(false));
                print("empacado festival");
            }
        }
        else if (collision.gameObject.tag == "duacales"&& gameObject.tag == "ducales_paque")
        {
            Destroy(collision.gameObject);
            recolectado_ducales++;
            if (recolectado_ducales == necesario_ducales)
            {
                paquetes_hechos += 1;
                Sequence sequence = DOTween.Sequence();
                sequence.Append(transform.DOMove(salida_ducales.position, 1f));
                sequence.OnComplete(() => gameObject.SetActive(false));
                print("empacado ducales");
            }
        }

        else if (collision.gameObject.tag == "duacales" && gameObject.tag != "ducales_paque")
        {
            collision.gameObject.transform.position = ubicacion_ducales.position;
        }

        else if (collision.gameObject.tag == "festival" && gameObject.tag != "festival_paquete")
        {
            collision.gameObject.transform.position = ubicacion_festival.position;
        }

        else if (collision.gameObject.tag == "sultana" && gameObject.tag != "sultana_paquete")
        {
            collision.gameObject.transform.position = ubicacion_sultana.position;
        }
        

    }

  
}
