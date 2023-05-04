using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace APItest;

public class ValueContext : DbContext
{
    public NpgsqlConnection con;
    public ValueContext()
    {
        var configuration = GetConfiguration();
        con = new NpgsqlConnection(configuration.GetSection("DefaultConnection").GetSection("ConnectionStrings").Value);
        con.Open();
    }
    
    public NpgsqlCommand sqlcmd()
    {
        using var cmd = new NpgsqlCommand();
        cmd.Connection = con;
        return cmd;
    }

    public IConfigurationRoot GetConfiguration()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        return builder.Build();
    }
    
    /*protected readonly IConfiguration _configuration;

public ValueContext(IConfiguration configuration)
{
    _configuration = configuration;
}
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultDatabase"));
}*/
}