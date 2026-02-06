using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
  
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
    

    public void AddMoney(float value)
    {
        _actualMoney += value;
    }

    public float GetMoneyValue()
    {
        return _actualMoney;
    }
}
