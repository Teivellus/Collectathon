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

public class Greenhouse : MonoBehaviour
{
    //CURRENCIES
    public int _supplementBudGrower;
    public int _money;
    public bool _supplementUsed = false;
    //PREFAB
    public GameObject _plantPrefab;
    //TEMPORARY PLANT INFO
    public GameObject _tempPlant;
    //KEPT PLANT INFO
    public GameObject _acceptedPlant;
    //GAME OBJECT LINKS
    public GameObject _plantLink;
    public GameObject _uiLink;
    public GameObject _deetsScreenLink;
    public GameObject _buttonControllerLink;
    //LISTS
    public List<GameObject> _acceptedPlants = new List<GameObject>();
    public List<int> _currentPlantCosts = new List<int>();
    public List<int> _deadPlantIndexList = new List<int>();
    //public List<int> _plantIndex = new List<int>();
    //VARIABLES
    public bool _acceptedPlantClickedOn;
    public bool _soldPlant = false;
    public bool _tempClickedOn;
    public bool _tempPlantExists;
    public bool _noPlants = true;
    public string _tempName;
    public string _tempSuffix;
    public float _tempHealth;
    public float _currentTempCost;
    public float _maxTempCost;
    public int _plantHealthIncrease;
    public int _plantHealthDecrease;
    public int _endOfDay;
    //PREFAB TRANSFORMS
    public Transform _plantParentTop;
    public Transform _plantParentMid;
    public Transform _plantParentLow;
    //TEXT DISPLAYS
    public TMP_Text _infoText;


    public void Awake()
    {
        //MIGHT USE THIS IF STARTING THE GAME WITH THE DAILY PLANT SCREEN WITHOUT PRESSING END DAY BUTTON

        //// Spawn the object, same rotation as the parent object. Add that new object to a List so we can keep track of it.
        //_tempPlant = Instantiate(_plantPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        //_tempPlantExists = true;
        //// Tell the plant to create random values. It doesn't have a return value so we don't have to save anything.
        //_tempPlant.GetComponent<Plant>().PlantNameGenerator();
        //_tempPlant.GetComponent<Plant>().PlantSuffixGenerator();
        //_tempPlant.GetComponent<Plant>().PlantHealthGenerator();
        //_tempPlant.GetComponent<Plant>().PlantMaxCostGenerator();
        ////_tempPlant.GetComponent<Plant>()._plantIndex += 1;
        ////_tempPlant.GetComponent<Plant>().PlantIndexGenerator();
        //_tempName = _tempPlant.GetComponent<Plant>().GetName();
        //_tempSuffix = _tempPlant.GetComponent<Plant>().GetSuffix();
        //_tempHealth = _tempPlant.GetComponent<Plant>().GetHealth();
        //_maxTempCost = _tempPlant.GetComponent<Plant>().GetMaxCost();
        //_tempIndex = _acceptedPlantNames.Count;
        //_tempIndex = _tempPlant.GetComponent<Plant>().GetIndex();
        //foreach (string _currentPlantName in _acceptedPlants) Debug.Log("Plant is " + _currentPlantName);
        //_uiLink.GetComponent<UIController>().IntroduceNewPlant(_tempName,_tempSuffix,_tempHealth,_tempCost);
    }
    // Start is called before the first frame update
    void Start()
    {
        _supplementUsed = false;
        _supplementBudGrower = 0;
        _endOfDay = 0;
        _money = 10;
        _plantPrefab.GetComponent<Plant>()._currentPlantIndex = 0;
        _plantPrefab.GetComponent<Plant>()._currentPlantHealth = 0;
    }

    public void SpawnPlant()
    {
        // Spawn the object, same rotation as the parent object. Add that new object to a List so we can keep track of it.
        _tempPlant = Instantiate(_plantPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        _tempPlantExists = true;
        // Tell the plant to create random values. It doesn't have a return value so we don't have to save anything.
        _tempPlant.GetComponent<Plant>().PlantNameGenerator();
        _tempPlant.GetComponent<Plant>().PlantSuffixGenerator();
        _tempPlant.GetComponent<Plant>().PlantHealthGenerator();
        _tempPlant.GetComponent<Plant>().PlantMaxCostGenerator();
        _tempName = _tempPlant.GetComponent<Plant>().GetName();
        _tempSuffix = _tempPlant.GetComponent<Plant>().GetSuffix();
        _tempHealth = _tempPlant.GetComponent<Plant>().GetHealth();
        _maxTempCost = _tempPlant.GetComponent<Plant>().GetMaxCost();
        _currentTempCost = _maxTempCost / (_tempHealth / 100);
        _endOfDay += 1;
        Debug.Log(_plantParentTop.name + " has " + _plantParentTop.transform.childCount + " children");
        Debug.Log(_plantParentMid.name + " has " + _plantParentMid.transform.childCount + " children");
        Debug.Log(_plantParentLow.name + " has " + _plantParentLow.transform.childCount + " children");
        // This section lowers the health of all plants if supplements weren't used at the end of the day.
        if (_supplementUsed == false)
        {
            _plantHealthDecrease = Random.Range(3, 7);

            for (int i = 0; i < _acceptedPlants.Count; i++)
            {
                _acceptedPlants[i].GetComponent<Plant>()._currentPlantHealth -= _plantHealthDecrease;
            }            
            _uiLink.GetComponent<UIController>().PlantDecayText();
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
                _cheapestPlant = (_acceptedPlants[i].GetComponent<Plant>()._currentPlantIndex);
                _cheapestPlantIndex = i;
                //_currentPlantCosts[i] = (int)Math.Round(_acceptedPlants[i].GetComponent<Plant>()._currentPlantCost);
                Debug.Log("Cheapest Plant is: " + (_cheapestPlant));
            }
        }
        return _cheapestPlant;
    }


    //public int CheapestPlant()
    //{
    //    int _cheapestPlant = 0;
    //    int _cheapestPlantLocation = -1;

    //    for (int i = 0; i < _cheapestPlant; i++)
    //    {
    //        _cheapestPlantLocation = i;
    //    }
    //    return _cheapestPlant;
    //}

    public void AcceptPlant()
    {
        // NEED TO GET THE EXISTING BUTTONS TO GRAB THIS DATA INSTEAD OF MOVING IT AS AN EXISTING BUTTON
        if (_acceptedPlants.Count != 10)
        {
            CheapestPlant(_currentPlantCosts);
            _noPlants = false;
            _plantPrefab.GetComponent<Plant>()._currentPlantIndex += 1;
            _plantPrefab.GetComponent<Plant>().GetMaxCost();
            Debug.Log(_plantPrefab.GetComponent<Plant>()._currentPlantIndex.ToString());
            //if (_plantPrefab.GetComponent<Plant>()._currentPlantIndex == 10)
            //{
            //    _plantPrefab.GetComponent<Plant>()._currentPlantIndex = 9;
            //}
            //_infoText = _tempPlant.GetComponentInChildren<TextMeshProUGUI>();
            _acceptedPlant = _tempPlant;
            _acceptedPlants.Add(_acceptedPlant);
            //Debug.Log(_acceptedPlants[0].GetComponent<Plant>()._currentPlantIndex);
            _tempPlantExists = false;
            _acceptedPlantClickedOn = _tempClickedOn;
            //_infoText.text = _tempName + " " + _tempSuffix;
            GameObject button = GameObject.FindWithTag("Plants");
            _uiLink.GetComponent<UIController>().AcceptedPlantText();
            //EndGame();
            _currentPlantCosts.Clear();
        }
        else
        {
            ReplacePlant();
        }
    }

        public void ReplacePlant()
        {
            //if (_acceptedPlants[0] != null)
            //{
            CheapestPlant(_currentPlantCosts);
            Debug.Log("It reads not null!");
            Debug.Log("The cheapest plant in your greenhouse is: " + (CheapestPlant(_currentPlantCosts)));
            //Report that there are no spaces left.
            _uiLink.GetComponent<UIController>().NoSpace();
        // Find lowest value plant. Remove plant. Add cost of plant to wallet. Play sell noise. Add new plant.

        //foreach (GameObject p in _acceptedPlants)
        //{
        //    p.GetComponent<Plant>()._currentPlantCost
        //}
            //int i = _currentPlantCosts[0];
            //_acceptedPlants.RemoveAt(_acceptedPlants.Count - 1);
            _acceptedPlants.RemoveAt(0);
            _acceptedPlant = _tempPlant;
            _acceptedPlants.Insert(0, _acceptedPlant);
            _tempPlantExists = false;
            _acceptedPlantClickedOn = _tempClickedOn;
            _infoText = _tempPlant.GetComponentInChildren<TextMeshProUGUI>();
            Debug.Log("PLANT NAMES ARE BEING CALLED");
            //_infoText.text = _tempName + " " + _tempSuffix;
            GameObject button = GameObject.FindWithTag("Plants");
            //_money = _money += (int)Math.Round(_acceptedPlants[i].GetComponent<Plant>()._currentPlantCost);
            _deadPlantIndexList.Clear();

            //EndGame();

    }

    public void RejectPlant()
    {
        _tempPlantExists = false;
        Destroy(_tempPlant);
        _currentPlantCosts.Clear();
    }

    public void SellPlant()
    {
        //Figure out how to tie this to specific plant button.
        _soldPlant = true;
        Destroy(_tempPlant);
        _soldPlant = false;
    }

    public void AddSupplement()
    {
        if(_money <= 5)
        {
            _uiLink.GetComponent<UIController>().NotEnoughMoneyText();
        }
        else
        {
            _uiLink.GetComponent<UIController>().BoughtSupplementText();
            _money =- 5;
            _supplementBudGrower ++;
        }
        if(_money < 0)
        {
            _money = 0;
        }
    }
    
    public void RemoveSupplement()
    {
        if(_supplementBudGrower < 1)
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
        if (_endOfDay == 20)
        {
            // Sell all plants for current values, destroy all plants.
            if (_money >= 100)
            {
                //Show success text, and reset the game.
                _uiLink.GetComponent<UIController>().WinningText();

            }
            if (_money <= 100)
            {
                _uiLink.GetComponent<UIController>().GameOverText();
                _money = 10;
                _supplementBudGrower = 0;
                _endOfDay = 0;
                foreach (GameObject g in GameObject.FindGameObjectsWithTag("Plants"))
                {
                    Destroy(g);
                    _acceptedPlants.Clear();
                    _uiLink.GetComponent<UIController>().PlotsAreEmpty();
                    _noPlants = true;
                    _plantPrefab.GetComponent<Plant>()._currentPlantIndex = 0;
                }
            }
        }
    }

    //Update is called once per frame
    public void Update()
    {
        int _deathPlantIndex;
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
                _deathPlantIndex = i;
                _deadPlantIndexList.Add(_deathPlantIndex);
                _acceptedPlants[i].GetComponent<Plant>()._plantDied = true;
            }

            if (_acceptedPlants[i].GetComponent<Plant>()._plantDied == true)
            {
                _acceptedPlant.GetComponent<Plant>()._currentPlantIndex = _deadPlantIndexList[0];
                _acceptedPlants[i].GetComponent<Plant>().DieTime();
                _acceptedPlants.Remove(_acceptedPlants[i]);
                //_deadPlantIndexList.Clear();
            }
        }

        for (int i = 0; i < _acceptedPlants.Count; i++)
        {
            _acceptedPlants[i].GetComponent<Plant>()._currentPlantIndex = i;
        }
    }
}

