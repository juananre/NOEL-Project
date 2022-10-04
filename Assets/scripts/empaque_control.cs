using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;



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

    [Header("--UI")]
    [SerializeField] Image letreroFinal;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Image letreroDecorado;
    [SerializeField] CanvasGroup canvasGroup2;
    [SerializeField] RectTransform rectTransform2;
    public float fadeTime = 1f;



    [SerializeField] GameObject paquetes_cerrado;

    int paquetes_hechos = 0;
    int hechos = 3;
    int finalizados = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (finalizados >= 3)
        {
            fadeInLetreroFinal();
            fadeOutLetreroDecorado();
        }
        
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
                sequence.Append(transform.DOMove(salida_sultana.position, 3f));
                sequence.OnComplete(() => gameObject.SetActive(false));
                print("empacado sultanas");
                finalizados++;
            }
        }

        else if (collision.gameObject.tag == "festival"&& gameObject.tag == "festival_paquete")
        {
            Destroy(collision.gameObject);
            recolectado_festival++;
            if (recolectado_festival == necesario_festival)
            {
                Sequence sequence = DOTween.Sequence();
                sequence.Append(transform.DOMove(salida_festival.position, 3f));
                sequence.OnComplete(() => gameObject.SetActive(false));
                print("empacado festival");
                finalizados ++;
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
                sequence.Append(transform.DOMove(salida_ducales.position, 3f));
                sequence.OnComplete(() => gameObject.SetActive(false));
                print("empacado ducales");
                finalizados++;
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

    public void fadeInLetreroFinal()
    {
        letreroFinal.gameObject.SetActive(true);
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(0f, 300f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), 2, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(1, fadeTime);
    }
    public void fadeOutLetreroDecorado()
    {
        canvasGroup2.alpha = 1f;
        rectTransform2.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform2.DOAnchorPos(new Vector2(0f, 300f), 2, false).SetEase(Ease.InOutQuint);
        canvasGroup2.DOFade(0, fadeTime).OnComplete(() => letreroDecorado.gameObject.SetActive(false));
    }

}
