using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class corte_control : MonoBehaviour
{
    public float energy_cortada;
    public int requerido = 10;

    [Header("objetos")]
    [SerializeField] GameObject maza_no_cortada;
    [SerializeField] GameObject maza_cortada;
    [SerializeField] GameObject bandejaOff;

    [Header("posiciones")]
    [SerializeField] Transform pocision_1;
    [SerializeField] Transform pocision_2;
    [SerializeField] Transform pocision_3;



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

            Sequence sequence = DOTween.Sequence();
            sequence.Append(maza_cortada.transform.DOMove(pocision_1.position, 3f));
            sequence.Append(maza_cortada.transform.DOMove(pocision_2.position, 3f));
            sequence.Append(maza_cortada.transform.DOMove(pocision_3.position, 3f));
            sequence.OnComplete(() => Destroy(maza_cortada));

        }
    }
}
