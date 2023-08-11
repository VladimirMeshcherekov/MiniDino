using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player.UI
{
    public class RestartLevel : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
