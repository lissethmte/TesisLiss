using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class ChangeGun : MonoBehaviour
{
    public static ChangeGun Instance;
    public GameObject gunA, gunB, gunC, gunD, gunE, gunF;


    private void Awake()
    {
       
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponReader.Instance.UpdateGun(0);
            gunA.SetActive(false);
            gunB.SetActive(false);
            gunC.SetActive(true);
            gunD.SetActive(false);
            gunE.SetActive(false);
            gunF.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponReader.Instance.UpdateGun(1);
            gunA.SetActive(true);
            gunB.SetActive(false);
            gunC.SetActive(false);
            gunD.SetActive(false);
            gunE.SetActive(false);
            gunF.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WeaponReader.Instance.UpdateGun(2);
            gunA.SetActive(false);
            gunB.SetActive(true);
            gunC.SetActive(false);
            gunD.SetActive(false);
            gunE.SetActive(false);
            gunF.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            WeaponReader.Instance.UpdateGun(3);
            gunA.SetActive(false);
            gunB.SetActive(false);
            gunC.SetActive(false);
            gunD.SetActive(true);
            gunE.SetActive(false);
            gunF.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            WeaponReader.Instance.UpdateGun(4);
            gunA.SetActive(false);
            gunB.SetActive(false);
            gunC.SetActive(false);
            gunD.SetActive(false);
            gunE.SetActive(true);
            gunF.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            WeaponReader.Instance.UpdateGun(5);
            gunA.SetActive(false);
            gunB.SetActive(false);
            gunC.SetActive(false);
            gunD.SetActive(false);
            gunE.SetActive(false);
            gunF.SetActive(true);
        }

    }
}