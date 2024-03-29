﻿using API_BARBEARIA.DAL.Entities;
using API_BARBEARIA.DAL.Enums;
using API_BARBEARIA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.Repository.Interfaces
{
    public interface IUserRepository
    {
        User RegisterUser(string Name, string Email, string CPF, string Password, string Phone, bool IsAdminBarber);

        User UserIsValid(string Email, string Password);
        Scheduling scheduling(long IdUser, DateTime HairCurtDate, string DesiredService, string Time, BarberEnum barberEnum);
        User GetEmail(long IdUser);
        Scheduling GetScheduling(long IdUser);
        User UpdateUser(long IdUser,string Name, string Email, string CPF, string Password, string Phone, bool IsAdminBarber);
        string DeleteUser(long IdUser);
        Scheduling UpdateScheduling(long IdScheduling, long IdUser, DateTime HairCurtDate, string DesiredService, string Time, BarberEnum barberEnum);
        string DeleteScheduling(long IdScheduling);
        string SchedulingCompleted (long IdScheduling, bool SchedulingCompleted);
        ListResultAllSchedulingDTO GetAllScheduling();
        List<User> GetallUsers();
        ListResultSchedulingDTO GetSchedulingPerId(long IdUser);
        string WarnigsRoutine();
        Sessions CreateSession(long IdUser, string Token);
        Sessions SeeTokenValid(string Token);
        string Logout(long IdUser, string token);
        ListResultAllSchedulingDTO GetSchedulingsBarbers(string NameBarber);
        User GetUserId(long IdUser);
        List<Shavy> GetAllShavies();
        List<Horary> GetAllHoraries();
        List<Service> GetAllService();

    }
}
