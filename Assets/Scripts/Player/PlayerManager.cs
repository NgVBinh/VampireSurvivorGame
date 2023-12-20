using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public CharacterData[] characters;
    public int currentCharacterIndex;// index của nhân vật

    [HideInInspector]
    public CharacterData character;

    //Player data
    private bool isDie= false;
    private float maxHp;
    private float currentHp;
    private float damagePlayer;
    private int exp = 0;

    private int level = 0;

    private Animator animator;
    //
    private ParticleSystem[] PS;
    // attributes
    public Attributes[] attributes;

    private void Awake()
    {
        SpawnCharacter();
        character = characters[currentCharacterIndex];
        maxHp = character.health;
        damagePlayer = character.initialDamage;
        currentHp = maxHp;
        PS = GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem ps in PS)
        {
            ps.Pause();
        }
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        
    }

    private void Update()
    {
        if (!isDie)
        {
            Die();

            // len cap
            if(exp == 5)
            {
                Debug.Log("Level Up");
                PS[1].Stop();
                PS[1].Play();
                exp = 0;
                level++;
            }
        }
    }

    private void SpawnCharacter()
    {
        // Hủy đối tượng nhân vật hiện tại nếu có
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

        // Tạo một đối tượng nhân vật mới với dữ liệu từ ScriptableObject
        GameObject newCharacter = InstantiateCharacter(currentCharacterIndex, transform);
    }

    private GameObject InstantiateCharacter(int id, Transform parent)
    {
        // Tạo một đối tượng nhân vật mới với dữ liệu từ ScriptableObject
        GameObject newCharacter = Instantiate(characters[id].characterPrefab);
        newCharacter.name = characters[id].characterName;
        newCharacter.transform.SetParent(parent);
        return newCharacter;
    }

    public void SwitchCharacter()
    {
        // Chuyển đổi sang nhân vật tiếp theo
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Length;

        // Tạo lại nhân vật
        SpawnCharacter();
    }
    public void TakeDamage(float damage)
    {
        currentHp = Mathf.Clamp(currentHp - damage, 0, maxHp);
        if(damage>0) { 
        animator.SetTrigger("TakeDamage");
            
            PS[0].Stop();
            PS[0].Play();
        }
        Debug.Log(currentHp +"/"+ maxHp);
    }

    public void Die()
    {
        if(currentHp == 0) {
            Debug.Log("End game");
            isDie = true;
        }
    }

    public float GetMaxHp()
    {
        return this.maxHp;
    }

    public float GetCurentHp()
    {
        return this.currentHp;
    }

    public float GetCurentExp()
    {
        return this.exp;
    }

    public float GetDamage()
    {
        return this.damagePlayer;
    }

    public int GetLevel()
    {
        return this.level;
    }

    public void IncreaseExp(int exp)
    {
        this.exp += exp;
    }


    public void test()
    {
        characters[0].health += 10;
    }
}
