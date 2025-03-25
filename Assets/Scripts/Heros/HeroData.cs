using JetBrains.Annotations;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TamQuoc
{
    public enum Country
    {
        Thuc = 0,
        Ngo = 1,
        Nguy = 2
    }
    public enum StatusState
    {
        HeroUi,
        HeroStrack
    }

    public enum HeroType
    {
        tankHero = 0,
        arrowHero = 1
    }

    [System.Serializable]
    public class HeroDataCf
    {
        public int Index;
        public string Name;
        public int Atk;
        public int Spd;
        public float Hp;
        public Country Country;
        public HeroType HeroType;
        public int Price;
        public int Star;

    }
    [System.Serializable]
    public class HeroData
    {
        public int Index;
        public int Star;
        public StatusState State;
        public int slot;

        public HeroData(int index)
        {
            this.Index = index;
            this.Star = 0;
            this.State = StatusState.HeroUi;
        }

    }
}

