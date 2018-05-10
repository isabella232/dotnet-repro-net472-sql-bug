using System;
using System.Data.SqlClient;
using System.Linq;
using SharpRaven;
using SharpRaven.Data;

class Program
{
    static void Main(string[] args)
    {
        var dsn = args.ElementAtOrDefault(0)
            ?? throw new ArgumentException("A DSN is required to report the error to Sentry");

        var client = new RavenClient(dsn);
        try
        {
            var connection = new SqlConnection("Data Source=;")
            {
                ConnectionString = null
            };
        }
        catch (Exception ex)
        {
            var eventId = client.Capture(new SentryEvent(ex));
            Console.WriteLine("Sentry event Id: " + eventId);
        }
    }
}

