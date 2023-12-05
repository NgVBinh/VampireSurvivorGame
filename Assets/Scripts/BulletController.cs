using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletController : MonoBehaviour
{
    public float speed;
    // private Vector3 direction = Vector3.right;
    private Vector3 vector3 = Vector3.right;
    private int damageBullet;

    private string nameControll = "Auto";
    // Update is called once per frame
    void Update()
    {
        switch (nameControll)
        {
            case "Direction":
                transform.Translate(vector3.normalized * Time.deltaTime * speed);
                break;
            case "Auto":
                transform.position = Vector3.MoveTowards(transform.position,vector3, Time.deltaTime * speed);
                break;
        }
    }

    //public void SetDirection(Vector3 direction)
    //{
    //    this.direction = direction;
    //}

    public void SetDamageBullet(int damage)
    {
        damageBullet = damage;
    }

    public int GetDamageBullet()
    {
        return damageBullet;
    }


    public void SetBullet(string name, Vector3 vector3)
    {
        this.name = name;
        this.vector3 = vector3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager playerManager = collision.gameObject.GetComponent<PlayerManager>();
            if (playerManager != null)
            {
                playerManager.TakeDamage(GetDamageBullet());
                gameObject.SetActive(false);
            }
            
        }
    }

}
