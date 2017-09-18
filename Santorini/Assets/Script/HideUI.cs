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
        GameObject.Find("Title").SetActive(false);
        GameObject.Find("Phrase").SetActive(false);
        GameObject.Find("Button").SetActive(false);
        GameObject.Find("RuleAndHint").SetActive(false);
        GameControl gameControll;
        gameControll = GameObject.Find("GameController").GetComponent<GameControl>();
        endMsg.SetActive(true);
        int playerFlag = gameControll.selectedCharacter.GetComponent<CharacterClicked>().playerFlag;
        Text msg = GameObject.Find("EndMsg").GetComponent<Text>();
        msg.text = "Congragulation!\n" + playerFlag + "P Won the Game!";
    }
}
