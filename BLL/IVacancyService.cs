using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IVacancyService
    {
        IEnumerable<Vacancy> GetAllVacancies();
        IEnumerable<Vacancy> GetAllVacancies(string vacancyName, int minSalary, int maxSalar);
        void AddNewVacancy(Vacancy model);
        void UpdateVacancy(Vacancy model);
        Vacancy GetById(int id);
        void DeleteVacancy(Vacancy vacancy);
    }
}
