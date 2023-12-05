using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttackDirection : BaseSkill
{
    public float speed;
    private Vector3 direction = Vector3.right;

    private void Update()
    {
        Activate();
    }

    public override void Activate()
    {
        base.Activate();
        transform.Translate(direction.normalized * Time.deltaTime * speed);

    }

    public void SetDirection(Vector3 pos)
    {
        this.direction = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager playerManager = collision.gameObject.GetComponent<PlayerManager>();
            if (playerManager != null)
            {
                playerManager.TakeDamage(this.GetDamage());
                gameObject.SetActive(false);
            }

        }
    }
}
