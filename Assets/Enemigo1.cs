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

    public GameObject target;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void Comportamiento_Enemigo()
    {
        if(Vector3.Distance(transform.position, target.transform.position) > 5) { 

            cronometro += 1 * Time.deltaTime;
        if (cronometro >= 2)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;
        }
        switch (rutina)
        {
            case 0:
                ani.SetBool("walk", false);
                break;

            case 1:
                grado = Random.Range(0, 360);
                rutina++;
                break;

            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                ani.SetBool("walk", true);
                break;
        }
    }
    else
    {
     var lookPos = target.transform.position - transform.position;
     lookPos.y = 0;
     var rotation = Quaternion.LookRotation(lookPos);
     transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
     ani.SetBool("walk", false);

    }
}

    void Update()
    {
      Comportamiento_Enemigo();
    }
}
