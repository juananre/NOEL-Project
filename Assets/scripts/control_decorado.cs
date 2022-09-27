using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Leap.Unity.Interaction {
    public class control_decorado : MonoBehaviour
    {
        [SerializeField] float energia_decorado;
        [SerializeField] int toque_puesto = 0;
        [SerializeField] float requerido = 5;
        [SerializeField] float requerido_2 = 2;
        
        
        [SerializeField] InteractionBehaviour script;
        [SerializeField] Transform reinicio;
        [SerializeField] Transform reinicio_2;

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
                    animar = true;

                }
            }

        }
        void aniam_user()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(usuario.transform.DOMove(momento_7.position, 1f));
            sequence.Append(usuario.transform.DOLocalRotateQuaternion(momento_7.rotation, 1f));
        }
        
       


    }
}


