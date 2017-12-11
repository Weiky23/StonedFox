using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StonedFox
{
    public abstract class ElementController : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public virtual void OnTop()
        {
            transform.SetAsLastSibling();
        }

        public virtual void ToBack()
        {
            transform.SetAsFirstSibling();
        }
    }
}
