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
        if (ingrediente_1 == true)
        {
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
        sequence.Append(usuario.transform.DOMove(momento_2.position, 1f));
        sequence.Append(usuario.transform.DOLocalRotateQuaternion(momento_2.rotation, 1f));
        contador_pasa = 0;
        
    }
   

}
