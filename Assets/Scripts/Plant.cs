using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{

    //public List<TMP_Text> _plantNameTextBoxList = new List<TMP_Text>();
    //Lists
    //public Button _plantButton;
    //public List<Button> _plantButtons = new List<Button>();
    public List<string> _plantNames = new List<string>();
    public List<string> _plantSuffix = new List<string>();
    // public List<int> _plantHealth = new List<int>();
    public float _plantHealth = 1;
    public float _plantCost;

    //Clicked Bool
    public bool _plantButtonClicked;

    //Plant prefab info
    public string _currentPlantName;
    public string _currentPlantSuffix;
    public float _currentPlantHealth;
    public float _maxPlantCost;
    public float _currentPlantCost;
    //public int _currentPlantIndex;
    public bool _plantDied;

    void Awake()
    {
        //PLANT NAMES TO CALL UP
        _plantNames.Add("Cerberus");
        _plantNames.Add("Lamia");
        _plantNames.Add("Harpy");
        _plantNames.Add("Gorgon");
        _plantNames.Add("Cyclops");
        _plantNames.Add("Dragon");
        _plantNames.Add("Unicorn");
        _plantNames.Add("Demon");
        _plantNames.Add("Goblin");
        _plantNames.Add("Wraith");
        _plantNames.Add("Sprite");
        _plantNames.Add("Angel");
        _plantNames.Add("Fairy");
        _plantNames.Add("Wyvern");
        _plantNames.Add("Slime");
        _plantNames.Add("Zombie");
        _plantNames.Add("Golem");
        _plantNames.Add("Ogre");
        _plantNames.Add("Mermaid");
        _plantNames.Add("Minotaur");
        _plantNames.Add("Werewolf");
        _plantNames.Add("Vampire");
        _plantNames.Add("Griffin");
        _plantNames.Add("Phoenix");
        _plantNames.Add("Basilisk");
        _plantNames.Add("Hydra");
        _plantNames.Add("Banshee");
        _plantNames.Add("Lich");
        _plantNames.Add("Wisp");
        _plantNames.Add("Dryad");
        _plantNames.Add("PegaSUS");

        //PLANT SUFFIXES TO CALL UP
        _plantSuffix.Add("Orchid");
        _plantSuffix.Add("Vine");
        _plantSuffix.Add("Fern");
        _plantSuffix.Add("Cactus");
        _plantSuffix.Add("Grass");
        _plantSuffix.Add("Tree");
        _plantSuffix.Add("Lily");
        _plantSuffix.Add("Ivy");
        _plantSuffix.Add("Bush");
        _plantSuffix.Add("Herb");
        _plantSuffix.Add("Bulb");
        _plantSuffix.Add("Climber");
        _plantSuffix.Add("Algae");
        _plantSuffix.Add("Weed");
        _plantSuffix.Add("Mushroom");
        _plantSuffix.Add("Thistle");
        _plantSuffix.Add("Lichen");
        _plantSuffix.Add("Reed");
        _plantSuffix.Add("Moss");
        _plantSuffix.Add("Shrub");
        _plantSuffix.Add("Bamboo");

        //PLANT HEALTH DEFAULT VALUE
        _plantHealth = 100f;

        //PLANT COST RANGE TO CALL UP
        _plantCost = Random.Range(10, 40);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnButtonClicked()
    {
        _plantButtonClicked = true;
        Debug.Log("THIS NEEDS TO OPEN PLANT DETAIL SCREEN FOR SELLING");
        Debug.Log(_currentPlantName + " " + _currentPlantSuffix);
        Debug.Log(_currentPlantCost);
        Destroy(gameObject);
        //_plantButtonClicked = false;
    }

    public void PlantNameGenerator(){
        _currentPlantName = _plantNames[Random.Range(0, _plantNames.Count)];
    }

    public string GetName() {
        return _currentPlantName;
    }

    public void PlantSuffixGenerator(){
        _currentPlantSuffix = _plantSuffix[Random.Range(0, _plantSuffix.Count)];
    }

    public string GetSuffix() {
        return _currentPlantSuffix;
    }

    public void PlantHealthGenerator(){
        _currentPlantHealth = _plantHealth;
        _currentPlantHealth -= Random.Range(5, 75);
    }

    public float GetHealth() {
        return _currentPlantHealth;
    }

    public void PlantMaxCostGenerator()
    {
        _maxPlantCost = _plantCost;
        //_currentPlantCost /= (_currentPlantHealth / 100);
    }

    public float GetMaxCost(){
        return _plantCost;
    }

    public void PlantCurrentCostGenerator()
    {
        _currentPlantCost /= _currentPlantHealth / 100;
    }

    public float GetCurrentCost()
    {
        return _currentPlantCost;
    }

    public void DieTime()
    {
        Destroy(gameObject);
    }

    //public void PlantIndexGenerator(){
    //    _currentPlantIndex = _plantIndex += 1;
    //}

    //public int GetIndex(){
    //    return _currentPlantIndex;    
    //}

    // Update is called once per frame
    void Update()
    {

    }
}
