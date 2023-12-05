using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;// list all enemy 
    public int[] indexEnemySpawns; 
    private Transform playerTransform;
    private Transform holder;

    private float timer;
    public float timeSpawner;
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        holder = GameObject.Find("EnemySpawner").transform;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy(indexEnemySpawns);
    }

    public void SpawnEnemy(int[] arrIndexEnemy)
    {
        timer += Time.deltaTime;

        if (timer >= timeSpawner)
        {
            timer = 0;
            int randomIndex = Random.Range( 0, arrIndexEnemy.Length );
            int index = arrIndexEnemy[randomIndex];
            if(index < enemyPrefabs.Length) {
                Instantiate(enemyPrefabs[index], randomPosSpawn(playerTransform.position), Quaternion.identity).transform.SetParent(holder);
            }
            else
            {
                Debug.Log("Vượt quá chỉ số mảng");
            }
            
        }
    }

    public Vector3 randomPosSpawn(Vector3 playerPos)
    {
        float posX =Random.Range(-12,13);
        float posY = (posX >= -9 && posX <= 9) ? posY = 6:posY = Random.Range(-5, 6);

        int random= Random.Range( 0, 2 );
        if(random == 0)
        {
            return new Vector3(playerPos.x + posX, playerPos.y + posY, 1);
        }
        else
        {
            return new Vector3(playerPos.x - posX, playerPos.y - posY, 1);
        }
    }
}
