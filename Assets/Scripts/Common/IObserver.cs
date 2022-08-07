using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waffle.Common
{
    public interface IObserver<T>
    {
        public void Notify(T subject);
    }
}

