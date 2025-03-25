using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TamQuoc
{
    public class ArrowMove : MonoBehaviour
    {
        public float moveTime = 5f;
        public void ArrowMovement(HeroModel target)
        {

            if (target == null) return;
            transform.DOMove(target.transform.position, moveTime)
                .SetEase(Ease.Linear)
                .OnStart(() => {})
                .SetDelay(0.2f)
            .OnComplete(() => { DestroyArrow(); });
        }
        private void DestroyArrow()
        {
            Destroy(gameObject);
        }
    }
}

