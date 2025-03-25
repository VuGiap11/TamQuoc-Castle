using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TamQuoc;
using UnityEngine;
using UnityEngine.UIElements;

namespace TamQuoc
{
    public class GameController : MonoBehaviour
    {
        public int rows = 8; // Số hàng
        public int columns = 16; // Số cột
        public float spacing = 1f; // Khoảng cách giữa các điểm
        public List<Vector3> gridPoints = new List<Vector3>();
        public List<ImageMap> imageMaps = new List<ImageMap>();
        public ImageMap pointPrefabs;
        public Transform SpawnPoint;
        public Transform pos01;
        public Transform pos02;

        public List<HeroModel> HeroModels;
        public List<HeroModel> Heros = new List<HeroModel>(); // list Heros;
        public List<HeroModel> Enemies = new List<HeroModel>(); // Enemy trong trận 
        
        public int MaxEnemy = 3;

        public bool isCombat;

        public int ChecKIndex;

        public static GameController instance;
        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            ChecKIndex = rows * columns;
            GeneratePoints();
            //SpawnBackGround();
            HeroDataManager.Instance.InitHeroTeams();
            //SpawnEnemy();
            SpawnEnemyNew();
        }
        //public int CheckNearPos(Vector2 pos)
        //{
        //    int index = 0;
        //    foreach (ImageMap hero in MapManager.instance.imageMaps)
        //    {
        //        if (hero.x > 2) //|| hero.HeroModel !=null)
        //        {
        //            index++;
        //            continue;
        //        }
        //        {
        //            if (hero.slotHero < 136)
        //            {
        //                if (pos.x < hero.transform.position.x + 0.5f && pos.x > hero.transform.position.x - 0.5f && pos.y < hero.transform.position.y + 0.5f && pos.y > hero.transform.position.y - 0.5f)
        //                {
        //                    Debug.Log(index);
        //                    return index;
        //                }
        //            }
        //            else
        //            {
        //                if (pos.x < hero.transform.position.x + 0.5f && pos.x > hero.transform.position.x - 0.5f && pos.y < hero.transform.position.y + .5f && pos.y > hero.transform.position.y - .5f)
        //                {
        //                    Debug.Log(index);
        //                    return index;
        //                }
        //            }
        //            index++;
        //        }
        //    }
        //    return -1;
        //}
        public int CheckNearPos(Vector2 pos)
        {
            int index = 0;
            foreach (ImageMap hero in imageMaps)
            {
                if (hero.x >= 3 && hero.slotHero <= ChecKIndex) //|| hero.HeroModel !=null)
                {
                    index++;
                    continue;
                }
                {
                    if (hero.slotHero < ChecKIndex)
                    {
                        if (pos.x < hero.transform.position.x + 0.5f && pos.x > hero.transform.position.x - 0.5f && pos.y < hero.transform.position.y + 0.5f && pos.y > hero.transform.position.y - 0.5f)
                        {
                            //Debug.Log(index);
                            return index;
                        }
                    }
                    else
                    {
                        if (pos.x < hero.transform.position.x + 0.5f && pos.x > hero.transform.position.x - 0.5f && pos.y < hero.transform.position.y + .5f && pos.y > hero.transform.position.y - .5f)
                        {
                            Debug.Log(index);
                            return index;
                        }
                    }
                    index++;
                }
            }
            return -1;
        }
        void GeneratePoints()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    float x = col * spacing;
                    float y = row * spacing;
                    Vector3 point = pos01.position + new Vector3(x, -y, 0f);
                    ImageMap imageMap;
                    imageMap = Instantiate(pointPrefabs);
                    imageMap.transform.position = point;
                    imageMap.x = col;
                    imageMap.y = row;
                    imageMap.slotHero = row * columns + col;
                    if (imageMap.TryGetComponent<ImageMap>(out ImageMap show))
                    {
                        this.imageMaps.Add(show);
                        show.ChangeBackGround();
                    }
                    imageMap.transform.SetParent(SpawnPoint.transform);
                    //gridPoints.Add(point);
                }
            }
            for (int col = 0; col < 15; col++)
            {
                float x = col * spacing;
                float y = 0 * spacing;
                Vector3 point = pos02.position + new Vector3(x, -y, 0f);
                ImageMap imageMap;
                imageMap = Instantiate(pointPrefabs);
                imageMap.transform.position = point;
                imageMap.x = 0;
                imageMap.y = col;
                imageMap.slotHero = ChecKIndex + col;
                if (imageMap.TryGetComponent<ImageMap>(out ImageMap show))
                {
                    this.imageMaps.Add(show);
                    show.ChangeBackGround();
                }
                imageMap.transform.SetParent(SpawnPoint.transform);
                //gridPoints.Add(point);
            }
        }
        public void swap(HeroModel hero, int oriPos, int targetPos)
        {
            Debug.Log("aaaaaa" + oriPos + "_" + targetPos);

            if (oriPos < 0)
            {
                imageMaps[targetPos].HeroModel = hero;
                hero.index = targetPos;
                hero.x = imageMaps[targetPos].x;
                hero.y = imageMaps[targetPos].y;
                hero.HeroData.slot = imageMaps[targetPos].slotHero;

                hero.transform.SetParent(imageMaps[targetPos].transform);
                hero.transform.localPosition = Vector2.zero;
                hero.SetUi();
            }
            else
            {
                if (imageMaps[targetPos].HeroModel == null)
                {
                    //// thêm vào lấy imagemap ban đầu (1 dong);
                    //hero.curentPos = imageMaps[targetPos];
                    imageMaps[targetPos].HeroModel = hero;
                    hero.index = targetPos;
                    hero.x = imageMaps[targetPos].x;
                    hero.y = imageMaps[targetPos].y;   
                    hero.HeroData.slot = imageMaps[targetPos].slotHero;

                    //hero.HeroMove.x = imageMaps[targetPos].x;
                    //hero.HeroMove.y = imageMaps[targetPos].y;

                    hero.transform.SetParent(imageMaps[targetPos].transform);
                    hero.transform.localPosition = Vector2.zero;
                    imageMaps[oriPos].HeroModel = null;
                    hero.SetUi();
                }
                else
                {
                    HeroModel temp = imageMaps[oriPos].HeroModel;
                    imageMaps[oriPos].HeroModel = imageMaps[targetPos].HeroModel;

                    imageMaps[targetPos].HeroModel = temp;
                    hero.index = targetPos;
                    hero.x = imageMaps[targetPos].x;
                    hero.y = imageMaps[targetPos].y;
                    hero.HeroData.slot = imageMaps[targetPos].slotHero;

                    //hero.HeroMove.x = imageMaps[targetPos].x;
                    //hero.HeroMove.y = imageMaps[targetPos].y;


                    hero.transform.SetParent(imageMaps[targetPos].transform);
                    hero.transform.localPosition = Vector2.zero;
                    hero.SetUi();

                    imageMaps[oriPos].HeroModel.index = oriPos;

                    imageMaps[oriPos].HeroModel.transform.SetParent(imageMaps[oriPos].transform);
                    imageMaps[oriPos].HeroModel.transform.localPosition = Vector2.zero;
                    imageMaps[oriPos].HeroModel.x = imageMaps[oriPos].x;
                    imageMaps[oriPos].HeroModel.y = imageMaps[oriPos].y;
                    imageMaps[oriPos].HeroModel.SetUi();
                    imageMaps[oriPos].HeroModel.HeroData.slot = imageMaps[oriPos].slotHero;

                }
                //hero.NextPosition();
                //hero.NextPositionNew();
            }
            // thêm vào lấy imagemap ban đầu (1 dong);
            hero.curentPos = imageMaps[targetPos];
            hero.CheckTargetModel();
        }

        public void CombatGame()
        {
            isCombat = true;
            foreach (HeroModel item in Heros)
            {
                //item.curentPos.HeroModel = null;
                //item.checkTarget();

                item.NextPositionNew();
            }
            foreach (HeroModel item in Enemies)
            {
                // item.checkTarget();
                item.NextPositionNew();
                item.curentPos.HeroModel = null;
                item.CheckTargetModel();
            }
        }

        //public void SpawnEnemy()
        //{

        //    List<ImageMap> EnemyPos = new List<ImageMap>();
        //    foreach (ImageMap spawnPoint in imageMaps)
        //    {
        //        if (spawnPoint.x >= 14 && spawnPoint.HeroModel == null)
        //        {
        //            EnemyPos.Add(spawnPoint);
        //        }
        //    }
        //    int index = UnityEngine.Random.Range(0, EnemyPos.Count);
        //    //Debug.Log(index);
        //    Debug.Log(HeroDataManager.Instance.EnemyTeams[0].Index);
        //    HeroModel hero = Instantiate(HeroModels[HeroDataManager.Instance.EnemyTeams[0].Index], EnemyPos[index].transform);
        //    Enemies.Add(hero);
        //    hero.index = EnemyPos[index].slotHero;
        //    hero.x = EnemyPos[index].x;
        //    hero.y = EnemyPos[index].y;
        //    hero.HeroDataCf = HeroDataManager.Instance.EnemyTeams[0];
        //    HeroData heroData = new HeroData(index);
        //    hero.HeroData = heroData;

        //    hero.HeroData.State = StatusState.HeroStrack;
        //    hero.transform.localScale = new Vector3(-6f, 6f, 6f);
        //    hero.isEnemy = true;
        //}

        public void SpawnEnemyNew()
        {
            List<ImageMap> EnemyPos = new List<ImageMap>();
            foreach (ImageMap spawnPoint in imageMaps)
            {
                if (spawnPoint.x >= 9 && spawnPoint.HeroModel == null)
                {
                    EnemyPos.Add(spawnPoint);
                }
            }
            if (EnemyPos.Count < MaxEnemy)
            {
                return;
            }
            List<int> availableIndices = new List<int>();
            for (int i = 0; i < EnemyPos.Count; i++)
            {
                availableIndices.Add(i);
            }
            for (int i = 0; i < MaxEnemy; i++)
            {
                int randomIndexPos = UnityEngine.Random.Range(0, availableIndices.Count);
                int spawnIndexPos = availableIndices[randomIndexPos];
                int randomEnemyIndex = UnityEngine.Random.Range(0, HeroDataManager.Instance.EnemyTeams.Count);
                HeroModel hero = Instantiate(HeroModels[HeroDataManager.Instance.EnemyTeams[randomEnemyIndex].Index], EnemyPos[spawnIndexPos].transform);
                hero.isEnemy = true;
                hero.x = EnemyPos[spawnIndexPos].x;
                hero.y = EnemyPos[spawnIndexPos].y;
                EnemyPos[spawnIndexPos].HeroModel = hero;
                //hero.CheckTargetModel();
                hero.NextPositionNew();

                hero.curentPos = EnemyPos[spawnIndexPos];

                //hero.NextPosition();
                //hero.NextPositionNew();
                Enemies.Add(hero);
                hero.index = EnemyPos[spawnIndexPos].slotHero;
                hero.x = EnemyPos[spawnIndexPos].x;
                hero.y = EnemyPos[spawnIndexPos].y;
                hero.HeroDataCf = HeroDataManager.Instance.EnemyTeams[0];
                HeroData heroData = new HeroData(spawnIndexPos);
                hero.HeroData = heroData;

                hero.HeroData.State = StatusState.HeroStrack;
                hero.transform.localScale = new Vector3(-6f, 6f, 6f);
                availableIndices.Remove(spawnIndexPos);
            }


        }


        public void SpawnHeroOnPanel(int index, HeroDataCf heroDataCf)
        {
            HeroData heroData = new HeroData(index);
            //this.HeroDatas.Add(heroData);
            HeroDataManager.Instance.IndexHerosOnShop.Remove(index);

            for (int i = 0; i < imageMaps.Count; i++)
            {
                if (imageMaps[i].slotHero < ChecKIndex || imageMaps[i].HeroModel != null)
                {
                    continue;
                }

                HeroModel hero = Instantiate(HeroModels[index], imageMaps[i].transform);
                Heros.Add(hero);
                hero.HeroData = heroData;
                hero.HeroData.slot = imageMaps[i].slotHero;
                hero.index = imageMaps[i].slotHero;
                hero.x = imageMaps[i].x;
                hero.x = imageMaps[i].y;
                hero.HeroDataCf = heroDataCf;
                imageMaps[i].HeroModel = hero;

                hero.SetUi();
                hero.UpdateStar();
                hero.transform.localScale = new Vector3(6f, 6f, 6f);

                List<HeroModel> heroDataCheck = new List<HeroModel>();
                for (int j = 0; j < Heros.Count; j++)
                {
                    if (Heros[j].HeroData.Index == index && Heros[j].HeroData.Star < 1) { heroDataCheck.Add(Heros[j]); }
                }
                if (heroDataCheck.Count >= 3)
                {
                    MergeHero(heroDataCheck);
                }

                return;
            }
        }
        public void MergeHero(List<HeroModel> heroDatas)
        {
            heroDatas[0].HeroData.Star += 1;
            //this.HeroDatas.Remove(heroDatas[2]);
            //this.HeroDatas.Remove(heroDatas[1]);
            Destroy(heroDatas[2].gameObject);
            Destroy(heroDatas[1].gameObject);
            this.Heros.Remove(heroDatas[2]);
            this.Heros.Remove(heroDatas[1]);
            for (int k = 0; k < imageMaps.Count; k++)
            {
                if (imageMaps[k].slotHero == heroDatas[1].HeroData.slot || imageMaps[k].slotHero == heroDatas[2].HeroData.slot)
                {
                    Debug.Log(heroDatas[1].HeroData.slot);
                    GameObject GO = imageMaps[k].HeroModel.gameObject;
                    imageMaps[k].HeroModel = null;
                    Destroy(GO);
                }
                else if (imageMaps[k].slotHero == heroDatas[0].HeroData.slot)
                {
                    imageMaps[k].HeroModel.UpdateStar();
                }
            }
            List<HeroModel> heroDataCheckStar = new List<HeroModel>();
            for (int j = 0; j < Heros.Count; j++)
            {
                if (Heros[j].HeroData.Index == heroDatas[0].HeroData.Index && Heros[j].HeroData.Star < 2) { heroDataCheckStar.Add(Heros[j]); }
            }
            if (heroDataCheckStar.Count >= 3)
            {
                MergeHero(heroDataCheckStar);
            }
        }
    }
}

