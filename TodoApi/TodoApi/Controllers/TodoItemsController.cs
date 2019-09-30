using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using PokeAPI;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Pokemon = TodoApi.Models.Pokemon;

namespace TodoApi.Controllers
{
    [Route("get/pokemon")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: get/pokemon/givenPokemonName
        [HttpGet("{pokemonName}")]
        public async Task<ActionResult<Pokemon>> Get(string pokemonName)
        {

            try
            {
                PokemonSpecies pokemon = await DataFetcher.GetNamedApiObject<PokemonSpecies>(pokemonName);
                               
                // For demo purposes, we assume the desired flavortext will always be provided by index 1
                // In a real scenario, this should change, by specifying what we should do with the foreign language
                // (e.g. always select en, translate the text, select specific value etc)
                string originalDescription = pokemon.FlavorTexts[1].FlavorText;

                var client = new HttpClient();

                // Create the HttpContent for the form to be posted.
                var requestContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("text", originalDescription),
                new KeyValuePair<string, string>("api_key", "dWuL_uQCQj4GYAxQDaVTEweF"),
                });

                // Get the response.
                HttpResponseMessage response = await client.PostAsync(
                    "https://api.funtranslations.com/translate/shakespeare.json",
                    requestContent);

                // Get the response content.
                HttpContent responseContent = response.Content;

                // Get the stream of the content.
                using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                {
                    // Write the output
                    JObject translatedPokemonDescriptionResult = JObject.Parse(await reader.ReadToEndAsync());
                    string translatedPokemonDescriptionResultText = (string)translatedPokemonDescriptionResult["contents"]["translated"];

                    //  Create an object for the requested Pokemon including Pokemon's name and Shakespeare's description
                    Pokemon requestedPokemon = new Pokemon();
                    requestedPokemon.Name = pokemonName;
                    requestedPokemon.Description = translatedPokemonDescriptionResultText;
                    return requestedPokemon;

                }
            }



            catch (Exception error)
            {
                // Log error
                // In caase of error, return a friendly message to the user.                                                                 
                Pokemon unknownPokemon = new Pokemon();
                unknownPokemon.Name = "MissingNO";
                unknownPokemon.Description = "Are you trying to catch MISSINGNO? (https://en.wikipedia.org/wiki/MissingNo.) " +
                    "Why don't you try a different name of a friendlier Pokemon such as 'Charizard', or 'Bulbasaur'?";
                return unknownPokemon;

            }
                                                         
        }

        private bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }


}
