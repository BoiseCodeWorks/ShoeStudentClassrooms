using System.Collections.Generic;
using System.Data;
using Dapper;
using shoeshoe.Models;

namespace shoeshoe.Repositories
{
    public class StudentsRepository
    {
        private readonly IDbConnection _db;
        public StudentsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Student> Get()
        {
            string sql = "SELECT * FROM students";
            return _db.Query<Student>(sql);
        }

        internal Student GetById(int Id)
        {
            string sql = "SELECT * FROM students WHERE id = @Id";
            return _db.QueryFirstOrDefault<Student>(sql, new { Id });
        }

        internal Student Create(Student newData)
        {
            string sql = @"
            INSERT INTO students 
            (name) 
            VALUES 
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newData);
            newData.Id = id;
            return newData;
        }

        internal void Edit(Student update)
        {

            string sql = @"
            UPDATE students
            SET 
            name = @Name,
            WHERE id = @Id; 
            ";
            _db.Execute(sql, update);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM students WHERE id = @id";
            _db.Execute(sql, new { id });
        }
    }
}
