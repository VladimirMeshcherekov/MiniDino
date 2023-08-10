using UnityEngine;
using System.IO;

namespace Player.Score
{
    public class PlayerBestScore
    {
        public int BestScoreValue;

        public PlayerBestScore()
        {
            GetBestScoreFromFile();
        }

        private void GetBestScoreFromFile()
        {
            if (!File.Exists(SaveFilePath()))
            {
                SaveNewBestScore(BestScoreValue);
            }

            var json = File.ReadAllText(SaveFilePath());
            JsonUtility.FromJsonOverwrite(json, this);
        }

        private void SaveNewBestScore(int newScore)
        {
            BestScoreValue = newScore;
            var json = JsonUtility.ToJson(this);
            File.WriteAllText(SaveFilePath(), json);
        }

        public void SetNewBestScore(int newScore)
        {
            if (newScore > BestScoreValue)
            {
                SaveNewBestScore(newScore);
                BestScoreValue = newScore;
            }
        }

        private string SaveFilePath()
        {
            return Application.persistentDataPath + "save.dino";
        }
    }
}