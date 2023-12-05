using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character")]
public class CharacterData : ScriptableObject
{
    [SerializeField] public GameObject characterPrefab;
    public int characterID;
    public string characterName;
    public string description;

    public float health;
    public float speed;
    public float initialDamage;

    // Thêm các thuộc tính khác của nhân vật ở đây
}
