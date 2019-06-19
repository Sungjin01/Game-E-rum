using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFile : MonoBehaviour
{
    public int SaveNum; //세이브 파일 번호
    public Selection Select;
    public SaveLoad Saveload;

    public void SelectSave()
    {
        if (PlayerPrefs.HasKey("Data" + Saveload.SaveFileNum + "Name")) {
            Select.SaveSelection = SaveNum;
        }
    }

    void Update()
    {
        if (Select.SaveSelection == SaveNum )
        {
            transform.position = new Vector3(transform.position.x, 540, transform.position.z);
            PlayerPrefs.SetInt("SelectData", Saveload.SaveFileNum);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 460, transform.position.z);
        }
    }
}
