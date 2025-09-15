using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameManager gameManager;

  public void OnTriggerEnter(Collider other)
  {
    // compare with player tag to show win panel
    if (other.CompareTag("Player"))
    {
      gameManager.GameWon();
    }
  }
}
