using System;
using System.Collections.Generic;
using shoeshoe.Models;
using shoeshoe.Repositories;

namespace shoeshoe.Services
{
    public class ClassroomStudentsService
    {
        private readonly ClassroomStudentsRepository _repo;
        public ClassroomStudentsService(ClassroomStudentsRepository sr)
        {
            _repo = sr;
        }

        internal void Create(ClassroomStudent newData)
        {
            ClassroomStudent exists = _repo.Find(newData);
            if (exists != null) { throw new Exception("Student already enrolled"); }
            _repo.Create(newData);
        }

        internal string Delete(ClassroomStudent cs)
        {
            ClassroomStudent exists = _repo.Find(cs);
            if (exists == null) { throw new Exception("Invalid Id Combination"); }
            _repo.Delete(exists.Id);
            return "Successfully Deleted";
        }
    }
}
