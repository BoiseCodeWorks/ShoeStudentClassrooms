using System.Collections.Generic;
using System.Data;
using Dapper;
using shoeshoe.Models;

namespace shoeshoe.Repositories
{
    public class ClassroomStudentsRepository
    {
        private readonly IDbConnection _db;
        public ClassroomStudentsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal ClassroomStudent Find(ClassroomStudent cs)
        {
            string sql = "SELECT * FROM classroomstudents WHERE (studentId = @StudentId AND classroomId = @ClassroomId)";
            return _db.QueryFirstOrDefault(sql, cs);
        }


        internal ClassroomStudent Create(ClassroomStudent newData)
        {
            string sql = @"
            INSERT INTO classroomstudents 
            (studentId, classroomId) 
            VALUES 
            (@StudentId, @ClassroomId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newData);
            newData.Id = id;
            return newData;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM classroomstudents WHERE id = @id";
            _db.Execute(sql, new { id });
        }
    }
}
