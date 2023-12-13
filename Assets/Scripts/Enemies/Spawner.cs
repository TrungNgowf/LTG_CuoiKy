using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    private float timeSpawn = 10f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (player.position.x >= 38f && player.position.x <= 54f && player.position.y >= -2f && player.position.y <= 1.1f)
            {
                timeSpawn = 6f;
            }
            else
            {
                timeSpawn = 10f;
            }

            yield return new WaitForSeconds(timeSpawn);

            Vector2 spawnOffset = Random.insideUnitCircle.normalized * 4f; // Vector ngẫu nhiên trong bán kính 4f
            Vector2 spawnPosition = (Vector2)player.position + spawnOffset;

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Đảm bảo rằng đối tượng mới có các thành phần cần thiết, chẳng hạn như Rigidbody2D, AudioManager, và Animator.
            // Có thể bạn cần truyền các thông số khác từ spawner đến enemy, tùy thuộc vào yêu cầu cụ thể của bạn.
        }
    }
}
