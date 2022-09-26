using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class AlacenaInteraccion : MonoBehaviour
{
    [Header("--aparece")]
    [SerializeField] GameObject harina;
    [SerializeField] GameObject vitaminas;
    [SerializeField] GameObject huevos;
    [SerializeField] GameObject azucar;

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

    [Header("--contadores")]
    [SerializeField] int contador_pasa = 0;
    [SerializeField] int necesario = 0;


    void Start()
    {
        
    }
    void Update()
    {
        if (contador_pasa == necesario)
        {
            trancicion();
        }
    }
    public void Entrada_Selec_Harian()
    {
        harina.SetActive(true);
    }
    public void Entrada_Selec_Azucar()
    {
        azucar.SetActive(true);
    }
    public void Entrada_Selec_huvos()
    {
        huevos.SetActive(true);
    }
    public void Entrada_Selec_Vitaminas()
    {
        vitaminas.SetActive(true);
    }


    public void salida_Selec_Vitaminas()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(bot_vitaminas.transform.DOMove(p_vitaminas.position, 1f));
        sequence.Append(bot_vitaminas.transform.DOMove(p_vitaminas_2.position, 3f));
        sequence.OnComplete(() => Destroy(bot_vitaminas));
        //Tween tran_v = bot_vitaminas.transform.DOMove(p_vitaminas.position, 3f);
        //tran_v.OnComplete(() => Destroy(bot_vitaminas));
        
        contador_pasa++;

    }
    public void salida_Selec_Huevos()
    {
        Sequence sequence2 = DOTween.Sequence();
        sequence2.Append(bot_huevos.transform.DOMove(p_huevos.position, 1f));
        sequence2.Append(bot_huevos.transform.DOMove(p_huevos_2.position, 3f));
        sequence2.OnComplete(() => Destroy(bot_huevos));
        contador_pasa++;
    }
    public void salida_Selec_Harina()
    {
        Sequence sequence3 = DOTween.Sequence();
        sequence3.Append(bot_harina.transform.DOMove(p_harina.position, 1f));
        sequence3.Append(bot_harina.transform.DOMove(p_harina_2.position, 3f));
        sequence3.OnComplete(() => Destroy(bot_harina));
        contador_pasa++;
    }
    public void salida_Selec_Azucar()
    {
        Sequence sequence4 = DOTween.Sequence();
        sequence4.Append(bot_azucar.transform.DOMove(p_azucar.position, 1f));
        sequence4.Append(bot_azucar.transform.DOMove(p_azucar_2.position, 3f));
        sequence4.OnComplete(() => Destroy(bot_azucar));
        contador_pasa++;
    }

    public void trancicion()
    {
        print("completo");
    }
}
