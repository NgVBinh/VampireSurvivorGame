using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUpgrade : MonoBehaviour
{
    public Attributes[] playerAttributes;
    public Button[] buttons;
    private void OnEnable()
    {
        buttons = GetComponentsInChildren<Button>();
        playerAttributes = GameObject.Find("Player").GetComponent<PlayerManager>().attributes;

        foreach (Button b in buttons)
        {
            int indexAttribute = Random.Range(0, playerAttributes.Length);

            Text text = b.GetComponentInChildren<Text>();
            text.text = playerAttributes[indexAttribute].nameAttribute;
            Image img = b.GetComponentInChildren<Image>();
            img.sprite = playerAttributes[indexAttribute].sprite;

            b.onClick.AddListener(()=>setAttribute(indexAttribute));
        
        }
    }

    public void setAttribute(int index)
    {
        PlayerManager player = GameObject.Find("Player").GetComponent<PlayerManager>();
        player.attributes[index].amount++;
    }
}
