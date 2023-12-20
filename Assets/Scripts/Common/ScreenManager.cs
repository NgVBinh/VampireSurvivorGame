using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager Instance;

    [SerializeField] private GameObject ingamePanel;
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private GameObject pausegamePanel;
    [SerializeField] private GameObject endgamePanel;

    public enum Screens
    {
        INGAME,
        UPGRADE,
        PAUSEGAME,
        ENDGAME
    }

    private GameObject currentScreen;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentScreen = ingamePanel;
    }

    public void changeScreen(Screens screen)
    {
        Time.timeScale = 1f;
        currentScreen.SetActive(false);
        switch (screen)
        {
            case Screens.INGAME:
                currentScreen = ingamePanel;
                break;
            case Screens.UPGRADE:
                currentScreen = upgradePanel;
                Time.timeScale = 0f;
                break;
            case Screens.PAUSEGAME:
                currentScreen = pausegamePanel;
                Time.timeScale = 0f;
                break;
            case Screens.ENDGAME:
                currentScreen = endgamePanel;
                break;
        }
        currentScreen.SetActive(true);
    }
}