using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace PixelSurvivor.Units.Player
{
    public class ExperienceObserver : IDisposable
    {
        private readonly ValueView _viewCurrentExperience;
        private readonly ValueView _viewMaxExperience;
        private readonly Image _filledProgressBar;
        
        private readonly PlayerExperienceData _data;
        
        private readonly IDisposable _disposableCurrentExperience;  
        private readonly IDisposable _disposableMaxExperience;
        private readonly IDisposable _disposableOldMaxExperience;

        /*private long _currentExperience;
        private long _oldMaxExperience;
        private long _currentMaxExperience;*/
        
        public ExperienceObserver(ValueView viewCurrentExperience, 
            ValueView viewMaxExperience, PlayerExperienceData data, Image filledProgressBar)
        {
            _viewCurrentExperience = viewCurrentExperience;
            _viewMaxExperience = viewMaxExperience;
            _filledProgressBar =  filledProgressBar;
            
            _data = data;
            
            _disposableCurrentExperience = _data.CurrentExperience.SkipLatestValueOnSubscribe().
                Subscribe(OnCurrentExperienceChanged);
            _disposableMaxExperience = _data.MaxExperienceOnLvl.SkipLatestValueOnSubscribe().
                Subscribe(OnMaxExperienceChanged);
            /*_disposableOldMaxExperience = _data.MaxExperienceOnLvl.SkipLatestValueOnSubscribe().
                Subscribe(OnMaxExperienceChanged);*/

            /*
            _currentExperience = _data.CurrentExperience.Value;
            _oldMaxExperience = _data.MaxExperienceOnLvl.Value;
            _currentMaxExperience = _data.MaxExperienceOnLvl.Value;*/
            
            OnCurrentExperienceChanged(0);
            OnMaxExperienceChanged(0);
            
            CalculatedFilledProgressBar();
        }

        public void Dispose()
        {
            _disposableCurrentExperience.Dispose();
            _disposableMaxExperience.Dispose();
            _disposableOldMaxExperience.Dispose();
        }
        
        private void OnCurrentExperienceChanged(long experience)
        {
            _viewCurrentExperience.UpdateCurrency(experience);
            
            /*_currentExperience = experience;*/
            
            CalculatedFilledProgressBar();
        }
        private void OnMaxExperienceChanged(long experience)
        {
            _viewMaxExperience.UpdateCurrency(experience);
            
            /*_currentMaxExperience = experience;*/
            
            CalculatedFilledProgressBar();
        }

        private void CalculatedFilledProgressBar()
        {
            float fillAmount = (float) (_data.CurrentExperience.Value - _data.OldMaxExperienceOnLvl.Value) / (_data.MaxExperienceOnLvl.Value - _data.OldMaxExperienceOnLvl.Value);
            _filledProgressBar.fillAmount = fillAmount;

            /*float fillAmount = (float)_currentExperience / _currentMaxExperience;

            fillAmount = Mathf.Clamp01(fillAmount);

            _filledProgressBar.fillAmount = fillAmount;
            */
            
            Debug.Log($"Опыт: {_data.CurrentExperience.Value - _data.OldMaxExperienceOnLvl.Value}/{_data.MaxExperienceOnLvl.Value - _data.OldMaxExperienceOnLvl.Value} = {fillAmount:P1}");
        }
    }
}