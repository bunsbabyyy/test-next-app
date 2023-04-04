using Microsoft.AspNetCore.Mvc;
using Simple.Models;
using System.Collections.Generic;

namespace APItest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        List<Value> values = new List<Value> {
            new Value { Id = 1, Content = "Value 1" },
            new Value { Id = 2, Content = "Value 2" },
            new Value { Id = 3, Content = "Value 3" },
            new Value { Id = 4, Content = "Value 4" },
            new Value { Id = 5, Content = "Value 5" },
        };
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Value> GetAll()
        {
            List<Value> tempList = values;
            return tempList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Value GetById(int id)
        {
            List<Value> tempList = values;
            Value tempValue = null;
            foreach (Value temp in tempList)
            {
                if (temp.Id == id)
                {
                    tempValue = temp;
                }
            }
            return tempValue;
        }

        [HttpPost("{id}")]
        public void Add(int id, [FromBody] string value)
        {
            Value tempValue = new Value();
            tempValue.Id = id;
            tempValue.Content = value;
            values.Add(tempValue);
        }

        [HttpPut("{id}")]
        public void Modify(int id, string value)
        {
            values.LastOrDefault((Value temp) => temp.Id == id).Content = value;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
