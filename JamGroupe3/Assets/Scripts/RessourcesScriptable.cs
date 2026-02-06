using UnityEngine;

[CreateAssetMenu(fileName = "RessourcesScriptable", menuName = "Scriptable Objects/RessourcesScriptable")]
public class RessourcesScriptable : ScriptableObject
{
    public string Name;
    public Mesh Mesh;
    public Material Material;
    public Sprite Sprite;
    [Range(1, 3)] public int Rarity;
}
