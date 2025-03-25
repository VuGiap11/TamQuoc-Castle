using System.Collections;
using System.Collections.Generic;
using TamQuoc;
using UnityEngine;

namespace TamQuoc
{
    public class ImageMap : MonoBehaviour
    {
        public GameObject[] imageBackGround;
        public int x;
        public int y;
        public int slotHero;
        public Transform HeroPos;

        public HeroModel HeroModel;

        public void ChangeBackGround()
        {
            //for (int i = 0; i < imageBackGround.Length; i++)
            //{
            //    imageBackGround[i].SetActive(false);
            //}
            //if (x < 3 && slotHero < GameController.instance.ChecKIndex)
            //{
            //    imageBackGround[0].SetActive(true);
            //    //Debug.Log("abc");
            //}
            //else if (x > 13 && slotHero < GameController.instance.ChecKIndex)
            //{
            //    imageBackGround[1].SetActive(true);
            //}
            //else if (x >=3  && x <= 13 && slotHero < GameController.instance.ChecKIndex)
            //{
            //    imageBackGround[2].SetActive(true);
            //}
            //else
            //{
            //    imageBackGround[0].SetActive(true);
            //}
            for (int i = 0; i < imageBackGround.Length; i++)
            {
                imageBackGround[i].SetActive(false);
            }
            if (slotHero < GameController.instance.ChecKIndex)
            {
                imageBackGround[1].SetActive(true);
                //Debug.Log("abc");
            }
            else
            {
                imageBackGround[0].SetActive(true);
            }
        }
    }
}
