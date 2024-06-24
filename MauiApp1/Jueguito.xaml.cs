namespace MauiApp1;
using System.Timers;
using Timer = System.Timers.Timer;


public partial class Jueguito : ContentPage
{
    private Button ultimoButtonClicked;
    private bool encontrandoMatch = false;
    private List<string> animalEmoji;
    private Timer timer;
    private int tiempoRestante = 60; // Los segundos que le quedan 
    private int parejasRestantes;

    public Jueguito()
	{
		InitializeComponent();

        SetUpGame();

        // Inicializar el temporizador 
        timer = new Timer
        {
            Interval = 1000 // 1 segundo
        };
        timer.Elapsed += OnTimerElapsed;
    }
    public void SetUpGame()
    {
        animalEmoji = new List<string>()
        {
                "🐹", "🐹",
                "🐑", "🐑",
                "🦒", "🦒",
                "🐩", "🐩",
                "🐸", "🐸",
                "🦆", "🦆",
                "🦢", "🦢",
                "🐙", "🐙",
        };

        Random random = new Random();
        foreach (Button view in Grid1.Children)
        {
            int index = random.Next(animalEmoji.Count);
            string nextEmoji = animalEmoji[index];
            view.Text = nextEmoji;
            animalEmoji.RemoveAt(index);
        }

        if (timer != null)
        {
            timer.Start();
        }
        else
        {
            // Manejar la situación cuando timer es null
            Console.WriteLine("Error: El temporizador no se ha inicializado correctamente.");

        }

        // Cuenta el número de parejas de emojis
        parejasRestantes = Grid1.Children.Count / 2;
    }

    public void Button_Clicked(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (!encontrandoMatch)
        {
            button.IsVisible = false;
            ultimoButtonClicked = button;
            encontrandoMatch = true;
        }
        else
        {
            if (button.Text == ultimoButtonClicked.Text)
            {
                button.IsVisible = false;
                encontrandoMatch = false;
                parejasRestantes--; // Muestra el número de parejas restantes
                if (parejasRestantes == 0)
                {
                    timer.Stop(); // Se detiene el temporizador si se encontraron todas las parejas
                }
            }
            else
            {
                button.IsVisible = true;
                ultimoButtonClicked.IsVisible = true;
                encontrandoMatch = false;
            }
        }
    }

    public void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        tiempoRestante--;


        MainThread.BeginInvokeOnMainThread(() =>
        {

            lblTiempoRestante.Text = $"Tiempo restante: {tiempoRestante} segundos";


            if (tiempoRestante == 0)
            {
                timer.Stop();

            }
            else
            {
                SetUpGame();
                tiempoRestante = 60;
                timer.Start();
            }
        });
    }


    public void OnRestartGameClicked(object sender, EventArgs e)
    {
        // Se inicia l juego el juego
        SetUpGame();

        tiempoRestante = 60;
        timer.Start();

        // se reiniciar el temporizador
    }

    public void siguienteClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new());
    }
}