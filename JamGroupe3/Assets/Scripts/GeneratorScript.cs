using System;
using System.Collections;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    [SerializeField] private GeneratorScriptable generatorData;
    [SerializeField] private float baseUpgradePrice = 10f;
    [SerializeField] private float upgradePriceMultiplier = 3f;
    [SerializeField] private float baseMoneyGeneration;
    [SerializeField] private float autoProductionPrice;
    [SerializeField] private float generationSpeed; // surement faudra faire une upgrade pr ça
    [SerializeField] private Vector3 newSpawnPosition;
    [SerializeField] private GameObject baseRessourceObject;
    [SerializeField] private float autoRessourcesBuyDelay;

    private int _level;
    private int _autoLevel;
    private float _upgradePrice;
    private int _numberOfRessourcesIn;
    private bool _autoProduction;
    private bool _canGenerate = true;

    private void Awake()
    {
        _upgradePrice = baseUpgradePrice;
    }
    
    public void Click()
    {
        _numberOfRessourcesIn += 1 + _level * 3;
        if (_autoProduction)
        {
            RessourceGeneration();
        }
    }

    public void RessourceGeneration()
    {
        Debug.Log(_canGenerate);
        Debug.Log(_numberOfRessourcesIn);
        if (_numberOfRessourcesIn != 0 && _canGenerate)
        {
            
            _numberOfRessourcesIn--;
            _canGenerate = false;
            StartCoroutine(Generate());
        }
    }

    IEnumerator Generate()
    {
        Debug.Log("ptn");
        yield return new WaitForSeconds(generationSpeed / (_level +1));
        GameObject newGO = Instantiate(baseRessourceObject);
        newGO.transform.position = newSpawnPosition;
        newGO.GetComponent<MeshFilter>().mesh = generatorData.OutRessourceScriptable.Mesh;
        newGO.GetComponent<MeshRenderer>().material = generatorData.OutRessourceScriptable.Material;
        GameManager.INSTANCE.AddMoney(baseMoneyGeneration * _level + (baseMoneyGeneration / 4)* _level); // ça a changer pr les gd
        _canGenerate = true;
        if (_autoProduction)
        {
            RessourceGeneration();
        }
    }

    public void LevelUp()
    {
        if (GameManager.INSTANCE.GetMoneyValue() >= _upgradePrice)
        {
            GameManager.INSTANCE.AddMoney(- _upgradePrice);
            _upgradePrice *= upgradePriceMultiplier;
            _level += 1;
        }
        
    }

    public void BuyAutoUpgrade() // rajouter une desactivation du bouton associé
    {
        if (GameManager.INSTANCE.GetMoneyValue() >= autoProductionPrice)
        {
            GameManager.INSTANCE.AddMoney(- autoProductionPrice);
            _autoProduction = true;
        }
        
    }

    public void LevelUpAutoRessources()
    {
        if (GameManager.INSTANCE.GetMoneyValue() >= autoProductionPrice)
        {
            GameManager.INSTANCE.AddMoney(- autoProductionPrice);
            StartCoroutine(AutoRessources());
        }
    }

    IEnumerator AutoRessources()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / (_level +1));
            Click();
        }
    }
    
    
    // rajouter ui
}
