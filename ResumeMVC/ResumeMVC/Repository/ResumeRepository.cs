using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResumeMVC.EDMXModel;
using System.IO;
using System.Data.Entity.Validation;
using System.Data.Entity;
using AutoMapper.QueryableExtensions;
using ResumeMVC.ViewModels;

namespace ResumeMVC.Repository
{
    public class ResumeRepository : IResumeRepository
    {
        //Db Context
        private readonly DBCVEntities _dbContext = new DBCVEntities();

        public bool AddCertification(Certification certification, int idPer)
        {
            try
            {
                int countRecords = 0;
                Person personEntity = _dbContext.People.Find(idPer);

                if (personEntity != null && certification != null)
                {
                    personEntity.Certifications.Add(certification);
                    countRecords = _dbContext.SaveChanges();
                }

                return countRecords > 0 ? true : false;
            }
            catch (DbEntityValidationException dbEx)
            {

                throw;
            }
           
        }

        public bool AddLanguage(Language language, int idPer)
        {
                int countRecords = 0;
                Person personEntity = _dbContext.People.Find(idPer);

                if (personEntity != null && language != null)
                {
                    personEntity.Languages.Add(language);
                    countRecords = _dbContext.SaveChanges();
                }

                return countRecords > 0 ? true : false;
        }

        public string AddOrUpdateEducation(Education education, int idPer)
        {
            string msg = string.Empty;

            Person personEntity = _dbContext.People.Find(idPer);

            if(personEntity != null)
            {
                if (education.IDEdu > 0)
                {
                    //we will update education entity
                    _dbContext.Entry(education).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    msg = "Education entity has been updated successfully";
                }
                else
                {
                    // we will add new education entity
                    personEntity.Educations.Add(education);
                    _dbContext.SaveChanges();

                    msg = "Education entity has been Added successfully";
                }
            }

            return msg;
        }

        public string AddOrUpdateExperience(WorkExperience workExperience, int idPer)
        {
            string msg = string.Empty;

            Person personEntity = _dbContext.People.Find(idPer);

            if (personEntity != null)
            {
                if (workExperience.IDExp > 0)
                {
                    //we will update work experience entity
                    _dbContext.Entry(workExperience).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    msg = "Work Experience entity has been updated successfully";
                }
                else
                {
                    // we will add new work experience entity
                    personEntity.WorkExperiences.Add(workExperience);
                    _dbContext.SaveChanges();

                    msg = "Work Experience entity has been Added successfully";
                }
            }

            return msg;
        }

        public bool AddPersonnalInformation(Person person, HttpPostedFileBase file)
        {
            try
            {
                int nbRecords = 0;

                if (person != null)
                {
                    if (file != null)
                    {
                        person.Profil = ConvertToBytes(file);
                    }

                    _dbContext.People.Add(person);
                    nbRecords = _dbContext.SaveChanges();
                }

                return nbRecords > 0 ? true : false;
            }
            catch (DbEntityValidationException dbEx)
            {

                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            
        }

        public bool AddSkill(Skill skill, int idPer)
        {
            int countRecords = 0;
            Person personEntity = _dbContext.People.Find(idPer);

            if(personEntity != null && skill != null)
            {
                personEntity.Skills.Add(skill);
                countRecords = _dbContext.SaveChanges();
            }

            return countRecords > 0 ? true : false;

        }

        public IQueryable<Certification> GetCertificationsById(int idPer)
        {
            var certificationList = _dbContext.Certifications.Where(w => w.IdPers == idPer);
            return certificationList;
        }

        public IQueryable<Education> GetEducationById(int idPer)
        {
            var educationList = _dbContext.Educations.Where(e => e.IdPers == idPer);
            return educationList;
        }

        public int GetIdPerson(string firstName, string lastName)
        {
            int idSelected = _dbContext.People.Where(p => p.FirstName.ToLower().Equals(firstName.ToLower()))
                                              .Where(p => p.LastName.ToLower().Equals(lastName.ToLower()))
                                              .Select(p => p.IDPers).FirstOrDefault();

            return idSelected;
        }

        public IQueryable<Language> GetLanguageById(int idPer)
        {
            var languageList = _dbContext.Languages.Where(w => w.IdPers == idPer);
            return languageList;
        }

        public Person GetPersonnalInfo(int idPer)
        {
            return _dbContext.People.Find(idPer);
        }

        public IQueryable<Skill> GetSkillsById(int idPer)
        {
            var skillsList = _dbContext.Skills.Where(w => w.IdPers == idPer);
            return skillsList;
        }

        public IQueryable<WorkExperience> GetWorkExperienceById(int idPer)
        {
            var workExperienceList = _dbContext.WorkExperiences.Where(w => w.IDPers == idPer);
            return workExperienceList;
        }

        private byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

    }
}