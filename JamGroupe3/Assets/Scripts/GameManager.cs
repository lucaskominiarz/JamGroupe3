using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    
    [SerializeField] private RessourcesScriptableHandler handler;
    [SerializeField] private float baseUpgradePrice;
    private int[] clickerLevels;
    [HideInInspector] public int[] numberOfRessources;
    private float _actualMoney;
    
    
    
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
    }

    public void Click(int index)
    {
        numberOfRessources[index] += 1 * clickerLevels[index] * clickerLevels[index];
    }

    public void UpgradeClick(int index)
    {
        if (_actualMoney >= clickerLevels[index] * 2 +index*index )
        {
            _actualMoney -= clickerLevels[index] * 2 + index * index;
            clickerLevels[index]++;
        }
    }

    public void AutoClick(int index)
    {
        StartCoroutine(AutoCLick(index));
    }

    IEnumerator AutoCLick(int index)
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Click(index);
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
