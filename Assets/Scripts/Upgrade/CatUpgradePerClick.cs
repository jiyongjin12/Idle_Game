using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Cat Upgrade/Cat Per Click", fileName ="Cat Per Click")]
public class CatUpgradePerClick : CatUpgrade
{

    public override void ApplyUpgrade()
    {
        CatManger.instance.CatPerClickUpgrade += UpgradeAmount;
    }
}
