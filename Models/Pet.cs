using System;
using System.Collections.Generic;
namespace Tamagotchi.Models
{
  public class Pet
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public DateTime Birthday { get; set; }

    public DateTime? DeathDate { get; set; }

    public int HungerLevel { get; set; }

    public int HappinessLevel { get; set; }
  }
}