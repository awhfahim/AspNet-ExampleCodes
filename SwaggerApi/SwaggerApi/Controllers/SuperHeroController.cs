using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SwaggerApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : ControllerBase
	{
		public static List<SuperHero> superHeroes = new List<SuperHero>()
		{
			new SuperHero()
			{
				Id = 1,
				Name = "My Father",
				FirstName = "Zakaria Hasan",
				LastName = "Zakir",
				Address = "Nichu Colony"
			}
		};

		[HttpGet]
		public async Task<ActionResult<SuperHero>> GetAllHeroes()
		{
			return Ok(superHeroes);
		}

		[HttpPut("id")]
		public async Task<ActionResult<SuperHero>> UpdateHero(int id, SuperHero model)
		{
			var hero = superHeroes.Find(x => x.Id == id);
			if(hero is not null)
			{
				hero.Name = model.Name;
				hero.FirstName = model.FirstName;
				hero.LastName = model.LastName;
				hero.Address = model.Address;
				return Ok(hero);
			}
			return NotFound();
		}

		[HttpGet("id")]
		public async Task<ActionResult<SuperHero>> GetHero(int id)
		{
			var hero = superHeroes.Find(x => x.Id == id);
			return hero is not null ? Ok(hero) : NotFound();
		}

		[HttpPost]
		public async Task<ActionResult<SuperHero>> AddHero([FromBody]SuperHero model)
		{
			if(ModelState.IsValid)
			{
				superHeroes.Add(model);
				return Ok(superHeroes);
			}
			return BadRequest();
		}

		[HttpDelete("Id")]
		public async Task<ActionResult<SuperHero>> DeleteHero(int id)
		{
			if(superHeroes.Find(x => x.Id == id) is not null)
			{
				superHeroes.Remove(superHeroes[id]);
				return Ok(superHeroes);
			}
			return NoContent();
		}
	}
}
