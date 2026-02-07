using UnityEngine;

[CreateAssetMenu(fileName = "GeneratorScriptable", menuName = "Scriptable Objects/GeneratorScriptable")]
public class GeneratorScriptable : ScriptableObject
{
    public RessourcesScriptable[] InRessourceScriptable;
    public RessourcesScriptable OutRessourceScriptable;
}
