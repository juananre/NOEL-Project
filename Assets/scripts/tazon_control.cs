using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class tazon_control : MonoBehaviour
{
    [Header("tiempos nesario")]
    public int conter;
    public int necesario = 0;
    public float energy_tazon;
    public int requerido = 10;

    [Header("--objetos")]
    [SerializeField] GameObject batidora;
    [SerializeField] GameObject momento3;

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
                animacion_tazon();
                if (aniamuser == true)
                {
                    animacion_usuario();
                }

                print("exito");//se mueve la hoya
                momento3.SetActive(true);
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
}
