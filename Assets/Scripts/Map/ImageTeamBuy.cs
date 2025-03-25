using System.Collections;
using System.Collections.Generic;
using TamQuoc;
using UnityEngine;

public class ImageTeamBuy : MonoBehaviour
{
    public int x;
    public int y;
    public HeroModel heroModel;
    public Transform heroPos;

    
//            if (!isEnemy)
//            {
//                if (Mathf.Abs(x - TargetHero.x) > DisMoveOX )
//                {
//                    for (int i = 0; i<GameController.instance.imageMaps.Count; i++)
//                    {
//                        if (GameController.instance.imageMaps[i].HeroModel == null && GameController.instance.imageMaps[i].x == (x + 1) && GameController.instance.imageMaps[i].y == y && Mathf.Abs(x - TargetHero.x) > DisMoveOX + 1)
//                        {
//                            NextPos = GameController.instance.imageMaps[i];
//                            NextPos.HeroModel = this;

//                            return NextPos;
//                        }
//                        else
//{
//    continue;
//}
//                    }
//                }
//                else
//{
//    if (y > TargetHero.y)
//    {
//        if (Mathf.Abs(y - TargetHero.y) > DisMoveOY)
//        {
//            for (int i = 0; i < GameController.instance.imageMaps.Count; i++)
//            {
//                if (GameController.instance.imageMaps[i].HeroModel == null && GameController.instance.imageMaps[i].x == x && GameController.instance.imageMaps[i].y == (y - 1) && Mathf.Abs(y - TargetHero.y) > DisMoveOY + 1)
//                {
//                    NextPos = GameController.instance.imageMaps[i];
//                    NextPos.HeroModel = this;
//                    return NextPos;
//                }
//                else
//                {
//                    continue;
//                }
//            }
//        }
//    }
//    else
//    {
//        if (Mathf.Abs(y - TargetHero.y) > DisMoveOY)
//        {
//            for (int i = 0; i < GameController.instance.imageMaps.Count; i++)
//            {
//                if (GameController.instance.imageMaps[i].HeroModel == null && GameController.instance.imageMaps[i].x == x && GameController.instance.imageMaps[i].y == (y + 1) && Mathf.Abs(y - TargetHero.y) > DisMoveOY + 1)
//                {
//                    NextPos = GameController.instance.imageMaps[i];
//                    NextPos.HeroModel = this;
//                    return NextPos;
//                }
//                else
//                {
//                    continue;
//                }
//            }
//        }
//    }

//}

//            }
//            else
//{
//    if (Mathf.Abs(x - TargetHero.x) > DisMoveOX)
//    {
//        for (int i = 0; i < GameController.instance.imageMaps.Count; i++)
//        {
//            if (GameController.instance.imageMaps[i].x == (x - 1) && GameController.instance.imageMaps[i].y == y)
//            {
//                NextPos = GameController.instance.imageMaps[i];
//                return NextPos;
//            }
//            else
//            {
//                continue;
//            }
//        }
//    }
//    else
//    {
//        if (y > TargetHero.y)
//        {
//            if (Mathf.Abs(y - TargetHero.y) > DisMoveOY)
//            {
//                for (int i = 0; i < GameController.instance.imageMaps.Count; i++)
//                {
//                    if (GameController.instance.imageMaps[i].x == x && GameController.instance.imageMaps[i].y == (y - 1))
//                    {
//                        NextPos = GameController.instance.imageMaps[i];
//                        return NextPos;
//                    }
//                    else
//                    {
//                        continue;
//                    }
//                }
//            }

//        }
//        else
//        {
//            if (Mathf.Abs(y - TargetHero.y) > DisMoveOY)
//            {
//                for (int i = 0; i < GameController.instance.imageMaps.Count; i++)
//                {
//                    if (GameController.instance.imageMaps[i].x == x && GameController.instance.imageMaps[i].y == (y + 1))
//                    {
//                        NextPos = GameController.instance.imageMaps[i];
//                        return NextPos;
//                    }
//                    else
//                    {
//                        continue;
//                    }
//                }
//            }

//        }
//    }
//}
//return NextPos;
}
