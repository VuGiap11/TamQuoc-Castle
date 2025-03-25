using System;
using System.Collections;
using System.Collections.Generic;
using TamQuoc;
using UnityEngine;

public class HeroShop : MonoBehaviour
{
    public HeroShowUI HeroShowPreb;
    public Transform Holder;
    public List<HeroShowUI> heroShowUIs;

    public void UpdateData()
    {
        HeroDataManager.Instance.ResetShop();
        this.heroShowUIs.Clear();
        foreach (Transform item in Holder)
        {
            item.gameObject.SetActive(false);
            if (item.TryGetComponent<HeroShowUI>(out HeroShowUI show)) { this.heroShowUIs.Add(show); }
        }
        for (int i = 0; i < HeroDataManager.Instance.IndexHerosOnShop.Count; i++)
        {
            int item = HeroDataManager.Instance.IndexHerosOnShop[i];
            HeroShowUI heroShow;
            try
            {
                heroShow = heroShowUIs[i];
            }
            catch (Exception e)
            {
                heroShow = Instantiate(HeroShowPreb);
                this.heroShowUIs.Add(heroShow);
            }
            heroShow.gameObject.SetActive(true);
            heroShow.SetData(HeroAsset.instance.HeroDataCfs.HeroDatas[item]);
            heroShow.transform.SetParent(this.Holder);
            heroShow.transform.localScale = Vector3.one;

        }
    }
}

