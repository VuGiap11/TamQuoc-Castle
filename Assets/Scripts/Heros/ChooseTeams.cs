using System.Collections;
using System.Collections.Generic;
using TamQuoc;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TamQuoc
{
    public class ChooseTeams : MonoBehaviour
    {
        public Country countryA;
        public void ChoiseCountry()
        {
            DataController.country = countryA;
            PlayerPrefs.SetInt(Contans.countryKey, (int)countryA);
            //HeroManager.Instance.InitHeroTeams();
            SceneManager.LoadScene("GameScene");
            Debug.Log(DataController.country);

        }
    }

}
