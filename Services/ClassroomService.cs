using System;
using System.Collections.Generic;
using shoeshoe.Interfaces;
using shoeshoe.Models;
using shoeshoe.Repositories;

namespace shoeshoe.Services
{
    public class ClassroomsService : IService<Classroom>
    {
        private readonly ClassroomsRepository _repo;
        public ClassroomsService(ClassroomsRepository sr)
        {
            _repo = sr;
        }

        public IEnumerable<Classroom> Get()
        {
            return _repo.Get();
        }

        public Classroom GetById(int id)
        {
            var exists = _repo.GetById(id);
            if (exists == null) { throw new Exception("Invalid Id"); }
            return exists;
        }

        public Classroom Create(Classroom newData)
        {
            _repo.Create(newData);
            return newData;
        }

        public Classroom Edit(Classroom update, int id)
        {
            update.Id = id;
            var exists = _repo.GetById(id);
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

        public IEnumerable<Classroom> GetByStudentId(int studentId)
        {
            return _repo.GetClassroomsByStudentId(studentId);
        }
    }
}
