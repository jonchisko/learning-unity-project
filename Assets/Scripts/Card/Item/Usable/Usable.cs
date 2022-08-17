using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CharacterSystems;

namespace Waffle.CardSystems.Item.Usable
{
    public abstract class Usable
    {
        protected PlayerSystem playerSystem;
        protected UsableInfo usableInfo;

        public Usable(PlayerSystem playerSystem, UsableInfo usableInfo)
        {
            this.playerSystem = playerSystem;
            this.usableInfo = usableInfo;
        }

        public abstract void Use();

        public UsableInfo GetUsableInfo()
        {
            return usableInfo;
        }
    }
}

