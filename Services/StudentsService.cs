using System;
using System.Collections.Generic;
using shoeshoe.Models;
using shoeshoe.Repositories;

namespace shoeshoe.Services
{
    public class StudentsService
    {
        private readonly StudentsRepository _repo;
        public StudentsService(StudentsRepository sr)
        {
            _repo = sr;
        }

        internal IEnumerable<Student> Get()
        {
            return _repo.Get();
        }

        internal Student GetById(int id)
        {
            var exists = _repo.GetById(id);
            if (exists == null) { throw new Exception("Invalid Id"); }
            return exists;
        }

        internal Student Create(Student newData)
        {
            _repo.Create(newData);
            return newData;
        }

        internal Student Edit(Student update)
        {
            var exists = _repo.GetById(update.Id);
            if (exists == null) { throw new Exception("Invalid Id"); }

            // update.AuthorId = exists.AuthorId

            _repo.Edit(update);
            return update;
        }

        internal string Delete(int id)
        {
            var exists = _repo.GetById(id);
            if (exists == null) { throw new Exception("Invalid Id"); }
            _repo.Delete(id);
            return "Successfully Deleted";
        }

        internal object GetByClassroomId(int id)
        {

            throw new NotImplementedException();
        }
    }
}
