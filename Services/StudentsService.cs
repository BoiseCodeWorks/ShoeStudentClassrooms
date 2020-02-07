using System;
using System.Collections.Generic;
using shoeshoe.Interfaces;
using shoeshoe.Models;
using shoeshoe.Repositories;

namespace shoeshoe.Services
{
    public class StudentsService : IService<Student>
    {
        private readonly StudentsRepository _repo;
        public StudentsService(StudentsRepository sr)
        {
            _repo = sr;
        }

        public IEnumerable<Student> Get()
        {
            return _repo.Get();
        }

        public Student GetById(int id)
        {
            var exists = _repo.GetById(id);
            if (exists == null) { throw new Exception("Invalid Id"); }
            return exists;
        }

        public Student Create(Student newData)
        {
            _repo.Create(newData);
            return newData;
        }

        public Student Edit(Student update)
        {
            var exists = _repo.GetById(update.Id);
            if (exists == null) { throw new Exception("Invalid Id"); }

            // update.AuthorId = exists.AuthorId

            _repo.Edit(update);
            return update;
        }

        public string Delete(int id)
        {
            var exists = _repo.GetById(id);
            if (exists == null) { throw new Exception("Invalid Id"); }
            _repo.Delete(id);
            return "Successfully Deleted";
        }

        public object GetByClassroomId(int id)
        {

            throw new NotImplementedException();
        }
    }
}
