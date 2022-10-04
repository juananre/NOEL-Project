using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AmazadoInteraccion : MonoBehaviour
{
    [Header("--energia")]

    public float energy;
    public float requerido =10;
    public float fadeTime = 1f;

    [Header("--objetos")]

    [SerializeField] GameObject maza_1;
    [SerializeField] GameObject maza_2;
    [SerializeField] GameObject rodillo_normal;
    [SerializeField] GameObject rodillo_corte;

    [Header("--UI")]
    [SerializeField] Image barra;
    [SerializeField] Image letrero;
    [SerializeField] Image barraCompleta;
    [SerializeField] Image letreroCorte;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] CanvasGroup canvasGroup2;
    [SerializeField] CanvasGroup canvasGroup3;
    [SerializeField] CanvasGroup canvasGroup4;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] RectTransform rectTransform2;
    [SerializeField] RectTransform rectTransform3;
    [SerializeField] RectTransform rectTransform4;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("rodillo"))
        {
            BarAnimation();
            energy += Time.deltaTime;
            if (energy >= requerido)
            {
                barra.DOFillAmount(1, 1);
                maza_1.SetActive(false);
                maza_2.SetActive(true);
                rodillo_normal.SetActive(false);
                rodillo_corte.SetActive(true);
                fadeOutLetrero();
                fadeOutBarra();
                fadeInLetreroCorte();
            }
        }              
    }

    public void BarAnimation()
    {      
        barra.DOFillAmount(1, 5.5f);
    }

    public void fadeOutLetrero()
    {
        canvasGroup2.alpha = 1f;
        rectTransform2.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform2.DOAnchorPos(new Vector2(0f, 300f), 2, false).SetEase(Ease.InOutQuint);
        canvasGroup2.DOFade(0, fadeTime).OnComplete(() => letrero.gameObject.SetActive(false));
    }

    public void fadeOutBarra()
    {
        canvasGroup3.alpha = 1f;
        rectTransform3.transform.localPosition = new Vector3(0f, -5f, 0f);
        rectTransform3.DOAnchorPos(new Vector2(0f, 420f), 2, false).SetEase(Ease.InOutQuint);
        canvasGroup3.DOFade(0, fadeTime).OnComplete(() => barraCompleta.gameObject.SetActive(false));
    }
    public void fadeInLetreroCorte()
    {
        letreroCorte.gameObject.SetActive(true);
        canvasGroup4.alpha = 0f;
        rectTransform4.transform.localPosition = new Vector3(0f, 300f, 0f);
        rectTransform4.DOAnchorPos(new Vector2(0f, 0f), 2, false).SetEase(Ease.InOutQuint);
        //rectTransform4.DOScale(transform.localScale * 1.1f, fadeTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        canvasGroup4.DOFade(1, fadeTime);
    }
}
