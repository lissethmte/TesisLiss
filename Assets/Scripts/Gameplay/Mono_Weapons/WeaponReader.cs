using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReader : MonoBehaviour
{
    public static WeaponReader Instance;

    private Gun currentGun;
    public int actualBulletDamage;
    public int actualbullets;
    public int actualPlayerSpeed;
    public float actualshootDelay = 0.2f;
    public string actualTypeOfShoot;

    public float bigShootCooldown = 5f;
    public int actualcartuchos;

    public Guns guns;
    public Transform shootSpawn;
    public GameObject[] bulletPrefabs = new GameObject[1];

    public List<Arma> armasDisponibles;

    public bool shooting;

    public float lastShootTime = 0f;

    private int selectedBulletIndex = 0;

    public int bulletCount = 4;
    float spreadAngle = 10f;

    private void Awake()
    {
        Instance = this;
        UpdateGun(0);
 
    }
    public void UpdateGun(int NumberGun)
    {
        currentGun = guns.GunList[NumberGun];
        actualBulletDamage = currentGun.BulletDamage;
        actualPlayerSpeed = currentGun.PlayerSpeed;
        actualbullets = currentGun.bullets;
        actualcartuchos = currentGun.cartuchos;
        actualTypeOfShoot = currentGun.TypeOfShoot;
    }
    public void Shoot()
    {

        if (Time.time - lastShootTime > actualshootDelay && actualbullets > 0)
        {
            switch (actualTypeOfShoot)
            {
                case "Single":
                    InstantiateBullet();
                    break;
                case "Burst":
                    StartCoroutine(ShootBurst());
                    break;
                case "Auto":
                    StartCoroutine(ShootAuto());
                    break;
                case "Quad":
                    StartCoroutine(ShootQuad());  // Llama a la nueva función
                    break;
                case "Big":
                    StartCoroutine(ShootBig());
                    break;
                case "Placapla":
                    StartCoroutine(ShootPlacapla());
                    break;
            }

            actualbullets--;
            lastShootTime = Time.time;
        }
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shooting = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            shooting = false;
        }

        // aqui
        if (shooting)
        {
            Shoot();
        }
    }

    public void InstantiateBullet()
    {
        if (bulletPrefabs.Length <= 0)
        {
            Debug.LogError("NO has metido prefabs en la lista pública de BulletPrefabs");
            Debug.LogError("BulletPrefabs.Length: " + bulletPrefabs.Length);
            Debug.LogError("NO has metido prefabs en la lista pública de BulletPrefabs");
        }
        else if (selectedBulletIndex <= -1)
        {
            Debug.LogError("selectedBulletIndex es menor o igual a 0");
            Debug.LogError("selectedBulletIndex: " + selectedBulletIndex);
        }
        else
        {
            Instantiate(bulletPrefabs[selectedBulletIndex], shootSpawn.position, shootSpawn.rotation);
        }
    }

    public IEnumerator ShootBurst()
    {
        int bulletCount = 3;
        float burstDelay = 0.1f;

        for (int i = 0; i < bulletCount; i++)
        {
            InstantiateBullet();
            yield return new WaitForSeconds(burstDelay);
        }
    }

    public IEnumerator ShootAuto()
    {
        while (shooting)
        {
            InstantiateBullet();
            yield return new WaitForSeconds(actualshootDelay);
        }

    }

    public IEnumerator ShootQuad()
    {
       
        int bulletCount = 3;
        float spreadAngle = 3f;  

        
        for (int i = 0; i < bulletCount; i++)
        {
            
            float angle = shootSpawn.rotation.eulerAngles.x + (i - 1) * spreadAngle;  

            
            Quaternion bulletRotation = Quaternion.Euler(angle, shootSpawn.rotation.eulerAngles.y, 0);  

            
            Instantiate(bulletPrefabs[selectedBulletIndex], shootSpawn.position, bulletRotation);

           
            yield return new WaitForSeconds(actualshootDelay);
        }
    }

    public IEnumerator ShootBig()
    {
        
        if (lastShootTime == 0f)
        {
            if (bulletPrefabs.Length > 0 && bulletPrefabs[selectedBulletIndex] != null)
            {
                
                Instantiate(bulletPrefabs[selectedBulletIndex], shootSpawn.position, shootSpawn.rotation);
                Debug.Log("Primer Big Shoot realizado.");

                lastShootTime = Time.time; 
            }
            else
            {
                Debug.LogError("No se encontró un prefab válido en la lista bulletPrefabs.");
            }
        }
        else
        {
            
            if (Time.time - lastShootTime >= bigShootCooldown)
            {
                if (bulletPrefabs.Length > 0 && bulletPrefabs[selectedBulletIndex] != null)
                {
                   
                    Instantiate(bulletPrefabs[selectedBulletIndex], shootSpawn.position, shootSpawn.rotation);
                    Debug.Log("Big Shoot realizado después del cooldown.");

                    lastShootTime = Time.time;  
                }
                else
                {
                    Debug.LogError("No se encontró un prefab válido en la lista bulletPrefabs.");
                }
            }
            else
            {
                Debug.Log("Big Shoot aún no está listo. Tiempo restante: " + (bigShootCooldown - (Time.time - lastShootTime)) + " segundos.");
            }
        }

       
        yield return null;
    }

    public IEnumerator ShootPlacapla()
    {
        int bulletCount = 7;
        float intervaloEntreBalas = 0.4f; 

        for (int i = 0; i < bulletCount; i++)
        {
            if (bulletPrefabs.Length > 0 && selectedBulletIndex >= 0 && selectedBulletIndex < bulletPrefabs.Length)
            {
                if (bulletPrefabs[selectedBulletIndex] != null)
                {
                    Instantiate(bulletPrefabs[selectedBulletIndex], shootSpawn.position, shootSpawn.rotation);
                }
                else
                {
                    Debug.LogError("El prefab seleccionado es nulo.");
                }
            }
            else
            {
                Debug.LogError("Índice fuera de rango o lista de prefabs vacía.");
            }

            
            yield return new WaitForSeconds(intervaloEntreBalas);
        }

        
        yield return new WaitForSeconds(actualshootDelay);
    }





}