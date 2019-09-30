# Gotta Catch 'Em All 

Hey you, Pokémon trainer! This web API built with ASP.NET Core returns the description of a given Pokémon written in Shakespeare’s style.

For example:

```bash
http --verify=no https://localhost:5001/get/pokemon/charizard
```

will return:

```
{ 
  "description": "Charizard flies 'round the sky in search of powerful opponents. 't breathes fire of such most wondrous 
heat yond 't melts aught. However, 't nev'r turns its fiery breath on any opponent weaker than itself.", 
  "name": "charizard" 
}
```

## Prerequisites
- [M.NET Core 3.0 SDK or later](https://dotnet.microsoft.com/download/dotnet-core/3.0)
- Packages:
```bash
Microsoft.EntityFrameworkCore.Design (3.0.0)
Microsoft.EntityFrameworkCore.InMemory (3.0.0)
Microsoft.EntityFrameworkCore.SqlServer (3.0.0)
Microsoft.VisualStudio.Web.CodeGeneration.Design (3.0.0)
PokeApi.NET (1.1.2)
Newtonsoft.Json
```

## Usage

after fulfilling the prerequisites just download, open and run the solution with Visual Studio. While you run the project, copy-paste the following in [httpie](https://httpie.org/):

```bash
http --verify=no https://localhost:5001/get/pokemon/charizard
http --verify=no https://localhost:5001/get/pokemon/bulbasaur
```

You should see the following:

![Usage Gif Example](https://github.com/vasilomanolis/Gotta-Catch-Em-All/blob/master/l19.gif)

In case you search for an unknown Pokémon you'll receive the following message referring to the famous [MissingNo Pokémon species](https://en.wikipedia.org/wiki/MissingNo.).


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)
