using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;        
    public Transform shootSpawn;           
    public Transform player;              
    public float shootInterval = 1f;       
    public float attackRange = 15f;        
    public float bulletSpeed = 20f;        

    private float lastShootTime = 0f;

    private void Update()
    {
        
        if (player == null) return;

       
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange)
        {
           
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            
            TryShoot();
        }
    }

    private void TryShoot()
    {
        
        if (Time.time - lastShootTime >= shootInterval)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    private void Shoot()
    {
        if (bulletPrefab == null || shootSpawn == null) return;

        
        GameObject bullet = Instantiate(bulletPrefab, shootSpawn.position, shootSpawn.rotation);

       
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.velocity = shootSpawn.forward * bulletSpeed;
        }
    }

    private void OnDrawGizmosSelected()
    {
       
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}


