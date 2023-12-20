using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WizardBaseSkill : MonoBehaviour
{
    public LayerMask enemyLayer;
    [SerializeField] private GameObject BulletPrefab;
    private GameObject Holder;
    private float timer;
    private float timeBetWeenShoot = 2f;
    public int level = 0;

    private List<GameObject> targetGOs = new List<GameObject>();
    private PlayerManager playerManager;
    private float damagePlayer;
    private void Start()
    {
        Holder = GameObject.Find("PlayerBullet");
        playerManager = FindObjectOfType<PlayerManager>();
    }
    // Start is called before the first frame update gd
    // Update is called once per frame
    void Update()
    {
        if(playerManager!= null)
        {
            if (level < 4) level = playerManager.GetLevel();
            damagePlayer = playerManager.GetDamage();
        }
        Skill(level);
    }

    public void Skill(int level)
    {
        switch (level)
        {
            case 0:
                shoot(1,5);
                break;
            case 1:
                timeBetWeenShoot = 1.9f;
                shoot(2,6);
                break;
            case 2:
                timeBetWeenShoot = 1.8f;
                shoot(3,7);
                break;
            case 3:
                timeBetWeenShoot = 1.7f;
                shoot(4,8);
                break;
            case 4:
                timeBetWeenShoot = 1.6f;
                shoot(5,9);
                break;
        }

    }

    public void shoot(int quantity, float distance)
    {
        timer += Time.deltaTime;
        targetGOs = GetsEnemyInDistance(distance);
        if (timer >= timeBetWeenShoot && targetGOs.Count > 0)
        {
            timer = 0;
            for (int i = 0; i < quantity; i++)
            {
                GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<BulletAuto>().SetTargetGameobject(targetGOs[Random.Range(0, targetGOs.Count)]);
                bullet.GetComponent<BulletAuto>().SetDamage(damagePlayer);
                bullet.transform.SetParent(Holder.transform);
            }
        }
    }

    public List<GameObject> GetsEnemyInDistance(float distance)
    {
        List<GameObject> listEnemy = new List<GameObject>();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, distance, enemyLayer);

        // Xử lý các enemy được phát hiện
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                // Kiểm tra xem enemy đã được thêm vào danh sách chưa
                if (!listEnemy.Contains(collider.gameObject))
                {
                    // Thêm enemy vào danh sách
                    listEnemy.Add(collider.gameObject);
                }
            }
        }

        for (int i = listEnemy.Count - 1; i >= 0; i--)
        {
            if (listEnemy[i] == null || Vector2.Distance(transform.position, listEnemy[i].transform.position) > distance)
            {
                listEnemy.RemoveAt(i);
            }
        }

        return listEnemy;
    }



}
