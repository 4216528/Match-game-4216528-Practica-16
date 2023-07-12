using System;

namespace Match_game_4216528;

/// <summary>
/// <Createdate>10/07/2023</Createdate>
/// <Company>USB Technology</Company>
/// <Lastmodificationdate>10/07/2023</Lastmodificationdate>
/// <Lastmodificationdescription>Se configuraron SetUpGame(); </Lastmodificationdescription>
/// <Lastmodificationautor>Nery David</Lastmodificationautor>
/// </summary>

public partial class MainPage : ContentPage

{

    public MainPage()

    {

        InitializeComponent();

        SetUpGame();

    }

    private void SetUpGame()

    {

        List<string> animalEmoji = new List<string>()

        {

            "🐳","🐳",

            "🐹","🐹",

            "🐨","🐨",

            "🐱","🐱",

            "🐿","🐿",

            "🐣","🐣",

            "🐻","🐻",

            "🐰","🐰",

        };

        Random random = new Random();

        foreach (Button view in Grid1.Children)

        {

            int index = random.Next(animalEmoji.Count);

            string nextEmoji = animalEmoji[index];

            view.Text = nextEmoji;

            animalEmoji.RemoveAt(index);

        }

    }

    Button ultimoButtonClicked;

    bool encontrandoMatch = false;

    private void Button_Clicked(object sender, EventArgs e)

    {

        Button button = sender as Button;

        if (encontrandoMatch == false)

        {

            button.IsVisible = false;

            ultimoButtonClicked = button;

            encontrandoMatch = true;

        }

        else if (button.Text == ultimoButtonClicked.Text)

        {

            button.IsVisible = false;

            encontrandoMatch = false;

        }

        else

        {

            ultimoButtonClicked.IsVisible = true;

            encontrandoMatch = false;

        }

    }

    private TimeOnly time = new();

    private bool isRunning;

    private void setTime()

    {

        Timer.Text = $"{time.Minute}:{time.Second:000}";

    }

    private async void Inicio_Clicked(object sender, EventArgs e)

    {

        isRunning = !isRunning;

        Inicio.Text = isRunning ? "Pause" : "Play";

        while (isRunning)

        {

            time = time.Add(TimeSpan.FromSeconds(1));

            setTime();

            await Task.Delay(TimeSpan.FromSeconds(1));

        }

    }

    private void Reiniciar_Clicked(object sender, EventArgs e)

    {

        time = new TimeOnly();

        setTime();

    }

    private void ReiniciarJuego_Clicked(object sender, EventArgs e)

    {

        Navigation.PushModalAsync(new MainPage());

    }

}


