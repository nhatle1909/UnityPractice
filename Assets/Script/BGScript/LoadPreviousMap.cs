
using UnityEngine;
namespace Assets
{
    public class LoadPreviousMap : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            ListMapManager.Instance.LoadPreviousMap(transform);
        }
       
    }
}
