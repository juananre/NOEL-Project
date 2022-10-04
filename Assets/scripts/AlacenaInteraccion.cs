using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class AlacenaInteraccion : MonoBehaviour
{
    public float fadeTime = 1f;
    [Header("--aparece")]
    [SerializeField] GameObject harina;
    [SerializeField] GameObject vitaminas;
    [SerializeField] GameObject huevos;
    [SerializeField] GameObject azucar;

    [Header("--UI")]
    [SerializeField] Image letrero;
    [SerializeField] Image letrero2;
    [SerializeField] Image notaFinal;
    [SerializeField] Image logo;    
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] CanvasGroup canvasGroup2;
    [SerializeField] CanvasGroup canvasGroup3;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] RectTransform rectTransform2;
    [SerializeField] RectTransform rectTransform3;
    [SerializeField] Image nota0;
    [SerializeField] CanvasGroup canvasGroup4;
    [SerializeField] RectTransform rectTransform4;
    [SerializeField] Image notaHuevos;
    [SerializeField] CanvasGroup canvasGroup5;
    [SerializeField] RectTransform rectTransform5;
    [SerializeField] Image notaHarina;
    [SerializeField] CanvasGroup canvasGroup6;
    [SerializeField] RectTransform rectTransform6;
    [SerializeField] Image notaLeche;
    [SerializeField] CanvasGroup canvasGroup7;
    [SerializeField] RectTransform rectTransform7;
    [SerializeField] Image notaMantequilla;
    [SerializeField] CanvasGroup canvasGroup8;
    [SerializeField] RectTransform rectTransform8;

    [Header("--botones")]
    [SerializeField] GameObject bot_harina;
    [SerializeField] GameObject bot_vitaminas;
    [SerializeField] GameObject bot_huevos;
    [SerializeField] GameObject bot_azucar;

    [Header("--posiciones")]
    [SerializeField] Transform p_vitaminas;
    [SerializeField] Transform p_vitaminas_2;
    [SerializeField] Transform p_huevos;
    [SerializeField] Transform p_huevos_2;
    [SerializeField] Transform p_harina;
    [SerializeField] Transform p_harina_2;
    [SerializeField] Transform p_azucar;
    [SerializeField] Transform p_azucar_2;
    [SerializeField] Transform momento_2;

    [Header("--contadores")]
    [SerializeField] int contador_pasa = 0;
    [SerializeField] int necesario = 0;

    [Header("--ususario")]
    [SerializeField] GameObject usuario;

    bool ingrediente_1 = true;
    bool ingrediente_2 = true;
    bool ingrediente_3 = true;
    bool ingrediente_4 = true;
     
    void Start()
    {
        letrero.gameObject.SetActive(true);
        logo.gameObject.SetActive(true);
        nota0.gameObject.SetActive(true);
    }
    void Update()
    {
         if (contador_pasa == necesario)
         {                                    
            trancicion();
            fadeOut();            
            fadeIn();
            fadeOutNotaHarina();
            fadeOutNotaHuevos();
            fadeOutNotaLeche();
            fadeOutNotaMantequilla();
            fadeOutNota0();
            fadeInNota();           
         }       
    }


    public void Entrada_Selec_Harian()
    {
        if (ingrediente_1 == true)
        {
            fadeInNotaHarina();
            contador_pasa += 1;
            ingrediente_1 = false;
        }
        
        Sequence sequence3 = DOTween.Sequence();
        sequence3.Append(bot_harina.transform.DOMove(p_harina.position, 1f));
        sequence3.Append(bot_harina.transform.DOMove(p_harina_2.position, 3f));
        sequence3.OnComplete(() => Destroy(bot_harina));
        
        harina.SetActive(true);
    }
    public void Entrada_Selec_Azucar()
    {
        if (ingrediente_2 == true)
        {
            fadeInNotaMantequilla();
            contador_pasa += 1;
            ingrediente_2 = false;
        }
        
        Sequence sequence4 = DOTween.Sequence();
        sequence4.Append(bot_azucar.transform.DOMove(p_azucar.position, 1f));
        sequence4.Append(bot_azucar.transform.DOMove(p_azucar_2.position, 3f));
        sequence4.OnComplete(() => Destroy(bot_azucar));
        
        azucar.SetActive(true);
    }
    public void Entrada_Selec_huvos()
    {
        if (ingrediente_3 == true)
        {
            fadeInNotaHuevos();
            contador_pasa += 1;
            ingrediente_3 = false;
        }
        Sequence sequence2 = DOTween.Sequence();
        sequence2.Append(bot_huevos.transform.DOMove(p_huevos.position, 1f));
        sequence2.Append(bot_huevos.transform.DOMove(p_huevos_2.position, 3f));
        sequence2.OnComplete(() => Destroy(bot_huevos));
        
        huevos.SetActive(true);
    }
    public void Entrada_Selec_Vitaminas()
    {
        if (ingrediente_4 == true)
        {
            fadeInNotaLeche();
            contador_pasa += 1;
            ingrediente_4 = false;
        }
        Sequence sequence = DOTween.Sequence();
        sequence.Append(bot_vitaminas.transform.DOMove(p_vitaminas.position, 1f));
        sequence.Append(bot_vitaminas.transform.DOMove(p_vitaminas_2.position, 3f));
        sequence.OnComplete(() => Destroy(bot_vitaminas));
        //Tween tran_v = bot_vitaminas.transform.DOMove(p_vitaminas.position, 3f);
        //tran_v.OnComplete(() => Destroy(bot_vitaminas));

        
        vitaminas.SetActive(true);
    }


    public void salida_Selec_Vitaminas()
    {
        

    }
    public void salida_Selec_Huevos()
    {
        
    }
    public void salida_Selec_Harina()
    {
     
    }
    public void salida_Selec_Azucar()
    {
        
    }

    public void trancicion()
    {
        print("a");
        Sequence sequence = DOTween.Sequence();
        sequence.Append(usuario.transform.DOLocalRotateQuaternion(momento_2.rotation, 1.8f));
        sequence.Append(usuario.transform.DOMove(momento_2.position, 4f));
        
        contador_pasa = 0;        
    }

    public void fadeOut()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 300f), fadeTime * 3, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0, fadeTime).OnComplete(() => letrero.gameObject.SetActive(false));        
    }

    public void fadeIn()
    {
        letrero2.gameObject.SetActive(true);
        canvasGroup2.alpha = 0f;
        rectTransform2.transform.localPosition = new Vector3(0f, 300f, 0f);
        rectTransform2.DOAnchorPos(new Vector2(0f, 0f), fadeTime * 2, false).SetEase(Ease.InOutQuint);
        rectTransform2.DOScale(transform.localScale * 1.1f, fadeTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        canvasGroup2.DOFade(1, fadeTime);
    }

    public void fadeInNota()
    {
        notaFinal.gameObject.SetActive(true);
        canvasGroup3.alpha = 0f;
        rectTransform3.transform.localPosition = new Vector3(1170f, 0f, 0f);
        rectTransform3.DOAnchorPos(new Vector2(744f, 0f), fadeTime * 2, false).SetEase(Ease.InOutQuint);
        canvasGroup3.DOFade(1, fadeTime);
    }

    public void fadeOutNota0()
    {
        canvasGroup4.alpha = 1f;
        rectTransform4.transform.localPosition = new Vector3(744f, 0f, 0f);
        rectTransform4.DOAnchorPos(new Vector2(1200f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup4.DOFade(1, fadeTime).OnComplete(() => nota0.gameObject.SetActive(false));
    }
    public void fadeInNotaHuevos()
    {
        notaHuevos.gameObject.SetActive(true);
        canvasGroup5.alpha = 0f;
        rectTransform5.transform.localPosition = new Vector3(1170f, 0f, 0f);
        rectTransform5.DOAnchorPos(new Vector2(744f, 0f), fadeTime , false).SetEase(Ease.InOutQuint);
        canvasGroup5.DOFade(1, fadeTime);
    }
    public void fadeOutNotaHuevos()
    {
        canvasGroup5.alpha = 1f;
        rectTransform5.transform.localPosition = new Vector3(744f, 0f, 0f);
        rectTransform5.DOAnchorPos(new Vector2(1200f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup5.DOFade(1, fadeTime).OnComplete(() => notaHuevos.gameObject.SetActive(false));
    }
    public void fadeInNotaHarina()
    {
        notaHarina.gameObject.SetActive(true);
        canvasGroup6.alpha = 0f;
        rectTransform6.transform.localPosition = new Vector3(1170f, 0f, 0f);
        rectTransform6.DOAnchorPos(new Vector2(744f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup6.DOFade(1, fadeTime);
    }
    public void fadeOutNotaHarina()
    {
        canvasGroup6.alpha = 1f;
        rectTransform6.transform.localPosition = new Vector3(744f, 0f, 0f);
        rectTransform6.DOAnchorPos(new Vector2(1200f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup6.DOFade(1, fadeTime).OnComplete(() => notaHarina.gameObject.SetActive(false));
    }
    public void fadeInNotaLeche()
    {
        notaLeche.gameObject.SetActive(true);
        canvasGroup7.alpha = 0f;
        rectTransform7.transform.localPosition = new Vector3(1170f, 0f, 0f);
        rectTransform7.DOAnchorPos(new Vector2(744f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup7.DOFade(1, fadeTime);
    }
    public void fadeOutNotaLeche()
    {
        canvasGroup7.alpha = 1f;
        rectTransform7.transform.localPosition = new Vector3(744f, 0f, 0f);
        rectTransform7.DOAnchorPos(new Vector2(1200f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup7.DOFade(1, fadeTime).OnComplete(() => notaLeche.gameObject.SetActive(false));
    }
    public void fadeInNotaMantequilla()
    {
        notaMantequilla.gameObject.SetActive(true);
        canvasGroup8.alpha = 0f;
        rectTransform8.transform.localPosition = new Vector3(1170f, 0f, 0f);
        rectTransform8.DOAnchorPos(new Vector2(744f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup8.DOFade(1, fadeTime);
    }
    public void fadeOutNotaMantequilla()
    {
        canvasGroup8.alpha = 1f;
        rectTransform8.transform.localPosition = new Vector3(744f, 0f, 0f);
        rectTransform8.DOAnchorPos(new Vector2(1200f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup8.DOFade(1, fadeTime).OnComplete(() => notaMantequilla.gameObject.SetActive(false));
    }

}
