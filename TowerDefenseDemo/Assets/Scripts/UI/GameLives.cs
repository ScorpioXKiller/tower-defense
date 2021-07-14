using UnityEngine.SceneManagement;

public class GameLives : GameElement
{
    public event System.Action OnValueChanged;

    public override void OnEnemySpawned()
    {
        FirstEnemy.OnReachedTarget += TakeLife;
    }

    public void TakeLife()
    {
        if(CurrentValue > 1)
        {
            CurrentValue--;
            OnValueChanged?.Invoke();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnDisable()
    {
        if(FirstEnemy != null)
        {
            FirstEnemy.OnReachedTarget -= TakeLife;
        }
    }
}