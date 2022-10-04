using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class horno_control : MonoBehaviour
{
    public float fadeTime = 1f;

    [Header("--objetos")]
    [SerializeField] GameObject indicador;
    [SerializeField] GameObject boton_final;
    [SerializeField] GameObject boton_inicio;

    [Header("--UI")]
    [SerializeField] Image letreroHorneado;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Image letreroHorneado2;
    [SerializeField] CanvasGroup canvasGroup2;
    [SerializeField] RectTransform rectTransform2;
    [SerializeField] Image feedback;
    [SerializeField] CanvasGroup canvasGroup3;
    [SerializeField] RectTransform rectTransform3;
    [SerializeField] Image feedbackCompletado;
    [SerializeField] CanvasGroup canvasGroup4;
    [SerializeField] RectTransform rectTransform4;
    [SerializeField] Image letreroDecorado;
    [SerializeField] CanvasGroup canvasGroup5;
    [SerializeField] RectTransform rectTransform5;


    [Header("--renders,(se auto asignan)")]
    [SerializeField] Renderer color_indicador;
    [SerializeField] Renderer color_boton_incio;
    [SerializeField] Renderer color_boton_final;

    [Header("--bandeja y posiciones")]
    [SerializeField] GameObject bandeja;
    [SerializeField] Transform pocision1;
    [SerializeField] Transform pocision2;
    [SerializeField] Transform momento_6;

    [Header("--usuario")]
    [SerializeField] GameObject usuario;

    [Header("--tiempos")]
    public float tiempo_master = 0;

    bool tiempo_ini = true;
    bool parar = false;
    bool tiempo_contar = false;
    
    public int control_switch = 0;

    // Start is called before the first frame update
    void Start()
    {
        color_indicador = indicador.GetComponent<Renderer>();
        color_boton_incio = boton_inicio.GetComponent<Renderer>();
        color_boton_final = boton_final.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (tiempo_contar == true)
        {
            
            tiempo_master += Time.deltaTime;
        }
        
        if(tiempo_master >=0.01 && tiempo_master <= 0)
        {
            fadeInLetreroHorneado2();
            tiempo_master = 0;
        }
        if (0.001f<=tiempo_master&&tiempo_master<=3)
        {
            color_indicador.material.color = Color.yellow;
            control_switch = 1;
            
            fadeOutLetreroHorneado();
            
        }

        else if (4 <= tiempo_master && tiempo_master <= 6)
        {
            color_indicador.material.color = Color.green;
            control_switch = 2;
        }

        else if (7 <= tiempo_master && tiempo_master <= 11)
        {
            color_indicador.material.color = Color.red;
            control_switch = 3;
        }
        else if (tiempo_master > 12)
        {
            tiempo_master = 0;
            print("de nuevo");
            
        }
    }
    public void Boton_inicio()
    {
        tiempo_contar = true;
        fadeInLetreroHorneado2();

        if (tiempo_ini == true)
        {
            color_boton_incio.material.color = Color.gray;
            color_boton_final.material.color = Color.blue;
            tiempo_ini = false;
            

            parar = true;
        }
        
    }
    public void Boton_final()
    {

        if (parar == true)
        {
            switch (control_switch)
            {
                case 1:
                    print("galletas crudas");
                    fadeInLetreroHorneado2();

                    parar = true;                  
                    tiempo_master = 0;
                    break;
            }
            switch (control_switch)
            {
                case 2:
                    print("galletas perfectas");

                    
                    parar = false;
                    tiempo_contar = false;
                    tiempo_master = 0;

                    Sequence sequence = DOTween.Sequence();
                    sequence.Append(bandeja.transform.DOMove(pocision1.position, 1f));
                    sequence.Append(bandeja.transform.DOMove(pocision2.position, 1f));
                    sequence.OnComplete(() => Destroy(bandeja));
                    sequence.Append(usuario.transform.DOLocalRotateQuaternion(momento_6.rotation, 1.6f));
                    sequence.Append(usuario.transform.DOMove(momento_6.position, 2.5f));
                    fadeFeedbackCompletado();
                    fadeOutLetreroHorneado2();
                    fadeInLetreroDecorado();

                    break;
            }
            switch (control_switch)
            {
                case 3:
                    print("galletas quemadas");

                    
                    parar = true;
                    tiempo_master = 0;
                    break;
            }
        }
    }

    public void fadeOutLetreroHorneado()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 300f), 2, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0, fadeTime).OnComplete(() => letreroHorneado.gameObject.SetActive(false));
    }
    public void fadeInLetreroHorneado2()
    {
        letreroHorneado2.gameObject.SetActive(true);
        canvasGroup2.alpha = 0f;
        rectTransform2.transform.localPosition = new Vector3(0f, 300f, 0f);
        rectTransform2.DOAnchorPos(new Vector2(0f, 0f), 2, false).SetEase(Ease.InOutQuint);
        canvasGroup2.DOFade(1, fadeTime);
    }

    public void fadeOutLetreroHorneado2()
    {
        canvasGroup2.alpha = 1f;
        rectTransform2.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform2.DOAnchorPos(new Vector2(0f, 300f), 2, false).SetEase(Ease.InOutQuint);
        canvasGroup2.DOFade(0, fadeTime).OnComplete(() => letreroHorneado2.gameObject.SetActive(false));
    }

    public void fadeFeedbackCompletado()
    {
        feedbackCompletado.gameObject.SetActive(true);
        canvasGroup4.alpha = 0f;
        rectTransform4.transform.localPosition = new Vector3(0f, -500f, 0f);
        rectTransform4.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup4.DOFade(1, fadeTime);
        canvasGroup4.alpha = 1f;
        rectTransform4.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform4.DOAnchorPos(new Vector2(0f, 500f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup4.DOFade(0, fadeTime).OnComplete(() => feedbackCompletado.gameObject.SetActive(false));
    }

    public void fadeInLetreroDecorado()
    {
        letreroDecorado.gameObject.SetActive(true);
        canvasGroup5.alpha = 0f;
        rectTransform5.transform.localPosition = new Vector3(0f, 300f, 0f);
        rectTransform5.DOAnchorPos(new Vector2(0f, 0f), 2, false).SetEase(Ease.InOutQuint);
        //rectTransform5.DOScale(transform.localScale * 1.1f, fadeTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        canvasGroup5.DOFade(1, fadeTime);
    }
}
