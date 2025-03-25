using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TamQuoc
{
    [System.Serializable]
    public class HeroDataCfs
    {
        public List<HeroDataCf> HeroDatas;
    }

    public class HeroAsset : MonoBehaviour
    {
        public static HeroAsset instance;

        public HeroDataCfs HeroDataCfs;
        public TextAsset HeroDatatext;

        private void Awake()
        {
            if (instance == null)instance = this;
            LoadData();
        }
        // Start is called before the first frame update
        void Start()
        {

        }
        public void LoadData()
        {
            this.HeroDataCfs = JsonUtility.FromJson<HeroDataCfs>(this.HeroDatatext.text);
        }

        public GameObject GetHeroUIPrefabByIndex(int index)
        {
            GameObject avaPreb = Resources.Load<GameObject>("HeroUI/No" + index);
            if (avaPreb != null)
            {
                return Instantiate(avaPreb);
            }
            Debug.LogError("Not found:" + index);
            return null;
        }

        //public GameObject GetHeroAvatarUIPrefabByIndex(int index)
        //{
        //    GameObject avaPreb = Resources.Load<GameObject>("HeroAvatar/No" + index);
        //    if (avaPreb != null)
        //    {
        //        return Instantiate(avaPreb);
        //    }
        //    Debug.LogError("Not found:" + index);
        //    return null;
        //}
    }

}

