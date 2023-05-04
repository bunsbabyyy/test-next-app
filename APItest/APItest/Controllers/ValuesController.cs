using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Simple.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace APItest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private NpgsqlCommand _cmd;
        private const string ConnectionString = "Host=localhost; Database=postgres; Username=postgres; Password=123456";
        private string _query;
        public ValuesController()
        {
            var context = new ValueContext();
            _cmd = context.sqlcmd();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetAll()
        {
            List<Value> result = new List<Value>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                _query = "SELECT * FROM information ORDER BY \"Id\" ASC";
                _cmd = new NpgsqlCommand(_query, connection);
                connection.Open();
                NpgsqlDataReader reader = _cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string content = reader.GetString(1);
                    result.Add(new Value() { Id = id, Content = content });
                }
            }
            string json = JsonConvert.SerializeObject(result);
            return json;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            List<Value> result = new List<Value>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                _query = $"SELECT * FROM information";
                _cmd = new NpgsqlCommand(_query, connection);
                connection.Open();
                NpgsqlDataReader reader = _cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id1 = reader.GetInt32(0);
                    string content = reader.GetString(1);
                    if (id1 == id) result.Add(new Value() { Id = id1, Content = content });
                }
            }
            string json = JsonConvert.SerializeObject(result);
            return json;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Add(string value)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {

                _query = $"INSERT INTO information (\"Id\", \"Content\") VALUES (DEFAULT, @Content)";
                _cmd = new NpgsqlCommand(_query, connection);
                connection.Open();
                _cmd.Parameters.AddWithValue("@Content", value);
                _cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Modify(int id, string value)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                _query = $"UPDATE information SET \"Content\" = @Content WHERE \"Id\" = @Id";
                _cmd = new NpgsqlCommand(_query, connection);
                connection.Open();
                _cmd.Parameters.AddWithValue("@Id", id);
                _cmd.Parameters.AddWithValue("@Content", value);
                _cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                _query = $"DELETE FROM information WHERE \"Id\" = @Id";
                _cmd = new NpgsqlCommand(_query, connection);
                connection.Open();
                _cmd.Parameters.AddWithValue("@Id", id);
                _cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
