using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TamQuoc
{
    public class OnOffBtn : MonoBehaviour
    {
        [SerializeField] private GameObject shop;
        public void OnOff()
        {
            shop.SetActive(!shop.activeSelf);
        }
    }
}


