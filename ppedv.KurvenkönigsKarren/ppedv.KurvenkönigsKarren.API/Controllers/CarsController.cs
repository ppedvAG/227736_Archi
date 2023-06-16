using Microsoft.AspNetCore.Mvc;
using ppedv.KurvenkönigsKarren.API.Model;
using ppedv.KurvenkönigsKarren.Model.Contracts;
using ppedv.KurvenkönigsKarren.Model.DomainModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.KurvenkönigsKarren.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IRepository repo;

        public CarsController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/<CarsController>
        [HttpGet]
        public IEnumerable<CarDTO> Get()
        {
            return repo.Query<Car>().Select(x => CarMapper.MapToCarDTO(x));
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public CarDTO Get(int id)
        {
            return CarMapper.MapToCarDTO(repo.GetById<Car>(id));
        }

        // POST api/<CarsController>
        [HttpPost]
        public void Post([FromBody] CarDTO car)
        {
            repo.Add(CarMapper.MapToCar(car));
            repo.SaveAll();
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CarDTO car)
        {
            repo.Update(CarMapper.MapToCar(car));
            repo.SaveAll();
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Delete(repo.GetById<Car>(id));
            repo.SaveAll();
        }
    }
}
