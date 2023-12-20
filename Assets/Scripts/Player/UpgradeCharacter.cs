using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UpgradeCharacter : MonoBehaviour
{
    public CharacterData[] characters;
    //
    public Transform characterTransform;    
    //
    public int currentCharacterIndex=0;
    [HideInInspector]
    public CharacterData character;

    //
    [SerializeField] private Text playerName;
    [SerializeField] private Text playerCoin;
    [Header("Text Infor Player")]
    [SerializeField] private Text txtHealth;
    [SerializeField] private Text txtMaxSpeed;
    [SerializeField] private Text txtDamage;


    [Header("Text Button")]
    [SerializeField] private Text btnHealth;
    [SerializeField] private Text btnSpeed;
    [SerializeField] private Text btnDamage;

    //
    private int coinHp;
    private int coinSpeed;
    private int coinDamage;


    // Start is called before the first frame update
    void Start()
    {
        characters = IOCharacterData.instance.dataCharacters;
        character = characters[currentCharacterIndex];
        CoinToUpgrade();
        Display();
    }

    // Update is called once per frame

    private void CoinToUpgrade()
    {
        coinHp = Convert.ToInt32(character.health * 2);
        coinSpeed = Convert.ToInt32(character.speed);
        coinDamage = Convert.ToInt32(character.initialDamage * 4);
    }

    public void Display()
    {
        if (characterTransform.childCount > 0)
        {
            Destroy(characterTransform.GetChild(0).gameObject);
        }
        GameObject prefab = Instantiate(character.characterPrefab, characterTransform.position, transform.rotation);
        prefab.transform.localScale = new Vector3(5, 5, 5);
        prefab.transform.SetParent(characterTransform);

        playerName.text = character.characterName;
        playerCoin.text = PlayerPrefs.GetInt("Coin") + " $ ";

        txtHealth.text = "Heath: " + ConvertFloat(character.health);
        txtMaxSpeed.text = "Max Speed: " + ConvertFloat(character.speed);
        txtDamage.text = "Damage Bullet: " + ConvertFloat(character.initialDamage);

        btnHealth.text = coinHp + "$";
        btnSpeed.text = coinSpeed + "$";
        btnDamage.text = coinDamage + "$";
    }

    public float ConvertFloat(float number)
    {
        float result = Convert.ToInt32(number * 10);
        result = Convert.ToSingle(result) / 10;
        return result;
    }

    public void AddCoin()
    {
        PlayerPrefs.SetInt("Coin", (PlayerPrefs.GetInt("Coin") + 1000));
        Display();
    }

    public void UpgradeHp()
    {

        if (PlayerPrefs.GetInt("Coin") >= coinHp)
        {
            character.health+= character.health / 10;
            PlayerPrefs.SetInt("Coin", (PlayerPrefs.GetInt("Coin") - coinHp));
            IOCharacterData.instance.ChangeScriptableObjectData(character);
            CoinToUpgrade();
            Display();

        }
    }

    public void UpgradeSpeed()
    {
        if (PlayerPrefs.GetInt("Coin") >= coinSpeed)
        {
            character.speed += character.speed / 10;
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - coinSpeed);
            IOCharacterData.instance.ChangeScriptableObjectData(character);
            CoinToUpgrade();
            Display();
        }
    }
    public void UpgradeDamage()
    {
        if (PlayerPrefs.GetInt("Coin") >= coinDamage)
        {
            character.initialDamage += character.initialDamage / 10;
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - coinDamage);
            IOCharacterData.instance.ChangeScriptableObjectData(character);
            CoinToUpgrade();
            Display();
        }
    }

    public void nextCharacter()
    {
        currentCharacterIndex++;
        currentCharacterIndex %=  characters.Length;
        character = characters[currentCharacterIndex];
        CoinToUpgrade();
        Display();
    }
}
