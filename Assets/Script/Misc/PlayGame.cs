
using UnityEngine;


using UnityEngine.SceneManagement;
namespace Assets
{
    public class PlayGame : MonoBehaviour
    {
        // Start is called before the first frame update
        public void StartGame()
        {
            SceneManager.LoadSceneAsync("Village Backside");

        }
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}

