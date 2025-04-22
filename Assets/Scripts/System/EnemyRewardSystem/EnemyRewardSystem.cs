using System;
using System.Collections.Generic;
using PixelSurvivor.Units.Player;
using UnityEngine;

namespace PixelSurvivor.ScoreManager
{
    public class EnemyRewardSystem //: IEnemyRewardsSystem
    {
        private Dictionary<EnemyController, Action> _enemySubscriptions = new();
        
        private readonly PlayerScoreData _scoreData;

        public EnemyRewardSystem(PlayerScoreData scoreData)
        {
            _scoreData = scoreData;
        }

        public void AddScore(int points)
        {
            _scoreData.AddScore(points);
            
            Debug.Log("Add score + " + points);
        }

        public void RegisterEnemy(EnemyController enemy)
        {
            if(_enemySubscriptions.ContainsKey(enemy)) return;

            Action onDeath = () =>
            {
                AddScore(enemy.KillReward);
                _enemySubscriptions.Remove(enemy);
            };

            enemy.OnDeath += onDeath;
            _enemySubscriptions.Add(enemy, onDeath);
        }
        
        public void UnregisterEnemy(EnemyController enemy)
        {
            if (_enemySubscriptions.TryGetValue(enemy, out var callback))
            {
                enemy.OnDeath -= callback;
                _enemySubscriptions.Remove(enemy);
            }
        }
    }
}