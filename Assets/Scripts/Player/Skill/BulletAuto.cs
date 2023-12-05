using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletAuto : BaseSkill
{
    public float force;
    private GameObject targetGameobject;
    private Rigidbody2D rb;
    Vector3 direc = Vector3.right;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Activate();
     
    }

    public override void Activate()
    {
        base.Activate();
        if (targetGameobject != null)
        {
            direc = targetGameobject.transform.position - transform.position;
        }
        rb.AddForce(direc.normalized * force,ForceMode2D.Force);
        transform.right= rb.velocity;
    }

    public void SetTargetGameobject(GameObject go)
    {
        this.targetGameobject = go;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(this.GetDamage());
                Destroy(gameObject);
            }

        }
    }
}
