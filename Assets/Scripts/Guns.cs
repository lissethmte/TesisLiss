using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GunData", menuName = "ScriptableObjects/GunsData", order = 1)]
public class Guns : ScriptableObject
{
    public List<Gun> GunList;



}

[Serializable]
public class Gun
{
    public string TypeOfShoot;
    public int BulletDamage;
    public int bullets;
    public int PlayerSpeed;
    public float shootDelay = 0.2f;

    public int index;
    public int cartuchos;
}