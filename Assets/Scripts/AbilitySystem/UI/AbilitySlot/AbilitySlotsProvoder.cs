using System.Collections.Generic;
using PixelSurvivor.NewAbilitySystem;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.UI
{
    public class AbilitySlotsProvoder : MonoBehaviour
    {
        [SerializeField] private RectTransform _widgetContainer;
        [SerializeField] private AbilitySlotPopup _slotWidget;

        public void TakeNewAbilities(List<PlayerAbility> abilities)
        {
            foreach (var ability in abilities)
            {
                AbilitySlotPopup widget = Instantiate(_slotWidget, _widgetContainer);
                widget.SetDisplayImage(ability.IconImage);

                ability.EventChangeCooldownTimer += widget.SetCooldown;
            }
        }

        public void TakeNewAbility(PlayerAbility newAbility)
        {
            AbilitySlotPopup widget = Instantiate(_slotWidget, _widgetContainer);
            widget.SetDisplayImage(newAbility.IconImage);

            newAbility.EventChangeCooldownTimer += widget.SetCooldown;
        }
    }
}