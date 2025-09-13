using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameManager gameManager;

  public void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      gameManager.GameWon();
    }
  }
}
