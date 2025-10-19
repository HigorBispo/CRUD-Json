var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Definir os EndPoints

//Metofo GET para retornar todos os usuarios
app.MapGet("/users", () =>
{
    return UserRepository.GetAll();
});

//Metofo POST para adicionar um novo usuario
app.MapPost("/users", (User user) =>
{
    UserRepository.Add(user);
    return Results.Ok(user);

});

//Metodo PUT
app.MapPut("/users/{id}", (int id, User UserUpdate) =>
{
    var user = UserRepository.GetAll().FirstOrDefault(u => u.id == id);
    if (user == null)
    {
        return Results.NotFound("não encontrado");
    }
    user.nome = UserUpdate.nome;
    user.email = UserUpdate.email;
    return Results.Ok(user);
});

//Metodo DELETE
app.MapDelete("/users/{id}", (int id) =>
{
    var user = UserRepository.GetAll().FirstOrDefault(u => u.id == id);
    if (user == null)
    {
        return Results.NotFound("nao enxontrado");

    }

    UserRepository.Remove(id);
    return Results.Ok("usuario deletado com sucesso");

});

app.Run();