using System.Data;
using System.Linq.Expressions;
using ServiceStack.OrmLite;

namespace WebanwendungHelferleinAufgabe.Repository;

public interface IBaseRepository<T>
    where T : class
{
    IDbConnection DbConnection { get; }

    List<object> GetDynamic(string sqlStatement);

    List<object> GetDynamic(SqlExpression<object> sqlStatement);

    int Insert(T list);

    void InsertAll(List<T> list);

    int Execute(string sqlStatement);

    int UpdateAll(List<T> list);

    int Update(T entity, Expression<Func<T, bool>> expression);

    int Update(object entity, Expression<Func<T, bool>> expression);

    int Update(T item);

    void Delete(Expression<Func<T, bool>> predicate);

    void Delete(T element);

    void DeleteAll(List<T> list);

    T GetFirstOrDefault(Expression<Func<T, bool>> predicate);

    T GetFirstOrDefault(SqlExpression<T> query);

    T GetFirstOrDefault(string sqlStatement);

    T GetById(int id);

    List<T> Get(SqlExpression<T> query);

    List<T> Get(string sqlStatement);

    List<T> Get(string sqlStatement, Dictionary<string, object> values);

    List<T> Get(SqlExpression<T> expression, Expression<Func<T, object>> include);

    List<T> GetWithoutReferences(SqlExpression<T> query);

    List<T> GetByWithReferences(Expression<Func<T, bool>> expression);

    List<T> GetByWithoutReferences(Expression<Func<T, bool>> expression);

    SqlExpression<T> CreateQueryBuilder();

    SqlExpression<T> CreateQueryBuilder(TableOptions tableOptions);

    List<T> LoadSelect();

    List<T> LoadSelect(Expression<Func<T, bool>> predicate);

    bool Exists(Expression<Func<T, bool>> expression);

    long Count();

    long CountBy(Expression<Func<T, bool>> expression);
}