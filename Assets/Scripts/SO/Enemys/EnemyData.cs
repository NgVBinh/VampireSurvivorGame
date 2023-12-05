using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField] public GameObject enemyPrefab;

    public int enemyID;
    public string enemyName;
    public string description;

    public bool isShortType;
    public int hp;
    public int speed;
    public int damage;
    public int timeBetweenAttack;
    public float Range;

}
