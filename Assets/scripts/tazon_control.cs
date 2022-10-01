using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class tazon_control : MonoBehaviour
{
    [Header("tiempos nesario")]
    public int conter;
    public int necesario = 0;
    public float energy_tazon;
    public int requerido = 10;
    public float fadeTime = 1f;

    
    [Header("--objetos")]
    [SerializeField] GameObject batidora;
    [SerializeField] GameObject momento3;
    [SerializeField] Image letrero2;
    [SerializeField] Image feedback1;
    [SerializeField] Image feedback2;
    [SerializeField] Image nota;
    [SerializeField] Image mezcla;
    [SerializeField] Image letrero5;
    [SerializeField] Image barra;
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
    [SerializeField] CanvasGroup canvasGroup6;
    [SerializeField] RectTransform rectTransform6;

    [Header("--pocision")]
    [SerializeField] Transform p_hoya;
    [SerializeField] Transform p_hoya_2;
    [SerializeField] Transform p_hoya_resta;
    [SerializeField] Transform momento_2_3;

    [Header("--usuario")]
    [SerializeField] GameObject usuario;

    bool aniamuser = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        print("hola");

        if (other.CompareTag("ingredientes"))
        {
            conter++;
            Destroy(other.gameObject);

            if(conter == 1)
            {                
                fade1();
            }
            if (conter == 3)
            {
                fade2();                
            }

            if (conter == necesario)
            {
                batidora.SetActive(true);
                letrero2.gameObject.SetActive(false);
                fadeOutNota();
                fadeInMezcla();
            }

        }

    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("batidora") && conter == necesario)
        {
            energy_tazon += Time.deltaTime;            
            if (energy_tazon >= requerido)
            {

                batidora.SetActive(false);
                animacion_tazon();
                fadeOutMezcla();
                if (aniamuser == true)
                {
                    animacion_usuario();
                }

                print("exito");//se mueve la hoya
                momento3.SetActive(true);
                fadeInLetrero5();
                fadeInBarra();
                //delay
                //se mueve la camara 
            }
            
        }
    }
    void animacion_tazon()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(p_hoya.position, 1f));
        sequence.Append(transform.DOMove(p_hoya_2.position, 1f));
        sequence.Append(transform.DORotateQuaternion(p_hoya.rotation, 2f));
        sequence.Append(transform.DORotateQuaternion(p_hoya_resta.rotation, 1f));
        sequence.Append(transform.DOMove(p_hoya.position, 1f));
        sequence.OnComplete(() => gameObject.SetActive(false));
    }
    void animacion_usuario()
    {
        print($"pos jugador: {usuario.transform.position}");
        print($"pos destino: {momento_2_3.position}");
        Sequence sequence2 = DOTween.Sequence();
        sequence2.Append(usuario.transform.DOMove(momento_2_3.position, 1f));
    }    

    public void fade1()
    {
        feedback1.gameObject.SetActive(true);

        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(-169f, 112f, 0f);
        rectTransform.DOAnchorPos(new Vector2(-169f, -112f), fadeTime*2, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(1, fadeTime);
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(-169f, 112f, 0f);
        rectTransform.DOAnchorPos(new Vector2(-306f, 452f), fadeTime*2, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0, fadeTime).OnComplete(() => feedback1.gameObject.SetActive(false));

    }

    public void fade2()
    {
        feedback2.gameObject.SetActive(true);

        canvasGroup2.alpha = 0f;
        rectTransform2.transform.localPosition = new Vector3(454f, 24f, 0f);
        rectTransform2.DOAnchorPos(new Vector2(454f, 24f), fadeTime * 2, false).SetEase(Ease.InOutQuint);
        canvasGroup2.DOFade(1, fadeTime);
        canvasGroup2.alpha = 1f;
        rectTransform2.transform.localPosition = new Vector3(454f, 24f, 0f);
        rectTransform2.DOAnchorPos(new Vector2(669f, 533f), fadeTime*2, false).SetEase(Ease.InOutQuint);
        canvasGroup2.DOFade(0, fadeTime).OnComplete(() => feedback2.gameObject.SetActive(false));
        
    }

    public void fadeOutNota()
    {
        canvasGroup3.alpha = 1f;
        rectTransform3.transform.localPosition = new Vector3(744f, 0f, 0f);
        rectTransform3.DOAnchorPos(new Vector2(1200f, 0f), 1, false).SetEase(Ease.InOutQuint);
        canvasGroup3.DOFade(1, fadeTime).OnComplete(() => nota.gameObject.SetActive(false));
    }

    public void fadeInMezcla()
    {
        mezcla.gameObject.SetActive(true);
        canvasGroup4.alpha = 0f;
        rectTransform4.transform.localPosition = new Vector3(0f, 300f, 0f);
        rectTransform4.DOAnchorPos(new Vector2(0f, 0f), 2, false).SetEase(Ease.InOutQuint);
        canvasGroup4.DOFade(1, fadeTime);
    }

    public void fadeOutMezcla()
    {
        canvasGroup4.alpha = 1f;
        rectTransform4.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform4.DOAnchorPos(new Vector2(0f, 300f), 2 , false).SetEase(Ease.InOutQuint);
        canvasGroup4.DOFade(0, fadeTime).OnComplete(() => mezcla.gameObject.SetActive(false));
    }

    public void fadeInLetrero5()
    {
        letrero5.gameObject.SetActive(true);
        canvasGroup5.alpha = 0f;
        rectTransform5.transform.localPosition = new Vector3(0f, 300f, 0f);
        rectTransform5.DOAnchorPos(new Vector2(0f, 0f), 2, false).SetEase(Ease.InOutQuint);
        canvasGroup5.DOFade(1, fadeTime);
    }

    public void fadeInBarra()
    {
        barra.gameObject.SetActive(true);
        canvasGroup6.alpha = 0f;
        rectTransform6.transform.localPosition = new Vector3(0f, 420f, 0f);
        rectTransform6.DOAnchorPos(new Vector2(0f, -5f), 2, false).SetEase(Ease.InOutQuint);
        canvasGroup6.DOFade(1, fadeTime);
    }


}
