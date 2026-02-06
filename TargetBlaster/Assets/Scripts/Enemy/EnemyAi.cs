using Unity.VisualScripting;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float enemySpeed = 5f;
    [SerializeField] Transform player;
    [SerializeField] float damage = 5f;

    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position,player.position,enemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit the Player");
        }
    }
}
