# Gotta Catch 'Em All 

Hey, you Pokémon trainer! This web API built with ASP.NET Core returns the description of a given Pokémon written using Shakespeare’s style.

For example:

```bash
http --verify=no https://localhost:5001/get/pokemon/charizard
```

will return:

```bash
{ "description": "Charizard flies 'round the sky in search 
of powerful opponents. 't breathes fire of such most wondrous 
heat yond 't melts aught. 
However, 't nev'r turns its fiery 
breath on 
any opponent weaker than itself.", "name": "charizard" }
```


## Installation

The fastest way to inspect the code is by following these steps: 
1. Download an open solution
2. Ensure you have installed xx ()
3. You might need to install the following 4 packages
-
-
-
-
4. Ensure you have


## Usage

While you running the project, copy-paste the following in httpie:

```bash
http --verify=no https://localhost:5001/get/pokemon/charizard
http --verify=no https://localhost:5001/get/pokemon/bulbasaur
```

You should see the following: 

// img

In case you search for an unknown Pokémon you'll receive the following message :

// img

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
