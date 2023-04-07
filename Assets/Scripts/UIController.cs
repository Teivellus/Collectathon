using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting;
using System.Threading.Tasks;
using UnityEngine.UIElements;
using System;

public class UIController : MonoBehaviour
{
    //Text Displays
    public TMP_Text _displayMoney;
    public TMP_Text _displayDay;
    public TMP_Text _displaySupplements;
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
    public TMP_Text _displaySupplementUsed;
    public TMP_Text _displayPlantHealing;
    public TMP_Text _displayPlantDecay;
    public TMP_Text _displayPlantDied;
    public TMP_Text _displayNameInfoText;
    public TMP_Text _displayHealthInfoText;
    public TMP_Text _displayPriceInfoText;
    public TMP_Text _displayNoSpace;
    public TMP_Text _displayNoPlant;
    public TMP_Text _displayGameOver;
    public TMP_Text _displayRestart;
    //Lists
    public List<TMP_Text> _displayPlantNamesList;
    public List<TMP_Text> _displayPublicPlantNamesList;
    public List<TMP_Text> _displayPlantHealthList;
    public List<TMP_Text> _displayPlantCostsList;

    //Links to Game Objects.
    public GameObject _greenhouseLink;
    public GameObject _plantLink;
    public GameObject _deetsScreenLink;

    // Start is called before the first frame update
    void Start()
    {
        _displayStartingScene.text = ("You are the brand new gardener of a greenhouse owned by evil alien overlords. They have told you that you have twenty days to make them delicious plants to eat, or the next gardener will replace you. You have access to supplements that cost 10 money each, which keep your plants healthy and expensive.");
    }

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
        _displayTempPlantedPlant.text = ("You have planted a " + (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix) + ".");
    }

    public void NoSpace()
    {
        _displayNoSpace.text = ("You did not have any space, so you sold 'lowest plant name, health, for price' to make space. You then planted " + (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix) + " with " + (_greenhouseLink.GetComponent<Greenhouse>()._tempHealth.ToString()) + " health and a price of " + (_greenhouseLink.GetComponent<Greenhouse>()._currentTempCost.ToString("$##.##") + "."));
    }

    public void NoPlant()
    {
        _displayNoPlant.text = ("There is no plant here.");
    }

    //Updates plant names for buttons
    public void UpdatePlantList() {
        for (int i = 0; i < _displayPlantNamesList.Count; i++)
        {    
             if (i < _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants.Count) {
                _displayPlantNamesList[i].text = (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[i].GetComponent<Plant>().GetName()) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[i].GetComponent<Plant>().GetSuffix());
             } else {
                _displayPlantNamesList[i].text = "Empty Plot";
             }
        }        
    }

    public int FindCheapestPlant(int index)
    {
        int _cheapestPlant = 0;
        int _cheapestPlantIndex = -1;
        for (int i = 0; i < _displayPlantNamesList.Count; i++)
        {
            if (_displayPlantNamesList[i].GetComponent<Plant>()._currentPlantCost < _cheapestPlant || _cheapestPlantIndex == -1)
            {
                _cheapestPlant = ((int)Math.Round(_displayPlantNamesList[i].GetComponent<Plant>()._currentPlantCost));
                _cheapestPlantIndex = i;
                //_currentPlantCosts[i] = (int)Math.Round(_acceptedPlants[i].GetComponent<Plant>()._currentPlantCost);
                Debug.Log("Cheapest Plant is: " + (_cheapestPlant));
            }            
        }
        return _cheapestPlant;
    }

    //Shows Name and Suffix
    public void DisplayPublicPlantData(int index)
    {
        if (index >= _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants.Count)
        {
            // The index is out of range, so do nothing or display an error message.
            Debug.Log("Else is being used.");
            NoPlant();
            _deetsScreenLink.SetActive(false);
            return;
        }
        for (int i = 0; i < _displayPublicPlantNamesList.Count; i++)
        {
            if (i < _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants.Count)
            {
                _displayPublicPlantNamesList[i].text = (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[index].GetComponent<Plant>().GetName() + " " + (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[index].GetComponent<Plant>().GetSuffix()));
                Debug.Log(_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[index].GetComponent<Plant>().GetName() + " " + (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[index].GetComponent<Plant>().GetSuffix()));
               
                _displayPlantHealthList[i].text = ("Health: " + _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[index].GetComponent<Plant>().GetHealth());
                Debug.Log(_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[index].GetComponent<Plant>().GetHealth());
                
                _displayPlantCostsList[i].text = ("Price: $" + _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[index].GetComponent<Plant>().GetCurrentCost());
                Debug.Log(_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[index].GetComponent<Plant>().GetCurrentCost());
            }
        }
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

    public void SupplementUsedText()
    {
        _displaySupplementUsed.text = ("You have already used a supplement today, are you trying to kill your plants with love?");
    }

    public void PlantHealingText()
    {
        _displayPlantHealing.text = ("You increased the health of your plants by " + (_greenhouseLink.GetComponent<Greenhouse>()._plantHealthIncrease) + " whole points !");
    }

    public void PlantDecayText()
    {
        _displayPlantDecay.text = ("You did not use any supplements to keep your plants healthy. Their health decreased by " + (_greenhouseLink.GetComponent<Greenhouse>()._plantHealthDecrease) + " whole points !");
    }
    public void PlantDisclaimer()
    {
        _displayPlantDisclaimer.text = ("*Price of the plant is modified by its current health value. \nIf your number of plants has reached ten, when you accept a plant, you will be selling your cheapest plant before planting it." + "\nCurrent Number of Plants: " + (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants.Count) + "/10");
    }

    public void SoldPlantText()
    {
        _displaySoldText.text = _greenhouseLink.GetComponent<Greenhouse>()._sold;
    }
    public void PlantDiedText()
    {
        _displayPlantDied.text = ("Your " + (_plantLink.GetComponent<Plant>()._currentPlantName) + " " + (_plantLink.GetComponent<Plant>()._currentPlantSuffix) + " wilted and died.");
    }
    public void GameOverText()
    {
        _displayGameOver.text = ("Your evil overlords are not impressed. Along with eating all of your plants, you are being used for fertiliser for the next batch.");
    }

    public void WinningText()
    {
        _displayRestart.text = ("Your evil overlords are happy with your contributions and have bought all of your plants from you. Continue to satisfy them, or you might become food for your plants.");
    }

    // Update is called once per frame
    void Update()
    {
        //Displays the current money value.
        _displayMoney.text = ("Money: " + (_greenhouseLink.GetComponent<Greenhouse>()._money.ToString($"##.##")));
        //Displays the current number of supplements.
        _displaySupplements.text = ("Supplements: " + (_greenhouseLink.GetComponent<Greenhouse>()._supplementBudGrower.ToString()));
        //Displays the current day.
        _displayDay.text = ("Current Day: " + (_greenhouseLink.GetComponent<Greenhouse>()._endOfDay.ToString()));
        //Displays the temporary Name, Health, and Cost of plants when being created.
        _displayTempPlantName.text = (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix);
        //_displayCurrentPlantName.text = (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempName);
        _displayTempHealth.text = ("Health: " + (_greenhouseLink.GetComponent<Greenhouse>()._tempHealth.ToString()));
        _displayTempCost.text = ("Price: " + (_greenhouseLink.GetComponent<Greenhouse>()._maxTempCost.ToString("#.##")));
        _displayPlantSellingDisclaimer.text = ("*Price of the plant is modified by its current health value. When you sell a plant, you get its value added to your money, but it is gone for good." + "\nCurrent Number of Plants: " + (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants.Count) + "/10");
        
        if (_plantLink.GetComponent<Plant>()._plantDied == true)
        {
            Debug.Log("PLANT DED");
            PlantDiedText();
        }
    }
}
