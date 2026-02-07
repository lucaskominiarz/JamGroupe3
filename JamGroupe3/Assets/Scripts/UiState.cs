using DG.Tweening;
using UnityEngine;

public class UiState : MonoBehaviour // le nom est catastrophique mais j'avais pas d'inspi
{
    [SerializeField] private GameObject ui;
    [SerializeField] private float speed = 0.1f;
    private bool _isActive = false;
    
    public void ChangeUiState()
    {
        if (_isActive)
        {
            ui.transform.DOScale(Vector3.zero, speed).SetEase(Ease.OutBack).OnComplete(() => { ui.SetActive(false); });
            
        }
        else
        {
            ui.SetActive(true);
            ui.transform.DOScale(new Vector3(6.9f,0.816319466f,0.816319466f), speed).SetEase(Ease.OutBack);
        }
        _isActive = !_isActive;
    }
}
