using System;
using UniRx;
using UnityEngine;

namespace PixelSurvivor.Units.Player
{
    public class ExperienceObserver : IDisposable
    {
        private readonly ValueView _viewCurrentExperience;
        private readonly ValueView _viewMaxExperience;
        
        private readonly PlayerExperienceData _data;
        
        private readonly IDisposable _disposableCurrentExperience;  
        private readonly IDisposable _disposableMaxExperience;

        public ExperienceObserver(ValueView viewCurrentExperience, 
            ValueView viewMaxExperience, PlayerExperienceData data)
        {
            _viewCurrentExperience = viewCurrentExperience;
            _viewMaxExperience = viewMaxExperience;
            
            _data = data;
            
            _disposableCurrentExperience = _data.CurrentExperience.SkipLatestValueOnSubscribe().
                Subscribe(OnCurrentExperienceChanged);
            _disposableMaxExperience = _data.MaxExperienceOnLvl.SkipLatestValueOnSubscribe().
                Subscribe(OnMaxExperienceChanged);
            
            OnCurrentExperienceChanged(0);
            OnMaxExperienceChanged(0);
        }

        public void Dispose()
        {
            _disposableCurrentExperience.Dispose();
            _disposableMaxExperience.Dispose();
        }
        
        private void OnCurrentExperienceChanged(long experience)
        {
            _viewCurrentExperience.UpdateCurrency(experience);
            
            Debug.Log("OnCurrentExperienceChanged" + experience);
        }
        private void OnMaxExperienceChanged(long experience)
        {
            _viewMaxExperience.UpdateCurrency(experience);
            
            Debug.Log("OnMaxExperienceChanged" + experience);
        }
    }
}