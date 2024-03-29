﻿using API_BARBEARIA.DAL.DAO;
using API_BARBEARIA.DAL.Entities;
using API_BARBEARIA.Repository;
using API_BARBEARIA.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API_BARBEARIA.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthAttributes : ActionFilterAttribute
    {
        IUserRepository _userRepository;
        public AuthAttributes(bool saveUserId = false)
        {

            IDAO<User> _userDAO = new BaseDAO<User>();
            IDAO<Scheduling> _schedulingDAO = new BaseDAO<Scheduling>();
            IDAO<Barber> _barberDAO = new BaseDAO<Barber>();
            IDAO<Sessions> _sessionDAO = new BaseDAO<Sessions>();
            IDAO<Service> _ServiceDAO = new BaseDAO<Service>();
            IDAO<Horary> _horaryDAO = new BaseDAO<Horary>();
            IDAO<Shavy> _shavyDAO = new BaseDAO<Shavy>();
            IDAO<Routers> _Router = new BaseDAO<Routers>();
            IDAO<RouterUsers> _RouterUsersDAO = new BaseDAO<RouterUsers>();

            _userRepository = new UserRepository(_userDAO, _schedulingDAO, _barberDAO, _sessionDAO, _ServiceDAO, _shavyDAO, _horaryDAO, _Router, _RouterUsersDAO);

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var path = context.HttpContext.Request.Path;
            var token = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token) || token == null)
            {
                context.HttpContext.Response.StatusCode = 401;
                context.Result = new JsonResult("Sorry, you are not logged in. Log in and try again!");
                return;
            }
            var SeeTokenValid = _userRepository.SeeTokenValid(token);
            if (SeeTokenValid == false)
            {
                context.HttpContext.Response.StatusCode = 401;
                context.Result = new JsonResult("Sorry, you Session has expired. Log in and try again!");
                return;
            }

            var VerifyRouters = _userRepository.VerifyPermissionsRouter(token, path);
            if (VerifyRouters == false)
            {
                context.HttpContext.Response.StatusCode = 401;
                context.Result = new JsonResult("Sorry, You do not have access to this route. Log in and try again!");
                return;
            }
           
        }
    }
}
