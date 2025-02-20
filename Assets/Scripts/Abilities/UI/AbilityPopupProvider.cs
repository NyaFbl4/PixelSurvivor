using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelSurvivor.UI
{
    public class AbilityPopupProvider : MonoBehaviour
    {
        [SerializeField] private List<CooldownObserver> _cooldownObservers;

        public CooldownObserver GetAbilityPopup()
        {
            foreach (var observer in _cooldownObservers)
            {
                var obs = observer.GetComponentInChildren<CooldownObserver>();

                var ability = obs.ability;
                
                if (ability == null)
                {
                    return observer;
                }
            }

            return null;
        }
    }
}