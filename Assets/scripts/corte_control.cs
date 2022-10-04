using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class corte_control : MonoBehaviour
{
    [Header("--tiempos")]
    public float energy_cortada;
    public int requerido = 10;
    public float fadeTime = 1f;

    [Header("--objetos")]
    [SerializeField] GameObject maza_no_cortada;
    [SerializeField] GameObject maza_cortada;
    [SerializeField] GameObject bandejaOff;
    [SerializeField] GameObject rodillo;

    [Header("--UI")]
    [SerializeField] Image letreroCorte;
    [SerializeField] Image feedback;
    [SerializeField] Image letreroHorneado;
    [SerializeField] Image letreroHorneado2;
    [SerializeField] Image feedbackToque;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] CanvasGroup canvasGroup2;
    [SerializeField] RectTransform rectTransform2;
    [SerializeField] CanvasGroup canvasGroup3;
    [SerializeField] RectTransform rectTransform3;
    [SerializeField] CanvasGroup canvasGroup4;
    [SerializeField] RectTransform rectTransform4;
    [SerializeField] CanvasGroup canvasGroup5;
    [SerializeField] RectTransform rectTransform5;

    [Header("--posiciones")]
    [SerializeField] Transform pocision_1;
    [SerializeField] Transform pocision_2;
    [SerializeField] Transform pocision_3;
    [SerializeField] Transform momento_5;

    [Header("--usuario")]
    [SerializeField] GameObject usuario;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

       /* if (Input.GetKeyDown(KeyCode.Space))
        {
           
        }*/
    }

    public void OnTriggerStay(Collider other)
    {
        energy_cortada += Time.deltaTime;
       

         if (energy_cortada >= requerido)
        {
            maza_no_cortada.SetActive(false);
            maza_cortada.SetActive(true);
            bandejaOff.SetActive(false);
            rodillo.SetActive(false);

            animacion_usuario();
            animacion_bandeja();
            fadeOutLetrero();
            fadeInLetreroHorneado();
            bounceToque();           
        }
    }
    void animacion_bandeja()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(maza_cortada.transform.DOMove(pocision_1.position, 1.5f));
        sequence.Append(maza_cortada.transform.DOMove(pocision_2.position, 1.5f));
        sequence.Append(maza_cortada.transform.DOMove(pocision_3.position, 2f));
        //sequence.OnComplete(() => Destroy(maza_cortada));
    }
    void animacion_usuario()
    {
        Sequence sequence2 = DOTween.Sequence();
        sequence2.Append(usuario.transform.DOMove(momento_5.position, 1f));
    }

    public void fadeOutLetrero()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 300f), 2, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0, fadeTime).OnComplete(() => letreroCorte.gameObject.SetActive(false));
    }

    public void fadeFeedback()
    {
        feedback.gameObject.SetActive(true);

        canvasGroup2.alpha = 0f;
        rectTransform2.transform.localPosition = new Vector3(194f, -261f, 0f);
        rectTransform2.DOAnchorPos(new Vector2(194f, -181f), fadeTime * 2, false).SetEase(Ease.InOutQuint);
        canvasGroup2.DOFade(1, fadeTime);
        canvasGroup2.alpha = 1f;
        rectTransform2.transform.localPosition = new Vector3(194f, -181f, 0f);
        rectTransform2.DOAnchorPos(new Vector2(669f, 533f), fadeTime * 2, false).SetEase(Ease.InOutQuint);
        canvasGroup2.DOFade(0, fadeTime).OnComplete(() => feedback.gameObject.SetActive(false));
    }

    public void fadeInLetreroHorneado()
    {       
        letreroHorneado.gameObject.SetActive(true);
        canvasGroup3.alpha = 0f;
        rectTransform3.transform.localPosition = new Vector3(0f, 300f, 0f);
        rectTransform3.DOAnchorPos(new Vector2(0f, 0f), 2, false).SetEase(Ease.InOutQuint);
        //rectTransform3.DOScale(transform.localScale * 1.1f, fadeTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        canvasGroup3.DOFade(1, fadeTime);
    }


    public void bounceToque()
    {
        feedbackToque.gameObject.SetActive(true);
        canvasGroup4.alpha = 0f;
        rectTransform4.transform.localPosition = new Vector3(66f, -351f, 0f);
        rectTransform4.DOAnchorPos(new Vector2(66f, -492f), fadeTime * 2, false).SetEase(Ease.InOutQuint);
        //rectTransform4.DOScale(transform.localScale * 2, fadeTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        canvasGroup4.DOFade(1, fadeTime);
        canvasGroup4.alpha = 1f;
        rectTransform4.transform.localPosition = new Vector3(66f, -492f, 0f);
        rectTransform4.DOAnchorPos(new Vector2(66f, -550f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup2.DOFade(0, fadeTime).OnComplete(() => feedbackToque.gameObject.SetActive(false));
    }
}
