using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideUI : MonoBehaviour {

    public GameObject hintGroup;
    public GameObject endMsg;
    public void HideRuleAndHint()
    {        
        hintGroup.SetActive(!hintGroup.active);
    }
    public void ShowEngMsg()
    {
        if (GameObject.Find("Title")) GameObject.Find("Title").SetActive(false);
        if (GameObject.Find("Phrase")) GameObject.Find("Phrase").SetActive(false);
        if (GameObject.Find("Button")) GameObject.Find("Button").SetActive(false);
        if(GameObject.Find("RuleAndHint")) GameObject.Find("RuleAndHint").SetActive(false);
        GameControl gameControll;
        gameControll = GameObject.Find("GameController").GetComponent<GameControl>();
        endMsg.SetActive(true);
        int playerFlag = gameControll.selectedCharacter.GetComponent<CharacterClicked>().playerFlag;
        Text msg = GameObject.Find("EndMsg").GetComponent<Text>();
        msg.text = "Congragulation!\n" + playerFlag + "P Won the Game!";
    }
}
