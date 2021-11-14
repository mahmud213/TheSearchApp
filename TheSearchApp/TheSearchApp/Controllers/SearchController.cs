using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using TheSearchApp.DataManager.Concreate;
using TheSearchApp.DataManager.Models;
using TheSearchApp.Helper;

namespace TheSearchApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public SearchController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("search-all")]
        public ActionResult SearchAll()
        {
            var result = _unitOfWork.SearchHistoryRepo.GetAll();

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("search-by-user-id")]
        public ActionResult SearchByUserId([FromBody] string userId)
        {
            var result = _unitOfWork.SearchHistoryRepo.GetSearchHistoryByUserId(userId);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("search-movie")]
        public ActionResult SearchMovie([FromBody] SearchMovie movie)
        {
            string responseStr = string.Empty;
            try
            {
                SearchHistory history = _unitOfWork.SearchHistoryRepo.GetSearchHistoryByCriteria(movie.movie_id.ToString(), "Movie");
                if (history == null || string.IsNullOrEmpty(history.APIResponse))
                {
                    string apiKey = _configuration.GetSection("AppConfiguration").GetSection("api_key").Value;
                    string url = _configuration.GetSection("AppConfiguration").GetSection("searchMovieURL").Value;

                    APICalling api = new APICalling();
                    Task<string> taskMovie = Task.Run<string>(async () => await api.SearchMovie(movie.movie_id, apiKey, url));
                    responseStr = taskMovie.Result;

                    //Add History
                    SearchHistory entity = new SearchHistory();
                    entity.UserId = movie.UserId;
                    entity.SearchCategory = "Movie";
                    entity.SearchCriteria = movie.movie_id.ToString();
                    entity.APIRequest = "";
                    entity.APIResponse = responseStr;
                    entity.RequestDate = DateTime.Now;
                    _unitOfWork.SearchHistoryRepo.Add(entity);
                    _unitOfWork.Save();
                }
                else
                {
                    responseStr = history.APIResponse;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(responseStr);
        }

        [HttpPost]
        [Route("search-people")]
        public ActionResult SearchPeople([FromBody] SearchPeople people)
        {
            string responseStr = string.Empty;
            try
            {
                SearchHistory history = _unitOfWork.SearchHistoryRepo.GetSearchHistoryByCriteria(people.person_id.ToString(), "People");
                if (history == null || string.IsNullOrEmpty(history.APIResponse))
                {
                    string apiKey = _configuration.GetSection("AppConfiguration").GetSection("api_key").Value;
                    string url = _configuration.GetSection("AppConfiguration").GetSection("searchPeopleURL").Value;

                    APICalling api = new APICalling();
                    Task<string> taskPeople = Task.Run<string>(async () => await api.SearchPeople(people.person_id, apiKey, url));
                    responseStr = taskPeople.Result;

                    //Add History
                    SearchHistory entity = new SearchHistory();
                    entity.UserId = people.UserId;
                    entity.SearchCategory = "People";
                    entity.SearchCriteria = people.person_id.ToString();
                    entity.APIRequest = "";
                    entity.APIResponse = responseStr;
                    entity.RequestDate = DateTime.Now;
                    _unitOfWork.SearchHistoryRepo.Add(entity);
                    _unitOfWork.Save();
                }
                else
                {
                    responseStr = history.APIResponse;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(responseStr);
        }

        [HttpPost]
        [Route("search-tv-shows")]
        public ActionResult SearchTVShows([FromBody] SearchTVShow tvshow)
        {
            string responseStr = string.Empty;
            try
            {
                SearchHistory history = _unitOfWork.SearchHistoryRepo.GetSearchHistoryByCriteria(tvshow.tv_id.ToString(), "TVShow");
                if (history == null || string.IsNullOrEmpty(history.APIResponse))
                {
                    string apiKey = _configuration.GetSection("AppConfiguration").GetSection("api_key").Value;
                    string url = _configuration.GetSection("AppConfiguration").GetSection("searchTVShowURL").Value;

                    APICalling api = new APICalling();
                    Task<string> taskPeople = Task.Run<string>(async () => await api.SearchTVShows(tvshow.tv_id, apiKey, url));
                    responseStr = taskPeople.Result;

                    //Add History
                    SearchHistory entity = new SearchHistory();
                    entity.UserId = tvshow.UserId;
                    entity.SearchCategory = "TVShow";
                    entity.SearchCriteria = tvshow.tv_id.ToString();
                    entity.APIRequest = "";
                    entity.APIResponse = responseStr;
                    entity.RequestDate = DateTime.Now;
                    _unitOfWork.SearchHistoryRepo.Add(entity);
                    _unitOfWork.Save();
                }
                else
                {
                    responseStr = history.APIResponse;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(responseStr);
        }

    }
}
