using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class corte_control : MonoBehaviour
{
    [Header("--tiempos")]
    public float energy_cortada;
    public int requerido = 10;

    [Header("--objetos")]
    [SerializeField] GameObject maza_no_cortada;
    [SerializeField] GameObject maza_cortada;
    [SerializeField] GameObject bandejaOff;
    [SerializeField] GameObject rodillo;

    [Header("--posiciones")]
    [SerializeField] Transform pocision_1;
    [SerializeField] Transform pocision_2;
    [SerializeField] Transform pocision_3;
    [SerializeField] Transform momento_5;

    [Header("--ususrio")]
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

        }
    }
    void animacion_bandeja()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(maza_cortada.transform.DOMove(pocision_1.position, 0.5f));
        sequence.Append(maza_cortada.transform.DOMove(pocision_2.position, 0.5f));
        sequence.Append(maza_cortada.transform.DOMove(pocision_3.position, 0.5f));
        sequence.OnComplete(() => Destroy(maza_cortada));
    }
    void animacion_usuario()
    {
        Sequence sequence2 = DOTween.Sequence();
        sequence2.Append(usuario.transform.DOMove(momento_5.position, 1f));
    }
}
