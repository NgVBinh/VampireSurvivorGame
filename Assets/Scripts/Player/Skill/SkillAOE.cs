using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAOE : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _particleSystem.Pause();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPartical()
    {
        Debug.Log("?");
        //_particleSystem.Stop();
        _particleSystem.Play();
    }

}
