using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    
    [SerializeField] private RessourcesScriptableHandler ressources;
    public GameObject baseRessourceObject; // faut mettre genre un cube avec un rigidbody
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

    public void Click(int ressourceIndex)
    {
        RessourcesScriptable ressourceToSpawn = ressources.RessourcesScriptablesTab[ressourceIndex];
        for (int i = 0; i < clickerLevels[ressourceIndex]; i++)
        {
            SpawnRessource(ressourceToSpawn, ressourceIndex);
        }
    }

    private void SpawnRessource(RessourcesScriptable ressourceToSpawn, int index) // le code est aberrant mais on s'en fou ça doit bugger
    {
        GameObject newRessource = Instantiate(baseRessourceObject);
        newRessource.transform.position = spawnersPositions[index].position;
        newRessource.GetComponent<MeshFilter>().mesh = ressourceToSpawn.Mesh;
        newRessource.GetComponent<MeshRenderer>().material = ressourceToSpawn.Material;
        newRessource.tag = ressourceToSpawn.Name;
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
