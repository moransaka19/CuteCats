using DAL.Interfaces;
using DAL.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class VacancyService : IVacancyService
    {
        private IVacancyRepository _vacancyRepository;

        public VacancyService(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        public IEnumerable<Vacancy> GetAllVacancies()
        {
            return _vacancyRepository.GetAll();
        }

        public IEnumerable<Vacancy> GetAllVacancies(string vacancyName, int minSalary, int maxSalary)
        {
            var vacancies = _vacancyRepository.GetAll();
            if (vacancyName != null)
            {
               vacancies = vacancies.Where(x => x.Name.Contains(vacancyName));
            }

            if (minSalary != 0)
            {
               vacancies = vacancies.Where(x => x.Price >= minSalary);
            }

            if (maxSalary != 0)
            {
                vacancies = vacancies.Where(x => x.Price <= maxSalary);
            }

            if (vacancies == null)
            {
                throw new NullReferenceException();
            }

            return vacancies;
        }

        public void AddNewVacancy(Vacancy model)
        {
            _vacancyRepository.Add(model);
        }

        public void UpdateVacancy(Vacancy model)
        {
            _vacancyRepository.Update(model);
        }

        public Vacancy GetById(int id)
        {
            var vacancy = _vacancyRepository.GetById(id);

            if (vacancy == null)
            {
                throw new NullReferenceException();
            }

            return vacancy;
        }

        public void DeleteVacancy(Vacancy vacancy)
        {
            _vacancyRepository.Delete(vacancy);
        }
    }
}
