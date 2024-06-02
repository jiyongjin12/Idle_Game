using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CatManger : MonoBehaviour
{
    public static CatManger instance;

    public GameObject mainGameCanvas;
    [SerializeField] private GameObject upgradeCanvas;
    [SerializeField] private TextMeshProUGUI CatHairCountText;
    [SerializeField] private TextMeshProUGUI catHairPerSecondText;
    [SerializeField] private GameObject CatObj;
    public GameObject catTextPopup;
    [SerializeField] private GameObject backGroundObj;

    [Space]
    public CatUpgrade[] CatUpgrades;
    [SerializeField] private GameObject upgradeUITospawn;
    [SerializeField] private Transform upgradeUIParent;
    public GameObject catHairPerSecondObjToSpawn;

    public double CurrentCatHairCount { get; set; }
    public double CurrentCatHairPerSecond { get; set; }

    public double CatPerClickUpgrade { get; set; }

    private InitializeUpgrades initializeUpgrade;
    private CatDisplay catDisplay;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        catDisplay = GetComponent<CatDisplay>();

        UpdateCatUI();
        UpdateCatHairPerSecondUI();

        upgradeCanvas.SetActive(false);
        mainGameCanvas.SetActive(true);

        initializeUpgrade = GetComponent<InitializeUpgrades>();
        initializeUpgrade.Initialize(CatUpgrades, upgradeUITospawn, upgradeUIParent);
    }

    public void OnCatClicked()
    {
        IncreaseCat();

        CatObj.transform.DOBlendableScaleBy(new Vector3(.5f, .5f, .5f), .1f).OnComplete(CatScaleBack);
        backGroundObj.transform.DOBlendableScaleBy(new Vector3(.5f, .5f, .5f), .1f).OnComplete(BackgroundScaleBack);

        PopupText.Create(1 + CatPerClickUpgrade);

        Debug.Log("check");
    }

    private void CatScaleBack()
    {
        CatObj.transform.DOBlendableScaleBy(new Vector3(-.5f, -.5f, -.5f), .5f);
    }

    private void BackgroundScaleBack()
    {
        backGroundObj.transform.DOBlendableScaleBy(new Vector3(-.5f, -.5f, -.5f), .5f);
    }

    public void IncreaseCat()
    {
        CurrentCatHairCount += 1 + CatPerClickUpgrade;
        UpdateCatUI();
    }

    // UI Updates

    private void UpdateCatUI()
    {
        //CatHairCountText.text = CurrentCatHairCount.ToString();
        catDisplay.UpdateCatText(CurrentCatHairCount, CatHairCountText);
    }

    private void UpdateCatHairPerSecondUI()
    {
        //catHairPerSecondText.text = CurrentCatHairPerSecond.ToString() + " P/S";
        catDisplay.UpdateCatText(CurrentCatHairPerSecond, catHairPerSecondText, " P/S");
    }

    //

    public void OnUpgradeButtonPress()
    {
        mainGameCanvas.SetActive(false);
        upgradeCanvas.SetActive(true);
    }

    public void OnResumeButtonPress()
    {
        upgradeCanvas.SetActive(false);
        mainGameCanvas.SetActive(true);
    }

    //

    public void SimpleCatIncrease(double amount)
    {
        CurrentCatHairCount += amount;
        UpdateCatUI();
    }

    public void SimpleCatPerSecondIncrease(double amount)
    {
        CurrentCatHairPerSecond += amount;
        UpdateCatHairPerSecondUI();
    }

    //

    public void OnUpgradeButtonClick(CatUpgrade upgrade, UpgradeButtonReferenc buttonRef)
    {
        if (CurrentCatHairCount >= upgrade.CurrentUpgradeCost)
        {
            upgrade.ApplyUpgrade();

            CurrentCatHairCount -= upgrade.CurrentUpgradeCost;
            UpdateCatUI();

            upgrade.CurrentUpgradeCost = Mathf.Round((float)(upgrade.CurrentUpgradeCost * (1 + upgrade.CostIncreaseMultiplierPerPurchase)));

            buttonRef.UpgradeCostText.text = "Cost: " + upgrade.CurrentUpgradeCost;
        }
    }
}
