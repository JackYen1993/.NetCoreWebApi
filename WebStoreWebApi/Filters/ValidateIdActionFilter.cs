using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Net;
using WebStoreWebApi.Exceptions;
using WebStoreWebApi.Interfaces;
using WebStoreWebApi.Models;

namespace WebStoreWebApi.Filters
{
    public class ValidateIdActionFilter<TEntity> : IActionFilter where TEntity : class, IBaseEntity
    {
        private readonly WebStoreDbContext _context;

        public ValidateIdActionFilter(WebStoreDbContext context)
        {
            _context = context;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Guid id = Guid.Empty;

            if (context.ActionArguments.ContainsKey("id"))
            {
                id = (Guid)context.ActionArguments["id"];
            }
            else
            {
                context.Result = new BadRequestObjectResult("Bad id parameter");
                return;
            }

            var entity = _context.Set<TEntity>().SingleOrDefault(x => x.Id.Equals(id));
            if (entity == null)
            {
                throw new CustomException((int)HttpStatusCode.NotFound, "Not Found", "Not Found");
            }
            else
            {
                context.HttpContext.Items.Add("entity", entity);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
