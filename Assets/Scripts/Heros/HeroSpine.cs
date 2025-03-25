using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TamQuoc
{
    public enum AnimationState
    {
        Idle,
        Run,
        Attack,
        Hurt, 
        Dead
    }

    public class HeroSpine : MonoBehaviour
    {
        public HeroModel HeroModel;
        public SkeletonAnimation skeletonAnimation;
        public AnimationState State = AnimationState.Idle;
        public bool isRun = false;
        public bool isStand = false;
        public bool isAtrack = false;
        // Start is called before the first frame update
        void Start()
        {
            if (skeletonAnimation != null)
            {

                skeletonAnimation.AnimationState.Event += HandleAnimationEvent;
            }
            else
            {
                skeletonAnimation = GetComponent<SkeletonAnimation>();
            }
        }

        private void HandleAnimationEvent(TrackEntry trackEntry, Spine.Event e)
        {
            if (e.Data.Name.Equals("end") && State == AnimationState.Attack)
            {
                //SpineAnimation("stand", true);
                State = AnimationState.Idle;
            }
            else if (e.Data.Name.Equals("attack"))
            {
                Debug.Log("attackdamage");
                HeroModel.AttackDamage();
            }
        }
        //public void Spin()
        //{
        //    switch (State)
        //    {
        //        case AnimationState.Idle:
        //            if (!isStand)
        //            {
        //                isStand = true;
        //                isRun = false;
        //                isAtrack = false;
        //                SpineAnimation("stand", true);
        //            }
        //            break;
        //        case AnimationState.Run:
        //            if (!isRun)
        //            {
        //                SpineAnimation("run", true);
        //                //Debug.Log("a");
        //                isRun = true;
        //                isStand = false;
        //                isAtrack = false;
        //            }
        //            break;
        //        case AnimationState.Attack:
        //            if (!isAtrack)
        //            {
        //                isAtrack= true;
        //                //isRun = false;
        //                isStand= false; 
        //                SpineAnimation("attack", true);
        //                //Debug.Log("attack");
        //            }

        //            break;
        //        case AnimationState.Hurt:
        //            isRun = false;
        //            SpineAnimation("hurt", false);
        //            break;

        //        default:
        //            break;

        //    }
        //}
        public void SpineAnimation(string animationName, bool loop = false)
        {
            if (skeletonAnimation == null) return;
            skeletonAnimation.AnimationState.SetAnimation(0, animationName, loop).TimeScale = 1;
        }
    }
}

