using UnityEngine;

namespace PixelSurvivor.Units.Player
{
    public class PlayerPresenter
    {
        
        
        private ExpereinceManager _expereinceManager;
        private HeathComponent _heathComponent;

        public PlayerPresenter(ExpereinceManager expereinceManager, HeathComponent heathComponent)
        {
            _expereinceManager = expereinceManager;
            _heathComponent = heathComponent;
        }
    }
}