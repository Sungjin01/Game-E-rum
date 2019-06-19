using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MakeFile : MonoBehaviour
{
    public InputField IsName;   //입력창

    public int Select;

    public int WeaponNum = 0;

    
    void Start()
    {
        Select = PlayerPrefs.GetInt("SelectData", 0);
        PlayerPrefs.Save();
    }
    

    public void CheckBeforeMake()
    {
        if (IsName.text != "" && WeaponNum != 0)
        {
            /*
            PlayerPrefs.SetString("DataName", );
            PlayerPrefs.SetInt("DataWeapon", WeaponNum);
            */

            PlayerPrefs.SetString("Data" + Select + "Name", IsName.text);

            switch (WeaponNum)
            {
                case 1:
                    PlayerPrefs.SetString("Data" + Select + "Weapon", "Sword");
                    break;
                case 2:
                    PlayerPrefs.SetString("Data" + Select + "Weapon", "Spear");
                    break;
                case 3:
                    PlayerPrefs.SetString("Data" + Select + "Weapon", "Bow");
                    break;
            }

            SceneManager.LoadScene("SelectSaveFile");

        }
    } 
}
