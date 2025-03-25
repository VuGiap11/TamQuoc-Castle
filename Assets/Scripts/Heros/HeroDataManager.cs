using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TamQuoc;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace TamQuoc
{
    public class HeroDataManager : MonoBehaviour
    {
        public List<int> IndexHerosOnShop;

        public static HeroDataManager Instance;
        public List<HeroModel> HeroModels;
        public List<HeroDataCf> HeroTeams = new List<HeroDataCf>(); // tất cả các tướng trong cùng 1 nước

        public List<HeroDataCf> EnemyTeams = new List<HeroDataCf>(); // những con quái có thể xuất hiện 
        //public List<HeroModel> HeroDatasOnPLay = new List<HeroModel>(); // những tướng trong trận;
        //public List<HeroData> HeroDatas = new List<HeroData>(); // những tướng có thể được chọn để thi đấu
        //public List<HeroModel> Enemies = new List<HeroModel>(); // tất cả enemy trông trận
        private void Awake()
        {
            Instance = this;
        }
        public void Start()
        {
            //InitHeroTeams();
            this.ResetShop();
            //SpawnEnemy();
        }

        //public void ResetShop()
        //{
        //    this.IndexHerosOnShop.Clear();
        //    //List<int> usedIndexes = new List<int>();
        //    for (int i = 0; i < 3; i++)
        //    {
        //        int index;
        //        //do
        //        //{
        //        //    index = HeroAsset.instance.HeroDataCfs.HeroDatas[UnityEngine.Random.Range(0, HeroAsset.instance.HeroDataCfs.HeroDatas.Count)].Index;
        //        //    //index = HeroAsset.instance.HeroDataCfs.HeroDatas[UnityEngine.Random.Range(0, 3)].Index;
        //        //    //IndexOfHeroData(index);
        //        //} while (usedIndexes.Contains(index));
        //        index = HeroTeams[UnityEngine.Random.Range(0, HeroTeams.Count)].Index;
        //        this.IndexHerosOnShop.Add(index);
        //        HeroData heroData = new HeroData(index);
        //        this.HeroDatas.Add(heroData);
        //        //usedIndexes.Add(index);
        //        List<HeroData> heroDataCheck = new List<HeroData>();
        //        for (int j = 0; j < HeroDatas.Count; j++)
        //        {
        //            if (HeroDatas[j].Index == index) { heroDataCheck.Add(HeroDatas[j]); }
        //            Debug.Log(HeroDatas[j].Index);
        //        }
        //        //if (heroDataCheck.Count >= 3) MergeHero(heroDataCheck);
        //    }
        //}
        //[ContextMenu("ResetShop")] // cách 1
        //public void ResetShop()
        //{
        //    this.IndexHerosOnShop.Clear();
        //    for (int i = 0; i < 3; i++)
        //    {
        //        int index;
        //        index = HeroTeams[UnityEngine.Random.Range(0, HeroTeams.Count)].Index;
        //        this.IndexHerosOnShop.Add(index);

        //    }
        //}

        [ContextMenu("ResetShop")]
        public void ResetShop()
        {
            this.IndexHerosOnShop.Clear();
            for (int i = 0; i < 3; i++)
            {
                int index;
                index = HeroTeams[UnityEngine.Random.Range(0, HeroTeams.Count)].Index;
                this.IndexHerosOnShop.Add(index);
            }
        }    
        public void InitHeroTeams()
        {
            HeroTeams.Clear();
            EnemyTeams.Clear();
            for (int i = 0; i < HeroAsset.instance.HeroDataCfs.HeroDatas.Count; i++)
            {
                //Debug.Log(HeroAssets.instance.HeroDataCfs.HeroDatas[i].Index);
                if (HeroAsset.instance.HeroDataCfs.HeroDatas[i].Country == DataController.country)
                {
                    HeroTeams.Add(HeroAsset.instance.HeroDataCfs.HeroDatas[i]);
                }
                else
                {
                    EnemyTeams.Add(HeroAsset.instance.HeroDataCfs.HeroDatas[i]);
                }
            }
        }
        //public void MergeHero(List<HeroModel> HeroModel)
        //{
        //    Debug.Log(JsonUtility.ToJson(HeroModel[0]));
        //    HeroModel[0].starIndex += 1;
        //    //Debug.Log(JsonUtility.ToJson(heroDatas[0]));
        //    HeroBuyed.Remove(HeroModel[2]);
        //    HeroBuyed.Remove(HeroModel[1]);
        //}

        public HeroDataCf GetHeroDataCfByIndex(int index)
        {
            Debug.Log(index);
            return this.HeroTeams.Find(a => { return a.Index == index; });
        }
        //public void swap(HeroModel hero, int oriPos, int targetPos)
        //{
        //    Debug.Log("aaaaaa" + oriPos + "_" + targetPos);

        //    if (oriPos < 0)
        //    {
        //        MapManager.instance.imageMaps[targetPos].HeroModel = hero;
        //        hero.index = targetPos;

        //        hero.transform.SetParent(MapManager.instance.imageMaps[targetPos].transform);
        //        hero.transform.localPosition = Vector2.zero;
        //    }
        //    else
        //    {
        //        if (MapManager.instance.imageMaps[targetPos].HeroModel == null)
        //        {
        //            MapManager.instance.imageMaps[targetPos].HeroModel = hero;
        //            hero.index = targetPos;

        //            hero.transform.SetParent(MapManager.instance.imageMaps[targetPos].transform);
        //            hero.transform.localPosition = Vector2.zero;
        //            MapManager.instance.imageMaps[oriPos].HeroModel = null;
        //        }
        //        else
        //        {
        //            HeroModel temp = MapManager.instance.imageMaps[oriPos].HeroModel;
        //            MapManager.instance.imageMaps[oriPos].HeroModel = MapManager.instance.imageMaps[targetPos].HeroModel;

        //            MapManager.instance.imageMaps[targetPos].HeroModel = temp;
        //            hero.index = targetPos;
        //            MapManager.instance.imageMaps[oriPos].HeroModel.index = oriPos;
        //            hero.transform.SetParent(MapManager.instance.imageMaps[targetPos].transform);
        //            hero.transform.localPosition = Vector2.zero;
        //            //MapManager.instance.imageMaps[oriPos].HeroModel = null;

        //            hero.index = targetPos;
        //            MapManager.instance.imageMaps[oriPos].HeroModel.index = oriPos;
        //            MapManager.instance.imageMaps[oriPos].HeroModel.transform.SetParent(MapManager.instance.imageMaps[oriPos].transform);
        //            MapManager.instance.imageMaps[oriPos].HeroModel.transform.localPosition = Vector2.zero;
        //            //MapManager.instance.imageMaps[oriPos].HeroModel = null;

        //        }
        //    }
        //}
        //public void swap(HeroModel hero, int oriPos, int targetPos)
        //{
        //    Debug.Log("aaaaaa" + oriPos + "_" + targetPos);

        //    if (oriPos < 0)
        //    {
        //        GameController.instance.imageMaps[targetPos].HeroModel = hero;
        //        hero.index = targetPos;
        //        hero.x = GameController.instance.imageMaps[targetPos].x;
        //        hero.y = GameController.instance.imageMaps[targetPos].y;

        //        hero.transform.SetParent(GameController.instance.imageMaps[targetPos].transform);
        //        hero.transform.localPosition = Vector2.zero;
        //    }
        //    else
        //    {
        //        if (GameController.instance.imageMaps[targetPos].HeroModel == null)
        //        {
        //            GameController.instance.imageMaps[targetPos].HeroModel = hero;
        //            hero.index = targetPos;
        //            hero.x = GameController.instance.imageMaps[targetPos].x;
        //            hero.y = GameController.instance.imageMaps[targetPos].y;

        //            hero.transform.SetParent(GameController.instance.imageMaps[targetPos].transform);
        //            hero.transform.localPosition = Vector2.zero;
        //            GameController.instance.imageMaps[oriPos].HeroModel = null;
        //        }
        //        else
        //        {
        //            HeroModel temp = GameController.instance.imageMaps[oriPos].HeroModel;
        //            GameController.instance.imageMaps[oriPos].HeroModel = GameController.instance.imageMaps[targetPos].HeroModel;

        //            GameController.instance.imageMaps[targetPos].HeroModel = temp;
        //            hero.index = targetPos;
        //            hero.x = GameController.instance.imageMaps[targetPos].HeroModel.x;
        //            hero.y = GameController.instance.imageMaps[targetPos].HeroModel.y;

        //            hero.transform.SetParent(GameController.instance.imageMaps[targetPos].transform);
        //            hero.transform.localPosition = Vector2.zero;

        //            GameController.instance.imageMaps[oriPos].HeroModel.index = oriPos;

        //            GameController.instance.imageMaps[oriPos].HeroModel.transform.SetParent(GameController.instance.imageMaps[oriPos].transform);
        //            GameController.instance.imageMaps[oriPos].HeroModel.transform.localPosition = Vector2.zero;
        //            GameController.instance.imageMaps[oriPos].HeroModel.x = GameController.instance.imageMaps[oriPos].HeroModel.x;
        //            GameController.instance.imageMaps[oriPos].HeroModel.y = GameController.instance.imageMaps[oriPos].HeroModel.y;
        //            //MapManager.instance.imageMaps[oriPos].HeroModel = null;

        //        }
        //    }
        //}
        //public void MergeHero(List<HeroData> heroDatas)
        //{
        //    //Debug.Log(JsonUtility.ToJson(heroDatas[0]));
        //    heroDatas[0].Star += 1;
        //    //Debug.Log(JsonUtility.ToJson(heroDatas[0]));
        //    this.HeroDatas.Remove(heroDatas[2]);
        //    this.HeroDatas.Remove(heroDatas[1]);

        //    for (int k = 0; k < GameController.instance.imageMaps.Count; k++)
        //    {
        //        //Debug.Log("a");
        //        if (GameController.instance.imageMaps[k].slotHero == heroDatas[1].slot || GameController.instance.imageMaps[k].slotHero == heroDatas[2].slot)
        //        {
        //            Debug.Log(heroDatas[1].slot);
        //            GameObject GO = GameController.instance.imageMaps[k].HeroModel.gameObject;
        //            GameController.instance.imageMaps[k].HeroModel = null;
        //            Destroy(GO);
        //        }
        //        else if (GameController.instance.imageMaps[k].slotHero == heroDatas[0].slot)
        //        {
        //            GameController.instance.imageMaps[k].HeroModel.UpdateStar();
        //        }
        //    }
        //    List<HeroData> heroDataCheckStar = new List<HeroData>();
        //    for (int j = 0; j < HeroDatas.Count; j++)
        //    {
        //        if (HeroDatas[j].Index == heroDatas[0].Index && HeroDatas[j].Star < 2) { heroDataCheckStar.Add(HeroDatas[j]); }
        //    }
        //    if (heroDataCheckStar.Count >= 3)
        //    {
        //        MergeHero(heroDataCheckStar);
        //    }
        //}
        //public void SpawnHeroOnPanel(int index) // cách 1
        //{
        //    HeroData heroData = new HeroData(index);
        //    this.HeroDatas.Add(heroData);
        //    this.IndexHerosOnShop.Remove(index);

        //    List<HeroData> heroDataCheck = new List<HeroData>();
        //    for (int j = 0; j < HeroDatas.Count; j++)
        //    {
        //        if (HeroDatas[j].Index == index && HeroDatas[j].Star <2) { heroDataCheck.Add(HeroDatas[j]); }
        //        //Debug.Log(HeroDatas[j].Index);
        //    }
        //    if (heroDataCheck.Count >= 3)
        //    {
        //        MergeHero(heroDataCheck);
        //        for (int k = 0; k < TeamsBuyManager.instance.imageMaps.Count; k++)
        //        {
        //            if (TeamsBuyManager.instance.imageMaps[k].heroModel != null)
        //            {
        //                //Destroy(TeamsBuyManager.instance.imageMaps[k].heroModel.gameObject);
        //                GameObject GO = TeamsBuyManager.instance.imageMaps[k].heroModel.gameObject;
        //                TeamsBuyManager.instance.imageMaps[k].heroModel = null;
        //                Destroy(GO);
        //            }
        //            //TeamsBuyManager.instance.imageMaps[i].heroModel = null;
        //        }
        //    }

        //    for (int i = 0; i < this.HeroDatas.Count; i++)
        //    {
        //        Debug.Log("a");
        //        Debug.Log(this.HeroDatas.Count);
        //        if (TeamsBuyManager.instance.imageMaps[i].heroModel != null)
        //        {
        //            continue;
        //        }
        //        HeroModel hero = Instantiate(HeroModels[HeroDatas[i].Index], TeamsBuyManager.instance.imageMaps[i].heroPos.transform);
        //        hero.HeroData = HeroDatas[i];
        //        TeamsBuyManager.instance.imageMaps[i].heroModel = hero;

        //        hero.StatusHero();
        //        hero.UpdateStar();
        //        hero.transform.localScale = new Vector3(6f, 6f, 6f);


        //    }

        //}

        //public void SpawnHeroOnPanel(int index)
        //{
        //    HeroData heroData = new HeroData(index);
        //    this.HeroDatas.Add(heroData);
        //    this.IndexHerosOnShop.Remove(index);

        //    for (int i = 0; i < GameController.instance.imageMaps.Count; i++)
        //    {
        //        if (GameController.instance.imageMaps[i].slotHero < GameController.instance.ChecKIndex || GameController.instance.imageMaps[i].HeroModel != null)
        //        {
        //            continue;
        //        }

        //        HeroModel hero = Instantiate(HeroModels[index], GameController.instance.imageMaps[i].HeroPos.transform);
        //        hero.HeroData = heroData;
        //        hero.HeroData.slot = GameController.instance.imageMaps[i].slotHero;
        //        hero.index = GameController.instance.imageMaps[i].slotHero;
        //        hero.x = GameController.instance.imageMaps[i].x;
        //        hero.x = GameController.instance.imageMaps[i].y;
        //        GameController.instance.imageMaps[i].HeroModel = hero;

        //        hero.SetUi();
        //        hero.UpdateStar();
        //        hero.transform.localScale = new Vector3(6f, 6f, 6f);

        //        List<HeroData> heroDataCheck = new List<HeroData>();
        //        for (int j = 0; j < HeroDatas.Count; j++)
        //        {
        //            if (HeroDatas[j].Index == index && HeroDatas[j].Star < 1) { heroDataCheck.Add(HeroDatas[j]); }
        //        }
        //        if (heroDataCheck.Count >= 3)
        //        {
        //            MergeHero(heroDataCheck);
        //        }

        //        return;
        //    }

        //}

        //public void SpawnEnemy()
        //{
        //    List<ImageMap> EnemyPos = new List<ImageMap>();
        //    foreach (ImageMap spawnPoint in GameController.instance.imageMaps)
        //    {
        //        if (spawnPoint.x >= 14 && spawnPoint.HeroModel == null)
        //        {
        //            EnemyPos.Add(spawnPoint);
        //        }
        //    }
        //    int index = UnityEngine.Random.Range(0, EnemyPos.Count);
        //    //HeroModel hero = Instantiate(HeroModels[EnemyTeams[0].Index], GameController.instance.imageMaps[i].HeroPos.transform);
        //    HeroModel hero = Instantiate(HeroModels[EnemyTeams[0].Index], EnemyPos[index].transform);
        //    Enemies.Add(hero);
        //    hero.index = EnemyPos[index].slotHero;
        //    hero.x = EnemyPos[index].x;
        //    hero.y = EnemyPos[index].y;

        //    hero.HeroData.State = StatusState.HeroStrack;
        //    hero.transform.localScale = new Vector3(-6f, 6f, 6f);
        //    hero.isEnemy = true;
        //}
    }
}

