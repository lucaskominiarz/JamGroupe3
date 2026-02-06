using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    
    [SerializeField] private RessourcesScriptableHandler ressources;
    [SerializeField] private Transform[] spawnersPositions;
    
    private float _actualMoney;
    private int[] clickerLevels;

    
    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        clickerLevels = new int[ressources.RessourcesScriptablesTab.Length];
        for (int i = 0; i < clickerLevels.Length; i++)
        {
            clickerLevels[i] = 1;
        }

        if (spawnersPositions.Length < ressources.RessourcesScriptablesTab.Length)
        {
            throw new Exception("You need to assign more spawners in the 'spawners positions' variables");
        }
    }
    

    public void AddMoney(float value)
    {
        _actualMoney += value;
    }

    public float GetMoneyValue()
    {
        return _actualMoney;
    }
}
