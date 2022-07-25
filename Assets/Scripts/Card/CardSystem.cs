using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Waffle.CardSystems
{
    public interface ICardSystem
    {
        Card GetTopCard();
    }


    public class CardSystem : MonoBehaviour, ICardSystem
    {


        public Card GetTopCard()
        {
            // todo
            return new Card();
        }
    }
}

