using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundClicked : MonoBehaviour {
    GameControl gameControll;
    GameObject selectedCharacter;
    GameObject house;
    public float angle;
    int x;//this value is divide by 4
    int z;//this value is divide by 4
    float[] yPosition = {0.8f,1.8f,2.8f,3.8f,4.8f};
    // Use this for initialization
    void Start () {
        gameControll = GameObject.Find("GameController").GetComponent<GameControl>();
        x = (int)this.transform.position.x / 4;
        z = (int)this.transform.position.z / 4;
    }
    void OnMouseDown()
    {
        selectedCharacter = gameControll.selectedCharacter;
        // this object was clicked - do something
        var groundStatus = gameControll.groundStatus;
        if(groundStatus == GameControl.GroundStatus.GameBegin)
        {
            //GameObject.Find("GameController").GetComponent<GameControl>().groundX = this.transform.position.x;
            //GameObject.Find("GameController").GetComponent<GameControl>().groundZ = this.transform.position.z;
            //GameObject.Find("GameController").GetComponent<GameControl>().groundNeedToClick = 0;            
            if (gameControll.playerMap[x,z] == 0 )
                gameControll.setPlayerPosition(this.transform.position.x , this.transform.position.z);
        }
        if(groundStatus == GameControl.GroundStatus.AMoveSelect ||
           groundStatus == GameControl.GroundStatus.BMoveSelect)//move player A / B
        {
            if(gameControll.Lighting==1)
            {
                if(Mathf.Abs(selectedCharacter.transform.position.x-transform.position.x)<= 4)
                {
                    if(Mathf.Abs(selectedCharacter.transform.position.z - transform.position.z) <= 4)
                    {
                        if (gameControll.playerMap[x, z] == 0)//the position player will go no player
                        {
                            int selectPlayerX = (int)selectedCharacter.transform.position.x / 4;
                            int selectPlayerZ = (int)selectedCharacter.transform.position.z / 4;
                            if (gameControll.groundMap[selectPlayerX, selectPlayerZ]+1>=gameControll.groundMap[x,z])//the position player can go because no too high
                            {
                                AudioSource tempAS = gameControll.GetComponent<AudioSource>();
                                tempAS.clip = gameControll.voiceClimb;
                                tempAS.Play();
                                //move character, move light , set map status , change global status   
                                float nowYPosition = yPosition[gameControll.groundMap[x, z]];
                                selectedCharacter.transform.LookAt(new Vector3(this.transform.position.x, selectedCharacter.transform.position.y, this.transform.position.z));
                                selectedCharacter.transform.position = new Vector3(this.transform.position.x, nowYPosition, this.transform.position.z);
                                gameControll.lastLightRec.transform.position = new Vector3(this.transform.position.x, nowYPosition, this.transform.position.z);
                                gameControll.playerMap[selectPlayerX, selectPlayerZ] = 0;
                                gameControll.playerMap[x, z] = 1;
                                if( gameControll.groundMap[x,z] == 3 )
                                {
                                    GameObject.Find("GameController").GetComponent<HideUI>().ShowEngMsg();
                                    gameControll.groundStatus = GameControl.GroundStatus.EndPhrase;
                                    gameControll.phraseMsg.text = "";
                                }
                                else if (groundStatus == GameControl.GroundStatus.AMoveSelect)
                                {
                                    gameControll.groundStatus = GameControl.GroundStatus.ABuildSelect;
                                    gameControll.phraseMsg.text = "Phrase : A Build Turn";
                                }
                                else if (groundStatus == GameControl.GroundStatus.BMoveSelect)
                                {
                                    gameControll.groundStatus = GameControl.GroundStatus.BBuildSelect;
                                    gameControll.phraseMsg.text = "Phrase : B Build Turn";
                                }                                
                            }
                        }
                    }
                }
            }
        }
        if(groundStatus == GameControl.GroundStatus.ABuildSelect||
           groundStatus == GameControl.GroundStatus.BBuildSelect)//the move player build
        {
            if (Mathf.Abs(selectedCharacter.transform.position.x - transform.position.x) <= 4)
            {
                if (Mathf.Abs(selectedCharacter.transform.position.z - transform.position.z) <= 4)
                {
                    if (gameControll.playerMap[x, z] != 1)
                    {
                        if (gameControll.groundMap[x, z] != 4)
                        {
                            selectedCharacter.transform.LookAt(new Vector3(this.transform.position.x, selectedCharacter.transform.position.y, this.transform.position.z));
                            AudioSource tempAS = gameControll.GetComponent<AudioSource>();
                            tempAS.clip = gameControll.voiceBuild;
                            tempAS.Play();
                            if (gameControll.groundMap[x, z] == 0)
                            {
                                house = Instantiate(gameControll.housePrefab, new Vector3(x, 0.3f, z) * gameControll.groundDistance, Quaternion.identity);
                                house.transform.Find("WuDin").gameObject.SetActive(false);
                                house.transform.Find("Floor3").gameObject.SetActive(false);
                                house.transform.Find("Floor2").gameObject.SetActive(false);
                                house.transform.Find("Floor1").gameObject.SetActive(true);
                            }
                            else if (gameControll.groundMap[x, z] == 1) house.transform.Find("Floor2").gameObject.SetActive(true);
                            else if (gameControll.groundMap[x, z] == 2) house.transform.Find("Floor3").gameObject.SetActive(true);
                            else if (gameControll.groundMap[x, z] == 3) house.transform.Find("WuDin").gameObject.SetActive(true);
                            gameControll.groundMap[x, z]++;
                            if (groundStatus == GameControl.GroundStatus.ABuildSelect)
                            {
                                gameControll.groundStatus = GameControl.GroundStatus.BMoveSelect;
                                gameControll.phraseMsg.text = "Phrase : B Move Turn";
                            }
                            else if (groundStatus == GameControl.GroundStatus.BBuildSelect)
                            {
                                gameControll.groundStatus = GameControl.GroundStatus.AMoveSelect;
                                gameControll.phraseMsg.text = "Phrase : A Move Turn";
                            }
                            DestroyObject(GameObject.Find("GameController").GetComponent<GameControl>().lastLightRec);
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
