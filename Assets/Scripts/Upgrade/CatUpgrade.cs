using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CatUpgrade : ScriptableObject
{
    public float UpgradeAmount = 1f;

    public double OriginalUpgradeCost = 100;
    public double CurrentUpgradeCost = 100;
    public double CostIncreaseMultiplierPerPurchase = .05f;

    public string UpgradeButtonText;
    [TextArea(3, 10)]
    public string UpgradeButtonDescription;

    public abstract void ApplyUpgrade();

    private void OnValidate()
    {
        CurrentUpgradeCost = OriginalUpgradeCost;
    }
}
