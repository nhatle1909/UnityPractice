
using UnityEngine;
namespace Assets
{
    public class LoadPreviousMap : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                ListMapManager.Instance.LoadPreviousMap(transform);
            }
        }
       
    }
}
