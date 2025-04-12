using System.Collections.Generic;
using PixelSurvivor.NewAbilitySystem;
using UnityEngine;

namespace PixelSurvivor.UI.Player.NewAbilityUi
{
    public class AbilitySlotsProvoder : MonoBehaviour
    {
        [SerializeField] private RectTransform _widgetContainer;
        [SerializeField] private AbilitySlotPopup _slotWidget;

        public void TakeNewAbilities(List<NewAbility> abilities)
        {
            foreach (var ability in abilities)
            {
                AbilitySlotPopup widget = Instantiate(_slotWidget, _widgetContainer);
                widget.SetDisplayImage(ability.IconImage);

                ability.EventChangeCooldownTimer += widget.SetCooldown;
            }
        }

        public void TakeNewAbility(NewAbility newAbility)
        {
            AbilitySlotPopup widget = Instantiate(_slotWidget, _widgetContainer);
            widget.SetDisplayImage(newAbility.IconImage);

            newAbility.EventChangeCooldownTimer += widget.SetCooldown;
        }
    }
}