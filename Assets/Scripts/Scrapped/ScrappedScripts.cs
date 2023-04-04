using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrappedScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


//~~~~~~~~FROM GREENHOUSE~~~~~~~~

//if (_plantParentTop.transform.childCount <= 2)
//{
//    _tempPlant.transform.SetParent(_plantParentTop);
//    _acceptedPlants.Add(_tempPlant);
//    _tempPlantExists = false;
//    _acceptedPlantClickedOn = _tempClickedOn;
//    _infoText = _tempPlant.GetComponentInChildren<TextMeshProUGUI>();
//    //_infoText.text = _tempName + " " + _tempSuffix;
//    GameObject button = GameObject.FindWithTag("Plants");
//    _uiLink.GetComponent<UIController>().AcceptedPlantText();
//    _endOfDay += 1;
//}
//else if (_plantParentMid.transform.childCount <= 2)
//{
//    _tempPlant.transform.SetParent(_plantParentMid);
//    _acceptedPlants.Add(_tempPlant);
//    _tempPlantExists = false;
//    _acceptedPlantClickedOn = _tempPlant.GetComponent<Plant>()._plantButtonClicked;
//    _infoText = _tempPlant.GetComponentInChildren<TextMeshProUGUI>();
//    //_infoText.text = _tempName + " " + _tempSuffix;
//    GameObject button = GameObject.FindWithTag("Plants");
//    _uiLink.GetComponent<UIController>().AcceptedPlantText();
//    _endOfDay += 1;
//}
//else if (_plantParentLow.transform.childCount <= 3)
//{
//    _tempPlant.transform.SetParent(_plantParentLow);
//    _acceptedPlants.Add(_tempPlant);
//    _tempPlantExists = false;
//    _acceptedPlantClickedOn = _tempPlant.GetComponent<Plant>()._plantButtonClicked;
//    _infoText = _tempPlant.GetComponentInChildren<TextMeshProUGUI>();
//    //_infoText.text = _tempName + " " + _tempSuffix;
//    GameObject button = GameObject.FindWithTag("Plants");
//    _uiLink.GetComponent<UIController>().AcceptedPlantText();
//    _endOfDay += 1;
//}
//else
//{
//    //Report that there are no spaces left.
//    _uiLink.GetComponent<UIController>().NoSpace();
//    // Find lowest value plant. Remove plant. Add cost of plant to wallet. Play sell noise. Add new plant.
//}



//if (_acceptedPlants.Count > 9)
//{
//    _uiLink.GetComponent<UIController>().NoSpace();
//}

//_tempClickedOn = _plantLink.GetComponent<Plant>()._plantButtonClicked;

//for (int plants)
//Show failed text, and reset game.
// _uiLink.GetComponent<UIController>().FailedGameText();

//else
//{
//    _endOfDay++;
//}

//_plantLink.GetComponent<Plant>()._plantButton.onClick.AddListener(PlantDetailsScreen);

//if (_plants == null)
//    _plants = GameObject.FindGameObjectsWithTag("Plants");

//foreach (GameObject Plants in _plants)
//{
//    Debug.Log(Plants);
//    Plants.GetComponent<Plant>().GetName();
//    Debug.Log(Plants.GetComponent<Plant>()._currentPlantName + " " + Plants.GetComponent<Plant>()._currentPlantSuffix + " has " + Plants.GetComponent<Plant>()._currentPlantHealth + " health and costs " + Plants.GetComponent<Plant>()._currentPlantCost.ToString("$#.##") + ".");
//}
//}

//for (int i = 0; i < _acceptedPlants.Count; i++)
//{

//}



//public void PlantDetailsScreen()
//{
//    if (_plantLink.GetComponent<Plant>()._plantButtonClicked == true)
//    {
//        _plantLink.GetComponent<Plant>().OnButtonClicked();
//        _deetsScreenLink.SetActive(true);
//    }
//}



//_tempClickedOn = _plantLink.GetComponent<Plant>()._plantButtonClicked;

//for (int plants)
//Show failed text, and reset game.
// _uiLink.GetComponent<UIController>().FailedGameText();

//else
//{
//    _endOfDay++;
//}

//_plantLink.GetComponent<Plant>()._plantButton.onClick.AddListener(PlantDetailsScreen);

//if (_plants == null)
//    _plants = GameObject.FindGameObjectsWithTag("Plants");

//foreach (GameObject Plants in _plants)
//{
//    Debug.Log(Plants);
//    Plants.GetComponent<Plant>().GetName();
//    Debug.Log(Plants.GetComponent<Plant>()._currentPlantName + " " + Plants.GetComponent<Plant>()._currentPlantSuffix + " has " + Plants.GetComponent<Plant>()._currentPlantHealth + " health and costs " + Plants.GetComponent<Plant>()._currentPlantCost.ToString("$#.##") + ".");
//}





//~~~~~~~~FROM UI CONTROLLER~~~~~~~~

//if (_greenhouseLink.GetComponent<Greenhouse>()._tempPlantExists == true)
//{
//    _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlantClickedOn = _greenhouseLink.GetComponent<Greenhouse>()._tempPlant.GetComponent<Plant>()._plantButtonClicked;
//    Debug.Log("Accepted Plant Clicked On!");
//}

//_buttonControllerLink.GetComponent<ButtonController>().LinkPlantToButton0();



//public void PlantButtonText()
    //{
        
        // if (_greenhouseLink.GetComponent<Greenhouse>()._noPlants == true)
        // {
        //     PlotsAreEmpty();
        //     Debug.Log("NO PLANTS");
        // }
        // //for (int i = -1; i < _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants.Count; i++)
        // //{

        // //}
        // else if (_buttonControllerLink.GetComponent<ButtonController>().button0 != _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[0])
        // {
        //     _buttonControllerLink.GetComponent<ButtonController>().button0 = _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[0];
        //     _displayPlant0Name.text = (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix);
        // }
        // else if (_buttonControllerLink.GetComponent<ButtonController>().button1 != _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[1])
        // {
        //     _buttonControllerLink.GetComponent<ButtonController>().button1 = _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[1];
        //     _displayPlant1Name.text = (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix);
        // }
        // else if (_buttonControllerLink.GetComponent<ButtonController>().button2 != _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[2])
        // {
        //     _buttonControllerLink.GetComponent<ButtonController>().button2 = _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[2];
        //     _displayPlant2Name.text = (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix);
        // }
        // else if (_buttonControllerLink.GetComponent<ButtonController>().button3 != _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[3])
        // {
        //     _buttonControllerLink.GetComponent<ButtonController>().button3 = _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[3];
        //     _displayPlant3Name.text = (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix);
        // }
        // else if (_buttonControllerLink.GetComponent<ButtonController>().button4 != _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[4])
        // {
        //     _buttonControllerLink.GetComponent<ButtonController>().button4 = _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[4];
        //     _displayPlant4Name.text = (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix);
        // }
        // else if (_buttonControllerLink.GetComponent<ButtonController>().button5 != _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[5])
        // {
        //     _buttonControllerLink.GetComponent<ButtonController>().button5 = _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[5];
        //     _displayPlant5Name.text = (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix);
        // }
        // else if (_buttonControllerLink.GetComponent<ButtonController>().button6 != _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[6])
        // {
        //     _buttonControllerLink.GetComponent<ButtonController>().button6 = _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[6];
        //     _displayPlant6Name.text = (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix);
        // }
        // else if (_buttonControllerLink.GetComponent<ButtonController>().button7 != _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[7])
        // {
        //     _buttonControllerLink.GetComponent<ButtonController>().button7 = _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[7];
        //     _displayPlant7Name.text = (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix);
        // }
        // else if (_buttonControllerLink.GetComponent<ButtonController>().button8 != _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[8])
        // {
        //     _buttonControllerLink.GetComponent<ButtonController>().button8 = _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[8];
        //     _displayPlant8Name.text = (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix);
        // }
        // else if (_buttonControllerLink.GetComponent<ButtonController>().button9 != _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[9])
        // {
        //     _buttonControllerLink.GetComponent<ButtonController>().button9 = _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[9];
        //     _displayPlant9Name.text = (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix);
        // }
        // else
        // {
        //     PlotsAreEmpty();
        //     //_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants.RemoveAt(9);
        //     _greenhouseLink.GetComponent<Greenhouse>()._noPlants = true;
        //     Debug.Log("ERROR");
        // }
        // //_buttonControllerLink.GetComponent<ButtonController>().LinkPlantToButton0();
    //}




//~~~~~~~~FROM BUTTON CONTROLLER~~~~~~~~

//if (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[0] != null)
//{
//    button1 = _greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[0];
//    _uiLink.GetComponent<UIController>()._displayPlant0Name.text = (_greenhouseLink.GetComponent<Greenhouse>()._tempName) + " " + (_greenhouseLink.GetComponent<Greenhouse>()._tempSuffix);
//}
//else if (_greenhouseLink.GetComponent<Greenhouse>()._acceptedPlants[0] == null)
//{
//    Debug.Log("ERROR");
//}