using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TamQuoc
{
    public class HeroShowUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textName;
        [SerializeField] private TextMeshProUGUI textAtk;
        [SerializeField] private TextMeshProUGUI textSpd;
        [SerializeField] private TextMeshProUGUI textHp;
        [SerializeField] private TextMeshProUGUI textPrice;

        public GameObject avaHero;
        public Transform charHero;
        public HeroDataCf HeroDataCf;

        public void SetData(HeroDataCf heroDataCf)
        {
            this.HeroDataCf = heroDataCf;
            if (this.avaHero != null) Destroy(this.avaHero);
            this.textName.text = heroDataCf.Name.ToString();
            this.textAtk.text = heroDataCf.Atk.ToString();
            this.textSpd.text = heroDataCf.Spd.ToString();
            this.textHp.text = heroDataCf.Hp.ToString();
            this.textPrice.text = heroDataCf.Price.ToString();

            GameObject avaPreb = HeroAsset.instance.GetHeroUIPrefabByIndex(heroDataCf.Index);
            if (avaPreb != null)
            {
                avaHero = avaPreb;
                avaHero.transform.SetParent(this.charHero);
                avaHero.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                avaHero.transform.localScale = Vector3.one;
            }
        }

        public void BuyHero()
        {
            //HeroDataManager.Instance.SpawnHeroOnPanel(HeroDataCf.Index);
            GameController.instance.SpawnHeroOnPanel(HeroDataCf.Index, HeroDataCf);
        }

    }
}

