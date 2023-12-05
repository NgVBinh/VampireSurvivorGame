using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BaseSkill : MonoBehaviour
{
    private string skillName;
    private float damage = 0;

    public virtual void Initialize()
    {
        // Initialization logic for the skill
    }

    public virtual void Activate()
    {
        // Basic skill activation logic
       // Debug.Log($"{character.name} used {skillName} skill for {damage} damage!");
    }

    public virtual string GetNameSkill()
    {
        return this.skillName;
    }

    public virtual float GetDamage()
    {
        return this.damage;
    }
    public virtual void SetDamage(float damage)
    {
        this.damage = damage;
    }

}
