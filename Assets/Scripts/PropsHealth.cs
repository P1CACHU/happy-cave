using System;
using UnityEngine;

public class PropsHealth : MonoBehaviour, IDamageHandler<Damage>
{
    [SerializeField] private float maxAmount;
    
    private HealthModel _model;
    
    public Action OnDestroy;

    private void Start()
    {
        _model = new HealthModel(maxAmount);
    }

    public void Handle(Damage dmg)
    {
        _model.Amount -= dmg.Amount;
        
        if (_model.Amount < 0)
            OnDestroy?.Invoke();
    }
}
