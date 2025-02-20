using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor
{
    public class AbilitiesViewProvider : MonoBehaviour
    {
        [SerializeField] private List<CooldownView> _emptyCooldownViews;

        public CooldownView GetFirstView()
        {
            CooldownView cooldownView = null;
            
            if (_emptyCooldownViews.Count > 0)
            {
                cooldownView = _emptyCooldownViews[0];
                //_emptyCooldownViews.RemoveAt(0);
            }
            
            return cooldownView;
        }

        public void GetView(CooldownView view)
        {
            //_activeCooldownViews.Add(view);
        }
    }
}