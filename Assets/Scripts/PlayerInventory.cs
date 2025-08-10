//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.UIElements;

//public class PlayerInventory : MonoBehaviour
//{
//    public int NumberOfDiamonds { get; private set; }

//    public UnityEvent<PlayerInventory> OnDiamondCollected;

//    public void DiamondCollected()
//    {
//        NumberOfDiamonds++;

//        OnDiamondCollected.Invoke(this);

//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfDiamonds { get; private set; }

    public UnityEvent<PlayerInventory> OnDiamondCollected;

    [Header("Win Condition")]
    public int totalDiamondsNeeded = 6;
    public GameObject WinPanel;

    void Start()
    {
        if (WinPanel != null)
            WinPanel.SetActive(false);
    }

    public void DiamondCollected()
    {
        NumberOfDiamonds++;
        OnDiamondCollected.Invoke(this);

        if (NumberOfDiamonds >= totalDiamondsNeeded)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        if (WinPanel != null)
            WinPanel.SetActive(true);

        Time.timeScale = 0f;
    }
    public int GetNumberOfDiamonds()
    {
        return NumberOfDiamonds;
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
