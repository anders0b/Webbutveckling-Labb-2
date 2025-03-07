namespace FrontEnd.Services;

public class AppState
{
    private int amount;
    public event Action OnChange;
    public int Amount
    {
        get => amount;
        set
        {
            amount = value;
            NotifyStateChanged();
        }
    }
    private void NotifyStateChanged() => OnChange?.Invoke();
}