using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class Game : MonoBehaviour
{
    [SerializeField] private RectTransform playButton;
    [SerializeField] private RectTransform foodLabel;
    [SerializeField] private RectTransform crystalLabel;
    [SerializeField] private RectTransform losePanel;
    [SerializeField] private WinPanel winPanel;
    [SerializeField] private SneakHead sneakHead;
    [SerializeField] private Jaws jaws;
    public event UnityAction StartedGame;
    private void OnEnable()
    {
        sneakHead.Died += Lose;
        jaws.Died += Lose;
    }
    private void OnDisable()
    {
        sneakHead.Died -= Lose;
        jaws.Died -= Lose;
    }
    private void Start()
    {
        crystalLabel.gameObject.SetActive(false);
        foodLabel.gameObject.SetActive(false);
        Time.timeScale = 0;
    }
    public void Play()
    {
        Time.timeScale = 1;
        playButton.gameObject.SetActive(false);
        crystalLabel.gameObject.SetActive(true);
        foodLabel.gameObject.SetActive(true);
        StartedGame?.Invoke();
    }
    public void Win(FinishChunk finishChunk)
    {
        winPanel.gameObject.SetActive(true);
        crystalLabel.gameObject.SetActive(false);
        foodLabel.gameObject.SetActive(false);
        finishChunk.LevelEnded -= Win;
        Time.timeScale = 0;
    }
    public void Lose()
    {
        losePanel.gameObject.SetActive(true);
        crystalLabel.gameObject.SetActive(false);
        foodLabel.gameObject.SetActive(false);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
