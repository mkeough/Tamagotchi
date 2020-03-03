using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;

namespace Tamagotchi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PetController : ControllerBase
  {
    public DatabaseContext db { get; set; } = new DatabaseContext();

    [HttpGet]
    public List<Pet> GetAllPets()
    {
      var Pets = db.Pets.OrderBy(p => p.Name);
      return Pets.ToList();
    }

    [HttpGet("{id}")]

    public Pet GetOnePet(int id)
    {
      var pet = db.Pets.FirstOrDefault(p => p.Id == id);

      return pet;
    }

    [HttpPost]
    public Pet CreateNewPet(Pet pet)
    {
      db.Pets.Add(pet);
      db.SaveChanges();
      return pet;
    }
    [HttpPut("{id}/play")]
    public Pet Play(int id)
    {
      var pet = db.Pets.FirstOrDefault(i => i.Id == id);
      pet.HappinessLevel += 5;
      pet.HungerLevel += 3;
      db.SaveChanges();
      return pet;
    }
    [HttpPut("{id}/feed")]
    public Pet Feed(int id)
    {
      var pet = db.Pets.FirstOrDefault(i => i.Id == id);
      pet.HappinessLevel += 5;
      pet.HungerLevel -= 3;
      db.SaveChanges();
      return pet;
    }

    [HttpPut("{id}/scold")]
    public Pet Scold(int id)
    {
      var pet = db.Pets.FirstOrDefault(i => i.Id == id);
      pet.HappinessLevel -= 5;
      db.SaveChanges();
      return pet;
    }
    [HttpDelete("{id}")]
    public ActionResult RemovePet(int id)
    {
      var pet = db.Pets.FirstOrDefault(i => i.Id == id);
      db.Pets.Remove(pet);
      db.SaveChanges();
      return Ok();
    }


  }
}