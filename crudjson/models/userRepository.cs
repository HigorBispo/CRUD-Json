public class UserRepository
{
    //lista para armazenar os usuarios
    private static List<User> users = new List<User>();
    public static List<User> GetAll()
    {
        //retorna os nomers de usuarios
        return users;
    }

    static UserRepository()
    {
        //carrega os usuarios do armazenamento
        users = UserStorage.Load();
    }

    public static void Add(User user)
    {
        //adiciona um novo usuario na lista
        users.Add(user);
        UserStorage.Save(users);
    }

    public static void Remove(int id)
    {
        var user = users.FirstOrDefault(u => u.id == id);
        if(user != null)
        {
            users.Remove(user);
            UserStorage.Save(users);
        }
    }
}