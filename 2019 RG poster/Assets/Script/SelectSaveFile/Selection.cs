using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    public Text text;
    public int SaveSelection = 0; //선택된 세이브 파일 번호
    public int ProduceNum = 0; //생성중인 세이브 파일 번호

    private int SaveNum;

    private void Start()
    {
        SaveNum = PlayerPrefs.GetInt("SelectData", 0);
    }

    public void StartGame()
    {
        if (SaveSelection != 0)
        {
            SceneManager.LoadScene("1-"+(PlayerPrefs.GetInt("Data" + SaveSelection + "clearStage")+1));
        }
    }

    public void NextStage()
    {
        if(PlayerPrefs.GetInt("Data" + SaveNum + "clearStage") == 1)
        {
            SceneManager.LoadScene("1-2");
        }
        else
        {
            text.transform.position = new Vector3(950, 680, 0);
        }
    }
}
