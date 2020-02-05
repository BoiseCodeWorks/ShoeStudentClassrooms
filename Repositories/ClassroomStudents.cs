using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using shoeshoe.Models;

namespace shoeshoe.Repositories
{
    public class ClassroomsRepository
    {
        private readonly IDbConnection _db;
        public ClassroomsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Classroom> Get()
        {
            string sql = "SELECT * FROM classrooms";
            return _db.Query<Classroom>(sql);
        }

        internal Classroom GetById(int Id)
        {
            string sql = "SELECT * FROM classrooms WHERE id = @Id";
            return _db.QueryFirstOrDefault<Classroom>(sql, new { Id });
        }

        internal Classroom Create(Classroom newData)
        {
            string sql = @"
            INSERT INTO classrooms 
            (name) 
            VALUES 
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newData);
            newData.Id = id;
            return newData;
        }

        internal void Edit(Classroom update)
        {

            string sql = @"
            UPDATE classrooms
            SET 
            name = @Name,
            WHERE id = @Id; 
            ";
            _db.Execute(sql, update);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM classrooms WHERE id = @id";
            _db.Execute(sql, new { id });
        }

        internal IEnumerable<Classroom> GetClassroomsByStudentId(int studentId)
        {
            string sql = @"
            SELECT c.*
            FROM classroomstudents cs
            JOIN classrooms c ON c.id = cs.classroomId
            WHERE studentId = @studentId;";

            return _db.Query<Classroom>(sql, new { studentId });
        }
    }
}
