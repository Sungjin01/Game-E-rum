using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFile : MonoBehaviour
{
    public SelectFile Select;
    public SaveLoad Check;

    public void DeleteSaveFile()
    {
        PlayerPrefs.DeleteKey("Data" + Select.SaveNum + "Name");
        PlayerPrefs.DeleteKey("Data" + Select.SaveNum + "Weapon");
        PlayerPrefs.DeleteKey("Data" + Select.SaveNum + "clearStage");

        Check.CHk();
    }
}
