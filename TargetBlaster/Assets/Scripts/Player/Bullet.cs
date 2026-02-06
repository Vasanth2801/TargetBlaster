using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTime = 3f;
    private float timer;
    EnemySpawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<EnemySpawner>();
    }

    private void OnEnable()
    {
        timer = lifeTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
            spawner.waves[spawner.currentWave].enemiesCount--;
        }
    }

}
