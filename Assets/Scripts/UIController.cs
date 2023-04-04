using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting;
using System.Threading.Tasks;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    //Text Displays
    public TMP_Text _displayMoney;
    public TMP_Text _displayDay;
    public TMP_Text _displayStartingScene;
    public TMP_Text _displayNewPlant;
    public TMP_Text _displayTempPlantName;
    public TMP_Text _displayTempHealth;
    public TMP_Text _displayTempCost;
    public TMP_Text _displaySoldText;
    public TMP_Text _displayTempPlantedPlant;
    public TMP_Text _displayPlantDisclaimer;
    public TMP_Text _displayPlantSellingDisclaimer;
    public TMP_Text _displayNotEnoughMoney;
    public TMP_Text _displayBoughtSupplement;
    public TMP_Text _displayNoSupplements;
    public TMP_Text _displayPlantHealing;
    public TMP_Text _displayPlantDecay;
    public TMP_Text _displayPlantDied;
    public TMP_Text _displayNameInfoText;
    public TMP_Text _displayHealthInfoText;
    public TMP_Text _displayPriceInfoText;
    public TMP_Text _displayNoSpace;
    public TMP_Text _displayGameOver;
    public TMP_Text _displayRestart;
    public List<TMP_Text> _displayPlantNamesList;
  
    //public TMP_Text _displayCurrentPlantName;
    //Links to Game Objects.
    public GameObject _greenhouseLink;
    public GameObject _plantLink;
    public GameObject _deetsScreenLink;
    public GameObject _buttonControllerLink;
    //Lists
    //public List<string> _buttonPlantNames = new List<string> {"Plant","Crabothy","Jason","Crustacy"};
    //public List<TMP_Text> _plantNameTextBoxList;

    // Start is called before the first frame update
    void Start()
    {
        _displayStartingScene.text = ("You are the brand new gardener of a greenhouse owned by evil alien overlords. They have told you that you have twenty days to make them delicious plants to eat, or the next gardener will replace you. You have access to supplements that cost 10 money each, which keep your plants healthy and expensive.");
        PlotsAreEmpty();
    }

    //public void IntroduceNewPlant(string _tempName, string _tempSuffix, float _tempHealth, float _tempCost)
    //{
    //    _plantLink.GetComponent<Plant>().PlantNameGenerator();
    //    _plantLink.GetComponent<Plant>().PlantSuffixGenerator();
    //    _plantLink.GetComponent<Plant>().PlantHealthGenerator();
    //    _plantLink.GetComponent<Plant>().PlantCostGenerator();
    //    _tempName = _plantLink.GetComponent<Plant>().GetName();
    //    _tempSuffix = _plantLink.GetComponent<Plant>().GetSuffix();
    //    _tempHealth = _plantLink.GetComponent<Plant>().GetHealth();
    //    _tempCost = _plantLink.GetComponent<Plant>().GetCost();
    //}

    public void AddText(string textToAdd)
    {

    }

    public void ClearText()
    {

    }

    public void Problems(string errorReport)
    {

    }

    public void NewPlantText()
    {
        _displayNewPlant.text = ("You have been offered a new plant from the evil alien overlords' discarded plants. What will you do with it?");
    }

    public void AcceptedPlantText()
    {
        _displayTempPlantedPlant.text = ("You have planted " + (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix) + " with " + (_greenhouseLink.GetComponent<Greenhouse>()._tempHealth.ToString()) + " health and a price of " + (_greenhouseLink.GetComponent<Greenhouse>()._currentTempCost.ToString("$#.##") + "."));
    }

    public void NoSpace()
    {
        _displayNoSpace.text = ("You did not have any space, so you sold 'lowest plant name, health, for price' to make space. You then planted " + (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix) + " with " + (_greenhouseLink.GetComponent<Greenhouse>()._tempHealth.ToString()) + " health and a price of " + (_greenhouseLink.GetComponent<Greenhouse>()._currentTempCost.ToString("$#.##") + "."));
    }

    public void updatePlantList() {
        for (int i = 0; i < _displayPlantNamesList.Count; i++)
        {    
             if (i < _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants.Count) {
                _displayPlantNamesList[i].text = (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[i].GetComponent<Plant>().GetName()) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[i].GetComponent<Plant>().GetSuffix());
             } else {
                _displayPlantNamesList[i].text = "Empty Plot";
             }
        }        
    }  

    public void DisplayPublicPlantData(int index) {
        Debug.Log(_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[index].GetComponent<Plant>().GetName() + " " + (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[index].GetComponent<Plant>().GetSuffix()));
    }

    public void NotEnoughMoneyText()
    {
        _displayNotEnoughMoney.text = ("You do not have enough money.");
    }
    public void BoughtSupplementText()
    {
        _displayBoughtSupplement.text = ("You bought the supplement 'Bud Grower' for 10 money!");
    }

    public void NoSupplementsText()
    {
        _displayNoSupplements.text = ("You do not have any supplements.");
    }

    public void PlantHealingText()
    {
        _displayPlantHealing.text = ("You increased the health of your plants by " + (_greenhouseLink.GetComponent<Greenhouse>()._plantHealthIncrease) + " whole points !");
    }

    public void PlantDecayText()
    {
        _displayPlantDecay.text = ("You did not use any supplements to keep your plants healthy. Their health decreased by " + (_greenhouseLink.GetComponent<Greenhouse>()._plantHealthDecrease) + " whole points !");
    }

    public void CurrentInfoText()
    {
        if (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants.Count >= 0)
        {
            //_displayNameInfoText.text = (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlantNames[0] + " " + _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlantSuffixes[0]);
            //_displayHealthInfoText.text = ("Health: " + _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlantHealth[0].ToString("##.##"));
            //_displayPriceInfoText.text = ("Price: " + _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlantCost[0].ToString("$##.##"));
        }
    }

    public void PlantDisclaimer()
    {
        _displayPlantDisclaimer.text = ("*Price of the plant is modified by its current health value. \nIf your number of plants has reached ten, when you accept a plant, you will be selling your cheapest plant before planting it." + "\nCurrent Number of Plants: " + (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants.Count) + "/10");
    }

    public void SellingPlantDisclaimer()
    {
        _displayPlantSellingDisclaimer.text = ("*Price of the plant is modified by its current health value. When you sell a plant, you get its value added to your money, but it is gone for good."  + "\nCurrent Number of Plants: " + (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants.Count) + "/10");
    }

    public void OnPointerClick()
    {
        if (_plantLink.GetComponent<Plant>()._plantButtonClicked == true)
        {
            _deetsScreenLink.SetActive(true);
            Debug.Log("This has read the clicked plant.");
        }
    }

    public void PlantDiedText()
    {
        _displayPlantDied.text = ("Your " + (_plantLink.GetComponent<Plant>()._currentPlantName) + " " + (_plantLink.GetComponent<Plant>()._currentPlantSuffix) + " wilted and died.");
    }

    public void PlotsAreEmpty()
    {
        // _displayPlant0Name.text = ("Empty Plot");
        // _displayPlant1Name.text = ("Empty Plot");
        // _displayPlant2Name.text = ("Empty Plot");
        // _displayPlant3Name.text = ("Empty Plot");
        // _displayPlant4Name.text = ("Empty Plot");
        // _displayPlant5Name.text = ("Empty Plot");
        // _displayPlant6Name.text = ("Empty Plot");
        // _displayPlant7Name.text = ("Empty Plot");
        // _displayPlant8Name.text = ("Empty Plot");
        // _displayPlant9Name.text = ("Empty Plot");
    }

    public void GameOverText()
    {
        _displayGameOver.text = ("Your evil overlords are not impressed. Along with eating all of your plants, you are being used for fertiliser for the next batch.");
    }

    public void WinningText()
    {
        _displayRestart.text = ("Your evil overloard are happy with your contributions and have bought all of your plants from you. Continue to satisfy them, or you might become food for your plants.");
    }

    // Update is called once per frame
    void Update()
    {
        //Displays the current money value.
        _displayMoney.text = ("Money: " + (_greenhouseLink.GetComponent<Greenhouse>()._money.ToString()));
        //Displays the current day.
        _displayDay.text = ("Current Day: " + (_greenhouseLink.GetComponent<Greenhouse>()._endOfDay.ToString()));
        //Displays the temporary Name, Health, and Cost of plants when being created.
        _displayTempPlantName.text = (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix);
        //_displayCurrentPlantName.text = (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempName);
        _displayTempHealth.text = ("Health: " + (_greenhouseLink.GetComponent<Greenhouse>()._tempHealth.ToString()));
        _displayTempCost.text = ("Price: " + (_greenhouseLink.GetComponent<Greenhouse>()._maxTempCost.ToString("#.##")));
        if (_greenhouseLink.GetComponent<Greenhouse>()._soldPlant == true)
        {
            _displaySoldText.text = ("You sold " + (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix) + " for " + (_greenhouseLink.GetComponent<Greenhouse>()._currentTempCost.ToString("#.##.")));
        }


        if (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlantClickedOn == true)
        {
            _deetsScreenLink.SetActive(true);
            Debug.Log("Hola");
            //_plantLink.GetComponent<Plant>().OnButtonClicked();
        }

        if (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlantClickedOn == true)
        {
            _deetsScreenLink.SetActive(true);
            Debug.Log("This has read the clicked plant.");
        }

        //if () == true)

        if (_plantLink.GetComponent<Plant>()._plantDied == true)
        {
            Debug.Log("PLANT DED");
            PlantDiedText();
        }
    }
}