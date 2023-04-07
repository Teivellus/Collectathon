using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using Unity.VisualScripting;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;
using System;
using Random = UnityEngine.Random;
using JetBrains.Annotations;
using System.Reflection;

public class Greenhouse : MonoBehaviour
{
    //CURRENCIES
    public int _supplementBudGrower;
    public float _money;
    public bool _supplementUsed = false;
    //PREFAB
    public GameObject _plantPrefab;
    //TEMPORARY PLANT INFO
    public GameObject _tempPlant;
    //GAME OBJECT LINKS
    public GameObject _plantLink;
    public GameObject _uiLink;
    public GameObject _deetsScreenLink;
    public GameObject _newPlantScreenLink;
    public GameObject _gameOverScreenLink;
    public GameObject _winScreenLink;
    //LISTS
    public List<GameObject> _acceptedPlants = new List<GameObject>();
    public List<int> _currentPlantCosts = new List<int>();
    public List<int> _currentPlantCostsIndex = new List<int>();
    //VARIABLES
    public bool _soldPlant = false;
    public bool _tempClickedOn;
    public bool _noPlants = true;
    public string _tempName;
    public string _tempSuffix;
    public string _sold;
    public float _tempHealth;
    public float _currentTempCost;
    public float _maxTempCost;
    public int _plantHealthIncrease;
    public int _plantHealthDecrease;
    public int _endOfDay;
    public int _selectedIndex;
    public int _plantRemovalIndex;
    //PREFAB TRANSFORMS
    public Transform _plantParentTop;
    public Transform _plantParentMid;
    public Transform _plantParentLow;
    //TEXT DISPLAYS
    public TMP_Text _infoText;


    public void Awake()
    {
        _supplementUsed = false;
        _supplementBudGrower = 0;
        _endOfDay = 1;
        _money = 10f;
        _plantPrefab.GetComponent<Plant>()._currentPlantHealth = 0;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SpawnPlant()
    {
        // Spawn the object, same rotation as the parent object. Add that new object to a List so we can keep track of it.
        _tempPlant = Instantiate(_plantPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        // Tell the plant to create random values. It doesn't have a return value so we don't have to save anything.
        if (_tempPlant != null)
        {
            _tempPlant.GetComponent<Plant>().PlantNameGenerator();
            _tempName = _tempPlant.GetComponent<Plant>().GetName();
            _tempPlant.GetComponent<Plant>().PlantSuffixGenerator();
            _tempSuffix = _tempPlant.GetComponent<Plant>().GetSuffix();
            _tempPlant.GetComponent<Plant>().PlantHealthGenerator();
            _tempHealth = _tempPlant.GetComponent<Plant>().GetHealth();
            _tempPlant.GetComponent<Plant>().PlantMaxCostGenerator();
            _maxTempCost = _tempPlant.GetComponent<Plant>().GetMaxCost();
            _tempPlant.GetComponent<Plant>().PlantCurrentCostGenerator();
            _currentTempCost = _tempPlant.GetComponent<Plant>().GetCurrentCost();
            _endOfDay += 1;
        }
        // This section lowers the health of all plants if supplements weren't used at the end of the day.
        if (_supplementUsed == false)
        {
            _plantHealthDecrease = Random.Range(2, 7);

            for (int i = 0; i < _acceptedPlants.Count; i++)
            {
                _acceptedPlants[i].GetComponent<Plant>()._currentPlantHealth -= _plantHealthDecrease;
            }            
            _uiLink.GetComponent<UIController>().PlantDecayText();
        }
        if (_tempPlant == null)
        {

        }
    }

    public int CheapestPlant(List<int> _currentPlantCosts)
    {
        int _cheapestPlant = 0;
        int _cheapestPlantIndex = -1;
        for (int i = 0; i < _acceptedPlants.Count; i++)
        {
            if (_acceptedPlants[i].GetComponent<Plant>()._currentPlantCost < _cheapestPlant || _cheapestPlantIndex == -1)
            {
                _cheapestPlant = ((int)Math.Round(_acceptedPlants[i].GetComponent<Plant>().GetCurrentCost()));
                _cheapestPlantIndex = i;
                Debug.Log("Cheapest Plant is: " + (_cheapestPlant));
            }
        }
        return _cheapestPlant;
    }

    public int CheapestPlantIndex(List<int> _currentPlantCostsIndex)
    {
        int _cheapestPlant = 0;
        int _cheapestPlantIndex = -1;
        for (int i = 0; i < _acceptedPlants.Count; i++)
        {
            if (_acceptedPlants[i].GetComponent<Plant>()._currentPlantCost < _cheapestPlant || _cheapestPlantIndex == -1)
            {
                _cheapestPlant = ((int)Math.Round(_acceptedPlants[i].GetComponent<Plant>().GetCurrentCost()));
                _cheapestPlantIndex = i;
                Debug.Log("The cheapest Plant's index is: " + (_cheapestPlantIndex));
            }
        }
        return _cheapestPlantIndex;
    }

    public void AcceptPlant()
    {
        // NEED TO GET THE EXISTING BUTTONS TO GRAB THIS DATA INSTEAD OF MOVING IT AS AN EXISTING BUTTON
        if (_acceptedPlants.Count != 10)
        {
            _noPlants = false;
            _acceptedPlants.Add(_tempPlant);
            _uiLink.GetComponent<UIController>().AcceptedPlantText();
            //EndGame();
        }
        else
        {
            ReplacePlant();
        }
    }

        public void ReplacePlant()
        {
            
            int j = CheapestPlant(_currentPlantCosts);
            int i = CheapestPlantIndex(_currentPlantCostsIndex);
            //_money += j;
            i = _plantRemovalIndex;
            Debug.Log("It reads not null!");
            Debug.Log("The cheapest plant in your greenhouse is: " + (CheapestPlant(_currentPlantCosts)));
            //Report that there are no spaces left.
            _uiLink.GetComponent<UIController>().NoSpace();
        // Find lowest value plant. Remove plant. Add cost of plant to wallet. Play sell noise. Add new plant.
            Debug.Log("You are DELETING: " + _acceptedPlants[i].GetComponent<Plant>()._currentPlantName);
            _acceptedPlants.RemoveAt(i);
            Debug.Log("PLANT NAMES ARE BEING CALLED");
            GameObject button = GameObject.FindWithTag("Plants");
            _currentPlantCosts.Clear();
            _currentPlantCostsIndex.Clear();
            //EndGame();

    }

    public void RejectPlant()
    {
        Destroy(_tempPlant);
        _tempPlant = null;
        _currentPlantCosts.Clear();
    }

    public void SetSelectedIndex(int index)
    {
        _selectedIndex = index;
    }
    public void SellPlant()
    {
        GameObject i;

        float _plantCost = _acceptedPlants[_selectedIndex].GetComponent<Plant>().GetCurrentCost();
        _money += _plantCost;
        i = _acceptedPlants[_selectedIndex];
        _sold = "Sold " + i.GetComponent<Plant>().GetName() + i.GetComponent<Plant>().GetSuffix() + " for $" + _plantCost + ". Total money: $" + _money;
        _acceptedPlants.Remove(i);
        Destroy(i);
    }

    public void AddSupplement()
    {
        if(_money < 10f)
        {
            _uiLink.GetComponent<UIController>().NotEnoughMoneyText();
        }
        else
        {
            _uiLink.GetComponent<UIController>().BoughtSupplementText();
            _money -= 10f;
            _supplementBudGrower ++;
        }
        if(_money < 0f)
        {
            _money = 0f;
        }
    }
    
    public void RemoveSupplement()
    {
        if (_supplementUsed == true)
        {
            _uiLink.GetComponent<UIController>().SupplementUsedText();
        }
        else if (_supplementBudGrower < 1)
        {
            _uiLink.GetComponent<UIController>().NoSupplementsText();
        }
        else
        {
            _plantHealthIncrease = Random.Range(3, 10);

            for (int i = 0; i < _acceptedPlants.Count; i++)
            {
                _acceptedPlants[i].GetComponent<Plant>()._currentPlantHealth += _plantHealthIncrease;
            }
            _supplementUsed = true;
            _uiLink.GetComponent<UIController>().PlantHealingText();
            _supplementBudGrower --;
        }
    }

    public void ResetSupplementUse() {
        _supplementUsed = false;
    }

    public void EndGame()
    {
        if (_endOfDay >= 21)
        {
            for (int i = 0; i < _acceptedPlants.Count; i++)
            {
                _money += _acceptedPlants[i].GetComponent<Plant>().GetCurrentCost();
            }
                // Sell all plants for current values, destroy all plants.
                if (_money >= 100f)
            {
                //Show success text, and reset the game.
                foreach (GameObject g in GameObject.FindGameObjectsWithTag("Plants"))
                {
                    Destroy(g);
                    _acceptedPlants.Clear();
                    _noPlants = true;
                    _newPlantScreenLink.SetActive(false);
                    _endOfDay = 0;
                    _winScreenLink.SetActive(true);
                }
            }
            else if (_money <= 100f)
            {
                _supplementBudGrower = 0;
                _endOfDay = 0;
                foreach (GameObject g in GameObject.FindGameObjectsWithTag("Plants"))
                {
                    Destroy(g);
                    _acceptedPlants.Clear();
                    _noPlants = true;
                    _newPlantScreenLink.SetActive(false);
                    _endOfDay = 0;
                    _gameOverScreenLink.SetActive(true);
                }
            }
        }
    }

    //Update is called once per frame
    public void Update()
    {
        //int _deathPlantIndex;
        for (int i = 0; i < _acceptedPlants.Count; i++)
        {
            _acceptedPlants[i].GetComponent<Plant>()._currentPlantCost = _acceptedPlants[i].GetComponent<Plant>()._maxPlantCost * (_acceptedPlants[i].GetComponent<Plant>()._currentPlantHealth / 100);

            if (_acceptedPlants[i].GetComponent<Plant>()._currentPlantHealth >= 100)
            {
                _acceptedPlants[i].GetComponent<Plant>()._currentPlantHealth = 100;
            }

            if (_acceptedPlants[i].GetComponent<Plant>()._currentPlantCost >= _acceptedPlants[i].GetComponent<Plant>()._plantCost)
            {
                _acceptedPlants[i].GetComponent<Plant>()._currentPlantCost = _acceptedPlants[i].GetComponent<Plant>()._plantCost;
            }

            if (_acceptedPlants[i].GetComponent<Plant>()._currentPlantHealth <= 0)
            {

                _acceptedPlants[i].GetComponent<Plant>()._plantDied = true;
            }

            if (_acceptedPlants[i].GetComponent<Plant>()._plantDied == true)
            {
                _acceptedPlants[i].GetComponent<Plant>().DieTime();
                _acceptedPlants.Remove(_acceptedPlants[i]);

            }
        }
    }
}

