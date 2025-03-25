using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TamQuoc
{
    public static class DataController
    {   
        public static Country country
        {
            get
            {
                return (Country)PlayerPrefs.GetInt(Contans.countryKey, 0);
            }
            set
            {
                PlayerPrefs.SetInt(Contans.countryKey, (int)value);
            }
        }
    }
}