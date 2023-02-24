using System.Data;
using System.Linq.Expressions;
using ServiceStack.OrmLite;

namespace WHA.Repository;

public class BaseRepository<T> : IBaseRepository<T>
    where T : class
{
    public BaseRepository(IDbConnection dbConnection)
    {
        this.DbConnection = dbConnection;
    }
    
    public IDbConnection DbConnection { get; }
    
    public List<dynamic> GetDynamic(string sqlStatement) => this.DbConnection.Select<dynamic>(sqlStatement);

    public List<dynamic> GetDynamic(SqlExpression<dynamic> sqlStatement) => this.DbConnection.Select(sqlStatement);

    public int Insert(T list) => (int) this.DbConnection.Insert(list, true);

    public void InsertAll(List<T> list) => this.DbConnection.InsertAll(list);

    public int Execute(string sqlStatement) => this.DbConnection.ExecuteSql(sqlStatement);

    public int UpdateAll(List<T> list) => this.DbConnection.UpdateAll(list);

    public int Update(T entity, Expression<Func<T, bool>> expression) => this.DbConnection.Update(entity, expression);

    public int Update(object entity, Expression<Func<T, bool>> expression) => this.DbConnection.Update(entity, expression);

    public int Update(T item) => this.DbConnection.Update(item);

    public void Delete(Expression<Func<T, bool>> predicate) => this.DbConnection.Delete(predicate);

    public void Delete(T element) => this.DbConnection.Delete(element);

    public void DeleteAll(List<T> list) => this.DbConnection.DeleteAll(list);

    public T GetFirstOrDefault(Expression<Func<T, bool>> predicate) => this.DbConnection.Single(predicate);

    public T GetFirstOrDefault(SqlExpression<T> query) => this.DbConnection.Single(query);

    public T GetFirstOrDefault(string sqlStatement) => this.DbConnection.Single<T>(sqlStatement);

    public T GetById(int id) => this.DbConnection.Single<T>(id);

    public List<T> Get(SqlExpression<T> query) => this.DbConnection.LoadSelect(query);

    public List<T> Get(string sqlStatement) => this.DbConnection.Select<T>(sqlStatement);

    public List<T> Get(string sqlStatement, Dictionary<string, object> values) => this.DbConnection.Select<T>(sqlStatement, values);

    public List<T> Get(SqlExpression<T> expression, Expression<Func<T, object>> include) =>
        this.DbConnection.LoadSelect<T>(expression, include);

    public List<T> GetByWithReferences(Expression<Func<T, bool>> expression) => this.DbConnection.LoadSelect(expression);

    public List<T> GetByWithoutReferences(Expression<Func<T, bool>> expression) => this.DbConnection.Select(expression);

    public List<T> GetWithoutReferences(SqlExpression<T> query) => this.DbConnection.Select(query);

    public List<T> LoadSelect(Expression<Func<T, bool>> predicate) => this.DbConnection.LoadSelect(predicate);

    public List<T> LoadSelect() => this.DbConnection.LoadSelect<T>();

    public SqlExpression<T> CreateQueryBuilder() => this.DbConnection.From<T>();

    public SqlExpression<T> CreateQueryBuilder(TableOptions tableOptions) => this.DbConnection.From<T>(tableOptions);

    public bool Exists(Expression<Func<T, bool>> expression) => this.DbConnection.Exists(expression);

    public long Count() => this.DbConnection.Count<T>();

    public long CountBy(Expression<Func<T, bool>> expression) => this.DbConnection.Count(expression);
    
}