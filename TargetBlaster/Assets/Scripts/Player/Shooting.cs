using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public ObjectPooler pooler;

    public float bulletForce = 20f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = pooler.SpawnFromPools("Bullet",firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}