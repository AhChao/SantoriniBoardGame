using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUI : MonoBehaviour {

    public GameObject hintGroup;
    public void HideRuleAndHint()
    {        
        hintGroup.SetActive(!hintGroup.active);
    }
}
