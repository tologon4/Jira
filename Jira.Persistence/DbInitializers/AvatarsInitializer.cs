using Jira.Domain;

namespace Jira.Persistance.DbInitializers;

public class AvatarsInitializer
{
    public static async Task Initialize(JiraDbContext dbcontext)
    {
        List<Avatar> avatars = new List<Avatar>()
        {
            new Avatar(){Id = 1, Url = "/img/avatars/pp1.png"},
            new Avatar(){Id = 2, Url = "/img/avatars/pp2.png"},
            new Avatar(){Id = 3, Url = "/img/avatars/pp3.png"},
            new Avatar(){Id = 4, Url = "/img/avatars/pp4.png"},
            new Avatar(){Id = 5, Url = "/img/avatars/pp5.png"},
            new Avatar(){Id = 6, Url = "/img/avatars/pp6.png"},
            new Avatar(){Id = 7, Url = "/img/avatars/pp7.png"},
            new Avatar(){Id = 8, Url = "/img/avatars/pp8.png"},
            new Avatar(){Id = 9, Url = "/img/avatars/pp9.png"},
            new Avatar(){Id = 10, Url = "/img/avatars/pp10.png"},
            new Avatar(){Id = 11, Url = "/img/avatars/pp11.png"},
            new Avatar(){Id = 12, Url = "/img/avatars/pp12.png"},
        };
        dbcontext.Avatars.AddRange(avatars);
        await dbcontext.SaveChangesAsync();
    }
}