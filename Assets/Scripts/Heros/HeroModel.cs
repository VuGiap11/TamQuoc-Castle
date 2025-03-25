using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace TamQuoc
{
    public class HeroModel : MonoBehaviour
    {
        public GameObject HpPanel;
        public int index;
        public int x;
        public int y;
        public List<GameObject> listStars;

        public float speedHero = 5;
        //public ImageMap Target;

        public HeroData HeroData;
        public HeroDataCf HeroDataCf;
        public HeroSpine heroSpine;
        public HeroModel TargetHero;

        public ImageMap NextPos;
        public ImageMap curentPos;
        public int DisTanceAtk = 2;
        public int DisMoveOX = 2;
        public int DisMoveOY = 2;

        public bool isEnemy = false;

        public HealthBar healthBar;
        public float CurrentHp;
        public bool isAttack = false;
        public bool isMoving = false;
        public bool isIdle = false;


        private void Start()
        {
            //NextPos.transform.position = transform.position;
            this.CurrentHp = this.HeroDataCf.Hp;
            //healthBar.UpdateHealthBar(HeroDataCf.Hp, CurrentHp);
        }
        private void Update()
        {
            CheckStack();
            if (!isEnemy)
            {
                if (CheckAtkHero())
                {
                    heroSpine.State = AnimationState.Attack;
                }
                else
                {
                    heroSpine.State = AnimationState.Idle;
                }
            }
            else
            {
                if (CheckAtkEnemy())
                {
                    heroSpine.State = AnimationState.Attack;
                }
                else if (CheckIdleEnemy())
                {
                    heroSpine.State = AnimationState.Idle;
                }
                else
                {
                    heroSpine.State = AnimationState.Run;
                }
            }

            if (GameController.instance.isCombat == true)
            {
                MoveHero();
            }
        }

        public void SetUi()
        {
            if (index < GameController.instance.ChecKIndex)
            {
                HeroData.State = StatusState.HeroStrack;
            }
            else
            {
                HeroData.State = StatusState.HeroUi;
            }
            StatusHero();
        }
        public void StatusHero()
        {
            ///Debug.Log("thay đổi Ui");
            switch (HeroData.State)
            {
                case StatusState.HeroUi:
                    HpPanel.SetActive(false);
                    break;
                case StatusState.HeroStrack:
                    HpPanel.SetActive(true);
                    break;
            }
        }
        public void UpdateStar()
        {
            for (int i = 0; i <= listStars.Count; i++)
            {
                if (i <= HeroData.Star)
                {
                    listStars[i].gameObject.SetActive(true);
                }
            }
        }

        public void MoveHero()
        {
            //if (this.HeroData.State == StatusState.HeroUi) return;
            ////if (TargetHero != null && Mathf.Abs(x - TargetHero.x) <= DisMoveOX && Mathf.Abs(y - TargetHero.y) <= DisMoveOY || x <= 0)
            ////{
            ////    heroSpine.State = AnimationState.Attack;
            ////    CheckStack();
            ////    NextPos = null;  
            ////    return;
            ////}
            //if (!isEnemy)
            //{
            //    return;
            //}
            if (!isEnemy)
            {
                return;
            }
            if (CheckAtkEnemy())
            {
                return;
            }
            heroSpine.State = AnimationState.Run;
            CheckStack();
            Vector2 newPosition = Vector2.MoveTowards(transform.position, NextPos.transform.position, speedHero * Time.deltaTime);
            if (transform.position == NextPos.transform.position)
            {
                transform.SetParent(NextPos.transform);
                x = NextPos.x;
                y = NextPos.y;
                NextPos.HeroModel = null;
                NextPositionNew();
                //CheckTargetModel();
            }
            transform.position = newPosition;
        }
        public bool CheckAtkHero()
        {
            if (TargetHero != null && Mathf.Abs(x - TargetHero.x) <= DisMoveOX && Mathf.Abs(y - TargetHero.y) <= DisMoveOY && y == TargetHero.y)
            {
                return true;
            }
            checkIdle();
            //return false;
            return !checkIdle();
        }
        public bool CheckAtkEnemy()
        {
            if (TargetHero != null && Mathf.Abs(x - TargetHero.x) <= DisMoveOX && Mathf.Abs(y - TargetHero.y) <= DisMoveOY && y == TargetHero.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkIdle()
        {
            return true;
        }
        public bool CheckIdleEnemy()
        {
            if (GameController.instance.isCombat == false)
            {
                return true;
            }
            return false;
        }

        public void CheckStack()
        {
            if (!isEnemy)
            {
                switch (heroSpine.State)
                {
                    case AnimationState.Idle:
                        if (!isIdle)
                        {
                            heroSpine.State = AnimationState.Idle;
                            heroSpine.SpineAnimation("stand", true);
                            isAttack = false;
                            isIdle = true;

                        }

                        break;

                    case AnimationState.Attack:
                        if (!isAttack)
                        {
                            heroSpine.State = AnimationState.Attack;
                            heroSpine.SpineAnimation("attack", true);
                            isAttack = true;
                            isIdle = false;

                        }

                        break;
                }
            }
            else
            {
                switch (heroSpine.State)
                {
                    case AnimationState.Idle:
                        if (!isIdle)
                        {
                            heroSpine.State = AnimationState.Idle;
                            heroSpine.SpineAnimation("stand", true);
                            isAttack = false;
                            isMoving = false;
                            isIdle = true;
                        }

                        break;

                    case AnimationState.Attack:
                        if (!isAttack)
                        {
                            heroSpine.State = AnimationState.Attack;
                            heroSpine.SpineAnimation("attack", true);
                            isAttack = true;
                            isIdle = false;
                            isMoving = false;
                        }

                        break;
                    case AnimationState.Run:
                        if (!isMoving)
                        {
                            heroSpine.State = AnimationState.Run;
                            heroSpine.SpineAnimation("run", true);
                            isAttack = false;
                            isMoving = true;
                            isIdle = false;
                        }
                        break;
                }

            }
        }

        public HeroModel CheckTargetModel()
        {
            if (this.TargetHero == null)
            {
                float minDis = float.MaxValue;
                var potentialTargets = isEnemy ? GameController.instance.Heros : GameController.instance.Enemies;

                foreach (HeroModel item in potentialTargets)
                {
                    if (item == null) return null;
                    // Bỏ qua các mục tiêu có slot lớn hơn hoặc bằng 136
                    if (item.HeroData.slot >= 72) continue;

                    // Kiểm tra tọa độ y
                    if (transform.position.y != item.transform.position.y) continue;

                    float distance = Distance(transform, item.transform);

                    if (distance < minDis)
                    {
                        this.TargetHero = item;
                        minDis = distance;
                        return this.TargetHero;
                    }
                }
                if (this.TargetHero == null)
                {
                    return null;
                }
            }
            return this.TargetHero;
        }

        public HeroModel checkTarget()
        {
            if (this.TargetHero == null)
            {
                float minDis = float.MaxValue;
                var a = GameController.instance.Enemies;
                if (isEnemy == true)
                {
                    a = GameController.instance.Heros;
                }
                else
                {
                    a = GameController.instance.Enemies;
                }
                foreach (HeroModel item in a)
                {
                    if (item.HeroData.slot >= 72) continue;
                    //if (item.curHpEnemy <= 0) continue;
                    float distance = Distance(transform, item.transform);
                    //Debug.Log(distance);
                    if (distance < minDis)
                    {
                        this.TargetHero = item;
                        //RotatePlayer(target.transform.position.x);
                        minDis = distance;
                        //Debug.Log("da thay doi target");
                        return this.TargetHero;
                    }
                }
                //return false;
            }
            return this.TargetHero;
            //return true;
        }
        private float Distance(Transform obj1, Transform obj2)
        {
            Vector3 position1 = obj1.position;
            Vector3 position2 = obj2.position;
            float distance = Vector3.Distance(position1, position2);
            return distance;

        }
        public ImageMap NextPositionNew()
        {
            if (isEnemy)
            {
                for (int i = 0; i < GameController.instance.imageMaps.Count; i++)
                {
                    if (GameController.instance.imageMaps[i].HeroModel == null && GameController.instance.imageMaps[i].x == (x - 1) && GameController.instance.imageMaps[i].y == y && GameController.instance.imageMaps[i].x >= 0)
                    {
                        NextPos = GameController.instance.imageMaps[i];
                        GameController.instance.imageMaps[i].HeroModel = this;
                        return NextPos;
                    }
                    else
                    {
                        continue;
                    }

                }
            }
            return NextPos;
        }
        public void AttackDamage()
        {
            TargetHero.GetDamage(HeroDataCf.Atk);
            Debug.Log(HeroDataCf.Atk);
        }

        public void GetDamage(int dmg)
        {
            this.CurrentHp -= dmg;
            this.healthBar.UpdateHealthBar(this.HeroDataCf.Hp, this.CurrentHp);
            if (this.CurrentHp <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            heroSpine.State = AnimationState.Dead;
            Destroy(gameObject);
        }
    }
}

