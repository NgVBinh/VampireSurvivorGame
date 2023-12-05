using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInfor : MonoBehaviour
{
    [SerializeField] private Slider hpPlayer;
    [SerializeField] private Slider expPlayer;
    private PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        hpPlayer.maxValue = playerManager.GetMaxHp();
        hpPlayer.value = playerManager.GetCurentHp();

    }
    // Update is called once per frame
    void Update()
    {
        DisplayInforPlayer();
    }

    public void DisplayInforPlayer()
    {
        hpPlayer.value = playerManager.GetCurentHp();
        expPlayer.value = playerManager.GetCurentExp();
    }
}
