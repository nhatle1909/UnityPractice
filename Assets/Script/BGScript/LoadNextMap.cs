
using UnityEngine;

namespace Assets
{
    public class LoadNextMap : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
          ListMapManager.Instance.LoadNextMap(transform);
        }
    }
}
