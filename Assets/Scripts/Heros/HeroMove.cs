using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


namespace TamQuoc
{
    public class HeroMove : MonoBehaviour
    {
        public float SpeedHero = 2f;
        public int x;
        public int y;

        public int DisAttack = 3;

        public HeroModel HeroModel;
        public GameObject Target_1;

        public ImageMap Target;
        public HeroModel thisTargetHero;
        private void Update()
        {
            if (GameController.instance.isCombat == true && thisTargetHero == null)
            {
                MoveHero();
            }
        }

        public void Init()
        {
            x = HeroModel.x;
            y = HeroModel.y;
        }
        public void MoveHero()
        {
            if (this.HeroModel.HeroData.State == StatusState.HeroUi) return;
            HeroModel.heroSpine.State = AnimationState.Run;
            //HeroModel.heroSpine.Spin();
            CheckPosMove();
            Attack();

            //Vector2 newPosition = Vector2.MoveTowards(transform.position, Target_1.transform.position, SpeedHero * Time.deltaTime);
            Vector2 newPosition = Vector2.MoveTowards(transform.position, Target.transform.position, SpeedHero * Time.deltaTime);
            if (thisTargetHero != null) return;
            //x += 1;
            if (transform.position == Target.transform.position)
            {
                transform.SetParent(Target.transform);
                x = Target.x;
                y = Target.y;

                this.HeroModel.x = Target.x;
                this.HeroModel.y = Target.y;

                //HeroModel.heroSpine.State = AnimationState.Idle;
                //HeroModel.heroSpine.Spin();

            }
            //if (x >= 5)
            //{
            //    x += 0;
            //    y += 1;
            //}
            transform.position = newPosition;
        }

        private float Distance(Transform obj1, Transform obj2)
        {
            Vector3 position1 = obj1.position;
            Vector3 position2 = obj2.position;
            float distance = Vector3.Distance(position1, position2);
            return distance;

        }

        private Vector2 CheckPosMove()
        {
            if (HeroModel.isEnemy == false)
            {
                for (int i = 0; i < GameController.instance.imageMaps.Count; i++)
                {
                    if (GameController.instance.imageMaps[i].x == (x + 1) && GameController.instance.imageMaps[i].y == y)
                    {
                        //Target = new Vector2(GameController.instance.imageMaps[i].transform.position.x, GameController.instance.imageMaps[i].transform.position.y);
                        Target = GameController.instance.imageMaps[i];
                        GameController.instance.imageMaps[i].HeroModel = this.HeroModel;
                    }
                }
            }
            else
            {

                for (int i = 0; i < GameController.instance.imageMaps.Count; i++)
                {
                    if (GameController.instance.imageMaps[i].x == (x - 1) && GameController.instance.imageMaps[i].y == y
                        && GameController.instance.imageMaps[i].slotHero <= GameController.instance.ChecKIndex)
                    {
                        //Target = new Vector2(GameController.instance.imageMaps[i].transform.position.x, GameController.instance.imageMaps[i].transform.position.y);
                        Target = GameController.instance.imageMaps[i];
                        GameController.instance.imageMaps[i].HeroModel = this.HeroModel;
                    }
                }

            }
            return Target.transform.position;
        }

        public bool Attack()
        {
            if (this.thisTargetHero == null)
            {
                //float minDis = float.MaxValue;
                for (int i = 0; i < GameController.instance.imageMaps.Count; i++)
                {
                    if (GameController.instance.imageMaps[i].HeroModel != null && this.HeroModel.x < GameController.instance.imageMaps[i].x + DisAttack || this.HeroModel.x < GameController.instance.imageMaps[i].x - DisAttack
                        || this.HeroModel.y < GameController.instance.imageMaps[i].y + DisAttack || this.HeroModel.x < GameController.instance.imageMaps[i].y - DisAttack)
                    {
                        thisTargetHero = GameController.instance.imageMaps[i].HeroModel;
                        Debug.Log(thisTargetHero);
                    }
                }
                return false;
            }
            return true; 
        }
        //tìm target cho hero rồi di chuyển đển vị trí của hero theo từng ô
        private bool CheckTarget()
        {
            if (this.thisTargetHero == null)
            {

            }
            return true;
        }
    }
}
