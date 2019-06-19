using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public struct PlayerData //플레이어의 데이터
    {
        public string Name;
        public string Weapon;
        public int clearStage;
    }

    public int SaveFileNum; //이 스크립트를 넣은 세이브 파일의 번호


    public Text NameText;   //각각 플레이어의 정보를 출력한다.
    public Text PointText;
    public Image WeaponImage;

    public PlayerData Data; //플레이어 정보

    //public InputField IsName;   //입력창

    public Sprite Sword;
    public Sprite Spear;
    public Sprite Bow;

    public Sprite NullSprite;

    public Selection Select;

    void Start()
    {
        CHk();
    }

    public void CHk()
    {
        if (PlayerPrefs.HasKey("Data" + SaveFileNum + "Name"))   //해당 번호의 세이브 파일이 존재한다면
        {
            Data.Name = PlayerPrefs.GetString("Data" + SaveFileNum + "Name", null);
            Data.Weapon = PlayerPrefs.GetString("Data" + SaveFileNum + "Weapon", null);
            Data.clearStage = PlayerPrefs.GetInt("Data" + SaveFileNum + "clearStage", 0);
            PlayerPrefs.Save();

            NameText.text = Data.Name;
            PointText.text = "1-"+Data.clearStage.ToString("D");

            switch (Data.Weapon)
            {
                case "Sword":
                    WeaponImage.sprite = Sword;
                    break;
                case "Spear":
                    WeaponImage.sprite = Spear;
                    break;
                case "Bow":
                    WeaponImage.sprite = Bow;
                    break;
            }
        }
        else   //세이브 파일이 존재하지 않는다면
        {

            NameText.text = "데이터 없음";
            PointText.text = "데이터 없음";
            WeaponImage.sprite = NullSprite;
        }
    }

    public void SaveFileMaking()
    {
        PlayerPrefs.SetString("Data" + SaveFileNum + "Name", null);
        PlayerPrefs.SetString("Data" + SaveFileNum + "Weapon", null);
        PlayerPrefs.SetInt("Data" + SaveFileNum + "clearStage", 0);
        
        PlayerPrefs.SetInt("SelectData", SaveFileNum);
    }


}
