using System;
using System.Collections.Generic;
using shoeshoe.Models;
using shoeshoe.Repositories;

namespace shoeshoe.Services
{
    public class ClassroomsService
    {
        private readonly ClassroomsRepository _repo;
        public ClassroomsService(ClassroomsRepository sr)
        {
            _repo = sr;
        }

        internal IEnumerable<Classroom> Get()
        {
            return _repo.Get();
        }

        internal Classroom GetById(int id)
        {
            var exists = _repo.GetById(id);
            if (exists == null) { throw new Exception("Invalid Id"); }
            return exists;
        }

        internal Classroom Create(Classroom newData)
        {
            _repo.Create(newData);
            return newData;
        }

        internal Classroom Edit(Classroom update)
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

        internal IEnumerable<Classroom> GetByStudentId(int studentId)
        {
            return _repo.GetClassroomsByStudentId(studentId);
        }
    }
}
