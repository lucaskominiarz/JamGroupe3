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

    private int _level;
    private float _upgradePrice;
    private int _numberOfRessourcesIn;
    private bool _autoProduction;

    private void Awake()
    {
        _upgradePrice = baseUpgradePrice;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(generatorData.InRessourceScriptable.Name))
        {
            _numberOfRessourcesIn++;
            if (_autoProduction)
            {
                RessourceGeneration();
            }
        }
    }

    public void RessourceGeneration()
    {
        if (_numberOfRessourcesIn != 0)
        {
            StartCoroutine(Generate());
        }
    }

    IEnumerator Generate()
    {
        yield return new WaitForSeconds(generationSpeed);
        GameObject newGO = Instantiate(GameManager.INSTANCE.baseRessourceObject);
        newGO.transform.position = newSpawnPosition;
        newGO.GetComponent<MeshFilter>().mesh = generatorData.OutRessourceScriptable.Mesh;
        newGO.GetComponent<MeshRenderer>().material = generatorData.OutRessourceScriptable.Material;
        newGO.tag = generatorData.OutRessourceScriptable.Name;
        GameManager.INSTANCE.AddMoney(baseMoneyGeneration * _level + (baseMoneyGeneration / 4)* _level); // ça a changer pr les gd
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
    
    // rajouter ui
}
