﻿using NLayer.Architecture.Bussines.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Xml.Linq;
using NLayer.Architecture.Bussines.Services;

namespace MiPokemonFavorito.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonService pokemonServices;

        private readonly ILogger<PokemonController> _logger;

        public PokemonController(PokemonService pokemonServices)
        {
            this.pokemonServices = pokemonServices;
        }

        [HttpGet("eevee")]
        public async Task<IActionResult> GetEevee()
        {
            try
            {
                var pokemon = await pokemonServices.GetPokemonAsync("eevee");
                return Ok(pokemon);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet(Name = "PokeAPI")]
        public async Task<IActionResult> GetPokemon(string name)
        {
            try
            {
                var pokemon = await pokemonServices.GetPokemonAsync(name);
                return Ok(pokemon);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
//