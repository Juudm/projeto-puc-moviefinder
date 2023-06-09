﻿using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using moviefinder.client;
using moviefinder.dto;
using moviefinder.dto.filme;
using moviefinder.dto.genero;
using moviefinder.dto.pessoa;
using moviefinder.dto.provedor;
using moviefinder.dto.recomendado;
using moviefinder.dto.usuario;
using moviefinder.Entities;
using moviefinder.service;
using Newtonsoft.Json;

namespace moviefinder.controller;

[ApiController]
[Route("v1/public/movieFinder")]
public class FilmeController : ControllerBase
{
    private readonly TheMovieDataBaseClient _theMovieDataBaseClient;
    private readonly string _apiKey;
    private readonly string _apiLanguage;
    private readonly FilmeService _filmeService;
    private readonly UsuarioService _usuarioService;

    public FilmeController(TheMovieDataBaseClient theMovieDataBaseClient, FilmeService filmeService,
        UsuarioService usuarioService)
    {
        _theMovieDataBaseClient = theMovieDataBaseClient;
        _apiKey = "a99efb9137ad32d6eb76bc2453ba6c28";
        _apiLanguage = "pt-BR";
        _filmeService = filmeService;
        _usuarioService = usuarioService;
    }

    [HttpGet("movie/popularity")]
    public async Task<IActionResult> ListPopularityMovies()
    {
        var response = await _theMovieDataBaseClient.ListPopularityMovies(_apiKey, _apiLanguage);
        var moviesByPopularity = JsonConvert.DeserializeObject<ListaPopularFilmes>(response);
        return Ok(moviesByPopularity.Results);
    }

    [HttpGet("movie/top_rated")]
    public async Task<IActionResult> ListTopRatedMovies()
    {
        var response = await _theMovieDataBaseClient.ListTopRatedMovies(_apiKey, _apiLanguage);
        var moviesByTopRated = JsonConvert.DeserializeObject<ListaTopRatedFilmesDto>(response);
        return Ok(moviesByTopRated.Results);
    }

    [HttpGet("movie/{id}")]
    public async Task<IActionResult> FindMovieById(string id)
    {
        var response = await _theMovieDataBaseClient.FindMovieById(id, _apiKey, _apiLanguage);
        var movieById = JsonConvert.DeserializeObject<FilmeDto>(response);
        return Ok(movieById);
    }

    [HttpGet("movie_query/{query}")]
    public async Task<IActionResult> FindMovieByQuery(string query)
    {
        var response = await _theMovieDataBaseClient.FindMovieByQuery(query, _apiKey, _apiLanguage);
        var movieByQuery = JsonConvert.DeserializeObject<ResultadosFilmePesquisaDto>(response);
        return Ok(movieByQuery);
    }

    [HttpGet("person/{id}")]
    public async Task<IActionResult> FindActorById(string id)
    {
        var response = await _theMovieDataBaseClient.FindPersonById(id, _apiKey, _apiLanguage);
        var personById = JsonConvert.DeserializeObject<PessoaDto>(response);
        return Ok(personById);
    }

    [HttpGet("genre/list")]
    public async Task<IActionResult> ListGenres()
    {
        var response = await _theMovieDataBaseClient.ListGenres(_apiKey, _apiLanguage);
        var genres = JsonConvert.DeserializeObject<GenerosDto>(response);
        return Ok(genres);
    }

    [HttpGet("discover/movie")]
    public async Task<IActionResult> DiscoverMovies([FromQuery] string genreId)
    {
        var response = await _theMovieDataBaseClient.DiscoverMovies(_apiKey, _apiLanguage, genreId);
        var discover = JsonConvert.DeserializeObject<ListaDiscoverFilmeDto>(response);
        return Ok(discover);
    }

    [HttpGet("provider/list")]
    public async Task<IActionResult> ListProviders()
    {
        var response = await _theMovieDataBaseClient.ListProviders(_apiKey, _apiLanguage);
        var providers = JsonConvert.DeserializeObject<ProvedoresDto>(response);
        return Ok(providers);
    }

    [HttpGet("languages/list")]
    public async Task<IActionResult> ListLanguages()
    {
        var response = await _theMovieDataBaseClient.ListLanguages(_apiKey);
        var idiomas = JsonConvert.DeserializeObject<List<IdiomaFaladoDto>>(response);
        return Ok(idiomas);
    }

    [HttpGet("recommendation/list/{id}")]
    public async Task<IActionResult> ListRecommendationsByMovie(string id)
    {
        var response = await _theMovieDataBaseClient.ListRecommendationsByMovie(id, _apiKey, _apiLanguage);
        var recommendations = JsonConvert.DeserializeObject<RecomendadoDto>(response);
        return Ok(recommendations);
    }
    
    [HttpGet("recommendationUser/list")]
    public async Task<IActionResult> RecommendationsMoviesListToUser([FromHeader(Name = "Authorization")] string authorizationHeader)
    {
        if (authorizationHeader.StartsWith("Bearer "))
        {
            var token = authorizationHeader.Substring("Bearer ".Length);
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var userId = jwtToken.Claims.FirstOrDefault(c => c.Type.Equals("userId")).Value;
            
            var response = await _theMovieDataBaseClient.ListRecommendationsByMovie(userId, _apiKey, _apiLanguage);
            
            var recommendations = JsonConvert.DeserializeObject<RecomendadoDto>(response);
            return Ok(recommendations.Results);
        }
        return Unauthorized();
    }

    [HttpGet("favoritarFilme/{movieId}")]
    public async Task<IActionResult> FavoritarFilme([FromHeader(Name = "Authorization")] string authorizationHeader,
        string movieId)
    {
        if (authorizationHeader.StartsWith("Bearer "))
        {
            var token = authorizationHeader.Substring("Bearer ".Length);
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var userId = jwtToken.Claims.FirstOrDefault(c => c.Type.Equals("userId")).Value;

            if (!string.IsNullOrEmpty(userId))
            {
                var movieById = await _theMovieDataBaseClient.FindMovieById(movieId, _apiKey, _apiLanguage);
                var filmeDto = JsonConvert.DeserializeObject<FilmeDto>(movieById);
                var filmeFavoritado = await _filmeService.FavoritarFilme(userId, filmeDto);

                if (filmeFavoritado)
                {
                    return Ok(filmeFavoritado);
                }
                else
                {
                    var responseErro = new
                    {
                        Message = "Filme já favoritado!",
                        Data = filmeDto.Title
                    };

                    return BadRequest(responseErro);
                }
            }
        }

        return Unauthorized();
    }

    [HttpGet("favoriteList")]
    public async Task<IActionResult> getFavoritesMoviesList(
        [FromHeader(Name = "Authorization")] string authorizationHeader)
    {
        if (authorizationHeader.StartsWith("Bearer "))
        {
            var token = authorizationHeader.Substring("Bearer ".Length);
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var userId = jwtToken.Claims.FirstOrDefault(c => c.Type.Equals("userId")).Value;

            if (!string.IsNullOrEmpty(userId))
            {
                var favoritesList = await _filmeService.GetListaFilmesFavoritosByUsuario(int.Parse(userId));
                
                List<FilmeDto> listaFilmes = new List<FilmeDto>();

                foreach (var favorito in favoritesList)
                {
                    var response = await _theMovieDataBaseClient.FindMovieById(favorito.IdFilme.TheMovieDbId.ToString(),
                        _apiKey, _apiLanguage);
                    var movieById = JsonConvert.DeserializeObject<FilmeDto>(response);
                    listaFilmes.Add(movieById);
                }

                return Ok(listaFilmes);
                
            }
        }

        return Unauthorized();
    }

    [HttpPost("cadastrarUsuario")]
    public async Task<IActionResult> CadastrarUsuario([FromBody] Usuario usuario)
    {
        var cadastrarUsuario = await _usuarioService.CadastrarUsuario(usuario);
        if (cadastrarUsuario)
        {
            var responseOk = new
            {
                Message = "Usuario cadastrado com sucesso!",
                Data = usuario.Email
            };
            return Ok(responseOk);
        }

        var responseErro = new
        {
            Message = "Já existe usuário cadastrado com esse endereço de e-mail!",
            Data = usuario.Email
        };

        return BadRequest(responseErro);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UsuarioDto usuarioDto)
    {
        var usuario = await _usuarioService.Login(usuarioDto);
        if (usuario == null)
        {
            var responseErro = new
            {
                Message = "Credenciais inválidas!",
                Data = usuarioDto.Email
            };

            return Unauthorized(responseErro);
        }

        var isSenhaCorreta = BCrypt.Net.BCrypt.Verify(usuarioDto.Senha, usuario.Senha);

        if (!isSenhaCorreta)
        {
            var responseErro = new
            {
                Message = "Credenciais inválidas!",
                Data = usuarioDto.Email
            };
            return Unauthorized(responseErro);
        }

        var usuarioAuthDto = new UsuarioAuthDto
        {
            Nome = usuario.Nome,
            Email = usuario.Email,
            Idade = usuario.Idade,
            Genero = usuario.Genero
        };

        var token = TokenService.GenerateToken(usuario);

        var responseOk = new
        {
            Message = "Login efetuado com sucesso!",
            Data = usuarioAuthDto,
            token
        };

        return Ok(responseOk);
    }

    [HttpGet("informacoesusuario")]
    public async Task<IActionResult> InformacoesLoggedUser(
        [FromHeader(Name = "Authorization")] string authorizationHeader)
    {
        if (authorizationHeader.StartsWith("Bearer "))
        {
            var token = authorizationHeader.Substring("Bearer ".Length);
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var jwtTokenId = jwtToken.Claims.FirstOrDefault(c => c.Type.Equals("userId")).Value;

            if (!string.IsNullOrEmpty(jwtTokenId))
            {
                var usuarioAuthDto = await _usuarioService.InformacoesUser(jwtTokenId);

                return Ok(usuarioAuthDto);
            }
        }

        return Unauthorized();
    }

    [HttpGet("isFilmeFavoritado/{movieId}")]
    public async Task<IActionResult> IsFilmeFavoritado([FromHeader(Name = "Authorization")] string authorizationHeader,
        string movieId)
    {
        if (authorizationHeader.StartsWith("Bearer "))
        {
            var token = authorizationHeader.Substring("Bearer ".Length);
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var usuarioId = jwtToken.Claims.FirstOrDefault(c => c.Type.Equals("userId")).Value;

            var isFilmeFavoritado = await _usuarioService.isFilmeFavoritado(usuarioId, movieId);

            return Ok(isFilmeFavoritado);
        }

        return Unauthorized();
    }
    
    [HttpGet("desfavoritarFilme/{movieId}")]
    public async Task<IActionResult> DesfavoritarFilme([FromHeader(Name = "Authorization")] string authorizationHeader,
        string movieId)
    {
        if (authorizationHeader.StartsWith("Bearer "))
        {
            var token = authorizationHeader.Substring("Bearer ".Length);
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var userId = jwtToken.Claims.FirstOrDefault(c => c.Type.Equals("userId")).Value;

            if (!string.IsNullOrEmpty(userId))
            {
                var filmeDesfavoritado = await _filmeService.DesfavoritarFilme(userId, movieId);

                if (filmeDesfavoritado)
                {
                    return Ok(filmeDesfavoritado);
                }
                else
                {
                    var responseErro = new
                    {
                        Message = "Filme não encontrado ou não foi favoritado pelo usuario",
                        MovieDBId = movieId
                    };

                    return BadRequest(responseErro);
                }
            }
        }
        return Unauthorized();
    }

    [HttpPut("alterarInformacoesUsuario")]
    public async Task<IActionResult> AlterarInformacoesUsuario([FromHeader(Name = "Authorization")] string authorizationHeader,
        [FromBody] RedefinicaoSenha redefinicao)
    {
        if (authorizationHeader.StartsWith("Bearer "))
        {
            var token = authorizationHeader.Substring("Bearer ".Length);
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var userId = jwtToken.Claims.FirstOrDefault(c => c.Type.Equals("userId")).Value;

            if (!string.IsNullOrEmpty(userId))
            {
                var usuarioDb = await _usuarioService.BuscarUsuario(userId);
                
                if (redefinicao.Senha != null)
                {
                    var isSenhaCorreta = BCrypt.Net.BCrypt.Verify(redefinicao.Senha, usuarioDb.Senha);
                    if (!isSenhaCorreta)
                    {
                        var responseErro = new
                        {
                            Message = "Credenciais inválidas!",
                            Data = usuarioDb.Email
                        };
                        return Unauthorized(responseErro);
                    }
                }

                var atualizarUsuario = await _usuarioService.AtualizarUsuario(usuarioDb, redefinicao);
                if (atualizarUsuario)
                {
                    return Ok("Usuario alterado com sucesso!");
                }
                return BadRequest();
            }
        }
        return Unauthorized("Credenciais inválidas");
    }
    
    [HttpDelete("deletarUsuario")]
    public async Task<IActionResult> DeletarUsuario([FromHeader(Name = "Authorization")] string authorizationHeader)
    {
        if (authorizationHeader.StartsWith("Bearer "))
        {
            var token = authorizationHeader.Substring("Bearer ".Length);
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var jwtTokenId = jwtToken.Claims.FirstOrDefault(c => c.Type.Equals("userId")).Value;

            if (!string.IsNullOrEmpty(jwtTokenId))
            {
                await _usuarioService.DeletarUsuario(jwtTokenId);
                return Ok("Usuario deletado com sucesso!");
            }
        }
        return BadRequest();
    }
    
    [HttpGet("makeRecommendationUserList")]
    public async Task<IActionResult> MakeRecommendationUserList([FromHeader(Name = "Authorization")] string authorizationHeader)
    {
        if (authorizationHeader.StartsWith("Bearer "))
        {
            var token = authorizationHeader.Substring("Bearer ".Length);
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var userId = jwtToken.Claims.FirstOrDefault(c => c.Type.Equals("userId")).Value;

            if (!string.IsNullOrEmpty(userId))
            {
                var listaFavoritosDb = await _filmeService.GetListaFilmesFavoritosByUsuario(int.Parse(userId));
                
                List<FilmeDto> listaFilmesMdb = new List<FilmeDto>();

                foreach (var favorito in listaFavoritosDb)
                {
                    var response = await _theMovieDataBaseClient.FindMovieById(favorito.IdFilme.TheMovieDbId.ToString(),
                        _apiKey, _apiLanguage);
                    var movieById = JsonConvert.DeserializeObject<FilmeDto>(response);
                    listaFilmesMdb.Add(movieById);
                }
                
                List<RecomendacoesFilmeDto> listaFilmesRecomendadosParaUsuario = new List<RecomendacoesFilmeDto>();
                
                foreach (var filme in listaFilmesMdb)
                {
                    var responseListaFilmesRecomendadosMdb =
                        await _theMovieDataBaseClient.ListRecommendationsByMovie(filme.Id.ToString(), _apiKey,
                            _apiLanguage);

                    var recomendacoes = JsonConvert.DeserializeObject<RecomendadoDto>(responseListaFilmesRecomendadosMdb);

                    if (recomendacoes != null && recomendacoes.Results.Count > 0)
                    {
                        List<RecomendacoesFilmeDto> listaFilmesOrdenadosPorNota = recomendacoes.Results.OrderByDescending(p => p.VoteAverage).ToList();
                        
                        for (int i = 0; i < 4 ; i++)
                        {
                            if (listaFilmesRecomendadosParaUsuario.All(item => item.Id != listaFilmesOrdenadosPorNota[i].Id))
                            {
                                listaFilmesRecomendadosParaUsuario.Add(listaFilmesOrdenadosPorNota[i]);
                            }
                            
                            if (i.Equals(listaFilmesOrdenadosPorNota.Count - 1))
                            {
                                break;
                            }
                        }
                    }
                }
                
                //verifica se na lista finalizada possui algum filme que já está favoritado
                foreach (var FilmeDto in listaFilmesMdb)
                {
                    var itemEncontrado = listaFilmesRecomendadosParaUsuario.Find(item => item.OriginalTitle == FilmeDto.OriginalTitle);
                    if (itemEncontrado != null)
                    {
                        listaFilmesRecomendadosParaUsuario.Remove(itemEncontrado);
                    }
                }
                
                return Ok(listaFilmesRecomendadosParaUsuario);
            }
        }
        return Unauthorized();
    }
    
}