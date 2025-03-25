using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


namespace TamQuoc
{
    public class Draggabled : MonoBehaviour
    {
        [SerializeField] private bool isDragged = false;
        [SerializeField] private Vector2 mouseDragStartPosition;
        [SerializeField] private Vector2 startPos;
        private int index;

        public HeroModel HeroModel;

        public SkeletonAnimation skeletonAnimation;
        private void Start()
        {
            //startPos = transform.position;
        }
        private void OnMouseDown()
        {
            isDragged = true;
            mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPos = transform.position;
            IncreaseOrderInlayer(5);
        }

        private void OnMouseDrag()
        {
            if (isDragged)
            {
                //transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
                mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = mouseDragStartPosition;
            }
        }
        private void OnMouseUp()
        {
            isDragged = false;
            mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int pos = GameController.instance.CheckNearPos(mouseDragStartPosition);

            Debug.Log(pos);
            if (pos == -1)
            {
                transform.position = startPos;
                Debug.Log(pos);

            }
            else
            {
                
               GameController.instance.swap(this.HeroModel, HeroModel.index, pos);
                index = pos;
                IncreaseOrderInlayer(1);
            }

        }


        private void IncreaseOrderInlayer(int increaseAmount)
        {
            if (skeletonAnimation != null)
            {
                Renderer renderer = skeletonAnimation.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.sortingOrder = increaseAmount;
                }
                else
                {
                    Debug.LogWarning("Renderer component not found on the SkeletonAnimation.");
                }
            }
            else
            {
                Debug.LogWarning("SkeletonAnimation not assigned.");
            }
        }
    }
}

