using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public float distancia;
    public GameObject target;
    public bool atacando;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {

            cronometro += Time.deltaTime;
            if (cronometro >= 2)
            {
                rutina++;  
            if (rutina > 2)
                {
                    rutina = 0;
                }
                cronometro = 0;

            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    ani.SetBool("run", false);
                    ani.SetBool("attack", false);
                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * Time.deltaTime);
                    ani.SetBool("walk", true);
                    ani.SetBool("run", false);
                    break;
            }
        }
        else if (Vector3.Distance(transform.position, target.transform.position) > distancia && !atacando)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);

            ani.SetBool("walk", false);
            ani.SetBool("run", true);
            ani.SetBool("attack", false);

            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }
        else
        {
           
            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack", true);
            atacando = true;

        }

      
    }

    

    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
    }

    void Update()
    {
        Comportamiento_Enemigo();
    }
}