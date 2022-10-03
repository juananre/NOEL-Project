using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace Leap.Unity.Interaction {
    using UnityEngine.UI;
    public class control_decorado : MonoBehaviour
    {
        [SerializeField] float energia_decorado;
        [SerializeField] int toque_puesto = 0;
        [SerializeField] float requerido = 5;
        [SerializeField] float requerido_2 = 2;
        public float fadeTime = 1f;

        [Header("--Objetos")]
        [SerializeField] InteractionBehaviour script;
        [SerializeField] Transform reinicio;
        [SerializeField] Transform reinicio_2;

        [Header("--UI")]
        [SerializeField] Image letreroDecorado;
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] RectTransform rectTransform;
        [SerializeField] Image letreroDecorado2;
        [SerializeField] CanvasGroup canvasGroup2;
        [SerializeField] RectTransform rectTransform2;
        [SerializeField] Image letreroEmpaque;
        [SerializeField] CanvasGroup canvasGroup3;
        [SerializeField] RectTransform rectTransform3;

        [SerializeField] GameObject zona_1;
        [SerializeField] GameObject zona_2;

        [SerializeField] GameObject crema;
        [SerializeField] GameObject toque_sec;
        [SerializeField] GameObject bandeja;

        [SerializeField] Transform posicion;
        [SerializeField] Transform momento_7;

        int galletas_1;
        int galletas_2;

        [SerializeField] int exito_1;
        [SerializeField] int exito_2 = 1;

        [SerializeField] GameObject usuario;

        bool verif = false;
        bool animar = false;
        
        
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        
        public void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("glasear"))
            {

                
                script.enabled = false;
                energia_decorado += Time.deltaTime;

                if (energia_decorado >= requerido)
                {
                    transform.position = reinicio.position;
                    transform.rotation = reinicio.rotation;

                    galletas_1++;

                    energia_decorado = 0;

                    script.enabled = true;
                }
                if (galletas_1 >= exito_1)
                {
                    zona_1.SetActive(false);
                    zona_2.SetActive(true);

                    crema.SetActive(false);
                    toque_sec.SetActive(true);
                    fadeOutLetreroDecorado();
                    fadeInLetreroDecorado2();

                    print("exito 1");
                }
            }
            else if (other.CompareTag("toque"))
            {
                
                toque_puesto++;

                transform.position = reinicio_2.position;
                transform.rotation = reinicio_2.rotation;

                script.enabled = false;
                verif = true;

                if (verif == true)
                {
                    script.enabled = true;
                    verif = false;
                }

                if (toque_puesto >= requerido_2)
                {
                    galletas_2++;           
                }
                if (galletas_2 >= exito_2)
                {
                    aniam_user();
                    print("exito 2");                   
                    fadeOutLetreroDecorado2();
                    fadeInLetreroEmpaque();
                    animar = true;

                }
            }

        }
        void aniam_user()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(usuario.transform.DOMove(momento_7.position, 3f));
            sequence.Append(usuario.transform.DOLocalRotateQuaternion(momento_7.rotation, 2f));
        }

        public void fadeOutLetreroDecorado()
        {
            canvasGroup.alpha = 1f;
            rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
            rectTransform.DOAnchorPos(new Vector2(0f, 300f), 2, false).SetEase(Ease.InOutQuint);
            canvasGroup.DOFade(0, fadeTime).OnComplete(() => letreroDecorado.gameObject.SetActive(false));
        }

        public void fadeInLetreroDecorado2()
        {
            letreroDecorado2.gameObject.SetActive(true);
            canvasGroup2.alpha = 0f;
            rectTransform2.transform.localPosition = new Vector3(0f, 300f, 0f);
            rectTransform2.DOAnchorPos(new Vector2(0f, 0f), 2, false).SetEase(Ease.InOutQuint);
            //rectTransform2.DOScale(transform.localScale * 1.1f, fadeTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
            canvasGroup2.DOFade(1, fadeTime);
        }

        public void fadeOutLetreroDecorado2()
        {
            canvasGroup2.alpha = 1f;
            rectTransform2.transform.localPosition = new Vector3(0f, 0f, 0f);
            rectTransform2.DOAnchorPos(new Vector2(0f, 300f), 2, false).SetEase(Ease.InOutQuint);
            canvasGroup2.DOFade(0, fadeTime).OnComplete(() => letreroDecorado2.gameObject.SetActive(false));
        }

        public void fadeInLetreroEmpaque()
        {
            letreroEmpaque.gameObject.SetActive(true);
            canvasGroup3.alpha = 0f;
            rectTransform3.transform.localPosition = new Vector3(0f, 300f, 0f);
            rectTransform3.DOAnchorPos(new Vector2(0f, 0f), 2, false).SetEase(Ease.InOutQuint);
            //rectTransform3.DOScale(transform.localScale * 1.1f, fadeTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
            canvasGroup3.DOFade(1, fadeTime);
        }



    }
}


