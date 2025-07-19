using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class LasersContainer : MonoBehaviour
    {
        [SerializeField] private List<Transform> _container;

        public List<Transform> Container => _container;
    }
}