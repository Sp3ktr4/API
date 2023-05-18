WebApplication app = WebApplication.Create();

app.Urls.Add("http://localhost:3000");
app.Urls.Add("http://*:3000");

List<Superhero> heroes = new();

heroes.Add(new() {Name = "Superman", Looks = "Blue & red", Strength = 9001 });
heroes.Add(new() {Name = "Batman", Looks = "Black & yellow", Strength = 15 });
heroes.Add(new() {Name = "Green Arrow", Looks = "Green", Strength = 7 });

app.MapGet("/", Answer);

app.MapGet("/superhero/", () => 
{
    return heroes;
});

app.MapGet("/superhero/{num}", (int num) =>
{
    if (num >= 0 && num < heroes.Count)
    {
        return Results.Ok(heroes[num]);
    }

    return Results.NotFound();
});

app.MapPost("/superhero/", (Superhero hero) =>
{
    Console.WriteLine("Added superhero " + hero.Name);

    heroes.Add(hero);
});

app.Run();

static string Answer()
{
    return "HELLO";
}