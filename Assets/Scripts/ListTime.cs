using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ListTime : MonoBehaviour
{
    //THIS IS A CLASS TO THINK ABOUT WHEN DECIDING WHICH IS THE CHEAPEST PLANT TO DESTROY WHEN ACCEPTING NEW PLANT AT TEN PLANT
    int _startingPlantWorth;
    public List<int> _plantIndex = new List<int>();

    // Start is called before the first frame update
    void Start()
    {

        print(_startingPlantWorth);
        // string _plantPlural = "plant";
        // if (_plantList = 0) {
        //     string _plantPlural = "plants";
        // }

        print($"The most expensive plant is {ExpensivestPlant(_plantIndex)}.");
        print($"The cheapest plant is {CheapestPlant(_plantIndex)}.");
        

        int ExpensivestPlant(List<int> _plantList) {
        int _highestCost = 0;
        int _expensivePlantLocation = -1;

        for(int i = 0;i< _plantIndex.Count;i++) {
            if (_plantIndex[i] > _highestCost) {
                _highestCost = _plantIndex[i];
                _expensivePlantLocation = i;
            }
        }

        return _expensivePlantLocation;
        }

        int CheapestPlant(List<int> _plantList) {
        int _lowestCost = 0;
        int _cheapestPlantLocation = -1;

        for(int i = 0;i< _plantIndex.Count;i++) {
            if (_plantIndex[i] < _lowestCost || _cheapestPlantLocation == -1) {
                _lowestCost = _plantIndex[i];
                _cheapestPlantLocation = i;
            }
        }

        return _cheapestPlantLocation;
        }
    }

    //public void SellLowestValue()
    //{
    //    Destroy(gameObject);
    //    _money = +price / health;
    //}

    public int TotalPlantCost(List<int> _plantList) {
        int _tempPlantCost = 0;
        for(int i = 0;i< _plantIndex.Count;i++) {
            _tempPlantCost += _plantIndex[i];
        }
        return _tempPlantCost;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

static class PlantIndexes
{
    
}