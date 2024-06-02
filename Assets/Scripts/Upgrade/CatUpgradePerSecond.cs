using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cat Upgrade/Cat Per Second", fileName = "Cat Per Second")]
public class CatUpgradePerSecond : CatUpgrade
{
    public override void ApplyUpgrade()
    {
        GameObject go = Instantiate(CatManger.instance.catHairPerSecondObjToSpawn, Vector3.zero, Quaternion.identity);
        go.GetComponent<CatPerSecondTimer>().CatPerSecond = UpgradeAmount;

        CatManger.instance.SimpleCatPerSecondIncrease(UpgradeAmount);
    }
}
