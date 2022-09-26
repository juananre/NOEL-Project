using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class tazon_control : MonoBehaviour
{
    public int conter;
    public int necesario = 0;
    public float energy_tazon;
    public int requerido = 10;

    [SerializeField] GameObject batidora;
    [SerializeField] GameObject momento3;

    [SerializeField] Transform p_hoya;
    [SerializeField] Transform p_hoya_2;
    [SerializeField] Transform p_hoya_resta;
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

            if (conter == necesario)
            {
                batidora.SetActive(true);
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

                Sequence sequence = DOTween.Sequence();
                sequence.Append(transform.DOMove(p_hoya.position, 3f));
                sequence.Append(transform.DOMove(p_hoya_2.position, 3f));
                sequence.Append(transform.DORotateQuaternion(p_hoya.rotation,3f));
                sequence.Append(transform.DORotateQuaternion(p_hoya_resta.rotation, 3f));
                sequence.Append(transform.DOMove(p_hoya.position, 3f));
                sequence.OnComplete(()=>gameObject.SetActive(false));
                print("exito");//se mueve la hoya
                momento3.SetActive(true);
                //delay
                //se mueve la camara 
            }
        }
    }
}
