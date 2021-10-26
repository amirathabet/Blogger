using AutoMapper;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
       
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
       


        public ArticlesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
           
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get(int? categoryid)
        {
            var allarticles = _unitOfWork.Articles.GetAllArticlesData(categoryid);
            return Ok(_mapper.Map<IEnumerable<ArticleViewModel>>(allarticles));
        }


    }
}

