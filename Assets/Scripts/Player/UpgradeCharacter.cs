using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCharacter : MonoBehaviour
{
    public CharacterData[] characters;
    public int currentCharacterIndex=0;
    [HideInInspector]
    public CharacterData character;

    //
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
        CoinToUpgrade();
        Display();
    }

    // Update is called once per frame
    void Update()
    {
        character = characters[currentCharacterIndex];

    }

    private void CoinToUpgrade()
    {
        coinHp = Convert.ToInt32(character.health * 2);
        coinSpeed = Convert.ToInt32(character.speed);
        coinDamage = Convert.ToInt32(character.initialDamage * 4);
    }

    public void Display()
    {
        playerCoin.text = PlayerPrefs.GetInt("Coin") + " $ ";

        txtHealth.text = "Heath: " + ConvertFloat(character.health);
        txtMaxSpeed.text = "Max Speed: " + ConvertFloat(character.speed);
        txtDamage.text = "Damage Bullet: " + ConvertFloat(character.initialDamage);
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
            CoinToUpgrade();
            Display();
        }
    }
    public void UpgradeDamageBullet()
    {
        if (PlayerPrefs.GetInt("Coin") >= coinDamage)
        {
            character.initialDamage += character.initialDamage / 10;
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - coinDamage);
            CoinToUpgrade();
            Display();
        }
    }
}
