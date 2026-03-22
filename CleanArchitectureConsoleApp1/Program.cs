using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();

//await AddNewRecords();
//QueryStreaming();
//await QueryFilter();
//await QueryMethods();
//await TrackingAndNotTracking();
//await AddNewStreamerWithVideoById();
//await AddNewActorWithVideo();
//await AddNewDirector();


await MultipleEntitiesQuery();

Console.WriteLine($"Presione cualquier tecla para salir");
Console.ReadKey();

async Task MultipleEntitiesQuery()
{
    //var videoWithActors = await dbContext!.Videos!.Include(q => q.Actores).FirstOrDefaultAsync(q => q.Id == 1);

    //var actor = await dbContext.Actor.Select(q => q.Name).ToListAsync();

    var videoWithDirector = await dbContext.Videos
        .Where(q => q.Director != null)
        .Include(q => q.Director)
        .Select(q =>
            new
            {
                Director_FullName = $"{q.Director.Name} {q.Director.LastName}",
                Movie = q.Name
            }
        )
        .ToListAsync();

    foreach ( var movie in videoWithDirector)
    {
        Console.WriteLine($"{movie.Director_FullName} dirigio {movie.Movie}");
    }
}

//async Task AddNewDirector()
//{
//    var director = new Director()
//    {
//        Name = "Lorenzo",
//        LastName = "Basteri",
//        VideoId = 1
//    };

//    await dbContext.AddAsync(director);
//    await dbContext.SaveChangesAsync();
//}

//async Task AddNewActorWithVideo()
//{
//    var actor = new Actor
//    {
//        Name = "Brad",
//        LastName = "Pitt"
//    };

//    await dbContext.AddAsync(actor);
//    await dbContext.SaveChangesAsync();

//    var videoActor = new VideoActor
//    {
//        ActorId = actor.Id,
//        VideoId = 1
//    };

//    await dbContext.AddAsync(videoActor);
//    await dbContext.SaveChangesAsync();
//    //}

//    async Task AddNewStreamerWithVideoById()
//    {
//        var batmanForever = new Video
//        {
//            Name = "Batman Forever",
//            StreamerId = 4

//        };

//        await dbContext.AddAsync(batmanForever);
//        await dbContext.SaveChangesAsync();
//    }

//    async Task AddNewStreamerWithVideo()
//    {
//        var screen = new Streamer
//        {
//            Name = "Screen"
//        };

//        var hungerGames = new Video
//        {
//            Name = "Hunger Games",
//            Streamer = screen,
//        };

//        await dbContext.AddAsync(hungerGames);
//        await dbContext.SaveChangesAsync();
//    }

//    async Task TrackingAndNotTracking()
//    {
//        var streamerWithTracking = await dbContext.Streamers.FirstOrDefaultAsync(x => x.Id == 1);
//        var streamerWithNoTracking = await dbContext.Streamers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);

//        streamerWithTracking!.Name = "Netflix Super";

//        streamerWithNoTracking!.Name = "Amazon Plus";

//        await dbContext.SaveChangesAsync();
//    }


//    async Task QueryLinq()
//    {
//        Console.WriteLine($"Ingrese el servicio de streaming que busca: ");
//        var streamerName = Console.ReadLine();

//        var streamers = await (from i in dbContext.Streamers
//                               where EF.Functions.Like(i.Name, $"%{streamerName}%")
//                               select i).ToListAsync();

//        foreach (var streamer in streamers)
//        {
//            Console.WriteLine($"{streamer.Id} - {streamer.Name}");
//        }
//    }

//    async Task QueryMethods()
//    {
//        var dbStreamer = dbContext!.Streamers!;

//        var streamers1 = await dbStreamer.Where(y => y.Name.Contains("a")).FirstAsync();
//        var firstAsync = await dbStreamer.Where(y => y.Name.Contains("a")).FirstOrDefaultAsync();
//        var firstOrDefault = await dbStreamer.FirstOrDefaultAsync(y => y.Name.Contains("a"));
//        var singleAsync = await dbStreamer.Where(Y => Y.Id == 1).SingleAsync();
//        var singleOrDefaultAsync = await dbStreamer.Where(y => y.Id == 1).SingleOrDefaultAsync();
//        var resultado = await dbStreamer.FindAsync(1);
//    }

//    async Task QueryFilter()
//    {
//        Console.WriteLine($"Ingrese una compania de streaming");
//        var streamingName = Console.ReadLine();
//        var streamers = await dbContext.Streamers.Where(x => x.Name.Equals(streamingName)).ToListAsync();

//        foreach (var streamer in streamers)
//        {
//            Console.WriteLine($"{streamer.Id} - {streamer.Name}");
//        }

//        //var streamerPartialResult = await dbContext.Streamers.Where(x => x.Name.Contains(streamingName)).ToListAsync();
//        var streamerPartialResult = await dbContext.Streamers.Where(x => EF.Functions.Like(x.Name, $"%{streamingName}%")).ToListAsync();

//        foreach (var similarStreaming in streamerPartialResult)
//        {
//            Console.WriteLine("Resultado Similar");
//            Console.WriteLine($"{similarStreaming.Id} - {similarStreaming.Name}");
//        }
//    }

//    void QueryStreaming()
//    {
//        var streamers = dbContext!.Streamers!.ToList();
//        var videos = dbContext!.Videos!.ToList();

//        foreach (var streamer in streamers)
//        {
//            Console.WriteLine($"{streamer.Id} - {streamer.Name}");
//        }
//        foreach (var video in videos)
//        {
//            Console.WriteLine($"{video.Id} - {video.Name}");
//        }
//    }

//    async Task AddNewRecords()
//    {

//        Streamer streamer = new()
//        {
//            Name = "Disney",
//            Url = "https://www.disneyplus.com"
//        };

//        dbContext!.Streamers!.Add(streamer);
//        await dbContext.SaveChangesAsync();

//    var movies = new List<Video> {
//        new Video
//    {
//        Name = "La Cenicienta",
//        StreamerId = streamer.Id,
//    },
//        new Video
//    {
//        Name = "101 Dalmatas",
//        StreamerId = streamer.Id,
//    },
//        new Video
//    {
//        Name = "El Jorobado de Notredame",
//        StreamerId = streamer.Id,
//    },
//        new Video
//    {
//        Name = "Star Wars",
//        StreamerId = streamer.Id,
//    }
//};

//        await dbContext.AddRangeAsync(movies);
//        await dbContext.SaveChangesAsync();
//    }
//}

