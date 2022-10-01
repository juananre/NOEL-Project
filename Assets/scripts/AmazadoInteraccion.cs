using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AmazadoInteraccion : MonoBehaviour
{
    public float energy;
    public int requerido =10;

    [SerializeField] GameObject maza_1;
    [SerializeField] GameObject maza_2;
    [SerializeField] Image barra;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] RectTransform rectTransform;


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
        BarAnimation();
        energy +=Time.deltaTime;
        if (energy>=requerido)
        {
            barra.fillAmount = 1;
            maza_1.SetActive(false);
            maza_2.SetActive(true);            
        }
        
    }

    public void BarAnimation()
    {
        barra.fillAmount = 0;
        barra.DOFillAmount(1, energy*8);
    }

}
